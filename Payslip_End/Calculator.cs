using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslip_End {
    public class Calculator {
        public Calculator() {

        }

        public decimal MonthlyIncomeTaxFromAnnualGross(List<TaxBand> taxBands, decimal incomeBeforeTax) {
            var taxBand = taxBands.First(band => incomeBeforeTax >= band.LowerBand && incomeBeforeTax < band.UpperBand);
            var unRoundedIncomeTax = (taxBand.FlatFee + (incomeBeforeTax - taxBand.LowerBand) * taxBand.TaxRate) / 12;
            return NumberMidpointRounder(unRoundedIncomeTax);
        }

        public decimal MonthlyGrossIncomeFromAnnualGross(decimal annualGross) {
            var unRoundedMonthlyGross = annualGross / 12;
            return NumberMidpointRounder(unRoundedMonthlyGross);
        }

        public decimal MonthlyNetIncome(decimal annualGross, decimal incomeTax) {
            var unRoundedMonthlyGross = annualGross - incomeTax;
            return NumberMidpointRounder(unRoundedMonthlyGross);
        }

        public decimal SuperKiwiSaverContribution(decimal annualGrossMonthlyIncome, decimal superOrKiwiRate) {
            var superOrKiwiRateAsPercentage = superOrKiwiRate / 100;
            var unRoundedMonthlyContribution = annualGrossMonthlyIncome * superOrKiwiRateAsPercentage;
            return NumberMidpointRounder(unRoundedMonthlyContribution);
        }

        public string PayPeriod(DateTime paymentStartDate, DateTime paymentEndDate) {
            return paymentStartDate.ToString("dd/MM/yyyy") + " - " + paymentEndDate.ToString("dd/MM/yyyy");
        }
        

        public decimal NumberMidpointRounder(decimal unRoundedNumber) {
            var round = Math.Round(unRoundedNumber, MidpointRounding.AwayFromZero);
            return round;
        }
    }
}