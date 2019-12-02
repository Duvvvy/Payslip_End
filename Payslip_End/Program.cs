using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Payslip_End {
    internal static class Program {
        public static void Main(string[] args) {
            ConsoleInterface consoleInterface = new ConsoleInterface();

            
            Console.Out.WriteLine("Welcome to the payslip generator!");
            Console.Out.WriteLine("\n");

            var firstName = consoleInterface.RegexDecisionGetter(new Regex(""), "Please input your name: ");//TODO find regex for names
            var lastName = consoleInterface.RegexDecisionGetter(new Regex(""), "Please input your surname: ");
            var annualSalary = Convert.ToDecimal(consoleInterface.RegexDecisionGetter(new Regex(@"\d"), "Please enter your annual salary: "));
            var superOrKiwisaverRate = Convert.ToDecimal(consoleInterface.RegexDecisionGetter(new Regex(@"\d"), "Please enter your super or kiwisaver rate: "));
            var paymentStartDate = consoleInterface.DateTimeDecisionGetter("dd/mm/yyyy","Please enter your payment start date: dd/mm/yyyy");
            var paymentEndDate = consoleInterface.DateTimeDecisionGetter("dd/mm/yyyy","Please enter your payment end date: dd/mm/yyyy");
            
            
            var person = new Person(firstName,lastName,annualSalary,superOrKiwisaverRate,paymentStartDate,paymentEndDate);

            PayslipWriter payslipWriter = new PayslipWriter();
            Payslip payslip = payslipWriter.CreatePayslipForPerson(person);
            Console.Out.WriteLine("Your payslip has been generated:");
            Console.Out.WriteLine(payslip.ToString());
            Console.Out.WriteLine("\nThank you for using MYOB!\n");

        }
    }
}