using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor_Task
{
    public class Boiler
    {
        public Water_Level level = new Water_Level();
        public bool verifyBoiler()
        {
            decimal nivelApa = level.getProcentApa();
            Console.WriteLine("In boiler este " + nivelApa);
            if (nivelApa < 20)
            {
                Console.WriteLine("Nivelul apei este insuficient pentru a face cafea, adaugati apa");
                adaugaApa();
            }
            return true;
        }

        public void adaugaApa()
        {
            decimal nivelApa = level.getProcentApa();
            Console.WriteLine("Cata apa adaugati?");
            decimal apa = Convert.ToDecimal(Console.ReadLine());
            while ((nivelApa + apa) > 100)
            {
                Console.WriteLine("Atata apa nu va incapea in boiler, alegeti cantitate mai mica");
            }
            level.schimbNivelApa(apa);
            verifyBoiler();
        }

    }
}
