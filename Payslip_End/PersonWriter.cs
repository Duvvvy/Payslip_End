using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;
using Payslip_End.DataStores;

namespace Payslip_End {
    public class PersonWriter {
        /*
         * The purpose of this class is to create person objects
         */
        private readonly ConsoleInterface _consoleInterface;

        public PersonWriter(ConsoleInterface consoleInterface) {
            _consoleInterface = consoleInterface;
        }

        public Person CreatePersonManually() {
            var firstName =
                _consoleInterface.RegexDecisionGetter(new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"),
                    "Please input your name: ");
            var lastName = _consoleInterface.RegexDecisionGetter(new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"), "Please input your surname: ");
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

    }
}