using System;
using System.Collections.Generic;

public class Bank:Location
{
    public Bank()
    : base() { }
    internal static int bankGold;
    internal static int investment;
    internal static int term;
    public static double bankRate = 0.05;
    public static List<string> bankButton = new List<string> { Colour.GOLD + "D" + Colour.RESET, Colour.GOLD + "W" + Colour.RESET, Colour.GOLD + "I" + Colour.RESET };
    public static List<string> bankText = new List<string> { "eposit", "ithdraw", "nvest" };
    public override void Menu()
    {

        Console.Clear();
        UI.BankChoice(new List<int> { 0, 0, 1 }, new List<string>
            {
                $"You enter a small but busy bank. One teller appears to be free. You walk up to him",
                "",
                Colour.SPEAK,"", $"'Hello, how may I be of service?'",""
            },
            bankText, bankButton);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "d")
        {
            if (Return.HaveGold(1))
            {
                int deposit = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Colour.SPEAK, " ", "'Excellent! How much would you like to deposit?'", "",
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
                        Colour.GOLD,"You deposit ", $"{deposit} ","gold."
                    });
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Colour.SPEAK,"", "'You don't have enough money!'",""
                    });
            }
            else UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Colour.SPEAK,"", "'You don't have any money!'",""
                });
        }
        else if (choice == "w")
        {
            if (bankGold > 0)
            {
                int withdraw = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Colour.SPEAK, " ", "'Excellent! How much would you like to withdraw?'", "",
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
                        Colour.GOLD,"You withdraw ", $"{withdraw} ","gold."
                    });
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Colour.SPEAK,"", "'You don't have enough money in the bank!'",""
                    });
            }
            else UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Colour.SPEAK,"", "'You don't have any money in the bank!'",""
                });
        }
        else if (choice == "c") CharacterSheet.Display();
        else if (choice == "i" && investment < 1)
        {
            if (Return.HaveGold(1))
            {
                int invest = UI.HowMuch(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Colour.SPEAK, " ", "'Excellent! How much would you like to invest?'", "",
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
                        Colour.GOLD,"You invest ", $"{invest} ","gold."
                    });
                    term = 3;
                    bankButton.RemoveAt(2);
                    bankText.RemoveAt(2);
                }
                else
                    UI.Keypress(new List<int> { 1 }, new List<string>
                    {
                        Colour.SPEAK,"", "'You don't have enough money!'",""
                    });
            }
            else
                UI.Keypress(new List<int> { 1 }, new List<string>
                        {
                            Colour.SPEAK,"", "'You don't have any money!'",""
                        });
        }
        else if (choice == "r") Utilities.ToTown();
        Menu();
    }    

    public static void InvestPay()
    {
        UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
        {
            "Your investments have paid off!",
            "",
            Colour.SPEAK,"You receive ", $"{investment}", " gold"
        });
        Create.p.Gold += investment;
        investment = 0;
        bankButton.Add(Colour.GOLD + "I" + Colour.RESET);
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
}