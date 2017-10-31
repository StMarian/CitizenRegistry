namespace Citizens.Counters
{
    class OddEvenCounter
    {
        private static int STEP = 2;

        private int oddCntr;
        private int evenCntr;

        public OddEvenCounter()
        {
            oddCntr = 1;
            evenCntr = 0;
        }

        public int Odd
        {
            get
            {
                return oddCntr;
            }
        }

        public int Even
        {
            get
            {
                return evenCntr;
            }
        }

        public void IncOdd() => oddCntr += STEP;

        public void IncEven() => evenCntr += STEP;
    }
}
