using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citizens
{
    public class CitizenList : ICitizenRegistry
    {
        private static string MAN = "man";
        private static string WOMAN = "woman";

        private List<ICitizen> citizens = new List<ICitizen>();
        private DateTime lastUpdateDate;

        public ICitizen this[string id]
        {
            get
            {
                if(id == null)
                {
                    throw new ArgumentNullException();
                }

                return citizens.Where((citizen) => citizen.VatId == id).SingleOrDefault();
            }
        }

        public void Register(ICitizen citizen)
        {
            if (String.IsNullOrWhiteSpace(citizen.VatId))
            {
                citizen.VatId = VatIdGenerator.Generate(citizen.Gender, citizen.BirthDate);
            }
            else if (citizens.Where((c) => c.VatId == citizen.VatId).FirstOrDefault() != null)
            {
                throw new InvalidOperationException(String.Format("Citizen with id [{0}] already exists", citizen.VatId));
            }

            citizens.Add((ICitizen)citizen.Clone());

            lastUpdateDate = SystemDateTime.Now().Date;
        }

        public string Stats()
        {
            int manCount = citizens.Where((citizen) => citizen.Gender == Gender.Male).Count();
            int womanCount = citizens.Count - manCount;

            string manWord = manCount != 1 ? MAN.Pluralize() : MAN;
            string womanWord = womanCount != 1 ? WOMAN.Pluralize() : WOMAN;

            StringBuilder lastUpdateMsgBuilder = new StringBuilder();

            if(lastUpdateDate != default(DateTime))
            {
                lastUpdateMsgBuilder.Append(". Last registration was ");

                var today = SystemDateTime.Now();
                var dayDiff = (today.Date - lastUpdateDate.Date).TotalDays;

                if (dayDiff == 1)
                {
                    lastUpdateMsgBuilder.Append("yesterday");
                }
                else
                {
                    lastUpdateMsgBuilder.Append(dayDiff);
                    lastUpdateMsgBuilder.Append(" days ago");
                }
            }

            return String.Format("{0} {1} and {2} {3}{4}", manCount, manWord, womanCount, womanWord, lastUpdateMsgBuilder.ToString());
        }
    }
}
