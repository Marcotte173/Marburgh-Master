using System;
using System.Collections.Generic;

public class Bank
{
    internal static int bankGold;
    internal static int investment;
    internal static int term;
    public static double bankRate = 0.05;
    public static List<string> bankButton = new List<string> { Color.GOLD + "D" + Color.RESET, Color.GOLD + "W" + Color.RESET, Color.GOLD + "I" + Color.RESET };
    public static List<string> bankText = new List<string> { "eposit", "ithdraw", "nvest" };
    public static void Menu()
    {
        GameState.location = Location.Bank;
        Console.Clear();
        UI.BankChoice(new List<int> { 0, 0, 1 }, new List<string>
            {
                $"You enter a small but busy bank. One teller appears to be free. You walk up to him",
                "",
                Color.SPEAK,"", $"'Hello, how may I be of service?'",""
            },
            bankText, bankButton);
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "d")
        {
            if (Return.HaveGold(1))
            {
                int deposit = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Color.SPEAK, " ", "'Excellent! How much would you like to deposit?'", "",
                    "",
                    "[0] Return"
                });
                if (deposit == 0) Menu();
                else if (Return.HaveGold(deposit))
                {
                    Create.p.Gold -= deposit;
                    bankGold += deposit;
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.GOLD,"You deposit ", $"{deposit} ","gold."
                    });
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.SPEAK,"", "'You don't have enough money!'",""
                    });
            }
            else UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.SPEAK,"", "'You don't have any money!'",""
                });
        }
        else if (choice == "?") Info();
        else if (choice == "w")
        {
            if (bankGold > 0)
            {
                int withdraw = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Color.SPEAK, " ", "'Excellent! How much would you like to withdraw?'", "",
                    "",
                    "[0] Return"
                });
                if (withdraw == 0) Menu();
                else if (bankGold >= withdraw)
                {
                    Create.p.Gold += withdraw;
                    bankGold -= withdraw;
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.GOLD,"You withdraw ", $"{withdraw} ","gold."
                    });
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.SPEAK,"", "'You don't have enough money in the bank!'",""
                    });
            }
            else UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.SPEAK,"", "'You don't have any money in the bank!'",""
                });
        }
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "i" && investment < 1)
        {
            if (Return.HaveGold(1))
            {
                int invest = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Color.SPEAK, " ", "'Excellent! How much would you like to invest?'", "",
                    "",
                    "[0] Return"
                });
                if (invest == 0) Menu();
                else if (Create.p.Gold >= invest)
                {
                    investment = invest;
                    Create.p.Gold -= invest;
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.GOLD,"You invest ", $"{invest} ","gold."
                    });
                    term = 3;
                    bankButton.RemoveAt(2);
                    bankText.RemoveAt(2);
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Color.SPEAK,"", "'You don't have enough money!'",""
                    });
            }
            else
                UI.Keypress(new List<int> { 1 }, new List<string>
                        {
                            Color.SPEAK,"", "'You don't have any money!'",""
                        });
        }
        else if (choice == "0") Utilities.ToTown();
        Menu();
    }    

    public static void InvestPay()
    {
        UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
        {
            "Your investments have paid off!",
            "",
            Color.SPEAK,"You receive ", $"{investment}", " gold"
        });
        Create.p.Gold += investment;
        investment = 0;
        bankButton.Add(Color.GOLD + "I" + Color.RESET);
        bankText.Add("nvest");
    }

    internal static void InvestmentCalculate()
    {
        double dblInvest = Convert.ToDouble(investment);
        investment += Convert.ToInt32(dblInvest *= bankRate);
    }

    internal static double RateCalculate()
    {
        if (Return.RandomInt(0,2) == 0) return bankRate += (Return.RandomInt(0, 99) / 10000);
        else return bankRate -= (Return.RandomInt(0, 99) / 10000);
    }
    static void Info()
    {
        Console.Clear();
        Console.WriteLine("\n" + Color.ITEM + "Items" + Color.RESET + " are a very important part of " + Color.ENERGY + "Marburgh" + Color.RESET + "\n\nThe right " + Color.ITEM + "equipment" + Color.RESET + " can mean the difference between sucess and " + Color.DAMAGE + "death" + Color.RESET + ".");
        Console.WriteLine("\n\n" + Color.CLASS + "CHARACTER SCREEN" + Color.RESET + "\n\nPress [" + Color.CLASS + "9" + Color.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Color.GOLD + "BUYING" + Color.RESET + "\n\n" + Color.ITEM + "Items" + Color.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Color.ITEM + "B" + Color.RESET + "]uy, then the " + Color.ITEM + "item" + Color.RESET + " you would like to purchase.\nIf you have the required " + Color.GOLD + "gold" + Color.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Color.GOLD + "SELLING" + Color.RESET + "\n\nWhen you sell an " + Color.ITEM + "item" + Color.RESET + ", you will receive half of the item's " + Color.GOLD + "value" + Color.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Color.ITEM + "item" + Color.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}