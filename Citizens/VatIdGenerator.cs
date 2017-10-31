using System;
using System.Linq;
using System.Text;

namespace Citizens
{
    public static class VatIdGenerator
    {
        private static BirthdaysPerDate birthdays = new BirthdaysPerDate();
        private static DateTime START_COUNT_DATE = new DateTime(1899, 1, 31);

        public static string Generate(ICitizen citizen) => Generate(citizen.Gender, citizen.BirthDate);

        public static string Generate(Gender gender, DateTime dateOfBirth)
        {
            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.Append(String.Format("{0:D5}", GetTotalDaysFromDateCountStart(dateOfBirth)));
            resultBuilder.Append(GetPeopleCountForDate(gender, dateOfBirth));
            resultBuilder.Append(GetCheckDigit(resultBuilder.ToString()));

            return resultBuilder.ToString();
        }

        // First five digits - number of days between 31.01.1899 and date
        private static int GetTotalDaysFromDateCountStart(DateTime date) => Convert.ToInt32((date.Date - START_COUNT_DATE.Date).TotalDays);

        private static string GetPeopleCountForDate(Gender gender, DateTime date)
        {
            birthdays.AddBirthday(gender, date);
            return String.Format("{0:D4}", birthdays.GetCount(gender, date));
        }

        private static int GetCheckDigit(string sNum)
        {
            int checkSum = new int[] 
            {
                Convert.ToInt32(sNum[0]) * -1,
                Convert.ToInt32(sNum[1]) * 5,
                Convert.ToInt32(sNum[2]) * 7,
                Convert.ToInt32(sNum[3]) * 9,
                Convert.ToInt32(sNum[4]) * 4,
                Convert.ToInt32(sNum[5]) * 6,
                Convert.ToInt32(sNum[6]) * 10,
                Convert.ToInt32(sNum[7]) * 5,
                Convert.ToInt32(sNum[8]) * 7,
            }.Sum();
            
            int checkDigit = (checkSum % 11) % 10;

            return checkDigit;
        }
    }
}
