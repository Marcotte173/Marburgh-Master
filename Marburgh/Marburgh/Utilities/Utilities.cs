using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utilities
{
    internal static void ToTown()
    {
        Location.now = Location.list[0];
        Location.now.Go();
    }

    internal static void Quit()
    {
        UI.Keypress(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<string>
            {
                "Well, you tried",
                "",
                "You tried but you failed",
                "",
                "And in the end, if that not the real victory?",
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
}