using System;
using System.Data.Common;

namespace Payslip_End {
    public class Person {
        
        public Person(string firstName, string lastName, decimal annualSalary, decimal superKiwiRate, DateTime paymentStartDate, DateTime paymentEndDate) {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperKiwiRate = superKiwiRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperKiwiRate { get; set; }
        public DateTime PaymentStartDate { get; set; }
        public DateTime PaymentEndDate { get; set; }
        
    }
}