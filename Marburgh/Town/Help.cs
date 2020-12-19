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
        //Page One
        Console.Clear();
        Write.Line(Color.BLOOD,"","MORE INFO","\n\nWelcome to Marburgh\n\nThis is a fairly straightforward dungeon crawler.");
        Write.Line(Color.NAME, "\nFamily\n");
        Console.WriteLine("\nYou are part of an adventuring family. Your family consists of 3 siblings.\nYou play as each sibling until their death or until the game ends.\nMoney in the bank when a sibling dies remains in the bank for the rest of the family");
        Console.WriteLine("If all of the siblings die, the game is over.\n");
        Write.Line(Color.ITEM, "Weapons and armor\n\n");
        Console.WriteLine("Weapons and armor can be purchased at the Item shop");
        Console.WriteLine("With an enhancement machine, you can use monster drops to enhance your weapons.\nYou can also use it to craft powerful weapons from boss drops");
        Write.Line(Color.MONSTER, "\nExploring\n\n");
        Console.WriteLine("Exploring is navigated with the N,S,E, and W keys.\nAt each point you will face choices, random events and monsters");
        Console.WriteLine("When you find monsters, you will begin combat, where you use your unique skills to defeat them\nWatch out though, they have their own unique skills as well!");
        Utilities.Keypress(0,28);
        //Page Two
        Console.Clear();
        Write.Line(Color.TIME, "Your House\n\n");
        Write.Line("Your house serves as your base of operations. \nYou can sleep to regain health, energy, potions and the ability to explore.\nSleeping causes time to move forward by one day\n\n");
        Write.Line(Color.GOLD, "The Bank\n\n");
        Write.Line("You can use the bank to store money and make investments. \nAll siblings share one bank account \nIf a family member dies, the siblings can access their money and investments\n\n");
        Write.Line(Color.XP, "Level Master\n\n");
        Write.Line("When you have enough experience, you can visit your level master.\nLeveling up with increase your combat stats, and occasionally give you access to new abilities\n\n");
        Write.Line(Color.DEFENCE, "Other Places\n\n");
        Write.Line("As marburgh continues to grow, there will be more place to visit.\nFor now, you can visit your family's grave.");
        Utilities.Keypress(0,28);
        //Page Three
        Console.Clear();
        Write.Line(Color.BURNING, "Stats\n\n");
        Write.Line(Color.DAMAGE, "STRENGTH\n\n");
        Write.Line("Strength determines your damage in combat. It also determines your success in some events\n\n");
        Write.Line(Color.CRIT, "AGILITY\n\n");
        Write.Line("Agility affects your ability to hit and avoid being hit, as well as your ability to critically strike. \nIf you are a rogue, agility also impact your damage. \nAgility can be used to determine the success of some events\n\n");
        Write.Line(Color.XP, "Stamina\n\n");
        Write.Line("Stamina affects your ability to take damage in combat as well as your success in some events\n\n");
        Write.Line(Color.ENERGY, "Intelligence\n\n");
        Write.Line("Intelligence affects your ability to cast spells, the damage from the spells and your success in some events");
        Utilities.Keypress(0, 28);
        Console.Clear();
        if (Create.p.PClass == PlayerClass.Warrior) Warrior();
        if (Create.p.PClass == PlayerClass.Mage) Mage();
        if (Create.p.PClass == PlayerClass.Rogue) Rogue();
        Utilities.Keypress(0, 28);
        Utilities.ToTown();
    }

    public static void Mage()
    {
        Write.Line(Color.CLASS, "MAGE\n");
        Console.WriteLine("\nThe Mage is a master of magic.\nWhile their damage and mitigation are low, a mage defends themselves with arcane forces. \nAs well, a Mage's potion is 5 hp larger");
        Write.Line(Color.DAMAGE, "\n\nATTACK");
        Write.Line("\n\nThis is the " + Color.CLASS + "Mage's" + Color.RESET + " most basic move. \nThe " + Color.CLASS + "Mage" + Color.RESET + " will do damage equal to the sum of: \n\n[1] The " + Color.CLASS + "Mage's " + Color.DAMAGE + "personal" + Color.RESET + " damage\n[2] The damage from the " + Color.CLASS + "Mage's" + Color.RESET + " main " + Color.ITEM + "weapon" + Color.RESET + "  \n[3] "+Color.DAMAGE + "2 /3"+ Color.RESET +" of the " + "damage of the " + Color.ITEM + "weapon" + Color.RESET + " in the " + Color.CLASS + "Mage's " + Color.RESET + "off hand, if any\n[4] Any other damage " + Color.DAMAGE + "buffs" + Color.RESET + " the " + Color.CLASS + "Mage " + Color.RESET + "may currently possess");
        Write.Line(Color.SHIELD, "\n\nSHIELD");
        Write.Line("\n\nPressing the " + Color.SHIELD + "[2]Shield" + Color.RESET + " button in combat will toggle the " + Color.CLASS + "Mage's " + Color.SHIELD + "Shield" + Color.RESET + " \nThere will be a " + Color.SHIELD + "'SHIELDED'" + Color.RESET + " indicator in the bottom left when the shield is on");
        Write.Line("While the " + Color.SHIELD + "shield" + Color.RESET + " is toggled on, The " + Color.CLASS + "Mage" + Color.RESET + " will lose " + Color.ENERGY + "energy" + Color.RESET + " INSTEAD of " + Color.HEALTH + "hitpoints" + Color.RESET + " from damage\nThe" + Color.CLASS + " Mage " + Color.RESET + "will lose" + Color.ENERGY + " 1" + Color.RESET + " energy for every" + Color.DAMAGE + " 2" + Color.RESET + " Damage dealt");
        Write.Line(Color.SHIELD+ "ADDITIONALLY, ANY " + Color.ABILITY + "TECHNIQUE" + Color.SHIELD + " USED BY AN OPPONNENT WILL NOT WORK");
        Write.Line("This is " + Color.HEALTH + "VITAL" + Color.RESET + " when the enemy is using its special " + Color.ABILITY + "technique" + Color.RESET + ". \nEven low level " + Color.ABILITY + "Techniques" + Color.RESET + " can do " + Color.DAMAGE + "serious damage" + Color.RESET + ", \n" + Color.DEFENCE + "AVOID THEM WHEN POSSIBLE");
        Write.Line(94, 28, Color.TIME, "Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
        Write.Line(Color.CLASS, "MAGE ABILITIES\n\n");
        Write.Line(Color.ABILITY, "1 - Fireblast - Level 2\n");
        Write.Line(Color.BURNING, "- The " + Color.CLASS + "Mage" + Color.RESET + " blasts his target with a burst of " + Color.BURNING + "fire" + Color.RESET + ", doing damage and causing ", "burning", "");
        Write.Line(Color.ABILITY,"\n2 - Magic Missile - Level 4\n");
        Console.WriteLine("- 3 bolts of pure " + Color.ENERGY + "Magic " + Color.RESET + "burst from the " + Color.CLASS + "Mage's" + Color.RESET + " hands.");
        Console.WriteLine("  Each " + Color.ENERGY + "bolt " + Color.RESET + "hits an enemy doing " + Color.DAMAGE + "1/3 (Spellpower plus Player Level)" + Color.RESET + " damage");
        Write.Line(Color.BURNING, "\n\n", "BURNING", "\n");
        Console.WriteLine("When a creature burns, they take " + Color.BURNING + "3 " + Color.RESET + "damage over 2 turns, incremented by spellpower.");
        
    }

    public static void Rogue()
    {
        Write.Line(Color.CLASS, "ROGUE\n");
        Console.WriteLine("\nThe " + Color.CLASS + "Rogue " + Color.RESET + "is a master of combat.\nRogues focus on high " + Color.DAMAGE + "damage " + Color.RESET + "and " + Color.STUNNED + "control " + Color.RESET + "abilities");
        Write.Line(Color.DAMAGE, "\n\nATTACK");
        Write.Line("\n\nThis is the " + Color.CLASS + "Rogue's" + Color.RESET + " most basic move. \nThe " + Color.CLASS + "Rogue" + Color.RESET + " will do damage equal to the sum of: \n\n[1] The " + Color.CLASS + "Rogue's " + Color.DAMAGE + "personal " + Color.RESET + " damage\n[2] The damage from each " + Color.ITEM + "weapon" + Color.RESET + " \n[3] Any other damage " + Color.DAMAGE + "buffs" + Color.RESET + " the " + Color.CLASS + "Rogue" + Color.RESET + " may currently possess");
        Write.Line(Color.DEFENCE, "\n\nDEFEND");
        Write.Line(Color.STUNNED, "\n\nThe " + Color.CLASS + "Rougue's " + Color.RESET + "", "defend ", "ability does ZERO damage, but it increases the " + Color.CLASS + "Rogue's" + Color.MITIGATION + " Mitigation" + Color.RESET + " and " + Color.DEFENCE + "Defence.");
        Write.Line("This is " + Color.HEALTH + "VITAL" + Color.RESET + " when the enemy is using its special " + Color.ABILITY + "technique" + Color.RESET + ". \nEven low level " + Color.ABILITY + "Techniques" + Color.RESET + " can do " + Color.DAMAGE + "serious damage" + Color.RESET + ", \n" + Color.DEFENCE + "AVOID THEM WHEN POSSIBLE\n\n");
        Write.Line(94, 28, Color.TIME, "Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
        Write.Line(Color.CLASS, "ROGUE ABILITIES\n\n");
        Write.Line(Color.ABILITY, "1 - Backstab - Level 2");
        Console.WriteLine("\n- The " + Color.CLASS + "Rogue" + Color.RESET + " sneaks behind the " + Color.MONSTER + "target" + Color.RESET + " and delivers a " + Color.DAMAGE + "crushing blow" + Color.RESET + ", dealing " + Color.DAMAGE + "double damage" + Color.RESET);
        Write.Line(Color.ABILITY, "\n2 - STUN - Level 4");
        Write.Line("\n- The " + Color.CLASS + "Rogue " + Color.RESET + "smacks his target with a sneaky strike, " + Color.DAMAGE + "damaging" + Color.RESET + " them and causing " + Color.STUNNED + "stun", "");
        Write.Line(Color.STUNNED, "\n\n\n", "Stunned", "\n");
        Console.WriteLine("When a creature is " + Color.STUNNED + "stunned" + Color.RESET + ", they cannot take an action.");
    }

    public static void Warrior()
    {
        Write.Line(Color.CLASS, "WARRIOR\n");
        Console.WriteLine("\nThe Warrior is a master of defence.\nWarriors focus on high mitigation and damage abilities");
        Write.Line(Color.DAMAGE, "\n\nATTACK");
        Write.Line("\n\nThis is the " + Color.CLASS + "Warrior's" + Color.RESET + " most basic move. \nThe " + Color.CLASS + "Warrior" + Color.RESET + " will do damage equal to the sum of: \n\n[1] The " + Color.CLASS + "Warrior's " + Color.DAMAGE + "personal" + Color.RESET + " damage\n[2] The damage from the " + Color.CLASS + "Warrior's" + Color.RESET + " main " + Color.ITEM + "weapon" + Color.RESET + "  \n[3] " + Color.DAMAGE + "2 /3" + Color.RESET + " of the " + "damage of the " + Color.ITEM + "weapon" + Color.RESET + " in the " + Color.CLASS + "Warrior's " + Color.RESET + "off hand, if any\n[4] Any other damage " + Color.DAMAGE + "buffs" + Color.RESET + " the " + Color.CLASS + "Warrior " + Color.RESET + "may currently possess");
        Write.Line(Color.DEFENCE, "\n\nDEFEND");
        Write.Line(Color.STUNNED, "\n\nThe " + Color.CLASS + "Warrior's " + Color.RESET + "", "defend ", "ability does ZERO damage, but it increases the " + Color.CLASS + "Warrior's" + Color.MITIGATION + " Mitigation" + Color.RESET + " and " + Color.DEFENCE + "Defence.");
        Write.Line("This is " + Color.HEALTH + "VITAL" + Color.RESET + " when the enemy is using its special " + Color.ABILITY + "technique" + Color.RESET + ". \nEven low level " + Color.ABILITY + "Techniques" + Color.RESET + " can do " + Color.DAMAGE + "serious damage" + Color.RESET + ", \n" + Color.DEFENCE + "AVOID THEM WHEN POSSIBLE\n\n");
        Write.Line(94, 28, Color.TIME, "Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
        Write.Line(Color.CLASS, "WARRIOR ABILITIES\n\n");
        Write.Line(Color.ABILITY, "-1 - Rend - Level 2\n");
        Write.Line(Color.BLOOD, "- The warrior slices his target with a mighty blow, doing damage and causing ", "bleeding", "");
        Write.Line(Color.ABILITY, "\n2 - Cleave - Level 4\n");
        Write.Line("- The warrior smashes his" + Color.MONSTER + " target" + Color.RESET + " so hard he also hits an additional " + Color.MONSTER + "target." + Color.RESET );
        Write.Line(Color.BLOOD, "\n\n", "BLEEDING\n", "");
        Console.WriteLine("When a creature bleeds, they take " + Color.DAMAGE + "3 " + Color.RESET + "damage over 2 turns.");
    }
}
