using System;
using System.Linq;
using System.Collections.Generic;

public class CombatArena
{
    public static GladiatorA currentGladiator = new GladiatorA(1, 1, 1, 1);
    public static GladiatorA rudiger = new GladiatorA(3,2,4,1,"Rudiger");
    public static bool firstTime = true;
    public static int round;
    public static void Menu()
    {        
        GameState.location = Location.CombatArena;
        Console.Clear();        
        if (Button.tournamentButton.active)
        {
            Utilities.Buttons(Button.listOfCombatArenaOptions);
            UI.Choice(new List<int> { }, new List<string>
            {

            },
            Button.list1, Button.button1);
        }
        else if (GameState.phase2b)
        {
            Utilities.Buttons(Button.listOfCombatArenaOptions);
            UI.Choice(new List<int> { }, new List<string>
            {

            },
            Button.list1, Button.button1);
        }
        else if (GameState.phase2a)
        {
            Utilities.Buttons(Button.listOfCombatArenaOptions);
            UI.Choice(new List<int> { }, new List<string>
            {

            },
            Button.list1, Button.button1);
        }
        else if (Button.dungeon1aButton.active)
        {
            UI.Keypress(new List<int> { 1,0,1,0,3 }, new List<string>
            {
                Color.SPEAK,"","'Hey, you're back","",
                "",
                Color.SPEAK,"","That's great and all, but don't you think you have bigger fish to fry?","",
                "",
                Color.SPEAK,Color.DAMAGE,Color.SPEAK,"","Come back when there's less horrible ","","danger hanging over the ","","town",""
            });
        }
        else
        {
            if (firstTime)
            {
                UI.Keypress(new List<int> { 1,0,0,0,0,0,2 }, new List<string>
                {
                    Color.MONSTER,"You enter the so called ","Combat arena","",
                    "",
                    "You don't say as much, but it is pretty sad",
                    "",
                    "There is no one here who looks like they have what it takes",
                    "",
                    Color.NAME,Color.CRIT,"You see ","Billiam",", the town ","seargent ","walk up to you"
                });
                UI.Keypress(new List<int> {1,0,1,0,3,0,0,0,1  }, new List<string>
                {
                    Color.SPEAK, "","'Lord knows it's not much, but it's all we got","",
                    "",
                    Color.SPEAK, "","That is, unless you were thinking of joining","",
                    "",
                    Color.SPEAK,Color.NAME,Color.SPEAK,"","Everyone knows the ","",Family.lastName,"", "s are all great adventurers, even the least of them","",
                    "",
                    "He eyes you",
                    "",
                    Color.SPEAK, "", "I hope'", ""
                });
                firstTime = false;
            }
            currentGladiator = rudiger;
            Button.challengeOpponentButton.text = $"hallenge {CombatArena.currentGladiator.Name}";
            Utilities.Buttons(Button.listOfCombatArenaOptions);           
            UI.Choice(new List<int> {4,0,1,0,2,0,3 }, new List<string>
            {
                Color.SPEAK,Color.BOSS,Color.SPEAK,Color.MONSTER,"","If you're hear to take a shot at the ","","Savage Orc","",", challenge ","","Rudiger","",
                "",
                Color.SPEAK,"","He is our gatekeeper of sorts","",
                "",
                Color.SPEAK,Color.BOSS,"","He's terrified of the ","","Savage Orc","",
                "",
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"", "But if you can't at least take ","","Rudiger","",", you have no chance",""
            },
            Button.list1, Button.button1);
            SelectOptions();
        }        
    }

