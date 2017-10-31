using System;
using System.Text;

namespace Citizens
{
    public class Citizen : ICitizen
    {
        private DateTime dateOfBirth;
        private string firstName;
        private Gender gender;
        private string lastName;
        private string vatId;

        public Citizen(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dateOfBirth;
            Gender = gender;
        }

        public DateTime BirthDate
        {
            get
            {
                return dateOfBirth.Date;
            }

            private set
            {
                if (value > SystemDateTime.Now())
                    throw new ArgumentException("Invalid date");
                else
                    dateOfBirth = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            private set
            {
                firstName = CorrectName(value);
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }

            private set
            {
                if (value != Gender.Male && value != Gender.Female)
                    throw new ArgumentOutOfRangeException("Invalid gender value");
                else
                    gender = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            private set
            {
                lastName = CorrectName(value);
            }
        }

        public string VatId
        {
            get
            {
                return vatId;
            }

            set
            {
                vatId = value;
            }
        }

        public object Clone()
        {
            Citizen copy = new Citizen(firstName, lastName, dateOfBirth, gender);
            copy.vatId = vatId;
            return copy;
        }

        // Takes any string as argument and return it's correct name representation.
        // First letter is uppercase, others - lowercase
        // Ex.: "bILLy" -> "Billy"
        private string CorrectName(string name)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(name.Substring(0, 1).ToUpper());
            sb.Append(name.Substring(1).ToLower());

            return sb.ToString();
        }
    }
}
