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
    public static void Heal()
    {
        if (Create.p.MaxHealth == Create.p.Health)
        {
            UI.Keypress(
            new List<int> { 1 },
            new List<string>
            {
                Color.HEALTH,"You don't need " ,"healing", "!"
            });
        }
        else
        {
            if (Create.p.PotionSize == 0)
            {
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH, "Your " ,"potion ", "is empty!"
                });
            }
            else if ((Create.p.MaxHealth - Create.p.Health) > Create.p.PotionSize)
            {
                int heal = Create.p.PotionSize;
                Create.p.AddHealth(heal);
                Create.p.PotionSize = 0;
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH,"You heal for " ,heal.ToString(), " hp!"
                });
            }
            else
            {
                int heal = Create.p.MaxHealth - Create.p.Health;
                Create.p.PotionSize -= (Create.p.MaxHealth - Create.p.Health);
                Create.p.AddHealth(heal);
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH,"You heal for " , heal.ToString() , " hp!"
                });
            }
        }
    }
}