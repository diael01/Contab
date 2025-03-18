using Contracts.Models;
using static CommonTestHelper.CommonHelper;

namespace CommonTestHelper
{
    public static class TestData
    {
        public static OrgDTO GetOrgDTO(int level, string? parent = null)
        {
            OrgDTO org = new OrgDTO();
            switch (level)
            {
                case 0:
                    org.NodeName = "Company";
                    break;
                case 1:
                    org.NodeName = "Department";
                    break;
                case 2:
                    org.NodeName = "Activity";
                    break;
                case 3:
                    org.NodeName = "Function";
                    break;
            }
            org.ParentNodeText = parent;
            org.Location = "Location";
            return org;
        }

        public static EmpDTO GetEmpDTO(EmpData d, short? level, string name,
                                                        string managerAsText = null)
        {
            EmpDTO emp = new EmpDTO();
            emp.LastName = name ?? "Eu";
            emp.FirstName = name+"Fst" ?? "EuFst";
            emp.EmpLevel = level ?? 0;
            emp.Location = "Location_" + name;
            emp.IdCardSerieNo = "RX12345";
            emp.IdCardCnp = "123456123456";
            emp.MainSalary = new decimal(100.5);
            emp.LastIdCardCreationDate = DateTime.Now; //just bogus data
            emp.LastIdCardCreatedBy = "spcp";
            emp.CountyCode = "NY";//judetul
            emp.PersonalEmail = "contab@gmail.com";
            emp.Birthday = DateTime.Now; //just bogus data
            emp.Gender = "F";
            emp.EmpShift = "Z";
            emp.HiringDate = DateTime.Now;
            emp.Studies = "University";

            //emp.ManagerNodeAsName = manager ?? "Eu";
            emp.ManagerNodeText = managerAsText;
            //emp.EmpDeptNodeAsName = dept ?? "IT";
            emp.EmpDeptNodeText = d.deptId;
            //emp.EmpActivityNodeAsName = act ?? "Research";
            emp.EmpActivityNodeText = d.actId;
            //emp.EmpWorkTypeNodeAsName = wtyp ?? "Paza";
            emp.EmpWorkTypeNodeText = d.workTypeId;
            //emp.EmpFunctionNodeAsName = func ?? "SDev";
            emp.EmpFunctionNodeText = d.funcId1;

            return emp;
        }
    }
}
