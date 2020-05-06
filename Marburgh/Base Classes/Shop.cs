using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shop : Location
{
    public void SellOld(List<Weapon> list, int choice, string name, Weapon w)
    {
        if (UI.Confirm(new List<int> { 1 }, new List<string> { Colour.ITEM, "I see you have a ", $"{w.Name}", ". Would you like to sell it?" }))
        {
            Create.p.Gold += w.Price / 2;
            Create.p.Gold -= list[choice].Price;
            Console.Clear();
            UI.Keypress(new List<int> { 3, 0, 2 }, new List<string>
            {
                Colour.NAME,Colour.ITEM, Colour.GOLD, "",$"{name} ","takes your ",$"{w.Name} ", "and gives you ",$"{w.Price / 2} ", "gold",
                "",
                Colour.NAME, Colour.ITEM, "Smiling, ", $"{name} ","takes your money and gives you your ",$"{list[choice].Name }","",
            });
            Create.p.Equip(list[choice], w);
        }
    }
    public void SellOld(List<Armor> list, int choice, string name)
    {
        if (UI.Confirm(new List<int> { 1 }, new List<string> { Colour.ITEM, "I see you have a ", $"{Create.p.Armor.Name}", ". Would you like to sell it?" }))
        {
            Create.p.Gold += Create.p.Armor.Price / 2;
            Create.p.Gold -= list[choice].Price;
            Console.Clear();
            UI.Keypress(new List<int> { 3, 0, 2 }, new List<string>
            {
                Colour.NAME,Colour.ITEM, Colour.GOLD, "",$"{name} ","takes your ",$"{Create.p.Armor.Name} ", "and gives you ",$"{ Create.p.Armor.Price / 2} ", "gold",
                "",
                Colour.NAME, Colour.ITEM, "Smiling, ", $"{name} ","takes your money and gives you your ",$"{list[choice].Name }","",
            });
            Create.p.Equip(list[choice]);
        }
    }

    public virtual void Info()
    {
        Console.Clear();
        Console.WriteLine("\n" + Colour.ITEM + "Items" + Colour.RESET + " are a very important part of " + Colour.ENERGY + "Marburgh" + Colour.RESET + "\n\nThe right " + Colour.ITEM + "equipment" + Colour.RESET + " can mean the difference between sucess and " + Colour.DAMAGE + "death" + Colour.RESET + ".");
        Console.WriteLine("\n\n" + Colour.CLASS + "CHARACTER SCREEN" + Colour.RESET + "\n\nPress [" + Colour.CLASS + "9" + Colour.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Colour.GOLD + "BUYING" + Colour.RESET + "\n\n" + Colour.ITEM + "Items" + Colour.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Colour.ITEM + "B" + Colour.RESET + "]uy, then the " + Colour.ITEM + "item" + Colour.RESET + " you would like to purchase.\nIf you have the required " + Colour.GOLD + "gold" + Colour.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Colour.GOLD + "SELLING" + Colour.RESET + "\n\nWhen you sell an " + Colour.ITEM + "item" + Colour.RESET + ", you will receive half of the item's " + Colour.GOLD + "value" + Colour.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Colour.ITEM + "item" + Colour.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}