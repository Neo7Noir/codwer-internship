using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor_Task
{
    public class StartButton : Button
    {
        public Boiler boiler = new Boiler();
        public BoilerHeater boilerHeater = new BoilerHeater();
        public DeliveryPipe deliveryPipe = new DeliveryPipe();
        
        public override void pressButton()
        {
            boiler.verifyBoiler();
            Console.Clear();
            boilerHeater.Incalzire();
            deliveryPipe.transmiteApa();
        }
    }
}
