using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Utils;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

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

    //this is advance
      public async Task<decimal?> UpdateClocking1Async(string employee)
        {
            var p = await paramSvc.GetAllAsync();//the one and only updated record in this table
            var param = Enumerable.FirstOrDefault(p);
            new ParamValidator().ValidateAndThrow(param);
            //find out if an employee is an Id=numer, or a Name(only letters, no numbers), or a node (/s and numbers)
            var typ = Utils.GetEmployeeType(employee);
            EmpDTO? emp = null;
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
            /* if (param.FiscalCode == "12345") //daca angajatorul vrea o formulta difereita se face pe cod fiscal pt alta firma
            {
                //regim normat la 8 ore  = nr de zile din luna => pt aprilie este 20 zile
                //var nrm = 20;

                //emp.MoneyAdvance = ((decimal)(emp.MainSalary / param.NormatedRegime * param.NoDaysForWhichAdvanceisPaid) / 10) * 10; //avans pt oamenii normali dar sunt si exceptii
                //emp.MoneyAdvance = ((decimal)(emp.MainSalary * (param.AdvancePercentRate/100)/ nrm * param.NoDaysForWhichAdvanceisPaid) / 10) * 10; 
                            }  */
            if (emp.ExceptedRetributionDays == null || emp.ExceptedRetributionDays == 0)
            {
                emp.MoneyAdvance = emp.MainSalary * (decimal)0.5 * param.AdvancePercentRate/100;
            }  
            else
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
            //sample c1
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




        //this is the liquidation

        /*
        Lichidare inseamna:

1.        sa updatez in system cate ore a lucrat fiecare OM (in firmele de constr asta vine o foaie de la un sef de ssectie) in IT, se face direct prin updaterea unor campuri din Employee (ca la mne sunt comasate)

            HOURsToWork

            OLA = HoursToWork (ore lucrate pe luna) pontajul vine pe zile dupa care secalculeza OLA si OLR in func de cat s-a lucrat.

            OLR = HoursRegie,                        …. Do not use pt ca in vechiul prg OREL= ? ?? FLRC, wedont use FLRC

            Adaug in tabela employee: RegimTarifarOrar = MainSalary/ param.NormalWorkHoursSchedule * 8

            NormalWorkHoursSchedule este: bazat pe nr de zile lucratorare din luna: deci: RN8, Pt aprilie = 20 de zile, pt febr = 18, pt martie = 21 samd

            Noua coloana in employee old RTATR = new LichidareaPartiala= (OLA sau OLR ) * RegimTarifarOrar

            Se face calcul estimativ la datorii: sanatatea, pensia, impozitul

4.       Ca sa updatez trebuie sa verific daca omul lucreaz in accord(3 cazuri: TL, indiv?, AI) sau in regie(1caz) ? Care sunt campurile pt accord si pt regie(sau campul)?
In vechiul program s-a mers pe AI sau regie nu pe altele

5.       Ca si user trebe sa updatez campurile:
            a. HoursRegie pt Regie
            b.OLAIND pt Acord Invidiual care coloana este: HoursIndivAccord
            c. OLA pt Indiv: HoursToWork

6.       Calcule partiale: care e formula? Vezi RTATR

7.       Do not use: ---------Acord global car de regula se da 100% dar daca sunt problem se da mai do DO not use: putin…caz particular:RTATR*Percentge

8.       Calcule finale:

9.       RTATR+Concedii+sporruri+oreIntreruper+premii-minusDdiminuari,cantitative, procentuale,conc far paltasamd = BR, BR+BCAS = BT…

                BCAS e pt boli…

                RPR = BR-Avans (eventual4 retineri, eventual minus premii)

                RPCAS = BCAS- Ajutoarele material dela Boli? De la stat

                Se calc: PreFinal = (BT-tickete masa)-BT25%CAS(pensia) -BT*1%Somaj- BT* 10%CASS(sanatate)

                Impozit = = (BT – Prefinal)*10%

                Final = BT-prefinal –impozit

                FinalTotal = Final – (Eventual Rate – sindicat – CAR…)*/
        public async Task<decimal?> UpdateClocking2Async(string employee)
        {
            var p = await paramSvc.GetAllAsync();//the one and only updated record in this table
            var param = Enumerable.FirstOrDefault(p);
            new ParamValidator().ValidateAndThrow(param);
            //find out if an employee is an Id=numer, or a Name(only letters, no numbers), or a node (/s and numbers)
            var typ = Utils.GetEmployeeType(employee);
            EmpDTO? emp = null;
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

            if(emp.IndivAcord!=0)
            {
                //RTATR
                    var RegimTarifarOrar = emp.MainSalary/param.NormalWorkHoursSchedule*8;
                    //OLAIND este pt acord individual, tre sa fie updatat inainte de calculare lichidare
                    //OLAIND = HoursIndivAcord
                    var LichidarePartiala = emp.HoursIndivAcord * RegimTarifarOrar;

                    var BR = RegimTarifarOrar; //RTATR+Concedii+sporruri+oreIntreruper+premii-minusDdiminuari,cantitative, procentuale,conc;
                    var BCAS = 0; //for now;
                    var BT = BR + BCAS; 
                    var RPR = BR-emp.MoneyAdvance; //Avans -(eventual4 retineri, eventual minus premii)
                    var RPCAS = BCAS;//- Ajutoarele material dela Boli? De la stat
                    var TicketeMasa = 0;
                    var PreFinal = BT - TicketeMasa - BT*25/100 - BT*1/100- BT*10/100;
                    var Impozit = (BT - PreFinal)*10/100;
                    var Final = BT - PreFinal - Impozit;
                    var FinalTotal = Final;// – (Eventual Rate – sindicat – CAR…)
                    emp.MoneyLeaveLiquidation = FinalTotal;
            }
            else{

            }
            await empSvc.UpdateEmployee(emp);


            return emp.MoneyLeaveLiquidation;
        }
    }
}
