namespace ImplementationProject
{
    public class Shield
    {
        private bool isRaised = false;
        public int Units { get; private set; } = 8000;


        public bool IsRaised()
        {
            return isRaised;
        }

        public void Raise()
        {
            isRaised = true;
        }

        public void Lower()
        { 
            isRaised = false;
        }

        public int AcceptPower(int units)
        {
            var overload = 0;

            Units += units;
            if (Units > 10000)
            {
                overload = Units - 10000;
                Units = 10000;
            }

            return overload;
        }

        public int AcceptDamage(int units)
        {
            Units -= units;
            if (Units < 0)
            {
                int passedDamage = -Units;

                Lower();
                
                Units = 0;
                return passedDamage;
            }
            return 0;
        }

    }
}
