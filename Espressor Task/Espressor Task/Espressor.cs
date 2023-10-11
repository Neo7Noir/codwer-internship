namespace Espressor_Task
{
    public class Espressor
    {
        StartButton startButton = new StartButton();
        public void Start()
        {
            startButton.pressButton();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Espressor espressor = new Espressor();
            espressor.Start();
        }
    }
}