using CsvHelper.Configuration;

namespace Payslip_End.DataStores {
    public sealed class PersonMap : ClassMap<Person> {
        /*
         * The purpose of this class is to store the class map so that the CSV reader can push data,
         * from the correct headers, into their respective props inside the person object
         */
        private PersonMap() {
            Map(p => p.FirstName).Name("first name");
            Map(p => p.LastName).Name(" last name"); 
            Map(p => p.AnnualSalary).Name(" annual salary");
            Map(p => p.SuperKiwiRate).Name(" super rate (%)");
            Map(p => p.PayPeriod).Name(" payment start date");
        }
    }
}