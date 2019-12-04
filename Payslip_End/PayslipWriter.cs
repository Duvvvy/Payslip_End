using System;
using System.Collections.Generic;
using System.Linq;
using Payslip_End.Constants;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class PayslipWriter {
        public PayslipWriter() {
            Calculator = new Calculator();
            AuTaxBands = new AuTaxBands();
        }

        public Calculator Calculator { get; set; }
        public AuTaxBands AuTaxBands { get; set; }

        public Payslip CreatePayslipForPerson(Person person) {
            var name = person.FirstName + " " + person.LastName;

            var payPeriod = "";
            if (person.PayPeriod != null)
                payPeriod = person.PayPeriod;
            else
                payPeriod = Calculator.PayPeriod(person.PaymentStartDate, person.PaymentEndDate);
            var grossIncomePerMonth = Calculator.MonthlyGrossIncomeFromAnnualGross(person.AnnualSalary);
            var incomeTax = Calculator.MonthlyIncomeTaxFromAnnualGross(AuTaxBands, person.AnnualSalary);
            var netIncome = Calculator.MonthlyNetIncome(grossIncomePerMonth, incomeTax);

            var superKiwiRateNumbersOnly = GetNumbers(person.SuperKiwiRate);

            var superOrKiwiContribution =
                Calculator.SuperKiwiSaverContribution(grossIncomePerMonth, Convert.ToDecimal(superKiwiRateNumbersOnly));

            var payslip = new Payslip(name, payPeriod, grossIncomePerMonth, incomeTax, netIncome,
                superOrKiwiContribution);

            return payslip;
        }

        public List<Payslip> CreatePayslipsForGroupOfPeople(IEnumerable<Person> group) {
            return group.Select(CreatePayslipForPerson).ToList();
        }

        private static string GetNumbers(string input) {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}