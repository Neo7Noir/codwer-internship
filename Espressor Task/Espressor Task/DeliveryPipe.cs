using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor_Task
{
    public class DeliveryPipe
    {
        public Boiler boiler = new Boiler();
        public void transmiteApa()
        {
            Console.WriteLine("Apa se transmite in filtru");
            boiler.consumaApa();
        }
    }
}
