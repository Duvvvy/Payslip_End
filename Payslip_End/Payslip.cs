using System;
using System.Text;

namespace Payslip_End {
    public class Payslip {
        public Payslip(string name, string payPeriod, decimal grossIncomePerMonth, decimal incomeTax, decimal netIncome, decimal superKiwiSaverContribution) {
            Name = name;
            PayPeriod = payPeriod;
            GrossIncomePerMonth = grossIncomePerMonth;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            SuperKiwiSaverContribution = superKiwiSaverContribution;
        }

        public string Name { get; set; }
        public decimal GrossIncomePerMonth { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal SuperKiwiSaverContribution { get; set; }
        public string PayPeriod { get; set; }

        public override string ToString() {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Name: " + Name);
            stringBuilder.AppendLine("Pay Period: " + PayPeriod);
            stringBuilder.AppendLine("Gross Income: " + GrossIncomePerMonth);
            stringBuilder.AppendLine("Income Tax: " + IncomeTax);
            stringBuilder.AppendLine("Net Income: " + NetIncome);
            stringBuilder.AppendLine("Super / KiwiSaver Contribution: " + SuperKiwiSaverContribution);

            return stringBuilder.ToString();

        }
    }
}