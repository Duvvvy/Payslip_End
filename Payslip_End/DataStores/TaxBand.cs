namespace Payslip_End.DataStores {
    public class TaxBand {
        public TaxBand(decimal lowerBand, decimal upperBand, decimal taxRate, decimal flatFee) {
            UpperBand = upperBand;
            LowerBand = lowerBand;
            TaxRate = taxRate;
            FlatFee = flatFee;
        }

        public decimal UpperBand { get; set; }
        public decimal LowerBand { get; set; }
        public decimal TaxRate { get; set; }
        public decimal FlatFee { get; set; }
    }
}