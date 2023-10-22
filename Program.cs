using System;

class Triangle
{
    protected int a, b, c;

    public Triangle(int a, int b, int c) => (this.a, this.b, this.c) = (a, b, c);

    public void Print() => Console.WriteLine($"Сторона A: {a}, Сторона B: {b}, Сторона C: {c}");

    public int Perimeter() => a + b + c;

    public virtual double Sqr()
    {
        int s = Perimeter() / 2;
        return Math.Round(Math.Sqrt(s * (s - a) * (s - b) * (s - c)), 2);
    }

    public bool Exists() => a + b > c && a + c > b && b + c > a;
}

class Equilateral : Triangle
{
    public Equilateral(int a) : base(a, a, a) { }

    public override double Sqr()
    {
        double s = (Math.Sqrt(3) / 4) * a * a;
        Console.WriteLine($"Площа рівностороннього трикутника: {Math.Round(s, 2)}");
        return Math.Round(s, 2);

    }

    public double Radius() => Math.Round(a / (2 * Math.Sqrt(3)), 2);
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            int sideA = random.Next(1, 10);
            int sideB = random.Next(1, 10);
            int sideC = random.Next(1, 10);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Triangle triangle = random.Next(2) == 0
                ? (Triangle)new Equilateral(sideA)
                : new Triangle(sideA, sideB, sideC);

            Console.WriteLine(triangle is Equilateral
                ? "Рівносторонній трикутник:"
                : "Звичайний трикутник:");

            triangle.Print();

            if (triangle.Exists())
            {
                Console.WriteLine($"Периметр: {triangle.Perimeter()}");
                triangle.Sqr();

                if (triangle is Equilateral equilateral)
                    Console.WriteLine($"Радіус вписаного кола: {Math.Round(equilateral.Radius(), 2)}");
            }
            else
            {
                Console.WriteLine("Такий трикутник не існує.");
            }

            Console.WriteLine();
        }
    }
}
