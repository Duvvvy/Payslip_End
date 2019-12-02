using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslip_End {
    public class PayslipWriter {
        public Calculator Calculator { get; set; }
        public AU_TaxBands AuTaxBands { get; set; }
        public PayslipWriter() {
            Calculator = new Calculator();
            AuTaxBands = new AU_TaxBands();
        }
        public Payslip CreatePayslipForPerson(Person person) {
            var name = (person.FirstName + " " + person.LastName);
            var payPeriod = Calculator.PayPeriod(person.PaymentStartDate,person.PaymentEndDate);
            var grossIncomePerMonth = Calculator.MonthlyGrossIncomeFromAnnualGross(person.AnnualSalary);
            var incomeTax = Calculator.MonthlyIncomeTaxFromAnnualGross(AuTaxBands, person.AnnualSalary);
            var netIncome = Calculator.MonthlyNetIncome(grossIncomePerMonth, incomeTax);
            var superOrKiwiContribution = Calculator.SuperKiwiSaverContribution(grossIncomePerMonth, person.SuperKiwiRate);
            
            var payslip = new Payslip(name,payPeriod,grossIncomePerMonth,incomeTax,netIncome,superOrKiwiContribution);
            
            return payslip;
        }

        public List<Payslip> CreatePayslipsForGroupOfPeople(List<Person> group) {
            return @group.Select(CreatePayslipForPerson).ToList();
        }
        
        
    }
}