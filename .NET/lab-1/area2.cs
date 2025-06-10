using System;

class area2
{
    static void Main(string[] args)
    {
        int s = 5;
        int sa = s * s;

        int w = 4;
        int h = 6;
        int ra = w * h;

        double r = 3.5;
        double ca = Math.PI * r * r;

        Console.WriteLine($"Square (s={s}): {sa}");
        Console.WriteLine($"Rect (w={w}, h={h}): {ra}");
        Console.WriteLine($"Circle (r={r}): {ca}");
    }
}