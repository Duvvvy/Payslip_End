using CsvHelper;
using CsvHelper.Configuration;

namespace Payslip_End.DataStores {
    public class DecimalConverter : CsvHelper.TypeConversion.DecimalConverter{
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) {
            var replace = text.Replace('%', new char());
            return base.ConvertFromString(replace, row, memberMapData);
        }
    }
}