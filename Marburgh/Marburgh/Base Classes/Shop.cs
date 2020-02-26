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
}