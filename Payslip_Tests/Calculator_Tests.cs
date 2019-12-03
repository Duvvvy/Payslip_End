using System.Collections.Generic;
using Payslip_End;
using Payslip_End.Constants;
using Xunit;

namespace Payslip_Tests {
    public class CalculatorTests {

        [Fact]
        public void TaxLowestIncome() {
            
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(), 1800);
            Assert.Equal(0, testOutput);
        }
        
        [Fact]
        public void TaxFirstIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(), 25000);
            Assert.Equal(108, testOutput);
        }
        
        
        [Fact]
        public void TaxSecondIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(), 60050);
            Assert.Equal(922, testOutput);
        }
        
        [Fact]
        public void TaxExactBracketSecond() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(), 37000);
            Assert.Equal(298, testOutput);//Expected is gross / 12 months
        }
        
        [Fact]
        public void TaxThirdIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(),90000);
            Assert.Equal(1744, testOutput);
        }
        
        [Fact]
        public void TaxHighestIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AuTaxBands(), 200000);
            Assert.Equal(5269, testOutput);
        }

        [Fact]
        public void KiwiSaverContributionTest() {
            Calculator calculator = new Calculator();
            
        }

        [Fact]
        public void NumberMidpointRounderTest() {
            Calculator calculator = new Calculator();
            var output1 = calculator.NumberMidpointRounder((decimal) 10.1);
            var output2 = calculator.NumberMidpointRounder((decimal) 11.8);
            var output3 = calculator.NumberMidpointRounder((decimal) 5.4);
            
            Assert.Equal(10,output1);
            Assert.Equal(12,output2);
            Assert.Equal(5,output3);
        }
        

    }
}