using System.Collections.Generic;
using Payslip_End;
using Xunit;

namespace Payslip_Tests {
    public class Calculator_Tests {

        [Fact]
        public void TaxLowestIncome() {
            List<TaxBand> taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0,18200,0,0));
            taxBands.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            taxBands.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            taxBands.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            taxBands.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
            Calculator calculator = new Calculator();
            var testOutput = calculator.CalculateIncomeTax(taxBands,1800);
            Assert.Equal(1800, testOutput);
        }
        
        [Fact]
        public void TaxFirstIncome() {
            List<TaxBand> taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0,18200,0,0));
            taxBands.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            taxBands.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            taxBands.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            taxBands.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
            Calculator calculator = new Calculator();
            var testOutput = calculator.CalculateIncomeTax(taxBands,25000);
            Assert.Equal(108, testOutput);
        }
        [Fact]
        public void TaxSecondIncome() {
            List<TaxBand> taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0,18200,0,0));
            taxBands.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            taxBands.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            taxBands.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            taxBands.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
            Calculator calculator = new Calculator();
            var testOutput = calculator.CalculateIncomeTax(taxBands,60050);
            Assert.Equal(922, testOutput);
        }
        [Fact]
        public void TaxThirdIncome() {
            List<TaxBand> taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0,18200,0,0));
            taxBands.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            taxBands.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            taxBands.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            taxBands.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
            Calculator calculator = new Calculator();
            var testOutput = calculator.CalculateIncomeTax(taxBands,90000);
            Assert.Equal(1744, testOutput);
        }
        [Fact]
        public void TaxHighestIncome() {
            List<TaxBand> taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0,18200,0,0));
            taxBands.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            taxBands.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            taxBands.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            taxBands.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
            Calculator calculator = new Calculator();
            var testOutput = calculator.CalculateIncomeTax(taxBands,200000);
            Assert.Equal(5269, testOutput);
        }
        
        

    }
}