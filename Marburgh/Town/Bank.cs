﻿using System;
using System.Collections.Generic;

public class Bank
{
    internal static int bankGold;
    internal static int investment;
    internal static int term;
    public static double bankRate = 0.05;
    
    public static void Menu()
    {
        GameState.location = Location.Bank;
        Console.Clear();
        if (GameState.currentJob != null)
        {
            if (GameState.currentJob.location == JobLocation.Bank) GameState.currentJob.ButtonCheck();
            else GameState.currentJob.ButtonsOff();
        }
        Utilities.Buttons(Button.listOfBankOptions);
        UI.BankChoice(new List<int> { 0, 0, 1 }, new List<string>
        {
            $"You enter a small but busy bank. One teller appears to be free. You walk up to him",
            "",
            Color.SPEAK,"", $"'Hello, how may I be of service?'",""
        },
        Button.list1, Button.button1);
        Write.Line(104, 27, "[" + Color.BLOOD + "?" + Color.RESET + "] " + Color.BLOOD + "MORE INFO" + Color.RESET);
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
        else if (choice == "a" && Button.jobButton.active) GameState.currentJob.Issue();
        else if (choice == "1" && (Button.SortMailButton.active|| Button.InventoryButton.active|| Button.BalanceBookButton.active|| Button.PaintButton.active)) GameState.currentJob.Finish();
        else if (choice == "2" && (Button.turnInButton.active)) GameState.currentJob.Complete();
        else if (choice == "t" && Button.robberyButton.active) Robbery();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "i" && Button.investButton.active)
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
                    Button.investButton.active = false;
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

    private static void Robbery()
    {
        UI.Keypress(new List<int> { 1, 0, 1,0,1 }, new List<string>
        {
            Color.NAME,"The ","teller's"," eyes go wide",
            "",
            Color.SPEAK,"","'Guards! Guards! Help!'","",
            "",
            Color.ITEM,"3 armed guards rush in, ","weapons"," drawn"
        });
        Dungeon.Summon(new Guard(3));
        Dungeon.Summon(new Guard(3));
        Dungeon.Summon(new Guard(3));
        Combat.Menu();
        int gold= Return.RandomInt(800, 1400);
        Create.p.RepAdd(-40) ;
        Create.p.Gold += gold * (1 + Create.p.MainHand.gold);
        Button.robberyButton.active = false;
        UI.Keypress(new List<int> { 2,0,1,0,1,0,1 }, new List<string>
        {
            Color.MONSTER,Color.GOLD,"The ","guards"," lay dead and the ","money"," is there for the taking",
            "",
            Color.CLASS,"Way to go, ","hero","",
            "",
            Color.GOLD,"You receive ",gold.ToString()," gold",
            "",
            Color.HIT,"You lose ","40"," reuputation"
        });        
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
        Button.investButton.active = true;
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
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine("The" + Color.TIME + " Bank " + Color.RESET + "is where you store your " + Color.GOLD + "gold" + Color.RESET + ". ");
        Console.WriteLine("\n\n" + Color.CLASS + "DEPOSIT" + Color.RESET + "\n\nStores gold in the bank. Any gold in the bank can be accessed by any other character. \nIf you die, any gold on your person(not in the bank) will be lost!");
        Console.WriteLine("\n\n" + Color.CLASS + "WITHDRAWL" + Color.RESET + "\n\nRetrieves your gold from the bank.");
        Console.WriteLine("\n\n" + Color.GOLD + "INVESTMENT" + Color.RESET + "\n\nYou can place your gold in the bank for 5 days. You will not be able to access it until the day is over.\nEach day, your invested gold sum increases based on the daily interest rate.\nAfter 5 days, you receive your investment sum, assuming you are still alive\n\n\n\n\n\n");
        Utilities.Keypress();
    }
}