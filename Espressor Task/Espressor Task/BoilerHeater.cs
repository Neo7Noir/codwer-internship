using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor_Task
{
    public class BoilerHeater : Heater
    {
        public WaterSensor waterSensor = new WaterSensor();
        public override void Incalzire()
        {
            Console.WriteLine("Incepe incalzirea apei, asteptati :)");
            waterSensor.Analyze();
        }
    }
}
