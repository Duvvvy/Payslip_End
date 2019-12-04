using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class PersonWriter {
        private readonly ConsoleInterface _consoleInterface;

        public PersonWriter(ConsoleInterface consoleInterface) {
            _consoleInterface = consoleInterface;
        }

        public Person CreatePersonManually() {
            var firstName =
                _consoleInterface.RegexDecisionGetter(new Regex(""),
                    "Please input your name: "); //TODO find regex for names
            var lastName = _consoleInterface.RegexDecisionGetter(new Regex(""), "Please input your surname: ");
            var annualSalary =
                Convert.ToDecimal(
                    _consoleInterface.RegexDecisionGetter(new Regex(@"\d"), "Please enter your annual salary: "));
            var superOrKiwisaverRate =
                Convert.ToDecimal(_consoleInterface.RegexDecisionGetter(new Regex(@"\d"),
                    "Please enter your super or kiwisaver rate: "));
            var paymentStartDate =
                _consoleInterface.DateTimeDecisionGetter("dd/mm/yyyy",
                    "Please enter your payment start date: dd/mm/yyyy");
            var paymentEndDate =
                _consoleInterface.DateTimeDecisionGetter("dd/mm/yyyy",
                    "Please enter your payment end date: dd/mm/yyyy");

            return new Person(firstName, lastName, annualSalary, superOrKiwisaverRate.ToString(), paymentStartDate,
                paymentEndDate);
        }

        public IEnumerable<Person> ReadInEnumerablePeopleFromCsv(string path) {
            using (TextReader reader = File.OpenText(path))
            using (var csv = new CsvReader(reader)) {
                csv.Configuration.RegisterClassMap<PersonMap>();
                foreach (var record in csv.GetRecords<Person>()) yield return record;
            }
        }
    }
}