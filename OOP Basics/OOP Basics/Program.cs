namespace OOP
{

    public struct dimensiune
    {
        decimal lungime { get; set; }
        decimal latime { get; set; }
        decimal inaltime { get; set; }
        public dimensiune(decimal _lungime, decimal _latime, decimal _inaltime)
        {
            lungime = _lungime;
            latime = _latime;
            inaltime = _inaltime;
        }
    }

    public abstract class Animal
    {
        private string name { get; set; }
        private decimal greutate { get; set; }
        private dimensiune dimensiune;
        private decimal viteza { get; set; }
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

        public void Mananca(Mancare m)
        {
            if (m.greutate < greutate / 8)
            {
                stomac.Add(m);
                Console.WriteLine("Mananca");
            }
        }

        public abstract double Energie();

        public void Alearga(decimal distanta)
        {
            decimal timp = distanta / (viteza / Convert.ToDecimal(Energie()));
            Console.WriteLine($"timpul = {timp} secunde");
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
        public decimal energie { get; set; }
    }

    public class Carne : Mancare
    {

    }

    public class Planta : Mancare
    {

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Numarul de animale =" + Animal.Numar());

            dimensiune dLup = new dimensiune(70, 50, 54);
            Carnivor lup = new Carnivor("Fiodor", 70, dLup, 10);

            dimensiune dOaie = new dimensiune(60, 40, 30);
            Erbivor oaie = new Erbivor("Zoluska", 60, dOaie, 7);

            dimensiune dUrs = new dimensiune(120, 70, 70);
            Omnivor urs = new Omnivor("Gena", 150, dUrs, 8);

            //Console.WriteLine("Numarul de animale =" + Animal.Numar());

            Planta salata = new Planta();
            Carne sunca = new Carne();

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

            lup.Alearga(200);
            oaie.Alearga(200);
            urs.Alearga(200);
        }
    }
}