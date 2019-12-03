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
            Console.Out.WriteLine("\n");
            
            var personWriter = new PersonWriter(consoleInterface);
            var payslipWriter = new PayslipWriter();


            var inputType = consoleInterface.ListDecisionGetter(new List<string>() {"manual", "csv"},
                "Do you want to input payroll information through 'csv' import or 'manual' entry?");


            switch (inputType) {
                case "manual":
                    var person = personWriter.CreatePersonManually();
                    var payslip = payslipWriter.CreatePayslipForPerson(person);
                    Console.Out.WriteLine(payslip.ToString());
                    break;
                case "csv":
                    // /Users/ryan.bircham/Downloads/kata-payslip/sample_input.csv  
                    string path = consoleInterface.RegexDecisionGetter(
                        new Regex(@"^\/$|(^(?=\/)|^\.|^\.\.)(\/(?=[^/\0])[^/\0]+)*\/?$"),
                        "Please enter the path to your CSV file: ");
                    var people = personWriter.ReadInEnumerablePeopleFromCsv(path);
                    List<Payslip> payslips = payslipWriter.CreatePayslipsForGroupOfPeople(people);
                    var outputType = consoleInterface.ListDecisionGetter(
                        new List<string>() {"terminal", "csv"},
                        "Do you want to display your payslips on the 'terminal' or output to a 'csv' file?");

                    switch (outputType) {
                        case "terminal": {
                            foreach (var p in people) {
                                Console.Out.WriteLine(p.ToString());  
                            }
                            break;
                        }
                        case "csv": {
                            var csvHandler = new CSVHandler();
                        
                            var outputPath = consoleInterface.RegexDecisionGetter(
                                new Regex(@"^\/$|(^(?=\/)|^\.|^\.\.)(\/(?=[^/\0])[^/\0]+)*\/?$"),
                                "Please enter the path to your CSV file: ");
                        
                            csvHandler.WriteToFile(outputPath, payslips);
                            break;
                        }
                    }

                    break;
                
                default:
                    Console.Out.WriteLine("ya yeet, the program has been beat");
                    break;
            }
            
            Console.Out.WriteLine("\nThank you for using MYOB!\n");

        }
    }
}