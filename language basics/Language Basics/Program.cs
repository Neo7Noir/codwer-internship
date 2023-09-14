void Task1() { 
    string ReadNum()
    {
        Console.WriteLine("Da un numar de 3 cifre");
        string x = Console.ReadLine();
        while (x.Length < 3)
        {
            Console.WriteLine("numarul e mai mic de 3 cifre");
            x = Console.ReadLine();
        }
        return x;
    }

    int ReverseNumber(string number)
    {
        char[] charArray = number.ToCharArray();
        Array.Reverse(charArray);
        string reverseNum = new string(charArray);
        int a = Convert.ToInt32(reverseNum);
        return a;
    }

    void PerfectSquare(int number)
    {
        double result = Math.Sqrt(number);
        bool isSquare = result % 1 == 0;

        if (isSquare == true)
        {
            Console.WriteLine("Numarul dat in oglinda e patrat perfect");
        }
        else
        {
            Console.WriteLine("Numarul dat in oglinda nu este patrat perfect");
        }

    }

    string number = ReadNum();
    int reverseNum = ReverseNumber(number);
    PerfectSquare(reverseNum);
}

void Task2()
{
    //Citirea array-ului
    double[] items = Console.ReadLine().Split().Select(double.Parse).ToArray();
    double minNum = items[0];

    foreach(double item in items)
    {
        //Afisarea numerelor neintregi
        if(item % 1 != 0)
        {
            Console.WriteLine(item);
        }
        
        //Cautarea si afisarea numarului minim
        if(minNum > item)
        {
            minNum = item;
        }
    }
    Console.WriteLine(minNum);
    
}

void Task3()
{
    Console.WriteLine("Dati numele de persoane:");
    string[] names = Console.ReadLine().Split();
    foreach (var name in names)
    {
        string nume = name.ToLower();
        Dictionary<char, int> frecventaCaractere = new Dictionary<char, int>();
        foreach (char caracter in nume)
        {
            if (Char.IsLetter(caracter))
            {
                if (frecventaCaractere.ContainsKey(caracter))
                {
                    frecventaCaractere[caracter]++;
                }
                else
                {
                    frecventaCaractere[caracter] = 1;
                }
            }
        }
        Console.WriteLine(name);
        Console.WriteLine("Frecventa caracterelor:");

        foreach (var entry in frecventaCaractere)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

//Task1();
//Task2();
//Task3();