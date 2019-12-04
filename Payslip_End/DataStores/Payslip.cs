using System.Text;

namespace Payslip_End.DataStores {
    public class Payslip {
        public Payslip(string name, string payPeriod, decimal grossIncomePerMonth, decimal incomeTax, decimal netIncome,
            decimal superKiwiSaverContribution) {
            Name = name;
            PayPeriod = payPeriod;
            GrossIncomePerMonth = grossIncomePerMonth;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            SuperKiwiSaverContribution = superKiwiSaverContribution;
        }

        private string Name { get; set; }
        private decimal GrossIncomePerMonth { get; set; }
        private decimal IncomeTax { get; set; }
        private decimal NetIncome { get; set; }
        private decimal SuperKiwiSaverContribution { get; set; }
        private string PayPeriod { get; set; }

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your payslip has been generated: \n");
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