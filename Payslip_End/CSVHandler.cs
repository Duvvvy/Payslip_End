using System;
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
        
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<Person> ReadInEnumerablePeopleFromCsv(string path) {
            TextReader reader;
            try {
                reader = File.OpenText(path);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Logger.Error(e, "File path exception");
                throw;
            }
            using (reader)
            using (var csv = new CsvReader(reader)) {
                csv.Configuration.RegisterClassMap<PersonMap>();
                foreach (var record in csv.GetRecords<Person>()) yield return record;
            }
        }
    }
}