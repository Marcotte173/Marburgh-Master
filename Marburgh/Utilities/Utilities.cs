using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utilities
{
    internal static void ToTown()
    {
        Town.Menu();
    }

    internal static void Quit()
    {
        UI.KeypressNEW(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<string>
            {
                "Well, you tried",
                "",
                "You tried but you failed",
                "",
                "And in the end, is that not the real victory?",
                "",
                "The answer is no...",
                "",
                "Goodbye"
            });
        Environment.Exit(0);
    }

    internal static void Keypress()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    internal static void Keypress(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
}