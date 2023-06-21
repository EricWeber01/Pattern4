using System;

// Интерфейс круглого отверстия
interface IRoundHole
{
    double GetRadius();
    bool Fits(IRoundPeg peg);
}

// Класс круглого отверстия
class RoundHole : IRoundHole
{
    private double radius;

    public RoundHole(double radius)
    {
        this.radius = radius;
    }

    public double GetRadius()
    {
        return radius;
    }

    public bool Fits(IRoundPeg peg)
    {
        return peg.GetRadius() <= radius;
    }
}

// Интерфейс круглого колышка
interface IRoundPeg
{
    double GetRadius();
}

// Класс круглого колышка
class RoundPeg : IRoundPeg
{
    private double radius;

    public RoundPeg(double radius)
    {
        this.radius = radius;
    }

    public double GetRadius()
    {
        return radius;
    }
}

// Адаптер, преобразующий квадратный колышек в круглый
class SquarePegAdapter : IRoundPeg
{
    private double width;

    public SquarePegAdapter(double width)
    {
        this.width = width;
    }

    public double GetRadius()
    {
        return width * Math.Sqrt(2) / 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание круглого отверстия
        RoundHole roundHole = new RoundHole(5);

        // Создание круглого колышка
        RoundPeg roundPeg = new RoundPeg(4);

        // Создание адаптера для квадратного колышка
        SquarePegAdapter squarePegAdapter = new SquarePegAdapter(4);

        // Проверка, поместится ли круглый колышек в круглое отверстие
        if (roundHole.Fits(roundPeg))
        {
            Console.WriteLine("Круглый колышек помещается в круглое отверстие.");
        }
        else
        {
            Console.WriteLine("Круглый колышек не помещается в круглое отверстие.");
        }

        // Проверка, поместится ли адаптированный квадратный колышек в круглое отверстие
        if (roundHole.Fits(squarePegAdapter))
        {
            Console.WriteLine("Квадратный колышек помещается в круглое отверстие.");
        }
        else
        {
            Console.WriteLine("Квадратный колышек не помещается в круглое отверстие.");
        }
    }
}

