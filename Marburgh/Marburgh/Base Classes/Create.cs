using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Create
{
    internal static Player p;
    internal static void Name()
    {
        Console.Clear();
        if (Family.alive.Count == 3) UI.KeypressNEW(new List<int> { 1, 1, 0, 0, 0, 2 }, new List<string>
            {
               Colour.NAME,  "Your name is", $" {Family.alive[0]}","",
               Colour.NAME,  "Your Mother, ", $"Helen {Family.lastName}", " was an adventurer.",
               "She was recently killed by an Orc. You never knew your father.",
               "",
               "You are the eldest child.",
               Colour.NAME, Colour.NAME, "Your siblings,", $" {Family.alive[1]}", " and", $" {Family.alive[2]}", " look up to you now to take care of them."
            });
        else if (Family.alive.Count == 2) UI.KeypressNEW(new List<int> { 1, 1, 0, 0, 0, 1 }, new List<string>
            {
                Colour.NAME,  "Your name is", $" {Family.alive[0]}","",
                Colour.NAME,  "Your Mother, ", $"Helen {Family.lastName}", " was an adventurer.",
                "She was recently killed by an Orc. You never knew your father.",
                "",
                "You are the eldest surviving child.",
                Colour.NAME, "Your sibling,", $" {Family.alive[1]}", " looks up to you now to put food on the table the only way you know how - Adventuring."
            });
        else UI.KeypressNEW(new List<int> { 1, 1, 0, 0, 1 }, new List<string>
            {
                Colour.NAME,  "Your name is", $" {Family.alive[0]}","",
                Colour.NAME,  "Your Mother, ", $"Helen {Family.lastName}", " was an adventurer.",
                "She was recently killed by an Orc. You never knew your father.",
                "",
                Colour.NAME, "You are the only survivng", $" {Family.lastName}", ".It is all up to you now."
            });
        ChooseClass();
    }

    private static void ChooseClass()
    {
        Console.Clear();
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Return.Width(15), Return.Height(7));
        Write.EmbedColourText(Colour.CLASS, "", "[W]", "arrior");
        Console.SetCursorPosition(Return.Width(15), Return.Height(12));
        Write.EmbedColourText(Colour.CLASS, "", "[R]", "ogue");
        Console.SetCursorPosition(Return.Width(15), Return.Height(16));
        Write.EmbedColourText(Colour.CLASS, "", "[M]", "age");
        Console.SetCursorPosition(Return.Width(35), Return.Height(7));
        Write.EmbedColourText(Colour.CLASS, "", "Practiced in combat, durable and menacing.", "");
        Console.SetCursorPosition(Return.Width(35), Return.Height(12));
        Write.EmbedColourText(Colour.CLASS, "", "High Damage, Good Evasion.", "");
        Console.SetCursorPosition(Return.Width(35), Return.Height(16));
        Write.EmbedColourText(Colour.CLASS, "", "Spells learned through intricate rituals, strong and versatile.", "");
        Write.Position(47, 22);
        Console.WriteLine("Please select a class");
        string choice = Return.Option();
        if (choice != "w" & choice != "r" && choice != "m") ChooseClass();
        else
        {
            if (choice == "w") if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Colour.CLASS, "You have chosen ", "Warrior", ", correct?" })) ChooseClass(); else p = new Warrior();
            else if (choice == "r") if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Colour.CLASS, "You have chosen ", "Rogue", ", correct?" })) ChooseClass(); else p = new Rogue();
            else if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Colour.CLASS, "You have chosen ", "Mage", ", correct?" })) ChooseClass(); else p = new Mage();
            p.Name = Family.alive[0];
            Story();
        }
    }
    public static void Story()
    {
        Console.Clear();
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(47, 22);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");
        UIComponent.DisplayTextWait(new List<int> { 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 }, new List<string>
            {
               Colour.CLASS,"You come from a long line of ","adventurers","",
               "",
               Colour.NAME, Colour.CLASS, Colour.MONSTER, "Your ","mother",", an ","adventurer ","herself, was murdered by ","Orcs",", as they ransacked your town",
               "",
               "Many villagers died, and even more were captured. ",
               "",
               "Until they are free, your town is but a shadow of its old self",
               "",
               Colour.BOSS, "Worse yet, the ","Savage Orc ","that leads them is getting stronger and building an army",
               "",
               Colour.TIME, "In ","five days",", your town will be overrun",
               "",
               "Are you a bad enough dude to save them?",
            });
        Console.ReadKey(true);
        Utilities.ToTown();
    }
}