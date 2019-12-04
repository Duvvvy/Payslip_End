using System;

namespace Payslip_End.DataStores {
    public class Person {
        /*
         * The purpose of this class is to store the information for a person
         */
        public Person(string firstName, string lastName, decimal annualSalary, string superKiwiRate,
            DateTime paymentStartDate, DateTime paymentEndDate) {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperKiwiRate = superKiwiRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
        }

        public Person() {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public string SuperKiwiRate { get; set; }
        public DateTime PaymentStartDate { get; set; }
        public DateTime PaymentEndDate { get; set; }
        public string PayPeriod { get; set; }
    }
}