    private static void SelectOptions()
    {
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "c" && Button.challengeOpponentButton.active) Fight();
        else if (choice == "s" && Button.selectOpponentButton.active) Select();
        else if (choice == "v" && Button.viewRankingsButton.active) Rankings();
        else if (choice == "w" && Button.wagerButton.active) Wager();
        else if (choice == "t" && Button.tournamentButton.active) Tournament();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Town.Menu();
        else Menu();
    }

    private static void Tournament()
    {
        
    }

    private static void Wager()
    {
        
    }

    private static void Rankings()
    {
        
    }

    private static void Select()
    {
        
    }

    private static void Fight()
    {
        if (!Button.dungeon1aButton.active) FirstFight();
        
    }

    private static void FirstFight()
    {
        Create.p.nonLethal = true;
        Create.p.tutorial = true;
        round = 0;
        string adviceOne = (Create.p.PClass != PlayerClass.Mage) ? "defensive technique" : "shield";
        string adviceTwo = (Create.p.PClass != PlayerClass.Mage) ? "You don't do any damage, but you take less damage and you are much harder to hit":"While your shield is active, it will prevent offensive special techniques from harming you. That will cost energy";
        UI.Keypress(new List<int> { 0,1,0,1 }, new List<string>
        {
            "",
            Color.DAMAGE,"","COMBAT TUTORIAL","",
            "",
            Color.HEALTH,"","HEADS UP",""
        });
        UI.Keypress(new List<int> { 1,0,1,0,3,0,4,0,2 }, new List<string>
        {
            Color.MONSTER,"","Rudiger", " limbers up and gets ready to fight",
            "",
            Color.CRIT,"The ","seargent"," walks over and starts explaining",
            "",
            Color.SPEAK,Color.MONSTER,Color.SPEAK,"","'Ok, Watch out, ","","Rudiger",""," has a special technique","",
            "",
            Color.SPEAK,Color.MONSTER,Color.ABILITY,Color.SPEAK,"","Every round you can see how ","","Rudiger",""," intends",""," to act","",
            "",
            Color.SPEAK,Color.ABILITY,"","It will be listed directly under his name in ","","purple",""
            
        });
        UI.Keypress(new List<int> { 4,0,4,0,4,0,1,0,4}, new List<string>
        {
            Color.SPEAK,Color.ABILITY,Color.SPEAK,Color.DAMAGE,"","If it says ","","Ready",""," he is planning to ","","attack","",
            "",
            Color.SPEAK,Color.STUNNED,Color.SPEAK,Color.STUNNED,"","If it says ","","Stunned","",", he ","","cannot","",
            "",
            Color.SPEAK,Color.ABILITY,Color.SPEAK,Color.ABILITY,"","If it says ","","Big Cut","",", he is planning on using his ","","big cut technique","",
            "",
            Color.ABILITY,"","TO BE CLEAR, THE WORDS IN PURPLE UNDER HIS NAME TELL YOU WHAT THE MONSTER'S >NEXT< MOVE IS SO YOU CAN PLAN ACCORDINGLY","",
            "",
            Color.SPEAK,Color.MONSTER,Color.SPEAK,Color.ABILITY,"","This will be true of all ","","enemies","",", although their ","","techniques may have different names",""          
        });
        UI.Keypress(new List<int> { 0,2,0,1,0,0,1,0,0,3,0,3 }, new List<string>
        {
            "",
            Color.SPEAK,Color.DEFENCE,"","In a case like that I'd consider using your ","",$"{adviceOne}","",
            "",
            Color.SPEAK,"",adviceTwo,"",
            "",
            "",
            Color.SPEAK,"","Oh, one last thing","",
            "",
            "",
            Color.SPEAK,Color.HEALTH,Color.SPEAK,"","You have a ","","healing",""," potion, tracked on the right side of your screen","",
            "",
            Color.SPEAK,Color.HEALTH,Color.SPEAK,"","You can use it at any time to restore ","","health","","'",""
        });
        Create.p.combatMonsters.Clear();
        Dungeon.Summon(currentGladiator,"Rudiger");
        //Get intention and display to start, after that, do it at the end
        foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
        Console.Clear();
        CombatUI.Box();
        while (Create.p.combatMonsters.Count > 0)
        {
            Create.p.ItemCheck();
            Create.p.AttackChoice();            
            foreach (Monster m in Create.p.combatMonsters.ToList())
            {
                if (m.Bleed > 0)
                {
                    Combat.AddCombatText(Color.MONSTER + m.Name + Color.BLOOD + " bleeds " + Color.RESET + "for " + Color.DAMAGE + m.BleedDam + Color.RESET + " damage!");
                    m.TakeDamage(m.BleedDam);
                    m.Bleed--;
                }
                else
                {
                    if (m.Status.Contains("Bleeding")) m.Status.Remove("Bleeding");
                }
                if (m.Burning > 0)
                {
                    Combat.AddCombatText(Color.MONSTER + m.Name + Color.BURNING + " burns " + Color.RESET + "for " + Color.DAMAGE + m.BurnDam + Color.RESET + " damage!");
                    m.TakeDamage(m.BurnDam);
                    m.Burning--;
                }
                else
                {
                    if (m.Status.Contains("Burning")) m.Status.Remove("Stunned");
                }
                if (m.Stun > 0)
                {
                    m.CanAct = false;
                    m.Stun--;
                }
                else
                {
                    m.CanAct = true;
                    if (m.Status.Contains("Stunned")) m.Status.Remove("Stunned");
                }
                if (m.CanAct) m.MakeAttack();
                else Combat.AddCombatText($"The {Color.MONSTER + m.Name + Color.RESET} is " + Color.STUNNED + "stunned " + Color.RESET + "and cannot act!");
            }
            foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
            if (Create.p.combatMonsters.Count == 0)
            {
                Console.WriteLine("\n\nPress any Key to continue");
                Console.ReadKey(true);
            }
            Combat.combatText.Clear();
        }
        Create.p.nonLethal = false;
        UI.Keypress(new List<int> { 0 }, new List<string>
        {
            "The Seargent walks back over",
        });
        UI.Keypress(new List<int> { 0,1,0,3,0,4,0,1,0,1 }, new List<string>
        {
            "",
            Color.SPEAK,"","'Well, that cinches it. You are our best hope","",
            "",
            Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here is ","","100",""," gold. " ,"",
            $"",
            Color.SPEAK,Color.NAME,Color.SPEAK,Color.HEALTH,"","I'll tell ","",Shop.itemNPC.name,""," to open up the ","","Item shop","",
            "",
            Color.SPEAK,"","They don't have much, but it should be enough to get you started","",
            "",
            Color.SPEAK,"","Good luck, we're counting on you'",""
        });
        Create.p.Gold += 100;
        Create.p.Health = Create.p.MaxHealth;
        Create.p.Energy = Create.p.MaxEnergy;
        Create.p.PotionSize = Create.p.MaxPotionSize;
        Button.dungeon1aButton.active = true;
        Button.itemShopButton.active = true;
        Button.challengeOpponentButton.active = false;
        Create.p.tutorial = false;
    }

    static void Info()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine(Color.BLOOD + "COMBAT ARENA" + Color.RESET + "\n\nYour" + Color.XP + " house" + Color.RESET + " is where you return at the end of each day to heal up, pass time and craft poweful items ");
        Console.WriteLine("\n\n" + Color.TIME + "SLEEPING" + Color.RESET + "\n\nWhen you sleep, several things happen. \n\n- Your potion refills itself\n- You can go adventuring. You can go adventuring once per day\n- The day passes. This is important as many events will happen on specific days");
        Console.WriteLine("\n\n" + Color.ENHANCEMENT + "CRAFTING" + Color.RESET + "\n\nDefeated " + Color.MONSTER + "monsters" + Color.RESET + " can " + Color.DROP + "drop" + Color.RESET + " special loot that can be used to craft " + Color.ITEM + "items" + Color.RESET + ".\nTo begin, you must find the " + Color.ENHANCEMENT + "crafting machine" + Color.RESET + "\n\n");
        Utilities.Keypress();
    }
}