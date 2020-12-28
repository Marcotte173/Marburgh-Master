using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class LocalGossip
{
    public static bool startedFight;
    public static bool firstSong = true;
    public static int giveSpeech = 0;
    public static int listenBard = 0;
    public static bool toldPotionDeath;
    public static bool toldBartenderPreference;
    public static bool caveTold;
    public static bool bardFound;

    public static void Menu()
    {
        Console.Clear();
        if (GameState.phase2b && giveSpeech == 0 && Create.p.Reputation > 60) Button.giveSpeechButton.active = true;
        else Button.giveSpeechButton.active = false;
        if ((GameState.phase1b||GameState.phase2b) && Create.p.Reputation > 49) Button.gossipButton.active = true;
        else Button.gossipButton.active = false;
        if ((GameState.phase1b || GameState.phase2b) && listenBard>0&& bardFound) Button.bardButton.active = true;
        else Button.bardButton.active = false;

        Utilities.Buttons(Button.listOfLocalsOptions);
        if(Create.p.Reputation < 50)
        {
            UI.Choice(new List<int> {1,0,0 }, new List<string>
            {
                Color.NAME,"The ","locals"," are surprisingly quiet",
                "",
                "You get the distint impression you're being watched",
            },
            Button.list1, Button.button1);
        }
        else
        {
            UI.Choice(new List<int> { 1,0,0}, new List<string>
            {
                Color.NAME,"The locals are chatting happily",
                "",
                "They motion to an empty chair as you approach",
            },
            Button.list1, Button.button1);
        }        
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (Create.p.Reputation < 50 && Return.RandomInt(0, 5) < 2) LocalStartsFight();
        else
            {
            if (choice == "s" && Button.startFightButton.active) Fight();
            else if (choice == "t" && Button.gossipButton.active) Gossip();
            else if (choice == "g" && Button.giveSpeechButton.active) Speech();
            else if (choice == "l" && Button.bardButton.active) Bard();
            else if (choice == "9") CharacterSheet.Display();
            else if (choice == "0") Tavern.Menu();
            Menu();
        }        
    }

    public static void Bard()
    {
        if(firstSong)
        UI.Keypress(new List<int> {0,0,1,0,3,0,1,0,1,0,1 }, new List<string>
        {
            "You grab a seat and settle in",
            "",
            Color.NAME,"","Roderic"," smiles and gets ready",
            "",
            Color.SPEAK,Color.NAME,Color.SPEAK,"","'Before I begin, I just want to thank the ","", Family.lastName,"","s for saving me","",
            "",
            Color.SPEAK,"","I would be dead, if not for them'","",
            "",
            Color.CRIT,"","And then the whole bar clapped","",
            "",
            Color.HIT,"You gain"," 5 ","reputation"
        });
        firstSong = false;
        Song();
    }

    private static void Speech()
    {
        UI.Keypress(new List<int> { }, new List<string>
        {
            Color.SPEAK,Color.NAME,Color.SPEAK,"","'Hey, it looks like " ,"",Create.p.Name,""," has something to say! Pipe down and listen!","",
            "",
            "Everytone gathers around and listens what you have to say",
            "",
            "You clear your throat and begin"
        });
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Write.Line(44, 7, Color.SHIELD, "ORATING");
        Thread.Sleep(300);
        Write.Line(51, 7, ".");
        Thread.Sleep(300);
        Write.Line(52, 7, ".");
        Thread.Sleep(300);
        Write.Line(53, 7, ".");
        Thread.Sleep(500);
        int bonus = (Create.p.Reputation - 60)/10;
        if(Return.StatCheck(Create.p.Intelilgence + bonus, 6))
        {
            UI.Keypress(new List<int> {2,0,1  }, new List<string>
            {
                Color.NAME,Color.MONSTER,"The ","locals"," look at you with ","interest","",
                "",
                Color.NAME,"",Name.list[Return.RandomInt(0,Name.list.Count)]," gets up and approaches you",
            });
            if(GameState.currentJob!= GameState.protectJob && GameState.currentJob != GameState.findJob && GameState.currentJob.status == JobStatus.Issued)
            {
                UI.Keypress(new List<int> { 2, 0, 1,0,3,0,2 }, new List<string>
                {
                    Color.SPEAK,Color.HEALTH,"","Wow, you are a real ","","Hero","",
                    "",
                    Color.SPEAK,"","I want to help in any way that I can","",
                    "",
                    Color.SPEAK,Color.NAME,Color.SPEAK,"","I hear you're doing a job for","",GameState.currentJob.npc.name,"",". Maybe I can do it for you","",
                    "",
                    Color.NAME,Color.HEALTH,"Your job for ",GameState.currentJob.npc.name," has been ","completed",""
                });
            }
            else
            {
                UI.Keypress(new List<int> { 2, 0, 1,0,4,0,2 }, new List<string>
                {
                    Color.SPEAK,Color.HEALTH,"","Wow, you are a real ","","Hero","",
                    "",
                    Color.SPEAK,"","I want to help in any way that I can","",
                    "",
                    Color.SPEAK,Color.POTION,Color.SPEAK,Color.HEALTH,"","Here is a ","","potion",""," that I found in the ","","forest",
                    "",
                    Color.NAME,Color.HEALTH,"I'll also tell ","everyone"," what a ","hero"," you are",
                });
                Return.RewardPotion(Return.RandomInt(5,11));
            }            
            giveSpeech = 3;
        }
        else
        {
            UI.Keypress(new List<int> { 2, 0, 0 ,0,1,0,1}, new List<string>
            {
                Color.NAME,Color.MONSTER,"The ","locals"," look at you with ","contempt","",
                "",
                "Silence reigns in the bar",
                "",
                Color.MONSTER,"You leave, as you're getting ","uncomfortable","",
                "",
                Color.BOSS,"","You doubt that they are going to listen to you again",""
            });
            giveSpeech = 99;
            Tavern.Menu();
        }
    }

    public static void Song()
    {
        listenBard = 3;
        UI.Keypress(new List<int> { 1, 0, 0 }, new List<string>
        {
            Color.NAME,"","Roderic"," begins performing",
            "",
            "You watch in rapt attention"
        });
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Write.Line(44, 7, Color.SHIELD, "LISTENING");
        Thread.Sleep(300);
        Write.Line(53, 7, ".");
        Thread.Sleep(300);
        Write.Line(54, 7, ".");
        Thread.Sleep(300);
        Write.Line(55, 7, ".");
        Thread.Sleep(500);
        int reaction = Return.RandomInt(0,5);
        if(reaction == 0)
        {
            UI.Keypress(new List<int> {1,0,1 }, new List<string>
            {
                Color.NAME,"You get swept up in ","Roderic's"," song!",
                "",
                Color.CRIT,"Without a care in the world, you start ","bellowing"," along",
            });
            UI.Keypress(new List<int> {1,0,1,0,1,0,1 }, new List<string>
            {
                Color.SHIELD,"When the ","song"," finishes, there is a hush in the bar",
                "",
                Color.NAME,"","Roderic"," looks impressed",
                "",
                Color.CRIT,"","Everyone in the bar starts clapping","",
                "",
                Color.HEALTH,"You are ","invigorated"," by the experience!"
            });
            Console.Clear();
            Write.SetY(15);
            UI.StandardBoxBlank();
            int bless1 = Return.RandomInt(0, 5);
            if (bless1 == 0)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 5" + Color.RESET + " to hit");
                Create.p.tempHit += 10;
            }
            else if (bless1 == 1)
            {
                Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.CRIT + " 2" + Color.RESET + " to crit");
                Create.p.tempCrit += 5;
            }
            else if (bless1 == 2)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 1" + Color.RESET + " to damage mitigation");
                Create.p.tempMit += 2;
            }
            else if (bless1 == 3)
            {
                Write.Line(44, 9, "You " + Color.HEALTH + "gain" + Color.HIT + " 5" + Color.RESET + " to defence");
                Create.p.tempDefence += 10;
            }
            else if (bless1 == 4)
            {
                Write.Line(44, 9, "You" + Color.HEALTH + " gain" + Color.HIT + " 2" + Color.RESET + " to damage");
                Create.p.tempDamage += 2;
            }
            Write.Line(44, 11, "This will last until you " + Color.TIME + "sleep");
            if (!Create.p.CanExplore) Write.Line(44, 13, "You can " + Color.DAMAGE + "Explore" + Color.RESET + " again!" );            
            Write.Line(46, 22, Color.SHIELD + "Press any key to continue");
            Console.ReadKey(true);
            Tavern.Menu(); 
        }
        else if (reaction == 4)
        {
            UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
            {
                Color.NAME,"You get swept up in ","Roderic's"," song!",
                "",
                Color.CRIT,"Without a care in the world, you start ","bellowing"," along",
            });
            UI.Keypress(new List<int> { 1, 0, 2, 0, 1 }, new List<string>
            {
                Color.DAMAGE,"People are ","NOT"," feeling it",
                "",
                Color.NAME,Color.MONSTER,"","Roderic"," stops singing, with an ","annoyed"," look on his face",
                "",
                Color.NAME," ",Name.list[Return.RandomInt(0,Name.list.Count)],", a known trouble maker, stands up and points at you"
            });
            Fight();
        }
        else
        {
            UI.Keypress(new List<int> {1,0,1,0,1,0,0 }, new List<string>
            {
                Color.NAME,"","Roderick"," finishes his song",
                "",
                Color.TIME,"Many ","locals"," have tears in their eyes",
                "",
                Color.MONSTER,"You are strangely ","unmoved","",
                "",
                "May you'll feel differently next time"
            });
            Tavern.Menu();
        }
    }

    public static void Gossip()
    {
        UI.Keypress(new List<int> {0,0,1 }, new List<string>
        {
            "You grab a seat and settle in",
            "",
            Color.NAME,"You start chatting with ",Name.list[Return.RandomInt(0,Name.list.Count)]," and see what you can learn"
        });
        //if(Create.p.Reputation > 80 && !caveTold)
        //{
        //
        //    caveTold = true;
        //    Tavern.Menu();
        //}
        if(Create.p.Reputation >60)
        {
            int gossip = Return.RandomInt(0, 4);
            if(gossip == 0 && !toldPotionDeath)
            {
                UI.Keypress(new List<int> {4,0,1,0,3  }, new List<string>
                {
                   Color.SPEAK,Color.DEATH,Color.SPEAK,Color.DEATH,"","I hear the ","","Necromancer's",""," Chambers are guarded by a ","","death fog","",
                   "",
                   Color.SPEAK,"Nothing alive can pass",
                   "",
                   Color.SPEAK,Color.DEATH,Color.SPEAK,"","The ","","dead",""," on the other hand....",""
                });
                Tavern.Menu();
            }
            else if(gossip == 1 && !toldBartenderPreference)
            {
                string color = (GameState.bartender1.favored == FavoredTrait.Agility) ? Color.HIT : (GameState.bartender1.favored == FavoredTrait.Stamina) ? Color.HEALTH : (GameState.bartender1.favored == FavoredTrait.Intelligence) ? Color.ENERGY : Color.DAMAGE;
                UI.Keypress(new List<int> { 4, 0, 1, 0, 3 }, new List<string>
                {
                   Color.SPEAK,Color.NAME,Color.SPEAK,color,"","I hear that ","",GameState.bartender1.name,""," is attracted to someone with high ","",GameState.bartender1.favored.ToString(),""
                   
                });
                Tavern.Menu();
            }            
        }
        int gossip1 = Return.RandomInt(0, 4);
        if (gossip1 == 0)
        {
            UI.Keypress(new List<int> { 4 }, new List<string>
            {
               Color.NAME,Color.NAME,Color.MONSTER,Color.NAME,"You learn that ",Name.list[Return.RandomInt(0,Name.list.Count)]," and ",Name.list[Return.RandomInt(0,Name.list.Count)]," are having an ","affair"," and ",Name.list[Return.RandomInt(0,Name.list.Count)]," has no idea"
            });
        }
        else if (gossip1 == 1 && GameState.phase2b)
        {
            UI.Keypress(new List<int> { 2}, new List<string>
            {
                Color.NAME,Color.ITEM,"You learn that ", GameState.currentJob.npc.name," the ",$"{GameState.currentJob.npc.job} shop owner", " is looking for help"
            });
        }
        else if (gossip1 == 2)
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have a good time chatting but don't learn anything of interest"
            });
        }
        else
        {
            UI.Keypress(new List<int> { 3 }, new List<string>
            {
                Color.NAME,Color.DAMAGE,Color.NAME,"You learn that ",Name.list[Return.RandomInt(0,Name.list.Count)]," does ","NOT"," like ",Name.list[Return.RandomInt(0,Name.list.Count)], ""
            });
        }
    }

    public static void Fight()
    {
        UI.Keypress(new List<int> { 1,0,1 }, new List<string>
        {
            Color.SPEAK,"","'Hey you, let's fight'","",
            "",
            Color.DAMAGE,"You roll up your sleeves, those are ","fighting words"," if ever your heard them"
        });
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Write.Line(44, 7, Color.DAMAGE, "Bang");
        Thread.Sleep(300);
        Write.Line(48, 7, ".");
        Thread.Sleep(300);
        Write.Line(49, 7, ".");
        Thread.Sleep(300);
        Write.Line(50, 7, ".");
        Thread.Sleep(300);
        Write.Line(52, 7, Color.DAMAGE, "Pow");
        Thread.Sleep(300);
        Write.Line(55, 7, ".");
        Thread.Sleep(300);
        Write.Line(56, 7, ".");
        Thread.Sleep(300);
        Write.Line(57, 7, ".");
        Thread.Sleep(300);
        Write.Line(59, 7, Color.DAMAGE, "Smash");
        Thread.Sleep(300);
        Write.Line(64, 7, ".");
        Thread.Sleep(300);
        Write.Line(65, 7, ".");
        Thread.Sleep(300);
        Write.Line(66, 7, ".");
        Thread.Sleep(500);
        if (Return.StatCheck(Create.p.TotalStrength, 4 ))
        {
            int repGain = Return.RandomInt(5, 11);
            UI.Keypress(new List<int> { 1,0,0,0,1 }, new List<string>
            {
                Color.HEALTH,"You emerge ","victorious!","",
                "",
                "Everyone is impressed by how tough you are",
                "",
                Color.HIT,"You gain ",repGain.ToString()," reputation"
            });
            Create.p.RepAdd(repGain);
            Tavern.Menu();
        }
        else
        {
            if (startedFight)
            {
                UI.Keypress(new List<int> { 2, 0, 1, 0, 1 }, new List<string>
                {
                    Color.XP,Color.DAMAGE,"You wake up at ","home"," covered in ","bruises","",
                    "",
                    Color.XP,"The last thing you remember is being told not to show your face around the ","tavern"," anymore",
                    "",
                    Color.DAMAGE,"You are at ","1"," health",
                });
                Create.p.Health = 1;
                House.Menu();
            }            
            else
            {
                int repGain = Return.RandomInt(3,7);
                UI.Keypress(new List<int> { 1, 0, 0, 0, 1, 0, 1 }, new List<string>
                {
                    Color.DAMAGE,"You wake up at home covered in ","bruises","",
                    "",
                    "That was not a good idea",
                    "",
                    Color.DAMAGE,"You are at ","1"," health",
                    "",
                    Color.HIT,"You lose ",repGain.ToString()," reputation"
                });
                Create.p.RepAdd(-repGain);
                Create.p.Health = 1;
                House.Menu();
            }            
        }
    }

    public static void StartFight()
    {
        UI.Keypress(new List<int> { 2}, new List<string>
        {
            Color.NAME,Color.MONSTER,"You walk up to the biggest ","local"," you can find and ","pour a beer"," on their head"
        });
        startedFight = true;
        Fight();
    }

    public static void LocalStartsFight()
    {
        UI.Keypress(new List<int> { 0,0,1 }, new List<string>
        {
            "Before you can react you notice a small commotion",
            "",
            Color.NAME," ",Name.list[Return.RandomInt(0,Name.list.Count)],", a known trouble maker, points at you"
        });
        startedFight = false;
        Fight();
    }
}