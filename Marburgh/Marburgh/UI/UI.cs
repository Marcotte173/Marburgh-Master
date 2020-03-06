using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    internal static void GameMenu(List<int> colourArray, List<string> descriptions, List<string> options, List<string> optionButton)
    {
        UIComponent.DisplayText(colourArray, descriptions);
        Write.Position(0, 15);
        Console.WriteLine("+-----------------------------+----------------------------------------------------------------------------------------+");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx   xxxxxxxxxx    xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx   xxxxxxxxxx    xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx    xxxxxxxxx    xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx    xxxxxxxxx    xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  x  xxxxxxx  x  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  x  xxxxxxx  x  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xx  xxxxx  xx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xx  xxxxx  xx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxx  xxx  xxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxx  xxx  xxx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxxx  x  xxxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxxx  x  xxxx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxxxx   xxxxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxxxx   xxxxx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Colour.RESET + "|");        
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|");
        Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        UIComponent.OptionsText(options, optionButton);
        Write.Position(55,26);
        Write.EmbedColourText(Colour.DAMAGE, "[", "Q", "]uit");
        Write.Position(42, 14);
        Write.EmbedColourText(Colour.GOLD, "", "Version 0.15 March 6, 2020, 12:22 A.M.", "");
    }

    internal static void BankChoice(List<int> colourArray, List<string> descriptions, List<string> options, List<string> optionButton)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Console.SetCursorPosition(0, 15);        
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                       |                       |                       |                      |                       |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|x               x|                                                                                  |xx             xx|");
        Console.WriteLine("|xx             xx|                                                                                  |xxx           xxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");        
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.SetCursorPosition(Return.Width(10) - Create.p.Name.Length / 2, 16);
        Console.WriteLine(Colour.NAME + $"{Create.p.Name}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Colour.XP + $"{Create.p.Level}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("Gold:" + Colour.GOLD + $"{Create.p.Gold}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Colour.CLASS + "C" + Colour.RESET + "]haracter");
        Console.SetCursorPosition(Return.Width(88), 16);
        Console.WriteLine("[" + Colour.MITIGATION + "R" + Colour.RESET + "]eturn");
        UIComponent.OptionsText(options, optionButton);
        Console.SetCursorPosition(4, 21);
        Console.Write(Colour.SPEAK + "Gold In Bank" + Colour.RESET);
        Console.SetCursorPosition(10 - Bank.bankGold.ToString().Length, 22);
        Write.ColourText(Colour.GOLD, $"{Bank.bankGold}");
        Console.SetCursorPosition(105, 21);
        Console.Write(Colour.SPEAK + "Investments" + Colour.RESET);
        Console.SetCursorPosition(111 - Bank.investment.ToString().Length, 22);
        Write.ColourText(Colour.GOLD, $"{Bank.investment}");
        Console.SetCursorPosition(0, 13);
        Write.CenterColourText(Colour.GOLD, "The current investment rate is ", $"{Bank.bankRate}", "%");
        UIComponent.TimeDisplay();
    }

    internal static bool ConfirmNEW(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(50, 22);
        Console.WriteLine("[" + Colour.HEALTH + "Y" + Colour.RESET + "]es         [" + Colour.BOSS + "N" + Colour.RESET + "]o");
        return (Return.Option() == "y") ? true : false;
    }

    public static void KeypressNEW(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(47, 22);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");
        Console.ReadKey(true);
    }

    internal static Weapon Hand(Weapon w)
    {
        if (w.Type == "Shield") return Create.p.OffHand;
        Console.Clear();
        UIComponent.DisplayText(new List<int> { 0 }, new List<string> { "Would you like to equip this in your Main hand or your Off hand ?" });
        Console.SetCursorPosition(0, 15);
        StandardBox();
        UIComponent.OptionsText(new List<string> { "ain hand", "ff hand" }, new List<string> { Colour.ITEM + "M" + Colour.RESET, Colour.ITEM + "O" + Colour.RESET });
        string choice = Return.Option();
        if (choice == "m") return Create.p.MainHand;
        else if (choice == "o") return Create.p.OffHand;
        else Hand(w);
        return null;
    }

    internal static string CreationBox()
    {
        UIComponent.DisplayText(new List<int> { 0, 1 }, new List<string>
        {
            "You are the oldest child of an old adventuring family",
            Colour.NAME, "What is your family " ,"name" , "?"
        });
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(55, 20);
        Console.Write(Colour.NAME);
        string choice = Return.String();
        Console.Write(Colour.RESET);
        return choice;
    }

    public static void Town(string[] descriptions, List<string> adventure, List<string> shop, List<string> service, List<string> other, List<string> adventureButton, List<string> shopButton, List<string> serviceButton, List<string> otherButton)
    {
        Console.Clear();
        for (int i = 0; i < descriptions.Length; i++)
        {
            Console.SetCursorPosition(Return.Width(50) - (descriptions[i].Length / 2), (Return.Height(14) - descriptions.Length / 2) + i);
            Console.WriteLine(descriptions[i]);
        }
        Write.SetY(15);
        UIComponent.TopBar();
        Console.SetCursorPosition(0, 19);
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.SetCursorPosition(0, 26);
        UIComponent.BottomBar();
        for (int i = 0; i < adventure.Count; i++)
        {
            if (adventure[i] != "")
            {
                Console.SetCursorPosition(Return.Width(1), 20 + i);
                Console.WriteLine($"[{adventureButton[i]}]{adventure[i]}");
            }
        }
        for (int i = 0; i < shop.Count; i++)
        {
            if (shop[i] != "")
            {
                Console.SetCursorPosition(Return.Width(26), 20 + i);
                Console.WriteLine($"[{shopButton[i]}]{shop[i]}");
            }
        }
        for (int i = 0; i < service.Count; i++)
        {
            if (service[i] != "")
            {
                Console.SetCursorPosition(Return.Width(51), 20 + i);
                Console.WriteLine($"[{serviceButton[i]}]{service[i]}");
            }
        }
        for (int i = 0; i < other.Count; i++)
        {
            if (other[i] != "")
            {
                Console.SetCursorPosition(Return.Width(76), 20 + i);
                Console.WriteLine($"[{otherButton[i]}]{other[i]}");
            }
        }
        Console.SetCursorPosition(0, Return.Height(33));
        for (int i = 0; i < 6; i++)
        {
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(25), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(50), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(75), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
            Console.Write("|\n");
        }
        Write.SetY(18);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(25), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(50), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(75), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
        Console.Write("|\n");
        Console.SetCursorPosition(Return.Width(8), 18);
        Write.ColourText(Colour.MONSTER, "Adventure");
        Console.SetCursorPosition(Return.Width(37), 18);
        Write.ColourText(Colour.ITEM, "Shops");
        Console.SetCursorPosition(Return.Width(60), 18);
        Write.ColourText(Colour.TIME, "Services");
        Console.SetCursorPosition(Return.Width(86), 18);
        Write.ColourText(Colour.XP, "Other");
    }

    public static void Store(List<int> colourArray, List<string> descriptions, List<Weapon> list)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }        
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Return.Width(16), 19);
        Console.Write("-----------------------------------------------------------------------------------");
        Console.SetCursorPosition(Return.Width(16), 18);
        if (list[1].Type == "Shield") Console.WriteLine(string.Format("{0,-24 }{1,-24 }{2,-19}{3,-10}", "Item", "Defence", "Mitigation", "Price"));
        else Console.WriteLine(string.Format("{0,-25 }{1,-10 }{2,-10 }{3,-10}{4,-15}{5,-10}", "Item","Hit", "Crit", "Damage","Spellpower", "Price"));
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Name == "") Console.WriteLine("");
            else
            {
                Console.SetCursorPosition(Return.Width(16), 19 + i);
                if (list[i].Type == "Shield") Console.WriteLine(string.Format("{0,-45 }{1,-45 }{2,-35 }{3,-31 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", Colour.DEFENCE + list[i].Defence + Colour.RESET, Colour.MITIGATION + list[i].Mitigation + Colour.RESET, "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
                else Console.WriteLine(string.Format("{0,-44 }{1,-31 }{2,-31 }{3,-31 }{4,-30 }{5,-10 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", Colour.HIT + list[i].Hit + Colour.RESET, Colour.CRIT + list[i].Crit + Colour.RESET, Colour.DAMAGE + list[i].Damage + Colour.RESET, Colour.SPECIAL + list[i].SpellPower + Colour.RESET, "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
            }
        }
    }
    public static void Store(List<int> colourArray, List<string> descriptions, List<Armor> list)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.TopBar(); for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Return.Width(16), 19);
        Console.Write("-----------------------------------------------------------------------------------");
        Console.SetCursorPosition(Return.Width(16), 18);
        Console.WriteLine(string.Format("{0,-24 }{1,-24 }{2,-19}{3,-10}", "Item", "Defence", "Mitigation", "Price"));
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Name == "") Console.WriteLine("");
            else
            {
                Console.SetCursorPosition(Return.Width(16), 19  + i);
                Console.WriteLine(string.Format("{0,-45 }{1,-45 }{2,-35 }{3,-31 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", Colour.DEFENCE + list[i].Defence + Colour.RESET, Colour.MITIGATION + list[i].Mitigation + Colour.RESET, "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
            }
        }
    }

    internal static void Choice(List<int> colourArray, List<string> descriptions, List<string> options, List<string> optionButton)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBox();
        UIComponent.OptionsText(options, optionButton);
    }

    internal static void StandardBoxBlank()
    {
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BottomBar();
    }

    internal static void StandardBox()
    {
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        UIComponent.StandardMiddle(8);
        UIComponent.BottomBar();
    }

    internal static bool Confirm(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBoxBlank();
        Write.Position(50,22);
        Console.WriteLine("[" + Colour.HEALTH + "Y" + Colour.RESET + "]es         [" + Colour.BOSS + "N" + Colour.RESET + "]o");
        return (Return.Option() == "y") ? true : false;
    }

    public static void Keypress(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBoxBlank();
        Write.Position(47, 22);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");
        Console.ReadKey(true);
    }
    public static int HowMuch(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBoxBlank();
        Write.Position(47, 22);
        Console.Write(Colour.GOLD);
        int number = Return.Integer();
        Console.Write(Colour.RESET);
        return number;
    }
    public static void DotDotDot(List<string> options, List<string> optionButton)
    {
        Console.Clear();
        Write.SetY(15);
        StandardBoxBlank();
        UIComponent.OptionsText(options, optionButton);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 8);
        Write.DotDotDot();
    }
}