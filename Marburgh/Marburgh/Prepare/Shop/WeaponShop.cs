using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WeaponShop : Shop
{
    Player p = Create.p;
    static List<Weapon> bluntList = new List<Weapon> { Blunt.list[0], Blunt.list[1], Blunt.list[2], Blunt.list[3] };
    static List<Weapon> sharpList = new List<Weapon> { Sharp.list[0], Sharp.list[1], Sharp.list[2], Sharp.list[3] };
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
        string choice = Return.Option();
        if (choice == "b") Buy(bluntList, sharpList, "Oscar");
        else if (choice == "c") CharacterSheet.Display();
        else if (choice == "r") Utilities.ToTown();
        else if (choice == "s") Sell("Oscar");
        Menu();
    }

    public void Buy(List<Weapon> list, List<Weapon> list1, string name)
    {
        UI.Store(new List<int> { 0, 0, 0 }, new List<string>
        {
            "Great! What would you like to buy?",
            "",
            "[0] Return"
        },
        list, list1);
        int choice = Return.Integer();
        if (choice > 0 && choice < list.Count + list1.Count)
        {
            List<Weapon> listToUse = list;
            listToUse = (choice > list.Count - 1) ? list1 : list;
            choice = (choice > list.Count - 1) ? choice -= list.Count - 1 : choice;
            if (p.Gold < listToUse[choice].Price)
            {
                UI.Keypress(new List<int> { 0 }, new List<string>
                    {
                        "You don't have enough gold!",
                    });
            }
            else
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Colour.ITEM, "Would you like to buy the ", $"{listToUse[choice].Name}", "?" }))
                {

                    if (listToUse[choice].Name != "None") SellOld(listToUse, choice, name, UI.Hand(listToUse[choice]));
                    else
                    {
                        p.Gold -= listToUse[choice].Price;
                        Console.Clear();
                        UI.Keypress(new List<int> { 2 }, new List<string>
                        {
                            Colour.NAME, Colour.ITEM,"Smiling, ",$"{name} ","takes your money and gives you your ",$"{listToUse[choice].Name}","",
                        });
                        p.Equip(listToUse[choice], UI.Hand(listToUse[choice]));
                    }
                }
            }
        }
        Menu();
    }

    public void Sell(string name)
    {
        if (p.MainHand.Name == "None" && p.OffHand.Name == "None")
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have nothing to sell!",
            });
        }
        else
        {
            Console.Clear();
            List<Weapon> EquipmentList = new List<Weapon> { new Blunt(0, 1) };
            if (p.MainHand.Name != "None") { EquipmentList.Add(p.MainHand); }
            if (p.OffHand.Name != "None") { EquipmentList.Add(p.OffHand); }
            UI.Store(new List<int> { 0, 0, 0 }, new List<string>
            {
                "What would you like to Sell?",
                "",
                "[0] Return"
            }, EquipmentList, null);
            Console.SetCursorPosition(58, 14);
            int sellChoice;
            do
            {

            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
            if (sellChoice > 0 && sellChoice < EquipmentList.Count)
            {
                if (UI.Confirm(new List<int> { 2 }, new List<string> { Colour.ITEM, Colour.GOLD, "Would you Like to sell your ", $"{EquipmentList[sellChoice].Name} ", "? I'll give you ", $"{EquipmentList[sellChoice].Price / 2} ", "for it" }))
                {
                    p.Gold += EquipmentList[sellChoice].Price / 2;
                    if (p.OffHand == EquipmentList[sellChoice]) p.OffHand = Blunt.list[0];
                    else if (p.MainHand == EquipmentList[sellChoice]) p.MainHand = Blunt.list[0];
                    UI.Keypress(new List<int> { 3 }, new List<string>
                    {
                        Colour.NAME,Colour.ITEM, Colour.GOLD, "Great!",$"{ name} ","takes your ",$"{EquipmentList[sellChoice].Name} ", "and gives you ",$"{EquipmentList[sellChoice].Price / 2} ", "gold",
                    });
                }
            }
        }
    }
}