using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArmorShop : Shop
{
    Player p = Create.p;
    new static List<Armor> list = new List<Armor> { Armor.list[0], Armor.list[1], Armor.list[2], Armor.list[3]};
    public ArmorShop()
    : base() { }

    public override void Menu()
    {
        Console.Clear();
        UI.Choice(new List<int> { 0, 2, 0, 1 }, new List<string>
        {
            $"You walk into Lela's Armor Shop",
            Colour.NAME, Colour.CLASS, $"", $"Lela ", "the ", $"Elf", " comes over to greet you",
            "",
            Colour.SPEAK,"", $"'Greetings, what can I do for you?'",""
        },
        new List<string> { "uy", "ell" }, new List<string> { Colour.ITEM + "B" + Colour.RESET, Colour.ITEM + "S" + Colour.RESET });
        string choice = Return.Option();
        if (choice == "b") Buy(list, "Lela");
        else if (choice == "c") CharacterSheet.Display();
        else if (choice == "r") Utilities.ToTown();
        else if (choice == "s") Sell("Lela");
        Menu();
    }

    public void Buy(List<Armor> list, string name)
    {
        UI.Store(new List<int> { 0, 0, 0 }, new List<string>
        {
            "Great! What would you like to buy?",
            "",
            "[0] Return"
        },
        list);
        int choice = Return.Int();
        if (choice > 0 && (choice < list.Count))
        {
            if (p.Gold < list[choice].Price)
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
                    if (p.Armor.Name != "None") SellOld(list, choice, name);
                    else
                    {
                        p.Gold -= list[choice].Price;
                        Console.Clear();
                        UI.Keypress(new List<int> { 2 }, new List<string>
                        {
                            Colour.NAME, Colour.ITEM,"Smiling, ",$"{name} ","takes your money and gives you your ",$"{list[choice].Name}","",
                        });
                        p.Equip(list[choice]);
                    }
                }
            }
        }
        Menu();
    }

    public void Sell(string name)
    {
        if (p.Armor.Name == "None")
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have nothing to sell!",
            });
        }
        else
        {
            Console.Clear();
            List<Armor> EquipmentList = new List<Armor> { new Armor(0, 1) };
            if (p.Armor.Name != "None") { EquipmentList.Add(p.Armor); }
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
                    p.Gold += EquipmentList[sellChoice].Price / 2;
                    p.Armor = Armor.list[0];
                    UI.Keypress(new List<int> { 3 }, new List<string>
                    {
                        Colour.NAME,Colour.ITEM, Colour.GOLD, "Great!",$"{ name} ","takes your ",$"{EquipmentList[sellChoice].Name} ", "and gives you ",$"{EquipmentList[sellChoice].Price / 2} ", "gold",
                    });
                }
            }
        }
    }
}