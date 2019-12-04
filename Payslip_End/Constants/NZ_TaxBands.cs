using System;
using System.Collections.Generic;
using Payslip_End.DataStores;

namespace Payslip_End.Constants {
    public class NzTaxBands {
        public class NZTaxBands : List<TaxBand> {
            public NZTaxBands() {
                throw new SystemException("This wont work, the flat fees are not implemented");
                Add(new TaxBand(0, 14000, new decimal(0.105), 0));
                Add(new TaxBand(14000, 48000, new decimal(0.175), 0));
                Add(new TaxBand(48000, 70000, new decimal(.30), 0));
                Add(new TaxBand(87000, decimal.MaxValue, new decimal(0.33), 0));
            }
        }
    }
}