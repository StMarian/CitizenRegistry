using System;

namespace Citizens.Counters
{
    class ManWomanCounter
    {
        private OddEvenCounter oddEvCntr = new OddEvenCounter();

        // Returns current counter for specified gender
        public int this[Gender gender]
        {
            get
            {
                int resultCounter;

                if (gender == Gender.Male)
                {
                    resultCounter = oddEvCntr.Odd;
                }
                else
                {
                    resultCounter = oddEvCntr.Even;
                }

                return resultCounter;
            }
        }

        public void Add(Gender gender)
        {
            switch(gender)
            {
                case Gender.Male:
                    oddEvCntr.IncOdd();
                    break;
                case Gender.Female:
                    oddEvCntr.IncEven();
                    break;
                default:
                    throw new ApplicationException(String.Format("Invalid gender: {0}", gender));
            }
        }
    }
}
