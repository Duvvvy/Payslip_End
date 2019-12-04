using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class CSVHandler {
        /*
         * The purpose of this class is to handle the CSV reader methods
         */
        public void WriteToFile(string path, List<Payslip> payslips) {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer)) {
                csv.WriteRecords(payslips);
            }
        }
    }
}