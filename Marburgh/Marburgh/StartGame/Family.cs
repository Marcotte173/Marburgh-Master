using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Family
{
    internal static List<string> alive = new List<string> { };
    internal static List<string> dead = new List<string> { };
    internal static string lastName = "";
    internal static void Create()
    {
        FamilyName();
        GenerateSiblings();
        global::Create.Name();
    }

    private static void FamilyName()
    {
        Console.Clear();
        lastName = UI.CreationBox();
        if (!UI.Confirm(new List<int> { 1 }, new List<string> { Colour.NAME, "Is ", $"{lastName}", " correct?" })) FamilyName();
    }

    private static void GenerateSiblings()
    {
        while (alive.Count < 3)
        {
            alive.Add($"{Name.list[Return.RandomInt(0, Name.list.Count)]} {lastName}");
            Name.list.Remove(alive[alive.Count - 1]);
        }
    }
}