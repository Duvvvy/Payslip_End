using System.Collections.Generic;
using Payslip_End.DataStores;

namespace Payslip_End.Constants {
    /*
     * The intention of this class is to define the australian tax bands for use in calculations.
     *
     * Lower band is the lowest amount of money before you are charged at that tax rate.
     *
     * Flat fee is a rounded calculation of all the previous brackets added together.
     */
    public class AuTaxBands : List<TaxBand>{

        public AuTaxBands() {
            this.Add(new TaxBand(0,18200,0,0));
            this.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            this.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            this.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            this.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
        }
        
        
    }
}