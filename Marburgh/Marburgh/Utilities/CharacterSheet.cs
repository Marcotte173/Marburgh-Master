using System;
using System.Collections.Generic;
using System.Text;

public class CharacterSheet
{
    static Player p = Create.p;
    internal static void Display()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 30);
        Console.WriteLine("+------------------------+-------------------------+-------------------------+------------------------+");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|------------------------+-------------------------+-------------------------+------------------------|");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        +-------------------------+-------------------------+                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        Console.WriteLine("|                        |                         |                         |                        |");
        UIComponent.BarBlank();
        Console.SetCursorPosition(10 - Create.p.Name.Length / 2, 31);
        Write.EmbedColourText(Colour.NAME, "Name: ", $"{p.Name}", "");

        Console.SetCursorPosition(34, 31);
        Write.EmbedColourText(Colour.XP, "Level: ", $"{p.Level}", "");

        Console.SetCursorPosition(56, 31);
        if (p.XP >= p.XPNeeded[p.Level]) Write.ColourText(Colour.XP, "VISIT LEVEL MASTER");
        else Write.EmbedColourText(Colour.XP, "Experience: ", $"{p.XP}/{p.XPNeeded[p.Level]}", "");

        Console.SetCursorPosition(83, 31);
        Write.EmbedColourText(Colour.CLASS, "Class: ", $"{p.PClass}", "");

        Console.SetCursorPosition(34, 33);
        Write.EmbedColourText(Colour.GOLD, "Gold: ", $"{p.Gold}", "");

        Console.SetCursorPosition(56, 33);
        Write.EmbedColourText(Colour.GOLD, "Gold In Bank: ", $"0", "");

        Console.SetCursorPosition(31, 37);
        Write.EmbedColourText(Colour.HEALTH, "Health: ", $"{p.Health}/{p.MaxHealth}", "");
        Console.SetCursorPosition(31, 39);
        Write.EmbedColourText(Colour.ENERGY, "Energy: ", $"{p.Energy}/{p.MaxEnergy}", "");
        Console.SetCursorPosition(31, 41);
        Write.EmbedColourText(Colour.ABILITY, "Spellpower: ", $"{p.Spellpower}", "");
        Console.SetCursorPosition(31, 43);
        Write.EmbedColourText(Colour.HEALTH, "Potion Size: ", $"{p.MaxPotionSize}", "");

        Console.SetCursorPosition(7, 34);
        Write.EmbedColourText(Colour.ITEM, "", "EQUIPMENT", "");

        Console.SetCursorPosition(2, 37);
        Console.Write("Main Hand: ");
        Write.ColourText(Colour.ITEM, p.MainHand.Name);

        Console.SetCursorPosition(2, 40);
        Console.Write("Off Hand: ");
        Write.ColourText(Colour.ITEM, p.OffHand.Name);

        Console.SetCursorPosition(2, 43);
        Console.Write("Armor: ");
        Write.ColourText(Colour.ITEM, p.Armor.Name);

        Console.SetCursorPosition(58, 37);
        Write.EmbedColourText(Colour.DAMAGE, "Damage: ", $"{p.Damage}", "");
        Console.SetCursorPosition(58, 38);
        Write.EmbedColourText(Colour.HIT, "Hit: ", $"{p.Hit}", "");
        Console.SetCursorPosition(58, 39);
        Write.EmbedColourText(Colour.CRIT, "Crit: ", $"{p.Crit}", "");

        Console.SetCursorPosition(58, 42);
        Write.EmbedColourText(Colour.MITIGATION, "Mitigation: ", $"{p.Mitigation}", "");
        Console.SetCursorPosition(58, 43);
        Write.EmbedColourText(Colour.DEFENCE, "Defence: ", $"{p.Defence}", "");

        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 8);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");

        Console.SetCursorPosition(87, 34);
        Write.EmbedColourText(Colour.RAREDROP, "", "DROPS", "");

        Console.ReadKey(true);
    }
}