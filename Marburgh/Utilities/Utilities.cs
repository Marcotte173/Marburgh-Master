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
            Room.ActionWait(desecrateColourArray, desecrateList, Color.DEATH + "Drinking" + Color.RESET, null);
        }
    }
}