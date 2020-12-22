using System;
using System.Collections.Generic;
using System.Text;

public class Town
{
    public static void Menu()
    {
        GameState.location = Location.Town;
        Console.Clear();
        Utilities.Buttons(Button.list1, Button.button1, Button.listOfDungeons);
        Utilities.Buttons(Button.list2, Button.button2, Button.listOfShops);
        Utilities.Buttons(Button.list3, Button.button3, Button.listOfServices);
        Utilities.Buttons(Button.list4, Button.button4, Button.listOfOther);

        if (GameState.phase3)
        {

        }
        else if (GameState.phase2b && Create.p.Level < 4)
        {
            UI.Town(new List<int> {1,0,0,0,1,0,1,0,1,0,1 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "It's a bustling little town",
                "",
                Color.XP,"Most of the ","shops"," are open",
                "",
                Color.NAME,"The ","townspeople"," look cautious, but hopeful that you may be able to help them finally be free",
                "",
                Color.DEATH,"At the top of the hill is the ","Necromancer's"," Mansion",
                "",
                Color.HEALTH,"To the east is the ","Forest",". You may want to consider going there to get stronger"
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (GameState.phase2b)
        {
            UI.Town(new List<int> { 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "It's a bustling little town",
                "",
                Color.XP,"Most of the ","shops"," are open",
                "",
                Color.NAME,"The ","townspeople"," look cautious, but hopeful that you may be able to help them finally be free",
                "",
                Color.DEATH,"At the top of the hill is the ","Necromancer's"," Mansion",
                "",
                "It's time to kick some ass"
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (GameState.phase2a)
        {
            UI.Town(new List<int> {1,0,1,0,1,0,1,0,1  },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                Color.DEATH,"Something's... ","off","",
                "",
                Color.NAME,"It's obvious the ","townspeople"," have returned but... they're clearly quite scared",
                "",
                Color.XP,"Most of the ","businesses"," are still closed. Didn't you save the town?",
                "",
                Color.XP,"There's a light on in the ","Tavern",". Maybe the bartender knows more "
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (GameState.phase1b)
        {
            UI.Town(new List<int> {1,0,0,0,0,0,3,0,1 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "It is a small town, but is clearly growing",
                "",
                "Who knows what will be here in a month?",
                "",
                Color.NAME,Color.ITEM,Color.POTION,"",Shop.itemNPC.name , $" finds you to let you know that {Shop.itemNPC.pronoun1b} has new ", "equipment ","as well as new ","potions","",
                "",
                Color.XP,"You also see more lights on in the ","tavern",". Might be worth checking out"
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (GameState.firstBossDead && GameState.villagersSaved == "")
        {
            UI.Town(new List<int> {1,0,0,0,3 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "You definitely remember alot more people living here",
                "",
                Color.DAMAGE,Color.SPEAK,Color.NAME,"You managed to defeat one of the immediate ","threats"," to ","Marburgh"," but the ","townspeople"," have not yet been rescued",
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (!GameState.firstBossDead && GameState.villagersSaved != "")
        {
            UI.Town(new List<int> {1,0,0,0,3 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "You definitely remember alot more people living here",
                "",
                Color.NAME,Color.HEALTH,Color.DAMAGE,"Many of the ","townspeople"," have been ","rescued",", but they can't really rebuild until the ","threat"," is gone",
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else if (Button.dungeon1aButton.active)
        {
            UI.Town(new List<int> {1,0,0,0,0,0,2 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "You definitely remember alot more people living here",
                "",
                "There is not a lot going on in this town",
                "",
                Color.ITEM,Color.BOSS,"Hopefully that will change when the ","townsfolk"," are rescued and the ","Savage Orc"," is defeated "
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        else
        {
            UI.Town(new List<int>{1,0,0,0,2,0,1,0,1,0,2 },
            new List<string>
            {
                Color.SPEAK,"You are in the town of ","Marburgh", "",
                "",
                "You definitely remember alot more people living here", 
                "",
                Color.NAME,Color.DAMAGE,"Any ","townspeople"," who remain are ","terrified"," they might be taken next",
                "",
                Color.XP,"Every business save the ","tavern"," has been destroyed or abandoned",
                "",
                Color.MONSTER,"Asking around, you find out that people who want to help are training at the ","combat arena","",
                "",
                Color.ITEM,Color.BOSS,"Anyone who proves themselves will be given ","equipment"," and the location of the ","Savage Orc",""
            }, Button.list1, Button.list2, Button.list3, Button.list4, Button.button1, Button.button2, Button.button3, Button.button4);
        }
        Write.Line(104, 27, "[" + Color.BLOOD + "?" + Color.RESET + "] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Return.Option();
        if (choice == "9") CharacterSheet.Display();
        else if (choice == "0")
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.DAMAGE, "Would you like to ", "quit","?"
                })) Utilities.Quit();
        }
        else if (choice == "m" && Button.magicShopButton.active) Shop.Menu(Shop.magicNPC);
        else if (choice == "w" && Button.weaponShopButton.active) Shop.Menu(Shop.weaponNPC);
        else if (choice == "a" && Button.armorShopButton.active) Shop.Menu(Shop.armorNPC);
        else if (choice == "i" && Button.itemShopButton.active) Shop.Menu(Shop.itemNPC);
        else if (choice == "l" && Button.levelMasterButton.active) Level.Menu();
        else if (choice == "c" && Button.combatArenaButton.active) CombatArena.Menu();
        else if (choice == "e" && Button.exploreTownButton.active) ExploreTown.Menu();
        else if (choice == "t") Tavern.Menu();
        else if (choice == "?") Help.Menu();
        else if (choice == "g") Graveyard.Menu();
        else if (choice == "y") House.Menu();
        else if (choice == "b" && Button.bankButton.active) Bank.Menu();
        else if (choice == "x") GameState.Cheat();
        //else if (choice == "z") GameState.Death();
        //else if (choice == "z") GameState.CraftCheat();
        else if (choice == "1" && Button.dungeon1aButton.active || (choice == "2" && Button.dungeon1bButton.active) || (choice == "*" && Button.dungeonCaveButton.active) || choice == "3" && Button.dungeonForestButton.active || choice == "4" && Button.dungeon2Button.active || choice == "5" && Button.dungeon3Button.active)
        {
            //If no, go home
            if (Create.p.CanExplore == false)
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    "You are exhausted",
                    "",
                    "You should go to bed"
                });
                Menu();
            }
            //Warning so you don't use it then leave right away
            if (UI.Confirm(new List<int> { 2, 0, 0 }, new List<string>
            {
                Color.MONSTER,Color.TIME,"You may only go ","exploring"," once a ","day","",
                "",
                "Would you like to go now?"
            }))
            //Explore!
            {
                Create.p.CanExplore = false;
                if (choice == "1")
                {                    
                    Explore.dungeon  = Dungeon.dungeon1a;
                    Explore.currentRoom = Explore.dungeon.layout[1];
                    Explore.Menu();
                }
                else if (choice == "2")
                {

                    Explore.dungeon = Dungeon.dungeon1b;
                    Explore.currentRoom = Explore.dungeon.layout[1];
                    Explore.Menu();
                }
                else if (choice == "3")
                {
                    Forest.Menu();
                }
                else if (choice == "*")
                {

                    //Explore.dungeon = Dungeon.MansionEntrance;
                    //Explore.dungeon.layout[1].room.Explore();
                }
                else if (choice == "4")
                {

                    Explore.dungeon = Dungeon.MansionEntrance;
                    Explore.dungeon.layout[1].room.Explore();
                    Explore.Menu();
                }
                else if (choice == "5")
                {

                    //Explore.dungeon = Dungeon.MansionEntrance;
                    //Explore.dungeon.layout[1].room.Explore();
                    //Explore.Menu();
                }                
            }
        }
        Menu();
    }    
}