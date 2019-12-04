using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Payslip_End.Constants;
using Payslip_End.DataStores;

namespace Payslip_End {
    internal static class Program {
        public static void Main(string[] args) {
            var consoleInterface = new ConsoleInterface();

            Console.Out.WriteLine(HumanText.Welcome);

            var personWriter = new PersonWriter(consoleInterface);
            var payslipWriter = new PayslipWriter();
            var csvHandler = new CSVHandler();
            
            var inputType = consoleInterface.ListDecisionGetter(new List<string> {"manual", "csv"},
                "Do you want to input payroll information through 'csv' import or 'manual' entry?");
            List<Payslip> payslips;
            switch (inputType) {
                case "manual":
                    payslips = new List<Payslip>();
                    var person = personWriter.CreatePersonManually();
                    payslips.Add(payslipWriter.CreatePayslipForPerson(person));
                    break;
                case "csv":
                    var path = consoleInterface.RegexDecisionGetter(
                        new Regex(@"^\/$|(^(?=\/)|^\.|^\.\.)(\/(?=[^/\0])[^/\0]+)*\/?$"),
                        "Please enter the path to your CSV file: ");
                    var people = personWriter.ReadInEnumerablePeopleFromCsv(path);
                    payslips = payslipWriter.CreatePayslipsForGroupOfPeople(people);
                    break;
                default:
                    payslips = new List<Payslip>();
                    break;
            }

            var outputType = consoleInterface.ListDecisionGetter(new List<string> {"terminal", "csv"},
                "Do you want to display your payslip data on the 'terminal' or output to a 'csv' file?");
            switch (outputType) {
                case "terminal": {
                    foreach (var p in payslips) Console.Out.WriteLine(p.ToString());
                    break;
                }
                case "csv": {
                    var outputPath = consoleInterface.RegexDecisionGetter(
                        new Regex(@"^\/$|(^(?=\/)|^\.|^\.\.)(\/(?=[^/\0])[^/\0]+)*\/?$"),
                        "Please enter the path to your CSV file: ");
                    csvHandler.WriteToFile(outputPath, payslips);
                    break;
                }
            }

            Console.Out.WriteLine("\nThank you for using MYOB!\n");
        }
    }
}