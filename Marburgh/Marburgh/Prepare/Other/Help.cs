using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Help:Location
{
    public Help()
    : base() { }
    public override void Menu()
    {
        Console.Clear();
        Console.WriteLine("HELP\n\nWelcome to Marburgh\n\nThis is a fairly straightforward dungeon crawler.");
        Write.ColourText(Colour.NAME, "\nFamily\n");
        Console.WriteLine("\nYou are part of an adventuring family. Your family consists of 3 siblings.\nYou play as each sibling until their death or until the game ends.\nMoney in the bank when a sibling dies remains in the bank for the rest of the family");
        Console.WriteLine("If all of the siblings die, the game is over.\n");
        Write.ColourText(Colour.ITEM, "WEAPONS AND ARMOR\n\n");
        Console.WriteLine("Weapons and armor can be purchased at the Item shop now, and the Weapon and Armor shops when they open");
        Console.WriteLine("With an enhancement machine, you can use monster drops to enhance your weapons.\nYou can also use it to craft powerful weapons from boss drops");
        Write.ColourText(Colour.MONSTER, "\nDUNGEON\n\n");
        Console.WriteLine("Dungeons are navigated with the N,S,E, and W keys.\nIn each room you will face choices, random events and monsters");
        Console.WriteLine("When you find monsters, you will begin combat, where you use your unique skills to defeat them\nWatch out though, they have their own unique skills as well!");
        Utilities.Keypress();
        Console.Clear();
        if (Create.p.PClass == "Warrior") Warrior();
        if (Create.p.PClass == "Mage") Mage();
        if (Create.p.PClass == "Rogue") Rogue();
        Utilities.Keypress();
        Utilities.ToTown();
    }

    private static void Mage()
    {
        Write.ColourText(Colour.CLASS, "Mage\n");
        Console.WriteLine("\nThe mage is a master of magic.\nWhile their damage and mitigation are low,Mages can hold 1 extra health potion and start with an ability");
        Write.ColourText(Colour.ABILITY, "\nFireblast");
        Write.EmbedColourText(Colour.BURNING, "\nThe mage blasts his target with a burst of fire, doing damage and causing ", "burning", "");
        Write.EmbedColourText(Colour.BURNING, "\n ", "BURNING", "\n\n");
        Console.WriteLine("When a creature burns, they take x damage over y turns, affected by spellpower.");
    }

    private static void Rogue()
    {
        Write.ColourText(Colour.CLASS, "Rogue\n");
        Console.WriteLine("\nThe rogue is a master of combat.\nRogues focus on high damage and control abilities");
        Write.ColourText(Colour.ABILITY, "\nSTUN");
        Write.EmbedColourText(Colour.STUNNED, "\n\nThe rogue smacks his target with a sneaky strike, doing damage and causing ", "stun", "");
        Write.EmbedColourText(Colour.STUNNED, "\n", "STUN", "\n");
        Console.WriteLine("When a creature is stunned, they cannot take an action.");
    }

    private static void Warrior()
    {
        Write.ColourText(Colour.CLASS, "Warrior\n");
        Console.WriteLine("\nThe mage is a master of defence.\nWarriors focus on high mitigation and damage abilities");
        Write.ColourText(Colour.ABILITY, "\nREND\n");
        Write.EmbedColourText(Colour.BLOOD, "\nThe warrior slice his target with a mighty blow, doing damage and causing ", "bleeding", "");
        Write.EmbedColourText(Colour.BLOOD, "\n", "BLEEDING\n", "");
        Console.WriteLine("When a creature bleeds, they take x damage over y turns.");
    }
}
