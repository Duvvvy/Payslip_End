using System;
using System.Collections.Generic;
using System.Linq;
using Payslip_End.Constants;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class PayslipWriter {
        /*
         * The purpose of this class is to create payslip objects
         */
        public PayslipWriter() {
            Calculator = new Calculator();
            AuTaxBands = new AuTaxBands();
        }

        public Calculator Calculator { get; set; }
        public AuTaxBands AuTaxBands { get; set; }

        public Payslip CreatePayslipForPerson(Person person) {
            var name = person.FirstName + " " + person.LastName;

            var payPeriod = "";
            payPeriod = person.PayPeriod ?? Calculator.PayPeriod(person.PaymentStartDate, person.PaymentEndDate);
            //The client has insisted that even though the wrong header is used, the import header "payment start date" is actually pay period.
            //If pay period is null, this means that we should display the pay period from the payment start date until the payment end date.
            
            var grossIncomePerMonth = Calculator.MonthlyGrossIncomeFromAnnualGross(person.AnnualSalary);
            var incomeTax = Calculator.MonthlyIncomeTaxFromAnnualGross(AuTaxBands, person.AnnualSalary);
            var netIncome = Calculator.MonthlyNetIncome(grossIncomePerMonth, incomeTax);
            
            //As the CSV reader cannot handle the formatting of the data, we handle it in the payslip writer.
            var superKiwiRateNumbersOnly = GetNumbers(person.SuperKiwiRate);
            var superOrKiwiContribution = Calculator.SuperKiwiSaverContribution(grossIncomePerMonth, Convert.ToDecimal(superKiwiRateNumbersOnly));
            var payslip = new Payslip(name, payPeriod, grossIncomePerMonth, incomeTax, netIncome, superOrKiwiContribution);

            return payslip;
        }

        public List<Payslip> CreatePayslipsForGroupOfPeople(IEnumerable<Person> group) {
            return group.Select(CreatePayslipForPerson).ToList();
        }

        private static string GetNumbers(string input) {//This function takes a string and strips all characters except digits (0-9)
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}