namespace Espressor_Task
{
    public class WaterSensor : Sensor
    {
        Random rand = new Random();
        private int waterTemp;
        public override void Analyze()
        {
            waterTemp = rand.Next(20, 60);
            while (waterTemp <100)
            {
                waterTemp += 1;
                if(waterTemp % 5 == 0)
                {
                    Console.WriteLine($"Temperatura este {waterTemp}°C");
                    Thread.Sleep(800);
                    Console.Clear();
                }
            }
            Console.WriteLine("Apa a fiert!");
        }
    }
}
