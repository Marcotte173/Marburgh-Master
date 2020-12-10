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
        Console.WriteLine("|                                    |                     |                             |                             |");
        Console.WriteLine("|                                    |                     |                             |                             |");
        Console.WriteLine("|                                    |                     |                             |                             |");
        Console.WriteLine("|                                    |                     |                             |                             |");
        Console.WriteLine("|                                    |                     |                             |                             |");
        Console.WriteLine("|                                    |                     |                             |                             |");      
        UIComponent.BarBlank();
        Write.Line(41,21,Color.DAMAGE + "Strength: "+Color.RESET+ Create.p.Strength.ToString());
        Write.Line(41,22,Color.HIT + "Agility: " +Color.RESET+ Create.p.Agility.ToString());
        Write.Line(41,23,Color.HEALTH + "Stamina: " +Color.RESET+ Create.p.Stamina.ToString());
        Write.Line(41,24,Color.ENERGY + "Intelligence: " + Color.RESET + Create.p.Intelilgence.ToString());
        Console.SetCursorPosition(10 - Create.p.Name.Length / 2, 16);
        Write.Line(Color.NAME, "", "Name", $": {Create.p.Name}");

        Console.SetCursorPosition(39, 16);
        Write.Line(Color.XP,"", "Level", $": {Create.p.Level}" );

        Console.SetCursorPosition(66, 16);
        if (Create.p.XP >= Create.p.XPNeeded[Create.p.Level]) Write.Line(Color.XP, "VISIT LEVEL MASTER");
        else Write.Line(Color.XP, "","Experience", $": {Create.p.XP}/{Create.p.XPNeeded[Create.p.Level]}");

        Console.SetCursorPosition(95, 16);
        Write.Line(Color.CLASS, "","Class", $": {Create.p.PClass}");

        Console.SetCursorPosition(39, 18);
        Write.Line(Color.GOLD, "","Gold", $": {Create.p.Gold}");

        Console.SetCursorPosition(66, 18);
        Write.Line(Color.GOLD, "", "Gold In Bank", $": {Bank.bankGold}");

        Console.SetCursorPosition(65, 21);
        Write.Line(Color.HEALTH, "","Health", $": {Create.p.Health}/{Create.p.MaxHealth}");
        Console.SetCursorPosition(65, 22);
        Write.Line(Color.ENERGY, "","Energy", $": {Create.p.Energy}/{Create.p.MaxEnergy}");
        Console.SetCursorPosition(65, 23);
        Write.Line(Color.ABILITY, "","Spellpower", $": {Create.p.Spellpower}");
        Console.SetCursorPosition(65, 25);
        Write.Line(Color.HEALTH, Color.HEALTH,"","Potion Size", $": {Create.p.PotionSize}/","",$"{Create.p.MaxPotionSize}");

        Console.SetCursorPosition(7, 18);
        Write.Line(Color.ITEM, "", "EQUIPMENT", "");

        Console.SetCursorPosition(2, 21);
        Console.Write(Color.ITEM+ "Main Hand" +Color.RESET+ $": {Create.p.MainHand.Name}");

        Console.SetCursorPosition(2, 23);
        Console.Write(Color.ITEM + "Off Hand" + Color.RESET + $": {Create.p.OffHand.Name}");

        Console.SetCursorPosition(2, 25);
        Console.Write(Color.ITEM + "Armor" + Color.RESET + $": {Create.p.Armour.Name}");

        Console.SetCursorPosition(99, 19);
        Write.Line(Color.DAMAGE, "","Damage", $": {Create.p.Damage}");
        Console.SetCursorPosition(99, 21);
        Write.Line(Color.HIT, "","Hit", $": {Create.p.Hit}");
        Console.SetCursorPosition(99, 22);
        Write.Line(Color.CRIT, "","Crit", $": {Create.p.Crit}");

        Console.SetCursorPosition(99, 24);
        Write.Line(Color.MITIGATION, "","Mitigation", $": {Create.p.Mitigation}");
        Console.SetCursorPosition(99, 25);
        Write.Line(Color.DEFENCE, "","Defence", $": {Create.p.Defence}");

        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 8);
        Write.Line(Color.ENERGY, "Press any key to continue");

        Console.SetCursorPosition(92, 27);
        Write.Line(Color.CRIT+ "Reputation" +Color.RESET+ ": "+Create.p.Reputation+$" ({Color.CRIT + Create.p.Rep+Color.RESET})");

        Console.SetCursorPosition(54, 27);
        Write.Line("["+ Color.RAREDROP+ "I" + Color.RESET+"]nventory");
        string choice = Return.Option();
        if (choice == "i")
        {
            Console.Clear();
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                Console.SetCursorPosition(0, (8 - Create.p.Drops.Count/2) + i);
                Write.CenterColourText(Color.dropColour[Create.p.Drops[i].rare], $"{Create.p.Drops[i].amount} ", Create.p.Drops[i].name, "");
            }            
            Write.SetY(15);
            UIComponent.BarBlank();
            UIComponent.StandardMiddle(8);
            UIComponent.BarBlank();
            if (Create.p.Drops.Count == 0) Write.Line(44, 8, "YOU HAVE NOTHING IN YOUR INVENTORY");
            Write.Position(47, 22);
            Write.Line(Color.ENERGY, "Press any key to continue");
            Console.ReadKey(true);          
        }       
    }
}