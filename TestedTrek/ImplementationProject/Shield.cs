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

        public void AcceptDamage(int units)
        {
            Units -= units;
        }

        public bool IsBuckled()
        {
            return Units <= 0;
        }
    }
}
