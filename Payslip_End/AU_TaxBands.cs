using System.Collections.Generic;

namespace Payslip_End {
    public class AU_TaxBands : List<TaxBand>{

        public AU_TaxBands() {
            this.Add(new TaxBand(0,18200,0,0));
            this.Add(new TaxBand(18200,37000,new decimal(0.19),0));
            this.Add(new TaxBand(37000,87000,new decimal(.325),3572));
            this.Add(new TaxBand(87000,180000,new decimal(0.37),19822));
            this.Add(new TaxBand(180000,decimal.MaxValue, new decimal(0.45),54232));
        }
        
        
    }
}