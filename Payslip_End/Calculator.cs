using System;
using System.Collections.Generic;

namespace Payslip_End {
    public class Calculator {
        public Calculator() {
            
        }

        public decimal CalculateIncomeTax(List<TaxBand> taxBands, decimal incomeBeforeTax) {
            foreach (var taxBand in taxBands) {
                if (incomeBeforeTax > taxBand.LowerBand && incomeBeforeTax < taxBand.UpperBand)
                    if (taxBand.TaxRate == 0) {//Anything multiplied by 0 is 0...
                        return incomeBeforeTax;
                    }
                    else {
                        var calc = (taxBand.FlatFee + (incomeBeforeTax - taxBand.LowerBand) * taxBand.TaxRate) / 12;
                        var round = Math.Round(calc, MidpointRounding.AwayFromZero);
                        return round;
                    }
            }
            throw new SystemException("Tax bracket not found!",new Exception("Tax Error"));
        }
        
    }
}