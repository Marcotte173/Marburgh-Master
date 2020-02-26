using System;
using System.Collections.Generic;
using System.Text;

public class CharacterSheet
{
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
        Write.EmbedColourText(Colour.NAME, "Name: ", $"{Create.p.Name}", "");

        Console.SetCursorPosition(39, 16);
        Write.EmbedColourText(Colour.XP, "Level: ", $"{Create.p.Level}", "");

        Console.SetCursorPosition(66, 16);
        if (Create.p.XP >= Create.p.XPNeeded[Create.p.Level]) Write.ColourText(Colour.XP, "VISIT LEVEL MASTER");
        else Write.EmbedColourText(Colour.XP, "Experience: ", $"{Create.p.XP}/{Create.p.XPNeeded[Create.p.Level]}", "");

        Console.SetCursorPosition(95, 16);
        Write.EmbedColourText(Colour.CLASS, "Class: ", $"{Create.p.PClass}", "");

        Console.SetCursorPosition(39, 18);
        Write.EmbedColourText(Colour.GOLD, "Gold: ", $"{Create.p.Gold}", "");

        Console.SetCursorPosition(66, 18);
        Write.EmbedColourText(Colour.GOLD, "Gold In Bank: ", $"0", "");

        Console.SetCursorPosition(36, 20);
        Write.EmbedColourText(Colour.HEALTH, "Health: ", $"{Create.p.Health}/{Create.p.MaxHealth}", "");
        Console.SetCursorPosition(36, 21);
        Write.EmbedColourText(Colour.ENERGY, "Energy: ", $"{Create.p.Energy}/{Create.p.MaxEnergy}", "");
        Console.SetCursorPosition(36, 22);
        Write.EmbedColourText(Colour.ABILITY, "Spellpower: ", $"{Create.p.Spellpower}", "");
        Console.SetCursorPosition(36, 24);
        Write.EmbedColourText(Colour.HEALTH, Colour.HEALTH,"Potion Size: ", $"{Create.p.PotionSize}","/",$"{Create.p.MaxPotionSize}", "");

        Console.SetCursorPosition(7, 18);
        Write.EmbedColourText(Colour.ITEM, "", "EQUIPMENT", "");

        Console.SetCursorPosition(2, 20);
        Console.Write("Main Hand: ");
        Write.ColourText(Colour.ITEM, Create.p.MainHand.Name);

        Console.SetCursorPosition(2, 22);
        Console.Write("Off Hand: ");
        Write.ColourText(Colour.ITEM, Create.p.OffHand.Name);

        Console.SetCursorPosition(2, 24);
        Console.Write("Armor: ");
        Write.ColourText(Colour.ITEM, Create.p.Armor.Name);

        Console.SetCursorPosition(65, 20);
        Write.EmbedColourText(Colour.DAMAGE, "Damage: ", $"{Create.p.Damage}", "");
        Console.SetCursorPosition(65, 21);
        Write.EmbedColourText(Colour.HIT, "Hit: ", $"{Create.p.Hit}", "");
        Console.SetCursorPosition(65, 22);
        Write.EmbedColourText(Colour.CRIT, "Crit: ", $"{Create.p.Crit}", "");

        Console.SetCursorPosition(65, 24);
        Write.EmbedColourText(Colour.MITIGATION, "Mitigation: ", $"{Create.p.Mitigation}", "");
        Console.SetCursorPosition(65, 25);
        Write.EmbedColourText(Colour.DEFENCE, "Defence: ", $"{Create.p.Defence}", "");

        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 8);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");

        Console.SetCursorPosition(99, 18);
        Write.EmbedColourText(Colour.RAREDROP, "", "DROPS", "");
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            Console.SetCursorPosition(99, 20+i);
            Write.EmbedColourText(Colour.dropColour[Create.p.Drops[i].rare], $"{Create.p.Drops[i].amount} ", Create.p.Drops[i].name, "");
        }

        Console.ReadKey(true);
    }
}