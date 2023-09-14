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

    if(isSquare == true)
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

