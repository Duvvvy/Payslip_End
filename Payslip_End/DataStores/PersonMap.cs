using CsvHelper.Configuration;

namespace Payslip_End.DataStores {
    public class PersonMap : ClassMap<Person> {
        private PersonMap() {
            Map(p => p.FirstName).Name("first name");
            Map(p => p.LastName)
                .Name(" last name"); //TODO Argue with client, about removing the space before ' last name'
            Map(p => p.AnnualSalary).Name(" annual salary");
            Map(p => p.SuperKiwiRate).Name(" super rate (%)");
            Map(p => p.PayPeriod).Name(" payment start date");
            //Map(m => m.PaymentStartDate).Name(null);
            //Map(m => m.PaymentEndDate).Name(null);
        }
    }
}