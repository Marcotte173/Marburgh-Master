using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Forest
{
    static int depth = 0;
    static int savedDepth = 0;
    static int campDepth = 3;
    static int clearingsFound=0;
    public static void Menu()
    {
        GameState.location = Location.Forest;
        UI.Keypress(new List<int> { 1,0,2,0,1,0,0 }, new List<string>
        {
            Color.HEALTH,"You make your way out to the ","forest","",
            "",
            Color.MONSTER,Color.MONSTER,"Rumor has it that many of the ","creatures"," that infested the ","Savage Orc's"," Lair escaped when he was defeated",
            "",
            Color.MONSTER,"Who knows, there may be ","creatures"," here you've never seen before",
            "",
            "Caution is is recommended"
        });
        depth = 0;
        Clearing();
        
    }

    private static void Clearing()
    {
        if (Create.p.forestCamp && depth >= campDepth) Button.campButton.active = true;
        else Button.campButton.active = false;
        Utilities.Buttons(Button.listOfForestOptions);
        UI.Choice(new List<int> { 1, 0, 1 }, new List<string>
        {
            Color.HEALTH,"You look around the foreboding ","forest","",
            "",
            Color.MONSTER,"Deeper inside, you think you hear ","movement","..."

        }, Button.list1, Button.button1);
        string choice = Return.Option();
        if (choice == "g") Deeper();
        else if (choice == "m" && Button.campButton.active && depth >= campDepth) Camp();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "h") Utilities.Heal();
        else if (choice == "i" && Button.potionButton.active) Utilities.Item();
        else if (choice == "0") Utilities.ToTown();
        Clearing();
    }

    private static void Camp()
    {
        UI.Keypress(new List<int> { 0, 0, 1, 1, 1, 0, 1 }, new List<string>
        {
            "You make camp and rest for several hours",
            "",
            Color.HEALTH, "", "Health " , "at Maximum ",
            Color.ENERGY , "", "Energy " ,  "at maximum",
            Color.HEALTH, "Your potion returns to " , "full " , "size",
            "",
            Color.MONSTER, "Waking up feeling ","refreshed",", you grip your weaapon and press on"
        });
        Create.p.forestCamp = false;
        Create.p.Health = Create.p.MaxHealth;
        Create.p.Energy = Create.p.MaxEnergy;
        Create.p.PotionSize = Create.p.MaxPotionSize;
    }

    private static void Deeper()
    {
        depth++;
        Console.Clear();
        Write.SetY(15);
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 9);
        Console.Write(Color.MONSTER+"Exploring"+Color.RESET);
        Write.DotDotDot();
        YouFind();
    }

    private static void YouFind()
    {
        Combat();
    }

    private static void Combat()
    {
        int amount = Return.RandomInt(1, 4);
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };
        for (int i = 0; i < amount; i++)
        {
            Monster summon = Dungeon.forestSummon[Return.RandomInt(0, Dungeon.forestSummon.Count)];
            colourArray.Add(1);
            summonList.Add(Color.MONSTER);
            if (summon.Name == "Orc") summonList.Add("An ");
            else summonList.Add("A ");
            summonList.Add(summon.Name);
            summonList.Add("");
            colourArray.Add(0);
            summonList.Add("");
            Dungeon.Summon(summon);
        }
        Room.ActionWait(colourArray, summonList, Color.RESET + "You have found" + Color.RESET, null);
        global::Combat.Menu();
    }

    public static void Reward(int mod)
    {

    }
}