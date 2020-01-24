using System;
using System.Collections.Generic;
using System.Text;

public class CharacterSheet
{
    static Player p = Create.p;
    internal static void Display()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 15);
        Console.WriteLine("+----------------------------+-----------------------------+-----------------------------+-----------------------------+");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|----------------------------+-----------------------------+-----------------------------+-----------------------------|");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            +-----------------------------+-----------------------------+                             |");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            |                             |                             |                             |");
        Console.WriteLine("|                            |                             |                             |                             |");      
        UIComponent.BarBlank();
        Console.SetCursorPosition(10 - Create.p.Name.Length / 2, 16);
        Write.EmbedColourText(Colour.NAME, "Name: ", $"{p.Name}", "");

        Console.SetCursorPosition(39, 16);
        Write.EmbedColourText(Colour.XP, "Level: ", $"{p.Level}", "");

        Console.SetCursorPosition(66, 16);
        if (p.XP >= p.XPNeeded[p.Level]) Write.ColourText(Colour.XP, "VISIT LEVEL MASTER");
        else Write.EmbedColourText(Colour.XP, "Experience: ", $"{p.XP}/{p.XPNeeded[p.Level]}", "");

        Console.SetCursorPosition(95, 16);
        Write.EmbedColourText(Colour.CLASS, "Class: ", $"{p.PClass}", "");

        Console.SetCursorPosition(39, 18);
        Write.EmbedColourText(Colour.GOLD, "Gold: ", $"{p.Gold}", "");

        Console.SetCursorPosition(66, 18);
        Write.EmbedColourText(Colour.GOLD, "Gold In Bank: ", $"0", "");

        Console.SetCursorPosition(36, 20);
        Write.EmbedColourText(Colour.HEALTH, "Health: ", $"{p.Health}/{p.MaxHealth}", "");
        Console.SetCursorPosition(36, 21);
        Write.EmbedColourText(Colour.ENERGY, "Energy: ", $"{p.Energy}/{p.MaxEnergy}", "");
        Console.SetCursorPosition(36, 22);
        Write.EmbedColourText(Colour.ABILITY, "Spellpower: ", $"{p.Spellpower}", "");
        Console.SetCursorPosition(36, 24);
        Write.EmbedColourText(Colour.HEALTH, "Potion Size: ", $"{p.MaxPotionSize}", "");

        Console.SetCursorPosition(7, 18);
        Write.EmbedColourText(Colour.ITEM, "", "EQUIPMENT", "");

        Console.SetCursorPosition(2, 20);
        Console.Write("Main Hand: ");
        Write.ColourText(Colour.ITEM, p.MainHand.Name);

        Console.SetCursorPosition(2, 22);
        Console.Write("Off Hand: ");
        Write.ColourText(Colour.ITEM, p.OffHand.Name);

        Console.SetCursorPosition(2, 24);
        Console.Write("Armor: ");
        Write.ColourText(Colour.ITEM, p.Armor.Name);

        Console.SetCursorPosition(65, 20);
        Write.EmbedColourText(Colour.DAMAGE, "Damage: ", $"{p.Damage}", "");
        Console.SetCursorPosition(65, 21);
        Write.EmbedColourText(Colour.HIT, "Hit: ", $"{p.Hit}", "");
        Console.SetCursorPosition(65, 22);
        Write.EmbedColourText(Colour.CRIT, "Crit: ", $"{p.Crit}", "");

        Console.SetCursorPosition(65, 24);
        Write.EmbedColourText(Colour.MITIGATION, "Mitigation: ", $"{p.Mitigation}", "");
        Console.SetCursorPosition(65, 25);
        Write.EmbedColourText(Colour.DEFENCE, "Defence: ", $"{p.Defence}", "");

        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 8);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");

        Console.SetCursorPosition(99, 18);
        Write.EmbedColourText(Colour.RAREDROP, "", "DROPS", "");

        Console.ReadKey(true);
    }
}