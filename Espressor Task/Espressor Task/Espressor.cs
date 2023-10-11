namespace Espressor_Task
{
    public class Espressor
    {
        public Boiler boiler = new Boiler();
        
        public void Start()
        {
            boiler.verifyBoiler();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Espressor espressor= new Espressor();
            espressor.Start();
        }
    }
}