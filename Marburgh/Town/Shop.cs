using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class 
    Shop 
{
    static List<Equipment> bluntList = new List<Equipment> { Blunt.list[0], Blunt.list[1], Blunt.list[2], Blunt.list[3], Blunt.list[4], Blunt.list[5], Blunt.list[6], Blunt.list[7] };
    static List<Equipment> swordList = new List<Equipment> { Sword.list[0], Sword.list[1], Sword.list[2], Sword.list[3], Sword.list[4], Sword.list[5], Sword.list[6], Sword.list[7] };
    static List<Equipment> daggerList = new List<Equipment> { Dagger.list[0], Dagger.list[1], Dagger.list[2], Dagger.list[3], Dagger.list[4], Dagger.list[5], Dagger.list[6], Dagger.list[7] };
    static List<Equipment> shieldList = new List<Equipment> { Shield.list[0], Shield.list[1], Shield.list[2], Shield.list[3], Shield.list[4], Shield.list[5], Shield.list[6], Shield.list[7] };
    static List<Equipment> armorList = new List<Equipment> { Armor.list[0], Armor.list[1], Armor.list[2], Armor.list[3], Armor.list[4], Armor.list[5], Armor.list[6], Armor.list[7] };
    static List<Equipment> magicList = new List<Equipment> { Magic.list[0], Magic.list[1], Magic.list[2], Magic.list[3], Magic.list[4], Magic.list[5], Magic.list[6], Magic.list[7] };
    static int[] upgrade = new int[] { 1000, 3000, 10000, 20000, 35000 };
    static int[] healAdd = new int[] { 3, 5, 7, 10, 15 };
    static int current = 0;
    

    public static void Menu(string shopKeep)
    {
        GameState.location = Location.Shop;
        Console.Clear();
        string race = (shopKeep == "Marley") ? "pup" : (shopKeep == "Oscar") ? "halfling" : "elf";
        List<string> choices = new List<string> { Color.ITEM + "B" + Color.RESET, Color.ITEM + "S" + Color.RESET };
        List<string> buttons = new List<string> { "uy", "ell" };
        if (shopKeep == "Marley")
        {
            choices.Add(Color.HEALTH + "P" + Color.RESET);
            buttons.Add("otions");
        }
        UI.Choice(new List<int> { 1, 2, 0, 1,0,1,1,1 }, new List<string>
        {
            Color.NAME, "You walk into ",$"{shopKeep}'s"," Weapon Shop",
            Color.NAME, Color.CLASS, $" ", shopKeep, " the ", race, " comes over to greet you",
            "",
            Color.SPEAK,"", $"'Greetings, what can I do for you?'","",
            "",
            Color.ITEM,"Main Hand :   ",$"{Create.p.MainHand.Name} ",  "",
            Color.ITEM,"Off Hand  :   ",$"{Create.p.OffHand.Name} " ,  "",
            Color.ITEM,"Armor Hand:   ",$"{Create.p.Armour.Name}   " ,  "",
        },
        buttons, choices);
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Return.Option();
        if (choice == "b" && shopKeep == "Oscar")
        {
            UI.Choice(new List<int> { 1, 0,1, 1, 1 }, new List<string>
            {
                Color.SPEAK,"", $"'And what can I interest you in?'","",
                "",
                Color.ITEM,"Main Hand :   ",$"{Create.p.MainHand.Name} ",  "",
                Color.ITEM,"Off Hand  :   ",$"{Create.p.OffHand.Name} " ,  "",
                Color.ITEM,"Armor Hand:   ",$"{Create.p.Armour.Name}   " ,  "",
            },
            new List<string> { "Swords", "Daggers", "Hammers", "Shields" }, new List<string> { Color.ITEM + "1" + Color.RESET, Color.ITEM + "2" + Color.RESET, Color.ITEM + "3" + Color.RESET, Color.ITEM + "4" + Color.RESET });
            string choice2 = Return.Option();
            if (choice2 == "1") Buy(swordList, shopKeep);
            else if (choice2 == "2") Buy(daggerList, shopKeep);
            else if (choice2 == "3") Buy(bluntList, shopKeep);
            else if (choice2 == "4") Buy(shieldList, shopKeep);
            else Menu(shopKeep);
        }
        else if (choice == "b" && shopKeep == "Lela") Buy(armorList, shopKeep);
        else if (choice == "b" && shopKeep == "Marley") Buy(magicList, shopKeep);
        else if (choice == "p" && shopKeep == "Marley") Potion();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "s") Sell(shopKeep);
        else if (choice == "?") Info();
        Menu(shopKeep);
    }
    public static void Buy(List<Equipment> list, string shopKeep)
    {
        UI.Store(new List<int> { 0, 0, 1,1,1,0,0 }, new List<string>
        {
            "Great! What would you like to buy?",
            "",
            Color.ITEM,"Main Hand:  ",$"{Create.p.MainHand.Name} ",  "",
            Color.ITEM,"Off Hand:   ",$"{Create.p.OffHand.Name} " ,  "",
            Color.ITEM,"Armor Hand: ",$"{Create.p.Armour.Name}   " ,  "",
            "",
            "[0] Return"
        },
        list);
        int choice = Return.Int();
        if (choice > 0 && choice < list.Count)
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
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.ITEM, "Would you like to buy the ", $"{list[choice].Name}", "?" }))
                {
                    if (list == armorList)
                    {
                        if (Create.p.Armour.Name != "None") SellOld(shopKeep, list[choice], Create.p.Armour);
                        else FinishSale(shopKeep, list[choice], Create.p.Armour);
                    }
                    else
                    {
                        if (Create.p.MainHand == UI.Hand(list[choice]))
                        {
                            if (Create.p.MainHand.Name != "None") SellOld(shopKeep, list[choice], Create.p.MainHand);
                            else FinishSale(shopKeep, list[choice], Create.p.MainHand);
                        }
                        else
                        {
                            if (Create.p.OffHand.Name != "None") SellOld(shopKeep, list[choice], Create.p.OffHand);
                            else FinishSale(shopKeep, list[choice], Create.p.OffHand);
                        }                        
                    }
                }
            }
        }
        Menu(shopKeep);
    }

    public static void SellOld(string shopKeep, Equipment item, Equipment current)
    {
        if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.ITEM, "I see you have a ", $"{current.Name}", ". Would you like to sell it?" }))
        {
            Create.p.Gold += current.Price / 2;
            Create.p.Gold -= item.Price;
            Console.Clear();
            UI.Keypress(new List<int> { 3, 0, 2 }, new List<string>
            {
                Color.NAME,Color.ITEM, Color.GOLD, "",$"{shopKeep} ","takes your ",$"{current.Name} ", "and gives you ",$"{current.Price / 2} ", "gold",
                "",
                Color.NAME, Color.ITEM, "Smiling, ", $"{shopKeep} ","takes your money and gives you your ",$"{item.Name}","",
            });
            Create.p.Equip(item, current);
        }
    }

    private static void FinishSale(string shopKeep, Equipment item, Equipment current)
    {
        Create.p.Gold -= item.Price;
        Console.Clear();
        UI.Keypress(new List<int> { 2 }, new List<string>
        {
        Color.NAME, Color.ITEM,"Smiling, ",$"{shopKeep} ","takes your money and gives you your ",$"{item.Name}","",
        });
        Create.p.Equip(item, current);
    }

    public static void Sell(string name)
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
            List<Equipment> EquipmentList = new List<Equipment> { new Blunt("Fist",0,0,0,0,false,0) };
            if (Create.p.MainHand.Name != "None") { EquipmentList.Add(Create.p.MainHand); }
            if (Create.p.OffHand.Name != "None") { EquipmentList.Add(Create.p.OffHand); }
            if (Create.p.OffHand.Name != "None") { EquipmentList.Add(Create.p.Armour); }
            UI.StoreSell(new List<int> { 0, 0, 0 }, new List<string>
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
                if (UI.Confirm(new List<int> { 2 }, new List<string> { Color.ITEM, Color.GOLD, "Would you Like to sell your ", $"{EquipmentList[sellChoice].Name} ", "? I'll give you ", $"{EquipmentList[sellChoice].Price / 2} ", "for it" }))
                {
                    Create.p.Gold += EquipmentList[sellChoice].Price / 2;
                    if (Create.p.OffHand == EquipmentList[sellChoice]) Create.p.OffHand = Blunt.list[0];
                    else if (Create.p.MainHand == EquipmentList[sellChoice]) Create.p.MainHand = Blunt.list[0];
                    UI.Keypress(new List<int> { 3 }, new List<string>
                    {
                        Color.NAME,Color.ITEM, Color.GOLD, "Great!",$"{ name} ","takes your ",$"{EquipmentList[sellChoice].Name} ", "and gives you ",$"{EquipmentList[sellChoice].Price / 2} ", "gold",
                    });
                }
            }
        }
    }

    private static void Potion()
    {
        if (UI.Confirm(new List<int> { 2, 0, 0 }, new List<string>
            {
                Color.HEALTH, Color.GOLD,"Upgrading your ", "potion ", "will cost ", $"{upgrade[current]} ", "gold.",
                "",
                "Would you like to do this?"
            }))
        {
            if (Return.HaveGold(upgrade[current]))
            {
                UI.Keypress(new List<int> { 3, 0, 0, 0, 1, 0, 2 }, new List<string>
                {
                    Color.NAME, Color.GOLD, Color.HEALTH,"", "Marley", " takes your ","money ","and your ","potion","",
                    "",
                    "He takes your potion to the back, and returns 5 minutes later",
                    "",
                    Color.SPEAK,"","'Here you go! Your potion is now bigger!'","",
                    "",
                    Color.HEALTH,Color.HEALTH,"Your ","potion ","can now heal up to ",$"{healAdd[current]} ","more hp!"
                });
                Create.p.Gold -= upgrade[current];
                Create.p.MaxPotionSize += healAdd[current];
                Create.p.PotionSize = Create.p.MaxPotionSize;
                current++;
            }
            else
                UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have enough gold!",
                });
        }
    }


    public static void Info()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine(Color.ITEM + "Items" + Color.RESET + " are a very important part of " + Color.ENERGY + "Marburgh" + Color.RESET + "\n\nThe right " + Color.ITEM + "item" + Color.RESET + " can mean the difference between sucess and " + Color.DAMAGE + "death" + Color.RESET + ".");
        Console.WriteLine("\n\n" + Color.CLASS + "CHARACTER SCREEN" + Color.RESET + "\n\nPress [" + Color.CLASS + "9" + Color.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Color.GOLD + "BUYING" + Color.RESET + "\n\n" + Color.ITEM + "Items" + Color.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Color.ITEM + "B" + Color.RESET + "]uy, then the " + Color.ITEM + "item" + Color.RESET + " you would like to purchase.\nIf you have the required " + Color.GOLD + "gold" + Color.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Color.GOLD + "SELLING" + Color.RESET + "\n\nWhen you sell an " + Color.ITEM + "item" + Color.RESET + ", you will receive half of the item's " + Color.GOLD + "value" + Color.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Color.ITEM + "item" + Color.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}