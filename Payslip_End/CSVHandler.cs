using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class CSVHandler {
        public CSVHandler() {
            
        }

        public void WriteToFile(string path, List<Payslip> payslips) {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {    
                csv.WriteRecords(payslips);
            }
        }
    }
}