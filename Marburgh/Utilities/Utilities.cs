using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utilities
{
    internal static void ToTown()
    {
        Town.Menu();
    }

    internal static void Quit()
    {
        UI.KeypressNEW(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<string>
        {
            "Well, you tried",
            "",
            "You tried but you failed",
            "",
            "And in the end, is that not the real victory?",
            "",
            "The answer is no...",
            "",
            "Goodbye"
        });
        Environment.Exit(0);
    }

    internal static void Keypress()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    internal static void Keypress(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    public static void Heal()
    {
        if (Create.p.MaxHealth == Create.p.Health)
        {
            UI.Keypress(
            new List<int> { 1 },
            new List<string>
            {
                Color.HEALTH,"You don't need " ,"healing", "!"
            });
        }
        else
        {
            if (Create.p.PotionSize == 0)
            {
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH, "Your " ,"potion ", "is empty!"
                });
            }
            else if ((Create.p.MaxHealth - Create.p.Health) > Create.p.PotionSize)
            {
                int heal = Create.p.PotionSize;
                Create.p.AddHealth(heal);
                Create.p.PotionSize = 0;
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH,"You heal for " ,heal.ToString(), " hp!"
                });
            }
            else
            {
                int heal = Create.p.MaxHealth - Create.p.Health;
                Create.p.PotionSize -= (Create.p.MaxHealth - Create.p.Health);
                Create.p.AddHealth(heal);
                UI.Keypress(
                new List<int> { 1 },
                new List<string>
                {
                    Color.HEALTH,"You heal for " , heal.ToString() , " hp!"
                });
            }
        }
    }

    internal static void SortDamage(List<Equipment> list)
    {
        Equipment temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i].Damage > list[i + 1].Damage)
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }
    internal static void SortDefence(List<Equipment> list)
    {
        Equipment temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i].Defence > list[i + 1].Defence)
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    public static void Buttons(List<string> list, List<string> buttonString, List<Button> buttons)
    {
        list.Clear();
        buttonString.Clear();
        foreach (Button b in buttons)
        {
            if (b.active)
            {
                list.Add(b.text);
                buttonString.Add(b.button);
            }
        }
    }
    public static void Buttons(List<Button> buttons)
    {
        Button.list1.Clear();
        Button.button1.Clear();
        foreach (Button b in buttons)
        {
            if (b.active)
            {
                Button.list1.Add(b.text);
                Button.button1.Add(b.button);
            }
        }
    }

    public static void Item()
    {
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        List<Drop> items = new List<Drop> { };
        foreach (Drop d in Create.p.Drops) if (d.rare == 2) items.Add(d);
        Write.Line(50, 10, "Please select an " + Color.POTION + "Item" + Color.RESET);
        Write.Line(46, 12, "Press [0] to return to combat");
        int width = 50;
        int height = 19;
        for (int i = 0; i < items.Count; i++)
        {
            Write.Line(width, height + i, $"[{i + 1}] {Color.POTION + items[i].name + Color.RESET}");
        }
        int x = Return.Int();
        if (x > 0 && x <= items.Count)
        {
            Drop chosenItem = items[x - 1];
            Console.Clear();
            Write.SetY(15);
            UI.StandardBoxBlank();
            Write.Line(45, 21, "[" + Color.HEALTH + "Y" + Color.RESET + "]es                  [" + Color.BOSS + "N" + Color.RESET + "]o");
            UIComponent.DisplayText(new List<int> { 1 }, new List<string>
            {
            Color.POTION, "Use the ", chosenItem.name,"?"
            });
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "y") ItemUse(chosenItem);
        }
        else { }
    }

    private static void ItemUse(Drop chosenItem)
    {
        if (chosenItem.name == DropList.potionOfDeath.name)
        {
            Create.p.RemoveDrop(DropList.potionOfDeath, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You feel ");
            desecrateList.Add("Strange");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DEATH);
            desecrateList.Add("");
            desecrateList.Add("Death ");
            desecrateList.Add("radiates from you");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You are at ");
            desecrateList.Add("-10 ");
            desecrateList.Add("health!");
            Create.p.Health = -10;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if(chosenItem.name == "Potion Of Fire")
        {
            Create.p.RemoveDrop(DropList.potionOfFire, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.BURNING);
            desecrateList.Add("You are on ");
            desecrateList.Add("FIRE");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DAMAGE);
            desecrateList.Add("You lose ");
            desecrateList.Add("half ");
            desecrateList.Add("your health!");
            Create.p.Health /=2;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if (chosenItem.name == "Potion Of Learning")
        {
            Create.p.RemoveDrop(DropList.potionOfLearning, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.ENERGY);
            desecrateList.Add("You feel ");
            desecrateList.Add("smarter");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.ENERGY);
            desecrateList.Add("You gain ");
            desecrateList.Add("1 ");
            desecrateList.Add("Intelligence until you sleep");
            Create.p.tempIntelligence += 1;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if (chosenItem.name == "Potion Of Life")
        {
            Create.p.RemoveDrop(DropList.potionOfLife, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You feel ");
            desecrateList.Add("tougher");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You gain ");
            desecrateList.Add("1 ");
            desecrateList.Add("Stamina until you sleep");
            Create.p.tempStamina += 1;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if (chosenItem.name == "Potion Of Power")
        {
            Create.p.RemoveDrop(DropList.potionOfPower, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DAMAGE);
            desecrateList.Add("You feel ");
            desecrateList.Add("stronger");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DAMAGE);
            desecrateList.Add("You gain ");
            desecrateList.Add("1 ");
            desecrateList.Add("Strength until you sleep");
            Create.p.tempStrength += 1;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if (chosenItem.name == "Potion Of Prowess")
        {
            Create.p.RemoveDrop(DropList.potionOfProwess, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.CRIT);
            desecrateList.Add("You feel more");
            desecrateList.Add("agile");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.ENERGY);
            desecrateList.Add("You gain ");
            desecrateList.Add("1 ");
            desecrateList.Add("Agility until you sleep");
            Create.p.tempAgility += 1;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
        else if (chosenItem.name == "Potion Of Knowledge")
        {
            Create.p.RemoveDrop(DropList.potionOfKnowledge, 1);
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.XP);
            desecrateList.Add("You feel ");
            desecrateList.Add("wiser");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.XP);
            desecrateList.Add("You gain ");
            desecrateList.Add("+25% ");
            desecrateList.Add("experience until you sleep");
            Create.p.tempXp += .25f;
            Room.ActionWait(desecrateColourArray, desecrateList, Color.POTION + "Drinking" + Color.RESET, null);
        }
    }
}