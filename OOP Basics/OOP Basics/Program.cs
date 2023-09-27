using System;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace OOP
{
    public enum TipAnimal
    {
        Lup, Urs, Oaie, Veverita, Pisica, Vaca
    }

    public struct dimensiune
    {
        public decimal lungime { get; set; }
        public decimal latime { get; set; }
        public decimal inaltime { get; set; }
        public dimensiune(decimal _lungime, decimal _latime, decimal _inaltime)
        {
            lungime = _lungime;
            latime = _latime;
            inaltime = _inaltime;
        }
    }

    public abstract class Animal
    {
        public string name { get; set; }
        protected decimal greutate { get; set; }
        protected dimensiune dimensiune;
        protected decimal viteza { get; set; }
        protected List<Mancare> stomac = new List<Mancare>();
        static int count = 0;
    

        public Animal(string nume, decimal weight, dimensiune size, decimal speed)
        {
            name = nume;
            greutate = weight;
            dimensiune = size;
            viteza = speed;
            count++;
        }

        public abstract void Mananca(Mancare m);


        public abstract double Energie();

        public void Alearga(decimal distanta)
        {
            decimal timp = distanta / (viteza / Convert.ToDecimal(Energie()));
            Console.WriteLine($"timpul = {timp} secunde");
        }

        public override string ToString()
        {
            return $"Tip animal: {this.GetType().Name}\n" +
                   $"Nume: {name}\n" +
                   $"Greutate: {greutate} kg\n" +
                   $"Dimensiuni: {dimensiune.lungime} x {dimensiune.latime} x {dimensiune.inaltime}\n" +
                   $"Viteza: {viteza} m/s\n";
        }

        public static int Numar()
        {
            return count;
        }
    }

    public class Carnivor : Animal
    {
        public Carnivor(string nume, decimal weight, dimensiune size, decimal speed) : base(nume, weight, size, speed)
        {

        }
        
        public override void Mananca(Mancare m)
        {
            if(m.GetType() == typeof(Carne)){
                if (m.greutate < greutate / 8)
                {
                    stomac.Add(m);
                    Console.WriteLine("Mananca");
                }
            }
        }

        public override double Energie()
        {
            decimal mediaGreutateMan = stomac.Sum(man => man.greutate)/stomac.Count();
            decimal sumEnerg = stomac.Sum(man => man.energie);
            return 0.2 - 1/5 * Convert.ToDouble(mediaGreutateMan) + Convert.ToDouble(sumEnerg);
        }
    }

    public class Erbivor : Animal
    {
        public Erbivor(string nume, decimal weight, dimensiune size, decimal speed) : base(nume, weight, size, speed)
        {

        }

        public override void Mananca(Mancare m)
        {
            if (m.GetType() == typeof(Planta))
            {
                if (m.greutate < greutate / 8)
                {
                    stomac.Add(m);
                    Console.WriteLine("Mananca");
                }
            }
        }

        public override double Energie()
        {
            decimal mediaGreutateMan = stomac.Sum(man => man.greutate) / stomac.Count();
            decimal sumEnerg = stomac.Sum(man => man.energie);
            return 0.5 - 1 / 3 * Convert.ToDouble(mediaGreutateMan) + Convert.ToDouble(sumEnerg);
        }
    }

    public class Omnivor : Animal
    {
        public Omnivor(string nume, decimal weight, dimensiune size, decimal speed) : base(nume, weight, size, speed)
        {

        }

        public override void Mananca(Mancare m)
        {
            if (m.greutate < greutate / 8)
            {
                stomac.Add(m);
                Console.WriteLine("Mananca");
            }
        }

        public override double Energie()
        {
            double coefGreutate = 0;
            foreach (Mancare m in stomac)
            {
                if(m.GetType() == typeof(Carne))
                {
                    coefGreutate -= 0.5;
                }else if(m.GetType() == typeof(Planta))
                {
                    coefGreutate += 0.5;
                }
            }
            decimal mediaGreutateMan = stomac.Sum(man => man.greutate) / stomac.Count();
            decimal sumEnerg = stomac.Sum(man => man.energie);
            return 0.35 + coefGreutate * Convert.ToDouble(mediaGreutateMan) + Convert.ToDouble(sumEnerg);
        }
    }

    public abstract class Mancare
    {
        public decimal greutate { get; set; }

        private decimal _energie;
        public decimal energie {
            get { return _energie; }
            set
            {
                if (value < 0 || value > 0.05M)
                {
                    throw new ArgumentException("Invalid value - Energy must be in the range 0-0.05");
                }
                _energie = value;
            } }

        public Mancare(decimal greutate, decimal energie)
        {
            this.greutate = greutate;
            this.energie = energie;
        }
    }

    public class Carne : Mancare
    {
        public Carne(decimal greutate, decimal energie) : base (greutate, energie) { }
    }

    public class Planta : Mancare
    {
        public Planta(decimal greutate, decimal energie) : base(greutate, energie) { }
    }

    public class Program
    {
        public static Animal CreeazaAnimal(TipAnimal tipAnimal, string nume, decimal greutate, dimensiune dimensiune, decimal viteza)
        {
            if(tipAnimal == TipAnimal.Lup || tipAnimal == TipAnimal.Pisica)
            {
                return new Carnivor(nume, greutate, dimensiune, viteza);
            }else if(tipAnimal == TipAnimal.Oaie || tipAnimal == TipAnimal.Vaca)
            {
                return new Erbivor(nume, greutate, dimensiune, viteza);
            }
            else return new Omnivor(nume, greutate, dimensiune, viteza);
        }
        public static void Main(string[] args)
        {

            /*
             * Instantierea animal + functia de afisare
            Animal lup = (Animal)CreeazaAnimal(TipAnimal.Lup, "Fedea", 70, new dimensiune(30, 40, 50), 10);
            Console.WriteLine(lup);
            */


            //Console.WriteLine("Numarul de animale =" + Animal.Numar());   //Contorul pentru verificare numar de animale create

            Planta salata = new Planta(3, 0.05M);
            Carne sunca = new Carne(4, 0.04M);

            /*
             * Hranirea animalelor
            Console.WriteLine("Lup");
            lup.Mananca(sunca);
            lup.Mananca(sunca);

            Console.WriteLine("Oaie");
            oaie.Mananca(salata);
            oaie.Mananca(salata);
            oaie.Mananca(salata);

            Console.WriteLine("Urs");
            urs.Mananca(sunca);
            urs.Mananca(salata);
            urs.Mananca(salata);
            urs.Mananca(salata);

              //Functia alearga
            lup.Alearga(200);
            oaie.Alearga(200);
            urs.Alearga(200);
            */
            

            //Ultimele cerinte I,J
            List<Animal> animale = new List<Animal>();
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                Type type = typeof(TipAnimal);
                Array values = type.GetEnumValues();
                int index = random.Next(values.Length);
                TipAnimal value = (TipAnimal)values.GetValue(index);

                //string animal = value.ToString();
                Animal animal = (Animal)CreeazaAnimal(value, "Animal", random.Next(60, 150), new dimensiune(random.Next(50,120), random.Next(40,60), random.Next(30,60)), random.Next(6,12));
                animale.Add(animal);
            }

            int manancaCarne = 0;
            int manancaSalata = 0;
            int manancaMancare = 0;

            foreach(Animal animal in animale)
            {
                if(animal.GetType() == typeof(Carnivor))
                {
                    animal.Mananca(sunca);
                    manancaCarne++;
                }else if(animal.GetType() == typeof(Erbivor))
                {
                    animal.Mananca(salata);
                    manancaSalata++;
                }
                else
                {
                    animal.Mananca(salata);
                    manancaMancare++;
                }
            }

            Console.WriteLine("Statistica:\n");
            Console.WriteLine("i.    " + manancaMancare + " animale mananca mancare");
            Console.WriteLine("ii.   " + manancaCarne + " animale mananca carne");
            Console.WriteLine("iii.  " + manancaSalata + " animale mananca salata");
            
        }
    }
}