using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor_Task
{
    public class Water_Level
    {
        static private decimal procenteApa = 0;

        public void adaugaNivelApa(decimal apaAdaugata)
        {
            procenteApa+= apaAdaugata;
            Console.WriteLine($"Acum sunt: {procenteApa}% de apa in boiler ");
        }

        public void scadeNivelApa()
        {
            procenteApa-= 20;
            Console.WriteLine($"Au ramas {procenteApa}% de apa in boiler");
        }

        public decimal getProcentApa()
        {
            return procenteApa;
        }
    }
}
