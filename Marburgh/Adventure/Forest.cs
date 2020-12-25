using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class Forest
{
    public static int progress = 1;
    public static int savedProgress = 1;
    public static int campProgress = 3;
    public static int depth=1;
    public static bool oldManBlessed;
    public static bool faeriesFound;
    public static bool firstTime;
    public static void Menu()
    {
        GameState.location = Location.Forest;
        if (firstTime)
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.HEALTH,"","The Forest",""
            });
            UI.Keypress(new List<int> {2,0,4,0,3 }, new List<string>
            {
                Color.HEALTH, Color.HEALTH, "As you progress through the ","forest"," your ","depth"," counter increases",
                "",
                Color.HEALTH, Color.MONSTER,Color.MONSTER,Color.HEALTH,"When you reach ","progress"," level of ",(8 + depth*2).ToString()," you will reach a new ","depth layer"," of the ","forest","",
                "",
                Color.MONSTER,Color.DAMAGE,Color.GOLD,"Each ","depth layer"," brings increased ","difficulty"," and ","reward",""
            });
            firstTime = false;
        }
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
        progress = savedProgress;
        savedProgress = 1;
        Clearing();        
    }

    private static void Clearing()
    {
        if (Create.p.forestCamp && progress >= campProgress) Button.campButton.active = true;
        else Button.campButton.active = false;
        Utilities.Buttons(Button.listOfForestOptions);
        UI.Choice(new List<int> { 1,0,1,0,0,0,2,0,2 }, new List<string>
        {
            Color.HEALTH,"You look around the foreboding ","forest","",
            "",
            Color.MONSTER,"","Deeper inside",", you think you hear movement",
            "",
            "",
            "",
            Color.HEALTH,Color.MONSTER,"","Forest Layer:","",depth.ToString(),"",
            "",
            Color.HEALTH,Color.MONSTER,"","Forest Progress:","",progress.ToString(),""
        }, Button.list1, Button.button1);
        string choice = Return.Option();
        if (choice == "g") Deeper();
        else if (choice == "m" && Button.campButton.active && progress >= campProgress) Camp();
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
            Color.MONSTER,Color.ITEM, "Waking up feeling ","refreshed",", you grip your ","weapon"," and press on"
        });
        Create.p.forestCamp = false;
        Create.p.Health = Create.p.MaxHealth;
        Create.p.Energy = Create.p.MaxEnergy;
        Create.p.PotionSize = Create.p.MaxPotionSize;
    }

    private static void Deeper()
    {
        progress++;
        if (progress >= 8 + depth*2) Reward();
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
        if(GameState.findJob.status == JobStatus.Issued &&  depth > 1 && progress > 4 && Return.RandomInt(0, 3) == 0) Roderick();        
        if (Return.RandomInt(1, 101) <= 30)
        {
            int encounterChosen = Return.RandomInt(0, 101);
            int faerieEncounter           = (depth == 1) ? 3  : (depth == 2) ? 6  : 9;
            int oldManGuessEncounter      = (depth == 1) ? 10 : (depth == 2) ? 10 : 10;
            int lostEncounter             = (depth == 1) ? 10 : (depth == 2) ? 10 : 10;
            int findSuppliesEncounter     = (depth == 1) ? 10 : (depth == 2) ? 10 : 10;
            int findPotionEncounter       = (depth == 1) ? 15 : (depth == 2) ? 15 : 15;
            int findHealthEncounter       = (depth == 1) ? 15 : (depth == 2) ? 13 : 10;
            int findBiggerHealthEncounter = (depth == 1) ? 7  : (depth == 2) ? 12 : 15;
            int manNeedsHelpEncounter     = (depth == 1) ? 10 : (depth == 2) ? 10 : 10;

            encounterChosen -= faerieEncounter;
            if (encounterChosen <= 0 && !faeriesFound && progress > 4 + depth) Faeries();

            encounterChosen -= oldManGuessEncounter;
            if (encounterChosen <= 0 && !oldManBlessed) OldManGuess();

            encounterChosen -= lostEncounter;
            if (encounterChosen <= 0 && progress > 4 + depth) Lost();

            encounterChosen -= findSuppliesEncounter;
            if (encounterChosen <= 0 && !Create.p.forestCamp) FindSupplies();

            encounterChosen -= findPotionEncounter;
            if (encounterChosen <= 0 && Return.RoomForPotions()) FindPotion();

            encounterChosen -= findHealthEncounter;
            if (encounterChosen <= 0 &&  Create.p.PotionSize == Create.p.MaxPotionSize) FindHealth();

            encounterChosen -= findBiggerHealthEncounter;
            if (encounterChosen <= 0) FindBiggerHealth();

            encounterChosen -= manNeedsHelpEncounter;
            if (encounterChosen <= 0) ManNeedsHelp();

            Nothing();
        }
        else Combat();
    }

    public static void Nothing()
    {
        UI.Keypress(new List<int> {1,0,1,0,0}, new List<string>
        {
            Color.MONSTER,"","You don't find a whole lot ","",
            "",
            Color.DAMAGE,"That's ","disappointing","",
            "",
            "Gritting your teeth, you move on..."
        });
        Clearing();
    }

    public static void Faeries()
    {
        UI.Choice(new List<int> {1,0,2,0,1,0,1 }, new List<string>
        {
            Color.SHIELD,"You step into an open area with a ","stream","",
            "",
            Color.SHIELD,Color.CRIT,"Frolicing near the ","stream",", you see some ","faeries","",
            "",
            Color.ENERGY,"They are famous for having powerful ","magics","",
            "",
            Color.ENERGY,"You could ask one of them for a ","blessing","",
        },new List<string> { Color.ENERGY + " Ask for a blessing" + Color.RESET,  Color.MITIGATION + " Walk away" + Color.RESET },new List<string> {"1","2" });        
        string choice = Return.Option();
        if(choice == "1")
        {
            FindThem();
        }
        else if (choice == "2")
        {
            UI.Keypress(new List<int> { 0,0,2,0,1,0,0 }, new List<string>
            {
                "Probably for the best",
                "",
                Color.CRIT,Color.ENERGY,"","Faeries"," are ","powerful","",
                "",
                Color.DAMAGE,"And ","unpredictable","",
                "",
                "Coward"
            });
            Clearing();
        }
        else Faeries();        
    }

    private static void FindThem()
    {
        int where = Return.RandomInt(1, 4);
        UI.Choice(new List<int> {2,0,1 }, new List<string>
        {
            Color.CRIT,Color.MONSTER,"The ","faeries"," see you walking towards them and ","SCATTER","",
            "",
            Color.MONSTER,"They each scamper off in a different ","direction",""
        }, new List<string> { Color.CRIT + " Chase the first faery" + Color.RESET, Color.CRIT + " Chase the second faery" + Color.RESET, Color.CRIT + " Chase the third faery" + Color.RESET, Color.MITIGATION + " Walk Away" + Color.RESET }, new List<string> { "1", "2","3","4" });
        int choice = Return.Int();
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Write.Line(52, 7, Color.MONSTER, "Chasing");
        Thread.Sleep(500);
        Write.Line(59, 7, ".");
        Thread.Sleep(500);
        Write.Line(60, 7, ".");
        Thread.Sleep(500);
        Write.Line(61, 7, ".");
        Thread.Sleep(500);
        if (choice == 4 || choice == 0)
        {
            UI.Keypress(new List<int> { 0, 0, 2, 0, 1, 0, 0 }, new List<string>
            {
                "Probably for the best",
                "",
                Color.CRIT,Color.ENERGY,"","Faeries"," are ","powerful","",
                "",
                Color.DAMAGE,"And ","unpredictable","",
                "",
                "Coward"
            });
            Clearing();
        }
        else if (choice > 4) FindThem();
        if (choice == where)
        {
            UI.Keypress(new List<int> {1,0,2  }, new List<string>
            {
                Color.CRIT,"The ","faery"," is clearly shocked that you caught it",
                "",
                Color.HEALTH, Color.SHIELD,"","Triumphant",", You demand your ","blessing",""
            });
            Console.Clear();
            Write.SetY(15);
            UI.StandardBoxBlank();
            Write.Line(44, 7, Color.SPEAK, "You receive");
            Thread.Sleep(500);
            Write.Line(55, 7, ".");
            Thread.Sleep(500);
            Write.Line(56, 7, ".");
            Thread.Sleep(500);
            Write.Line(57, 7, ".");
            Thread.Sleep(500);
            int bless = Return.RandomInt(1, 101);
            if ( bless< 45)
            {
                int bless1 = Return.RandomInt(0,6);
                Write.Line(59, 7, Color.HEALTH + "A Blessing");
                if (bless1 == 0)
                {                    
                    Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 10" + Color.RESET + " to hit");
                    Create.p.tempHit += 10;
                }
                if (bless1 == 1)
                {
                    Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.CRIT + " 5" + Color.RESET + " to crit");
                    Create.p.tempCrit += 5;
                }
                if (bless1 == 2)
                {
                    Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 2" + Color.RESET + " to damage mitigation");
                    Create.p.tempMit += 2;
                }
                if (bless1 == 3)
                {
                    Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 10" + Color.RESET + " to defence");
                    Create.p.tempDefence += 10;
                }
                if (bless1 == 4)
                {
                    Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.HIT + " 2" + Color.RESET + " to damage");
                    Create.p.tempDamage += 2;
                }
                if (bless1 == 5)
                {
                    Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 25%" + Color.RESET + " to experience");
                    Create.p.tempXp += 0.25f;
                }
                Write.Line(44, 11, "This will last until you " + Color.TIME + "sleep");
                if (Family.cursed) Write.Line(44, 13, "Your Family is no longer " + Color.DAMAGE + "cursed!");
            }
            else if (bless < 55)
            {
                int bless1 = Return.RandomInt(0, 6);
                Write.Line(59, 7, Color.DAMAGE + "A Curse");
                if (bless1 == 0)
                {
                    Write.Line(44, 9, "You" + Color.DAMAGE + " lose" + Color.HIT + " 10" + Color.RESET + " to hit");
                    Create.p.tempHit -= 10;
                }
                if (bless1 == 1)
                {
                    Write.Line(44, 9, "You" + Color.DAMAGE + " lose" + Color.CRIT + " 5" + Color.RESET + " to crit");
                    Create.p.tempCrit -= 5;
                }
                if (bless1 == 2)
                {
                    Write.Line(44, 9, "You" + Color.DAMAGE + " lose" + Color.HIT + " 2" + Color.RESET + " to damage mitigation");
                    Create.p.tempMit -= 2;
                }
                if (bless1 == 3)
                {
                    Write.Line(44, 9, "You " + Color.DAMAGE + "lose" + Color.HIT + " 10" + Color.RESET + " to defence");
                    Create.p.tempDefence -= 10;
                }
                if (bless1 == 4)
                {
                    Write.Line(44, 9, "You " + Color.DAMAGE + "lose" + Color.HIT + " 1" + Color.RESET + " to damage");
                    Create.p.tempDamage -= 1;
                }
                if (bless1 == 5)
                {
                    Write.Line(44, 9, "You " + Color.DAMAGE+"lose" + Color.HIT + " 25%" + Color.RESET + " to experience");
                    Create.p.tempXp -= 0.25f;
                }
                Write.Line(44, 11, "This will last until you " + Color.TIME + "sleep");
            }
            else
            {
                Write.Line(59, 7, Color.DAMAGE + "Nothing");
                Write.Line(44, 9, "The " + Color.CRIT + "faerie" + Color.RESET + " looks at you in disgust");
                Write.Line(44, 11, Color.SPEAK + "'" + Color.CRIT + "Bless" + Color.SPEAK + " yourself, loser'");
                Write.Line(44, 13, "Shrugging, you move on");
            }
            Write.Line(46, 22, Color.SHIELD + "Press any key to continue");
            Console.ReadKey(true);
        }
        else
        {
            Lost();
        }        
        Clearing();
    }

    public static void OldManGuess()
    {        
        UI.Keypress(new List<int> { 0, 0, 2, 0, 0 }, new List<string>
        {
            "As you enter a clearing, you spot an old man sitting on a wooden stump",
            "",
            Color.ENERGY,Color.ENERGY,"He is wearing a wizard's ","hat"," and ","robes"," and mubling something to himself",
            "",
            "He looks up at you, visibly annoyed to have been interupted"
        });
        UI.Choice(new List<int> { 1,0,1,0,1,0,3,0,4 }, new List<string>
        {
            Color.SPEAK," ","'Is there no such thing as privacy anymore?","",
            "",
            Color.SPEAK,"","Let me guess, you heard I was giving away blessings and you just COULDN'T wait till I was finished meditating","",
            "",
            Color.SPEAK,"","Tell you what, I'll give you the opportunity to match wits with me","",
            "",
            Color.SPEAK,Color.HEALTH,Color.SPEAK,"","If you ","","WIN",""," I will grant you a blessing","",
            "",
            Color.SPEAK,Color.DAMAGE,Color.SPEAK,Color.NAME,"","If you ","","LOSE",""," I will curse your entire ","","FAMILY'",""

        }, new List<string> {" Match wits"," Walk away" }, new List<string> {Color.ENERGY+"1"+Color.RESET, Color.MITIGATION + "2" + Color.RESET });
        string choice = Return.Option();
        if (choice == "1") OldManFirstGuess();
        else if (choice == "2")
        {
            UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
            {
                "Probably for the best",
                "",
                "Sometimes, the only winning move is to not play"
            });
            Clearing();
        }
        else OldManGuess();
    }

    private static void OldManFirstGuess()
    {
        int tries = 0;
        int number = Return.RandomInt(1, 11);
        int guess = UI.HowMuch(new List<int> { 0,0,1,0,3 }, new List<string>
        {
            "He looks at you coyly",
            "",
            Color.SPEAK,"","Pick a number between 1 and 10","",
            "",
            Color.SPEAK,Color.HEALTH,Color.SPEAK,"","You have ","",(3-tries).ToString(),""," guesses left",""
        });
        if (guess > 0 && guess < 11) OldManGuessGo(tries, number, guess);
        OldManFirstGuess();       
    }

    static void OldManGuessGo(int tries,int number,int guess)
    {        
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Write.Line(44, 7, Color.SPEAK, "You have chosen");
        Thread.Sleep(300);
        Write.Line(59, 7, ".");
        Thread.Sleep(300);
        Write.Line(60,7, ".");
        Thread.Sleep(300);
        Write.Line(61, 7, ".");
        Thread.Sleep(300);
        if (guess == number)
        {
            Write.Line(63, 7, Color.HEALTH + "Wisely");
            Write.Line(46, 22, Color.DAMAGE + "Press any key to continue");
            Console.ReadKey(true);
            OldManGuessWin();
        }
        else
        {
            Write.Line(63, 7, Color.DAMAGE + "Poorly");
            tries++;
            if (tries < 3)
            {
                if (guess > number) Write.Line(44, 9, Color.HEALTH, "Pick a ", "lower", " number");
                else Write.Line(44, 9, Color.HEALTH, "Pick a ", "higher", " number");
                Write.Line(44, 11, Color.SPEAK+$"You have {Color.HEALTH+(3-tries)+Color.SPEAK} guesses remaining");
                Write.Position(57, 22);
                Console.Write(Color.GOLD);
                guess = Return.Integer();
                Console.Write(Color.RESET);
            }
            if (tries > 2)
            {
                Write.Line(46, 22, Color.DAMAGE + "Press any key to continue");
                Console.ReadKey(true);
                OldManGuessLose();
            }
            else OldManGuessGo(tries, number, guess);
        }        
    }    

    private static void OldManGuessWin()
    {
        UI.Keypress(new List<int> { 0,0,1,0,1,0,1 }, new List<string>
        {
            "The old man looks impressed",
            "",
            Color.SPEAK,"","'I must admit, I took you for a half-Wit","",
            "",
            Color.SPEAK,"","Well, Fair's fair...'","",
            "",
            Color.HEALTH,"","You receive a blessing",""
        });
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        int bless = Return.RandomInt(1, 101);
        if (bless < 45)
        {
            int bless1 = Return.RandomInt(0, 6);
            if (bless1 == 0)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 10" + Color.RESET + " to hit");
                Create.p.tempHit += 10;
            }
            else if (bless1 == 1)
            {
                Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.CRIT + " 5" + Color.RESET + " to crit");
                Create.p.tempCrit += 5;
            }
            else if (bless1 == 2)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 2" + Color.RESET + " to damage mitigation");
                Create.p.tempMit += 2;
            }
            else if (bless1 == 3)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 10" + Color.RESET + " to defence");
                Create.p.tempDefence += 10;
            }
            else if (bless1 == 4)
            {
                Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.HIT + " 2" + Color.RESET + " to damage");
                Create.p.tempDamage += 2;
            }
            else if (bless1 == 5)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 25%" + Color.RESET + " to experience");
                Create.p.tempXp += 0.25f;
            }
            Write.Line(44, 11, "This will last until you " + Color.TIME + "sleep");
            if (Family.cursed) Write.Line(44, 13, "Your Family is no longer " + Color.DAMAGE + "cursed!");
        }
        Write.Line(46, 22, Color.SHIELD + "Press any key to continue");
        Console.ReadKey(true);
        oldManBlessed = true;
        Clearing();
    }
    private static void OldManGuessLose()
    {
        UI.Keypress(new List<int> { 0,0,1,0,2,0,1 }, new List<string>
        {
            "The old man looks at you smugly",
            "",
            Color.SPEAK,"","Just as I suspected, a real dum dum","",
            "",
            Color.SPEAK,Color.NAME,"","If it's any consolation, you won't suffer at all, just your ","","family","",
            "",
            Color.DAMAGE,"","Your family members have been cursed",""
        });
        Family.cursed = true;
        oldManBlessed = true;
        Clearing();
    }

    public static void Lost()
    {
        int progressLoss = Return.RandomInt(1+depth, 4+depth);
        UI.Keypress(new List<int> { 1,0,0,0,1 }, new List<string>
        {
            Color.DAMAGE,"Well, there's no doubt about it, you are ","LOST","",
            "",
            "It takes you quite a while to find your bearings",
            "",
            Color.MONSTER,"You lose ",progressLoss.ToString()," progress"
        });
        progress -= progressLoss;
        Clearing();
    }


    public static void FindSupplies()
    {
        UI.Keypress(new List<int> { 1,0,1,0,2 }, new List<string>
        {
            Color.MONSTER,"You stumble across an ","abandoned camp","",
            "",
            Color.DAMAGE,"From the way things are scattered, it looks like someone has been ","attacked","",
            "",
            Color.GOLD,Color.MONSTER,"It looks like the most of the ","valuables"," have been taken, but you do find some ","camping supplies",""
        });
        UI.Keypress(new List<int> { 1}, new List<string>
        {
            Color.MONSTER,Color.TIME,"You can"," make camp"," again ","today",""
        });
        Create.p.forestCamp = true;
        Clearing();
    }

    public static void FindPotion()
    {
        UI.Keypress(new List<int> { 1, 0, 1, 0, 2 }, new List<string>
        {
            Color.MONSTER,"You stumble across an ","abandoned camp","",
            "",
            Color.DAMAGE,"From the way things are scattered, it looks like someone has been ","attacked","",
            "",
            Color.GOLD,Color.POTION,"It looks like the most of the ","valuables"," have been taken, but you do find a ","potion",""
        });
        Return.RewardPotion();
        Clearing();
    }

    public static void FindHealth()
    {
        UI.Keypress(new List<int> { 1, 0, 1, 0, 2 }, new List<string>
        {
            Color.MONSTER,"You stumble across an ","abandoned camp","",
            "",
            Color.DAMAGE,"From the way things are scattered, it looks like someone has been ","attacked","",
            "",
            Color.GOLD,Color.MONSTER,"It looks like the most of the ","valuables"," have been taken, but you do find a ","full healing potion",""
        });
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.HEALTH,"You refill your"," potion",""
        });
        Create.p.PotionSize = Create.p.MaxPotionSize;
        Clearing();
    }

    public static void FindBiggerHealth()
    {
        int potionGrow = Return.RandomInt(4+depth, 10+depth) ;
        UI.Keypress(new List<int> { 1, 0, 1, 0, 2,0,1 }, new List<string>
        {
            Color.MONSTER,"You stumble across an ","abandoned camp","",
            "",
            Color.DAMAGE,"From the way things are scattered, it looks like someone has been ","attacked","",
            "",
            Color.GOLD,Color.MONSTER,"It looks like the most of the ","valuables"," have been taken, but you do find a ","full healing potion","",
            "",
            Color.HEALTH,"It is ","BIGGER"," than yours!"
        });
        UI.Keypress(new List<int> {2 }, new List<string>
        {
            Color.HEALTH,Color.HEALTH,"Your ","potion ","can now heal up to ",$"{potionGrow} ","more hp!"
        });
        Create.p.MaxPotionSize += potionGrow;
        Clearing();
    }

    public static void ManNeedsHelp()
    {        
        UI.Keypress(new List<int> { 2,0,1 }, new List<string>
        {
            Color.MONSTER,Color.HEALTH,"Your ","search"," is interupted by faint cries for ","help","",
            "",
            Color.NAME,"Investigating you find a ","man"," standing by a caravan looking anxious"
        });
        int job = Return.RandomInt(0, 4);
        ManNeedsHelpChoice(job);        
    }

    private static void ManNeedsHelpChoice(int job)
    {        
        if (job == 0)
            UI.Choice(new List<int> { 1,0,3,0,3 }, new List<string>
            {
                Color.SPEAK,"","Thank god you're here","",
                "",
                Color.SPEAK,Color.ITEM,Color.SPEAK,"","I'm transporting ","","lumber",""," and a giant load fell off my cart","",
                "",
                Color.SPEAK,Color.CRIT,Color.SPEAK,"","Could you help me ","","put it back",""," on the cart?","",
            }, new List<string> { " Help Out", " Walk away" }, new List<string> { Color.DAMAGE + "1" + Color.RESET, Color.MITIGATION + "2" + Color.RESET });
        else if (job == 1)
            UI.Choice(new List<int> { 1, 0, 3 }, new List<string>
            {
                Color.SPEAK,"","Thank god you're here","",
                "",
                Color.SPEAK,Color.CRIT,Color.SPEAK,"","The axle on my wheel broke, could you ","","help me",""," fix it?","",
            }, new List<string> { " Help Out", " Walk away" }, new List<string> { Color.CRIT + "1" + Color.RESET, Color.MITIGATION + "2" + Color.RESET });
        else if (job == 2)
            UI.Choice(new List<int> { 1,0,2,0,3 }, new List<string>
            {
                Color.SPEAK,"","Thank god you're here","",
                "",
                Color.SPEAK,Color.SHIELD,"","My caravan lost it's traction and fell in the ","","River","",
                "",
                Color.SPEAK,Color.HEALTH,Color.SPEAK,"","Could you help me ","","pull",""," it out?","",

            }, new List<string> { " Help Out", " Walk away" }, new List<string> { Color.HEALTH + "1" + Color.RESET, Color.MITIGATION + "2" + Color.RESET });
        else
            UI.Choice(new List<int> { 1,0,2,0,2}, new List<string>
            {
                Color.SPEAK,"","Thank god you're here","",
                "",
                Color.SPEAK,Color.ENERGY,"","I'm completely",""," lost!","",
                "",
                Color.SPEAK,Color.MONSTER,"","Could you point me ","","northward?",""
            }, new List<string> { " Help Out", " Walk away" }, new List<string> { Color.ENERGY + "1" + Color.RESET, Color.MITIGATION + "2" + Color.RESET });
        string choice = Return.Option();
        if (choice == "1")
        {
            int stat = (job == 0) ? Create.p.TotalStrength : (job == 1) ? Create.p.TotalAgility : (job == 2) ? Create.p.TotalStamina : Create.p.TotalIntelligence;
            int successCheck = Return.RandomInt(0, stat);
            Console.Clear();
            Write.SetY(15);
            UI.StandardBoxBlank();
            string actionText = (job == 0) ? "Lifting" : (job == 1) ? "Fixing" : (job == 2) ? "Pulling" : "Navigating";
            string actionColor = (job == 0) ? Color.DAMAGE : (job == 1) ? Color.CRIT : (job == 2) ? Color.HEALTH : Color.ENERGY;
            int actionLength = (job == 0) ?7 : (job == 1) ? 6 : (job == 2) ?7 : 10;
            Write.Line(44 + actionLength, 9, actionColor + actionText+ Color.RESET);
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(1000);
            if (successCheck > 4)
            {
                UI.Keypress(new List<int> { 1, 0, 1, 0, 3 }, new List<string>
                {
                    Color.HEALTH,"You ","SUCCEED","",
                    "",
                    Color.HEALTH,"The ","man"," is beside himself with relief",
                });
                int reward = Return.RandomInt(0, 3);
                if (reward == 0) Return.RewardEquipment(6 + 7*depth, 17+7*depth, Return.RandomInt(6 + depth*2, 10 + depth * 2), Equipment.LISTS[Return.RandomInt(0, Equipment.LISTS.Count)], 4 +depth);
                else if (reward == 1 && Return.RoomForPotions()) Return.RewardPotion(6 + 7 * depth, 17 + 7 * depth, Return.RandomInt(6 + depth * 2, 10 + depth * 2));
                else if(reward == 1 && !Return.RoomForPotions())
                {
                    int reward1 = Return.RandomInt(0, 2);
                    if(reward1 == 0 ) Return.RewardEquipment(6 + 7 * depth, 17 + 7 * depth, Return.RandomInt(6 + depth * 2, 10 + depth * 2), Equipment.LISTS[Return.RandomInt(0, Equipment.LISTS.Count)], 4 + depth);
                    else Return.RewardGold(7 * depth, 17* depth, Return.RandomInt(6 + depth * 2, 10 + depth * 2));
                }
                else if (reward == 2) Return.RewardGold(7 * depth, 17  * depth, Return.RandomInt(6 + depth * 2, 10 + depth * 2));
            }
            else
            {
                UI.Keypress(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
                {
                    Color.DAMAGE, "You ", "FAIL", "",
                    "",
                    Color.NAME, "Mumbling something about incompetence, the ", "man", " walks away",
                    "",
                    Color.MONSTER, "Shrugging, you ", "move on", ""
                });
            }
            Clearing();
        }
        if (choice == "2")
        {
            UI.Keypress(new List<int> {0,0,1 }, new List<string>
            {
                "You shrug. This really isn't your business",
                "",
                Color.MONSTER,"You ","press on",""
            });
            Clearing();
        }
        else ManNeedsHelpChoice(job);
    }

    private static void Roderick()
    {
        UI.Choice(new List<int> { 1, 0, 0, 0, 1, 0, 1, 0, 3 }, new List<string>
        {
            Color.NAME,"You find ","Roderick","!",
            "",
            "He looks pretty rough, as if he hasn't eaten in days",
            "",
            Color.ENERGY , "", "'Thank god you found me. I feel pretty rough and haven't eaten in days!" ,  "",
            "",
            Color.SPEAK,"","Can you help me find my way home?'","",
            "",
            Color.NAME,Color.HEALTH,Color.DAMAGE,"Helping ","Roderick"," find his way home involves leaving the ","forest"," and will reset your ","progress",""
        },
        new List<string> { " Keep going", " Help Roderick find his way home" }, new List<string> { Color.CRIT + "1" + Color.RESET, Color.DAMAGE + "2" + Color.RESET });
        string choice = Return.Option();
        if (choice == "1")
        {
            UI.Keypress(new List<int> { 2,0,1,0,1,0,1 }, new List<string>
            {
                Color.NAME,Color.HEALTH,"You leave ","Roderick"," in the ","forest","",
                "",
                Color.HEALTH, "I mean, you're a ","hero",", right?",
                "",
                Color.NAME , "You don't have time to save every helpless ","person"," you come across",
                "",
                Color.GOLD, "Go get your ","lootz",""
            });
            GameState.findJob.status = JobStatus.Complete;
            Clearing();
        }
        else if (choice == "2")
        {
            UI.Keypress(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
            {
                Color.NAME,"You guide ","Roderick"," back to town",
                "",
                Color.HEALTH, "I mean, you're a ","hero",", right?",
                "",
                Color.HEALTH , "That's what ","heroes"," do"
            });
            GameState.findJob.status = JobStatus.Complete;
            GameState.findJob.ButtonCheck();
            progress = 0;
            Utilities.ToTown();
        }
        else Roderick();
    }

    private static void Combat()
    {
        int amount = Return.RandomInt(depth, 3+depth);
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };
        for (int i = 0; i < amount; i++)
        {
            List<Monster> monsters = Dungeon.forestSummon[depth];
            Monster summon = monsters[Return.RandomInt(0, monsters.Count)];
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

    public static void Reward()
    {
        UI.Keypress(new List<int> {  }, new List<string>
        {
            Color.MONSTER,Color.HEALTH,"You have reached a new ","Depth Layer"," of ","Forest","!",
            "",
            Color.MONSTER,Color.HEALTH,"You will now start here every time you go to ","explore"," the ","Forest","",
            "",
            Color.XP,"You gain ",""," experience"
        });
        progress = 0;
        depth++;
        firstTime = true;
        Utilities.ToTown();
    }
}