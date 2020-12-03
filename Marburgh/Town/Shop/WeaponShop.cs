using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WeaponShop : Shop
{
    static List<Weapon> bluntList = new List<Weapon>   { Blunt.list[0],  Blunt.list[1],  };
    static List<Weapon> swordList = new List<Weapon>   { Sword.list[0],  Sword.list[1],  };
    static List<Weapon> daggerList = new List<Weapon> { Dagger.list[0], Dagger.list[1],  };
    static List<Weapon> shieldList = new List<Weapon> { Shield.list[0], Shield.list[1],  };
    public WeaponShop()
    : base() { }

    public override void Menu()
    {
        Console.Clear();
        UI.Choice(new List<int> { 0, 2, 0, 1 }, new List<string>
        {
            $"You walk into Oscar's Weapon Shop",
            Colour.NAME, Colour.CLASS, $"", $"Oscar ", "the ", $"halfing", " comes over to greet you",
            "",
            Colour.SPEAK,"", $"'Greetings, what can I do for you?'",""
        },
        new List<string> { "uy", "ell" }, new List<string> { Colour.ITEM + "B" + Colour.RESET, Colour.ITEM + "S" + Colour.RESET });
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Colour.BLOOD + "MORE INFO" + Colour.RESET);
        string choice = Return.Option();
        if (choice == "b")
        {
            UI.Choice(new List<int> { 0, 2, 0, 1 }, new List<string>
            {
                $"And what can I interest you in?",
            },
            new List<string> { "Swords", "Daggers","Hammers", "Shields" }, new List<string> { Colour.ITEM + "1" + Colour.RESET, Colour.ITEM + "2" + Colour.RESET, Colour.ITEM + "3" + Colour.RESET, Colour.ITEM + "4" + Colour.RESET });
            string choice2 = Return.Option();
            if (choice2 == "1") Buy(swordList,  "Oscar");
            else if (choice2 == "2") Buy(daggerList, "Oscar");
            else if (choice2 == "3") Buy(bluntList, "Oscar");
            else if (choice2 == "4") Buy(shieldList, "Oscar");
            else Menu();
        }
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "s") Sell("Oscar");
        else if (choice == "?") Info();
        Menu();
    }

    public override void Info()
    {
        base.Info();
    }

    public void Buy(List<Weapon> list, string name)
    {
        UI.Store(new List<int> { 0, 0, 0 }, new List<string>
        {
            "Great! What would you like to buy?",
            "",
            "[0] Return"
        },
        list);
        int choice = Return.Int();
        if (choice > 0 && choice < list.Count )
        {
            if (Create.p.Gold < list[choice].Price)
            {
                UI.Keypress(new List<int> { 0 }, new List<string>
                    {
                        "You don't have enough gold!",
                    });
            }
            else
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Colour.ITEM, "Would you like to buy the ", $"{list[choice].Name}", "?" }))
                {

                    if (Create.p.MainHand.Name != "None") SellOld(list, choice, name, UI.Hand(list[choice]));
                    else
                    {
                        Create.p.Gold -= list[choice].Price;
                        Console.Clear();
                        UI.Keypress(new List<int> { 2 }, new List<string>
                        {
                            Colour.NAME, Colour.ITEM,"Smiling, ",$"{name} ","takes your money and gives you your ",$"{list[choice].Name}","",
                        });
                        Create.p.Equip(list[choice], UI.Hand(list[choice]));
                    }
                }
            }
        }
        Menu();
    }

    public void Sell(string name)
    {
        if (Create.p.MainHand.Name == "None" && Create.p.OffHand.Name == "None")
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have nothing to sell!",
            });
        }
        else
        {
            Console.Clear();
            List<Weapon> EquipmentList = new List<Weapon> { new Blunt(0) };
            if (Create.p.MainHand.Name != "None") { EquipmentList.Add(Create.p.MainHand); }
            if (Create.p.OffHand.Name != "None") { EquipmentList.Add(Create.p.OffHand); }
            UI.Store(new List<int> { 0, 0, 0 }, new List<string>
            {
                "What would you like to Sell?",
                "",
                "[0] Return"
            }, EquipmentList);
            Console.SetCursorPosition(58, 14);
            int sellChoice;
            do
            {

            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
            if (sellChoice > 0 && sellChoice < EquipmentList.Count)
            {
                if (UI.Confirm(new List<int> { 2 }, new List<string> { Colour.ITEM, Colour.GOLD, "Would you Like to sell your ", $"{EquipmentList[sellChoice].Name} ", "? I'll give you ", $"{EquipmentList[sellChoice].Price / 2} ", "for it" }))
                {
                    Create.p.Gold += EquipmentList[sellChoice].Price / 2;
                    if (Create.p.OffHand == EquipmentList[sellChoice]) Create.p.OffHand = Blunt.list[0];
                    else if (Create.p.MainHand == EquipmentList[sellChoice]) Create.p.MainHand = Blunt.list[0];
                    UI.Keypress(new List<int> { 3 }, new List<string>
                    {
                        Colour.NAME,Colour.ITEM, Colour.GOLD, "Great!",$"{ name} ","takes your ",$"{EquipmentList[sellChoice].Name} ", "and gives you ",$"{EquipmentList[sellChoice].Price / 2} ", "gold",
                    });
                }
            }
        }
    }
}