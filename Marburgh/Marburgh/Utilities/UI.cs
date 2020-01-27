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
        Write.Position(0, 12);
        Console.WriteLine("+-----------------------------+----------------------------------------------------------------------------------------+");
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx     xxxxxxxxxxxxx     xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx     xxxxxxxxxxxxx     xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  x   xxxxxxxxxxx   x  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  x   xxxxxxxxxxx   x  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xx   xxxxxxxxx   xx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xx   xxxxxxxxx   xx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxx   xxxxxxx   xxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxx   xxxxxxx   xxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxx   xxxxx   xxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxx   xxxxx   xxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxx   xxx   xxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxx   xxx   xxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxx   xx   xxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxx   xx   xxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxx      xxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxx      xxxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxxxx  xxxxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxxxx  xxxxxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|");
        Console.WriteLine("|" + Colour.SHIELD + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxx  xxxxxxxxxxxxxxxxxxx  xxx" + Colour.RESET + "|"); 
        Console.WriteLine("|" + Colour.SHIELD + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|                                                          |" + Colour.DAMAGE + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + Colour.RESET + "|");
        Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        UIComponent.OptionsText(options, optionButton);
        Write.Position(55,26);
        Write.EmbedColourText(Colour.DAMAGE, "[", "Q", "]uit");
        Write.Position(45, 16);
        Write.EmbedColourText(Colour.GOLD, "", "Version 0.05 January 26, 2020, 3:14 P.M.", "");
    }

    internal static void BankChoice(List<int> colourArray, List<string> descriptions, List<string> options, List<string> optionButton)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Console.SetCursorPosition(0, 15);        
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                       |                       |                       |                       |                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxx  Gold In Bank  xxxx|                                                                      |xxx   Investments   xxx|");
        Console.WriteLine("|xxxxx             xxxxx|                                                                      |xxxxx             xxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxx|                                                                      |xxxxxxxxxxxxxxxxxxxxxxx|");        
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
        Console.SetCursorPosition(12 - Bank.bankGold.ToString().Length, 22);
        Write.ColourText(Colour.GOLD, $"{Bank.bankGold}");
        Console.SetCursorPosition(108 - Bank.investment.ToString().Length, 22);
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

    public static void Store(List<int> colourArray, List<string> descriptions, List<Weapon> list, List<Weapon> list1)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        if (list1 != null)
        {
            {
                UIComponent.ShopMiddle(8);
                UIComponent.BarBlank();
                int number = 0;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].Name == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(Return.Width(16),17+ i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
                        number++;
                    }
                }
                for (int i = 1; i < list1.Count; i++)
                {
                    if (list1[i].Name == "") Console.WriteLine("");
                    {
                        Console.SetCursorPosition(Return.Width(51), 17 + i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{number + i}]{Colour.ITEM + list1[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list1[i].Price + Colour.RESET));
                    }
                }
            }
        }
        else
        {
            {
                UIComponent.StandardMiddle(8);
                UIComponent.BarBlank();
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].Name == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(Return.Width(16), 17 + i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
                    }
                }
            }
        }
    }
    public static void Store(List<int> colourArray, List<string> descriptions, List<Armor> list, List<Armor> list1)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Write.SetY(15);
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        if (list1 != null)
        {
            {
                UIComponent.ShopMiddle(8);
                UIComponent.BarBlank();
                int number = 0;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].Name == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(Return.Width(16), 17 + i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
                        number++;
                    }
                }
                for (int i = 1; i < list1.Count; i++)
                {
                    if (list1[i].Name == "") Console.WriteLine("");
                    {
                        Console.SetCursorPosition(Return.Width(51), 17 + i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{number + i}]{Colour.ITEM + list1[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list1[i].Price + Colour.RESET));
                    }
                }
            }
        }
        else
        {
            {
                UIComponent.StandardMiddle(8);
                UIComponent.BarBlank();
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].Name == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(Return.Width(16), 17 + i);
                        Console.WriteLine(string.Format("{0,-40 }{1,-15 }", $"[{i}]{Colour.ITEM + list[i].Name + Colour.RESET}", "$ " + Colour.GOLD + list[i].Price + Colour.RESET));
                    }
                }
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