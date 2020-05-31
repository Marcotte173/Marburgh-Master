using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Help
{
    public static void Menu()
    {
        GameState.location = Location.Help;
        Console.Clear();
        Write.Line(Color.BLOOD,"","MORE INFO","\n\nWelcome to Marburgh\n\nThis is a fairly straightforward dungeon crawler.");
        Write.Line(Color.NAME, "\nFamily\n");
        Console.WriteLine("\nYou are part of an adventuring family. Your family consists of 3 siblings.\nYou play as each sibling until their death or until the game ends.\nMoney in the bank when a sibling dies remains in the bank for the rest of the family");
        Console.WriteLine("If all of the siblings die, the game is over.\n");
        Write.Line(Color.ITEM, "WEAPONS AND ARMOR\n\n");
        Console.WriteLine("Weapons and armor can be purchased at the Item shop");
        Console.WriteLine("With an enhancement machine, you can use monster drops to enhance your weapons.\nYou can also use it to craft powerful weapons from boss drops");
        Write.Line(Color.MONSTER, "\nDUNGEON\n\n");
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
        Write.Line(Color.CLASS, "MAGE\n");
        Console.WriteLine("\nThe mage is a master of magic.\nWhile their damage and mitigation are low,Mages can hold 1 extra health potion and start with an ability");
        Write.Line(Color.ABILITY, "\nFireblast");
        Write.Line(Color.BURNING, "\nThe mage blasts his target with a burst of fire, doing damage and causing ", "burning", "");
        Write.Line(Color.BURNING, "\n ", "BURNING", "\n\n");
        Console.WriteLine("When a creature burns, they take x damage over y turns, affected by spellpower.");
    }

    private static void Rogue()
    {
        Write.Line(Color.CLASS, "ROGUE\n");
        Console.WriteLine("\nThe rogue is a master of combat.\nRogues focus on high damage and control abilities");
        Write.Line(Color.ABILITY, "\nSTUN");
        Write.Line(Color.STUNNED, "\n\nThe rogue smacks his target with a sneaky strike, doing damage and causing ", "stun", "");
        Write.Line(Color.STUNNED, "\n", "STUN", "\n");
        Console.WriteLine("When a creature is stunned, they cannot take an action.");
    }

    private static void Warrior()
    {
        Write.Line(Color.CLASS, "WARRIOR\n");
        Console.WriteLine("\nThe mage is a master of defence.\nWarriors focus on high mitigation and damage abilities");
        Write.Line(Color.ABILITY, "\nREND\n");
        Write.Line(Color.BLOOD, "\nThe warrior slice his target with a mighty blow, doing damage and causing ", "bleeding", "");
        Write.Line(Color.BLOOD, "\n", "BLEEDING\n", "");
        Console.WriteLine("When a creature bleeds, they take x damage over y turns.");
    }
}
