using System;
using System.Collections.Generic;

public class House:Location
{
    public static List<string> houseOptionButton = new List<string>
    {
        Colour.NAME + "S" + Colour.RESET
    };
    public static List<string> houseOptionList = new List<string>
    {
        "leep"
    };
    public House()
    : base() { }
    //When you go to your house
    public override void Menu()
    {
        Console.Clear();
        if (houseOptionList.Count < 3)
            UI.Choice(new List<int> { 1 }, new List<string>
            {
                Colour.SPEAK, "", "You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.", "",
            },
            houseOptionList, houseOptionButton);
        else
            UI.Choice(new List<int> { 1, 1 }, new List<string>
            {
                Colour.SPEAK, "","You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.","",
                Colour.ENHANCEMENT, "In the center of the room you see your ", "crafting machine","","Now you just have to figure out how it works"
            },
            houseOptionList, houseOptionButton);
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Colour.BLOOD + "MORE INFO" + Colour.RESET);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();        
        if (choice == "0") Utilities.ToTown();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "?") Info();
        else if (choice == "s")
        {
            Console.Clear();            
            if (UI.Confirm(
                new List<int> { 0, 2, 1 }, new List<string>
                {
                    "Would you like to sleep until morning?",
                    Colour.HEALTH,Colour.ENERGY,"Your ", "Health " ,"and " ,"Energy " , "will be restored to maximum",
                    Colour.TIME, "Time will advance by ","one ","day",
                }))
            {
                Console.Clear();
                Time.DayChange(1);
                UI.Keypress(new List<int> { 0, 0, 1, 1, 1, 0, 0 }, new List<string>
                    {
                        "You sleep until morning",
                        "",
                        Colour.HEALTH, "", "Health " , "at Maximum ",
                        Colour.ENERGY , "", "Energy " ,  "at maximum",
                        Colour.HEALTH, "Your potion returns to " , "full " , "size",
                        "",
                        "You can explore again",
                    });
            }
            else Location.list[8].Menu();
        }
        //If you hit c and it's available, you get to choose how to craft
        if (choice == "e" && GameState.CanCraft) Location.list[12].Go();
        Location.list[8].Menu();
    }
    void Info()
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