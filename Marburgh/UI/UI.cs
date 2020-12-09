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
        Console.WriteLine("|" + Color.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx   xxxxxxxxxx    xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx   xxxxxxxxxx    xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx    xxxxxxxxx    xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx    xxxxxxxxx    xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  x  xxxxxxx  x  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  x  xxxxxxx  x  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xx  xxxxx  xx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xx  xxxxx  xx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxx  xxx  xxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxx  xxx  xxx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxxx  x  xxxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxxx  x  xxxx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxxxx   xxxxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxxxx   xxxxx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|");
        Console.WriteLine("|" + Color.SHIELD + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxx  xxxxxxxxxxxxx  xxxxxx" + Color.RESET + "|");        
        Console.WriteLine("|" + Color.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Color.RESET + "|                                                          |" + Color.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Color.RESET + "|");
        Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        UIComponent.OptionsText(options, optionButton,20);
        Write.Position(55,26);
        Write.Line(Color.DAMAGE, "[", "Q", "]uit");
        Write.Position(42, 14);
        Write.Line(Color.GOLD, "", "Early Access 1.15 December 08, 2020 ", "");
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
        Console.WriteLine(Color.NAME + $"{Create.p.Name}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Color.XP + $"{Create.p.Level}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("Gold:" + Color.GOLD + $"{Create.p.Gold}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Color.CLASS + "9" + Color.RESET + "]Character");
        Console.SetCursorPosition(Return.Width(88), 16);
        Console.WriteLine("[" + Color.MITIGATION + "0" + Color.RESET + "]Return");
        UIComponent.OptionsText(options, optionButton, 15);
        Console.SetCursorPosition(4, 21);
        Console.Write(Color.SPEAK + "Gold In Bank" + Color.RESET);
        Console.SetCursorPosition(10 - Bank.bankGold.ToString().Length, 22);
        Write.Line(Color.GOLD, $"{Bank.bankGold}");
        Console.SetCursorPosition(105, 21);
        Console.Write(Color.SPEAK + "Investments" + Color.RESET);
        Console.SetCursorPosition(111 - Bank.investment.ToString().Length, 22);
        Write.Line(Color.GOLD, $"{Bank.investment}");
        Console.SetCursorPosition(0, 13);
        Write.CenterColourText(Color.GOLD, "The current investment rate is ", $"{Bank.bankRate}", "%");
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
        Console.WriteLine("[" + Color.HEALTH + "Y" + Color.RESET + "]es         [" + Color.BOSS + "N" + Color.RESET + "]o");
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
        Write.Line(Color.ENERGY, "Press any key to continue");
        Console.ReadKey(true);
    }

    internal static Equipment Hand(Equipment w)
    {
        if (w.Type == "Shield") return Create.p.OffHand;
        Console.Clear();
        UIComponent.DisplayText(new List<int> { 0 }, new List<string> { "Would you like to equip this in your Main hand or your Off hand ?" });
        Console.SetCursorPosition(0, 15);
        StandardBox();
        UIComponent.OptionsText(new List<string> { "ain hand", "ff hand" }, new List<string> { Color.ITEM + "M" + Color.RESET, Color.ITEM + "O" + Color.RESET },15);
        Write.Line(35, 24,Color.ITEM, "Current: ", Create.p.MainHand.Name,"");
        Write.Line(74, 24, Color.ITEM, "Current: " , Create.p.OffHand.Name,"");
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
            Color.NAME, "What is your family " ,"name" , "?"
        });
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(55, 20);
        Console.Write(Color.NAME);
        string choice = Return.String();
        Console.Write(Color.RESET);
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
        Write.Line(Color.MONSTER, "Adventure");
        Console.SetCursorPosition(Return.Width(37), 18);
        Write.Line(Color.ITEM, "Shops");
        Console.SetCursorPosition(Return.Width(60), 18);
        Write.Line(Color.TIME, "Services");
        Console.SetCursorPosition(Return.Width(86), 18);
        Write.Line(Color.XP, "Other");
    }

    public static void Store(List<int> colourArray, List<string> descriptions, List<Equipment> list)
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
        Console.SetCursorPosition(Return.Width(16), 18);
        if (list[1].Type == "Shield" || list[1].Type == "Armor") Console.WriteLine(string.Format("{0,-24 }{1,-24 }{2,-24}{3,-10}", "Item", "Defence", "Mitigation", "Price"));
        else Console.WriteLine(string.Format("{0,-25 }{1,-10 }{2,-10 }{3,-10}{4,-15}{5,-10}", "Item","Hit", "Crit", "Damage","Spellpower", "Price"));
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Name == "") Console.WriteLine("");
            else
            {
                Console.SetCursorPosition(Return.Width(16), 18 + i);
                if (list[i].Type == "Shield" || list[1].Type == "Armor") Console.WriteLine(string.Format("{0,-45 }{1,-45 }{2,-40 }{3,-31 }", $"[{i}]{Color.ITEM + list[i].Name + Color.RESET}", Color.DEFENCE + list[i].Defence + Color.RESET, Color.MITIGATION + list[i].Mitigation + Color.RESET, "$ " + Color.GOLD + list[i].Price + Color.RESET));
                else Console.WriteLine(string.Format("{0,-44 }{1,-31 }{2,-31 }{3,-31 }{4,-30 }{5,-10 }", $"[{i}] {Color.ITEM + list[i].Name + Color.RESET}", Color.HIT + list[i].Hit + Color.RESET, Color.CRIT + list[i].Crit + Color.RESET, Color.DAMAGE + list[i].Damage + Color.RESET, Color.SPECIAL + list[i].SpellPower + Color.RESET, "$ " + Color.GOLD + list[i].Price + Color.RESET));
            }
        }
    }

    public static void StoreSell(List<int> colourArray, List<string> descriptions, List<Equipment> list)
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
        Write.Line(19, 18, "    Item");
        Write.Line(89, 18, "Resale Value");
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Name == "") Console.WriteLine("");
            else
            {
                Write.Line(19, 19 +i, $"[{i}] {Color.ITEM + list[i].Name+ Color.RESET}");
                Write.Line(89, 19 + i, Color.GOLD + (list[i].Price/2).ToString() + Color.RESET); ;
            }
        }
    }


    internal static void Choice(List<int> colourArray, List<string> descriptions, List<string> options, List<string> optionButton)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBox();
        UIComponent.OptionsText(options, optionButton,15);
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
        Console.WriteLine("[" + Color.HEALTH + "Y" + Color.RESET + "]es         [" + Color.BOSS + "N" + Color.RESET + "]o");
        return (Return.Option() == "y") ? true : false;
    }

    public static void Keypress(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBoxBlank();
        Write.Position(47, 22);
        Write.Line(Color.ENERGY, "Press any key to continue");
        Console.ReadKey(true);
    }
    public static int HowMuch(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        StandardBoxBlank();
        Write.Position(47, 22);
        Console.Write(Color.GOLD);
        int number = Return.Integer();
        Console.Write(Color.RESET);
        return number;
    }
    public static void DotDotDot(List<string> options, List<string> optionButton)
    {
        Console.Clear();
        Write.SetY(15);
        StandardBoxBlank();
        UIComponent.OptionsText(options, optionButton,15);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 8);
        Write.DotDotDot();
    }
}