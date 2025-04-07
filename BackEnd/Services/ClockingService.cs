using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Utils;
using Contracts.Validation;
using FluentValidation;

namespace Services
{
    public class ClockingService : IClockingService
    {

        IParamService paramSvc;
        IEmpService empSvc;

        ContabContext DBContext { get; set; }
        private readonly IMapper Mapper;

        public ClockingService(ContabContext ctx, IMapper map, IParamService psvc, IEmpService esvc)
        {
            DBContext = ctx;
            Mapper = map;
            paramSvc = psvc;
            empSvc = esvc;
        }


        public async Task<decimal?> UpdateClocking1Async(string employee)
        {
            var param = await paramSvc.GetByIdAsync(1);//the one and only updated record in this table
            //find out if an employee is an Id=numer, or a Name(only letters, no numbers), or a node (/s and numbers)
            var typ = Utils.GetEmployeeType(employee);
            EmpDTO emp = null;
            switch (typ)
            {
                case EmpType.Id:
                    emp = await empSvc.GetEmployeeById(employee);
                    break;
                case EmpType.Name:
                    emp = await empSvc.GetEmployeeByLastName(employee);
                    break;
                case EmpType.Node:
                    emp = await empSvc.GetEmployeeByNode(employee);
                    break;
                case EmpType.Other:
                    throw new Exception("Not a valid employeeid,name or node");
            }

            new EmpDTOValidator().ValidateAndThrow(emp);
            if (param.FiscalCode == "12345")
            {
                emp.MoneyAdvance = ((decimal)(emp.MainSalary / param.NormatedRegime * param.NoDaysForWhichAdvanceisPaid) / 10) * 10; //avans pt oamenii normali dar sunt si exceptii
            } else if (emp.ExceptedRetributionDays == 0)
            {
                emp.MoneyAdvance = emp.MainSalary * (decimal)0.5 * param.AdvancePercentRate;
            } else
            {
                emp.MoneyAdvance = emp.MainSalary * (decimal)0.5 * emp.ExceptedRetributionDays * param.AdvancePercentRate /
                    (100 * param.NoDaysForWhichAdvanceisPaid);
                //nu tre sa fie 8 , tre sa fie //cate ore pe zi munceste omul , de exemplu poa sa fie 4
            }
            //todo: validate
            await empSvc.UpdateEmployee(emp);
            return emp.MoneyAdvance;

            //calculare MoneyAdvance = AVC pt toti angajatii

            //validate
            //tre sa iau zire, CAV sau RN8,ZAP8 din Params si il folosesc la algoritmul pt calculare AVG-ului
            //AdvancePercentate=CAV
            //NormatedRegime = RN8
            //NoOfDaysForWhichAdvanceisPaid = ZAP8
            //pt constructii unu dna cociorva a decis asta
            //----------------------------------------
            //if (zire == 0)
            //    var avc = (retrib * 0.5 * CAV) / 100;
            //else
            //{
            //    //var avc = int(int(retrib / rn8 * zire) / 10) * 10;
            //    var avc = retrib * 0.5 * zire*cav/(100*8);//nu tre sa fie 8 , tre sa fie 
            //                                            //cate ore pe zi munceste omul , de exemplu
            //                                            //poa sa fie 4
            //}
            //--------------------------------------------

        }

        public async Task<decimal?> UpdateClocking2Async(string empId)
        {
            return 0;
        }
    }
}
