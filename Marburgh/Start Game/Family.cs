using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Family
{
    internal static List<string> alive = new List<string> { };
    internal static List<string> dead = new List<string> { };
    internal static List<string> cause = new List<string> { };
    internal static string lastName = "";
    public static int[,] timeOfDeath = new int[3, 4]
    {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }
    };

    internal static void Name()
    {
        Console.Clear();
        lastName = UI.CreationBox();
        if (lastName.Length < 3) Name();
        if (UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "Is ", $"{lastName}", " correct?" }))
            GenerateSiblings(); 
        else Name();        
    }

    private static void GenerateSiblings()
    {
        while (alive.Count < 3)
        {
            alive.Add($"{(global::Name.list[Return.RandomInt(0, global::Name.list.Count)])} {lastName}");
            global::Name.list.Remove(alive[alive.Count - 1]);
        }
        Create.Story();
    }
}