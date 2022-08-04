namespace ImplementationProject
{
    public class Shield
    {
        private bool isRaised = false;
        public int Units { get; } = 8000;

        public bool IsUp()
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


    }

    interface IEnergyConsumer
    {

    }

    interface IEnergySource
    {
            
    }

}
