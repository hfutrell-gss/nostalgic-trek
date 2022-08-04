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

        public void AcceptPower(int units)
        {
            Units += units;
        }

        public int AcceptDamage(int units)
        {
            Units -= units;
            if (Units < 0)
            {
                int passedDamage = -Units;
                Units = 0;
                return passedDamage;
            }
            return 0;
        }

        public bool IsBuckled()
        {
            return Units <= 0;
        }
    }
}
