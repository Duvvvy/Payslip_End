using System.Collections.Generic;
using Payslip_End;
using Xunit;

namespace Payslip_Tests {
    public class CalculatorTests {

        [Fact]
        public void TaxLowestIncome() {
            
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(), 1800);
            Assert.Equal(0, testOutput);
        }
        
        [Fact]
        public void TaxFirstIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(), 25000);
            Assert.Equal(108, testOutput);
        }
        
        
        [Fact]
        public void TaxSecondIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(), 60050);
            Assert.Equal(922, testOutput);
        }
        
        [Fact]
        public void TaxExactBracketSecond() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(), 37000);
            Assert.Equal(298, testOutput);//Expected is gross / 12 months
        }
        
        [Fact]
        public void TaxThirdIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(),90000);
            Assert.Equal(1744, testOutput);
        }
        
        [Fact]
        public void TaxHighestIncome() {
            Calculator calculator = new Calculator();
            var testOutput = calculator.MonthlyIncomeTaxFromAnnualGross(new AU_TaxBands(), 200000);
            Assert.Equal(5269, testOutput);
        }



        [Fact]
        public void KiwiSaverContributionTest() {
            Calculator calculator = new Calculator();
            
        }
        
        

    }
}