using Contracts.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Contracts.Utils
{

    public enum EmpType
    {
        Id,
        Name,
        Node,
        Other
    }


    public static class Utils
    {
        public static string GetEmployeeLastName(string fullName)
        {
            return fullName.Split(' ')[0];
        }
        public static string GetEmployeeLastNameUpper(string fullName)
        {
            return fullName.Split(' ')[0].ToUpper();
        }
        public static string[] GetEmployeeNames(string fullName)
        {
            var names = fullName.Split(' ');
            //if (names.Length == 1)
            //{
            //    node!.LastName = names[0];
            //} else if (names.Length == 2)
            //{
            //    node!.LastName = names[0];
            //    node.FirstName = names[1];
            //} else if (names.Length == 3)
            //{
            //    node!.LastName = names[0];
            //    node.MiddleName = names[1];
            //    node.FirstName = names[2];
            //}
            return names;
        }

        public static EmpType GetEmployeeType(string emp)
        {
            if (emp.All(char.IsLetter))
                return EmpType.Name;
            else if (emp.All(char.IsDigit))
                return EmpType.Id;
            else
            {
                var pattern = @"/\d+";
                bool slashDigits = Regex.IsMatch(emp, pattern);
                return slashDigits ? EmpType.Node : EmpType.Other;
            }
        }
    }
}
