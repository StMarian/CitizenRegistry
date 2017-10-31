using System;
using System.Collections.Generic;
using Citizens.Counters;

namespace Citizens
{
    class BirthdaysPerDate
    {
        // Holds number of birthdays per specific day.
        // While generating new VatId access this number, don't forget to increment its counter.
        private Dictionary<DateTime, ManWomanCounter> birthdaysPerDate = new Dictionary<DateTime, ManWomanCounter>();

        public int GetCount(Gender gender, DateTime date)
        {
            ManWomanCounter cntr;
            birthdaysPerDate.TryGetValue(date, out cntr);
            // Do we need to handle nulls here?

            return cntr[gender];
        }

        public void AddBirthday(Gender gender, DateTime date)
        {
            if(!birthdaysPerDate.ContainsKey(date))
            {
                birthdaysPerDate.Add(date, new ManWomanCounter());
            }

            birthdaysPerDate[date].Add(gender);
        }
    }
}
