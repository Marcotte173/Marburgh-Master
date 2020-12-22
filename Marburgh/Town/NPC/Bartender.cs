using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bartender:NPC
{
    public NPC npc;
    static List<string> friendly = new List<string> {"'If it isn't my favorite customer! How can I help?'" };
    static List<string> neutral = new List<string> {"'How can I help you?'" };
    static List<string> unfriendly = new List<string> {"'Oh. It's you. What do you want?'" };
    static string reactionToBartender;
    public int fallingForYou = 0;

    public Bartender(string job)
    :base(job)
    {
        favored = (FavoredTrait)Return.RandomInt(0, 4);
        reactionToBartender = (friendlyness == 2) ? "Not exactly a friend, but at least you can be reasonably sure your drink won't be poisoned" : (friendlyness == 3) ? "Finally, a friendly face" : (friendlyness == 1) ? "*sigh*" : "Oh crap";
    }

    public void Menu()
    {
        Console.Clear();
        Utilities.Buttons(Button.listOfBartenderOptions);
        UI.Choice(new List<int> { 0,2,0,0,0,1,0,0,0,1 }, new List<string>
        {
            "",
            Color.NAME,Color.CLASS,"It appears that ", name, " the ", race, " is working today",
            "",
            reactionToBartender,
            "",
            Color.NAME,"As you sidle up to the bar, ",name,$" looks up briefly from the very dirty mug {pronoun1c} trying to clean",
            "",
            "",
            "",
            Color.SPEAK, "", (friendlyness == 3)?friendly[Return.RandomInt(0,friendly.Count)]:(friendlyness == 1)?unfriendly[Return.RandomInt(0,unfriendly.Count)]:(friendlyness ==2)?neutral[Return.RandomInt(0,neutral.Count)]:"'Get out. I will not ask again'",""
        },
        Button.list1, Button.button1);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "o" && Button.drinkButton.active) OrderDrink();       
        else if (choice == "t" && Button.chatUpBartenderButton.active)
        {
            if (Create.p.flirted)
            {
                UI.Keypress(new List<int> { 2}, new List<string>
                {
                    Color.SPEAK,Color.TIME,"","I'm sorry, it got really busy, maybe I can chat ","","tomorrow",""
                });
            }
            else ChatUp();
        }
        else if (choice == "w") Help();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Tavern.Menu();
        Menu();
    }

    public void Mate()
    {
        Console.Clear();
        Utilities.Buttons(Button.listOfMateOptions);
        UI.Choice(new List<int> { 0, 1, 0, 1 }, new List<string>
        {
            "",
            Color.NAME,"", name, $" smiles when {pronoun1d} you",
           "",
           Color.SPEAK,"","'Hey, do you need anything?'",""
        },
        Button.list1, Button.button1);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "w") Help();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") House.Menu();
        else if (choice == "a" && Button.drinkButton1.active) BuyBeer();
    }


    private void Help()
    {
        if (GameState.phase3)
        {

        }
        else if (GameState.phase2b&& Create.p.Level <4)
        {
            UI.Keypress(new List<int> { 3,0,2,0,3 }, new List<string>
            {
                Color.SPEAK,Color.DEATH,Color.SPEAK,"","This ","Necromancer","","is easily the greatest threat you've faced so far",
                "",
                Color.SPEAK,Color.HEALTH,"","Short of finding another stupidly named town to live in... I think your best bet is to","","buff up ","",
                "",
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"","Visit the '","","Forest",""," on the east side of town. Oh, and bring a weapon",""
            });
        }
        else if(GameState.phase2b)
        {
            UI.Keypress(new List<int> { 3, 0, 1, 0, 2 }, new List<string>
            {
                Color.SPEAK,Color.DEATH,Color.SPEAK,"","This ","Necromancer","","is easily the greatest threat you've faced so far",
                "",
                Color.SPEAK,"","On the bright side, you're no slouch yourself","",
                "",
                Color.SPEAK,Color.MONSTER,"","Get in there and","","kick his ass",""
            });
        }
        else if (GameState.phase1b)
        {
            UI.Keypress(new List<int> { 2,0,2,0,1 }, new List<string>
            {
                Color.SPEAK,Color.MONSTER,"","'Well, now that you know the REAL location of the ","","Savage Orc","",
                "",
                Color.SPEAK,Color.MONSTER,"","I think your mission is clear... ","","Kill him ","",
                "",
                Color.SPEAK,"","He'll never see it coming'",""
            });
        }
        else if (GameState.firstBossDead)
        {
            UI.Keypress(new List<int> { 2,0,3,0,1 }, new List<string>
            {
                Color.SPEAK,Color.MONSTER,"","'Well you managed to kill the ","","Orc's Lietenant","",
                "",
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"","I think you want to go back in there and make sure you've found any ","","Townspeople ","","that needs saving","",
                "",
                Color.SPEAK,"","Never hurts to be thorough'",""
            });
        }
        else if(Button.dungeon1aButton.active)
        {
            UI.Keypress(new List<int> { 3,0,3,0,1 }, new List<string>
            {
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"","'Enter the ","","Savage Orc","","s lair, and kill him","",
                "",
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"","While you're at it, try and save as many",""," Townspeople ","","as you can","",
                "",
                Color.SPEAK,"","I mean, you WERE paying attention, right?'",""
            });
        }
        else 
        {
            UI.Keypress(new List<int> { 4, 0, 1 }, new List<string>
            {
                Color.SPEAK,Color.BOSS,Color.SPEAK,Color.MONSTER,"","'Well, I hear that anyone interested in trying to take on the ","","Orc","","'s army has been asked to report to the ","","Combat Arena","",
                "",
                Color.SPEAK,"","You should try there'",""
            }) ;
        }
    }

    private void ChatUp()
    {
        if (fallingForYou < 10)
        {
            if (Create.p.Reputation <= 40 || friendlyness == 1)
            {
                UI.Keypress(new List<int> { }, new List<string>
            {
                Color.NAME,Color.NAME,$"You can tell by the look on ",pronoun3," face that ",pronoun1c," not interested",
                "",
                $"Maybe some other time. Or better yet, some other person"
            });
            }
            else
            {
                Utilities.Buttons(Button.listOfFlirtOptions);
                if (friendlyness == 3)
                {
                    UI.Choice(new List<int> { 0, 1, 0, 1 }, new List<string>
                {
                    "",
                    Color.SPEAK,"","'If I didn't know better","",
                    "",
                    Color.SPEAK,"","I'd say you're flirting with me!'","",
                },
                    Button.list1, Button.button1);
                }
                else
                {
                    UI.Choice(new List<int> { 0, 1, 0, 1 }, new List<string>
                {
                    "",
                    Color.SPEAK,"","'Go ahead","",
                    "",
                    Color.SPEAK,"","Impress Me'","",
                },
                    Button.list1, Button.button1);
                }
            }
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "f" && Button.flexButton.active) Impress(Create.p.TotalStrength, FavoredTrait.Strength, Create.p.Reputation);
            else if (choice == "s" && Button.sleightOfHand.active) Impress(Create.p.TotalAgility, FavoredTrait.Agility, Create.p.Reputation);
            else if (choice == "d" && Button.shotsButton.active) Impress(Create.p.TotalStamina, FavoredTrait.Stamina, Create.p.Reputation);
            else if (choice == "r" && Button.languageButton.active) Impress(Create.p.TotalIntelligence, FavoredTrait.Intelligence, Create.p.Reputation);
            else if (choice == "9") CharacterSheet.Display();
            else if (choice == "0") Tavern.Menu();
            Menu();
        }
        else
        {
            UI.Keypress(new List<int> { 1,0,1,0,1}, new List<string>
            {
                Color.SPEAK,"","'Why don't we stop beating around the bush. I like you, you like me, we should live together'",$"",
                "",
                Color.NAME,"Not really knowing what else to say, you agree. ",name," moves into your house",
                "",
                Color.HEALTH,"You go home to ahem... ","celebrate",""
            });
            Button.hangoutButton.active = true;
            Button.drinkButton1.active = true;
            Button.chatUpBartenderButton.active = false;
            House.mate = this;
            if (GameState.currentBartender == GameState.bartender1) GameState.bartender1 = new Bartender("Bartender");
            else if (GameState.currentBartender == GameState.bartender2) GameState.bartender2 = new Bartender("Bartender");
            else if (GameState.currentBartender == GameState.bartender3) GameState.bartender3 = new Bartender("Bartender");
            House.Sleep();
            House.Menu();
        }
    }

    private void Impress(int value,FavoredTrait favoredTrait,int rep)
    {
        Create.p.flirted = true;
        int impress = Return.RandomInt(1,101);
        if ((rep > 80 && impress <= 20 + value * 3) || (rep > 60 && impress <= 20 + value * 2) || (rep > 40 && impress <= 20 + value * 1))
        {
            if (favoredTrait == favored)
            {
                UI.Keypress(new List<int> { 1,0,1,0,2 }, new List<string>
                {
                    Color.NAME,"",name,$" looks astonished",
                    "",
                    Color.SPEAK,"","'You are AMAZING! I'm going to tell everybody!'","",
                    "",
                    Color.XP,Color.CRIT,"Other ","customers"," hear your interaction and look impressed, you gain ","10"," reputation"
                });
                Create.p.RepAdd(10);
                fallingForYou += 2;
                if (fallingForYou > 4) friendlyness = 3;
            }
            else
            {
                UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
            {
                Color.NAME,"",name,$" looks impressed",
                "",
                Color.SPEAK,"","'Looks like there's more to you than meets the eye'",""
            });
                fallingForYou += 2;
                if (fallingForYou > 4) friendlyness = 3;
            }
        }
        else
        {
            if(favoredTrait == favored)
            {
                UI.Keypress(new List<int> { 1, 0,1,0, 2 }, new List<string>
                {
                    Color.NAME,"",name,$" rolls {pronoun3} eyes",
                    "",
                    Color.SPEAK,"","'Are you serious? if you're going to waste my time, DON'T BOTHER'","",
                    "",
                    Color.XP,Color.CRIT,"Other ","customers"," hear your interaction and start snickering, you lose ","5"," reputation"
                });
                Create.p.RepAdd(-5);
            }    
            else
            {
                UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
            {
                Color.NAME,"",name,$" rolls {pronoun3} eyes",
                "",
                Color.SPEAK,"","'If you don't mind, I'm kind of busy here'",""
            });
            }            
        }
    }    

    private void OrderDrink()
    {
        Console.Clear();
        Utilities.Buttons(Button.ListOfBuyDrinkOptions);        
        UI.Choice(new List<int> { 0,1,0,1,0,0 }, new List<string>
        {
            "",
            Color.SPEAK,"","'Drinks, I have'","",
            "",
            Color.SPEAK,"","'What can I get for you?'","",
            "",
            "[0] to return"
        },
        Button.list1, Button.button1);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "b" && Button.beerButton.active)
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.GOLD, "Would you like to buy a beer for ", $"40", " gold?" }))
            {
                if (Return.HaveGold(40))
                {
                    Create.p.Gold -= 40;
                    BuyBeer();
                }
                else
                {
                    UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have the money!"
                });
                }
            }
        }
        else if (choice == "r" && Button.roundButton.active)
        {
            if (Return.HaveGold(600))
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.ITEM, "Would you like to buy everyone in the bar a round for ", $"600", " gold?" }))
                {
                    Create.p.Gold -= 600;
                    int repBoost = Return.RandomInt(4, 9);
                    Create.p.RepAdd(repBoost);
                    UI.Keypress(new List<int> { 0, 1, 0, 1, 0, 0, 2 }, new List<string>
                    {
                        "",
                        Color.NAME,"Everyone cheers as ", GameState.currentBartender.name, " starts handing out drinks to everyone",
                        "",
                        Color.NAME,"Let's hear it for ", Create.p.Name, "!",
                        "",
                        "",
                        Color.HIT,Color.HIT,"Your ", "reputation ","is increased by ",repBoost.ToString(),"! "
                    });
                }
            }
            else
            {
                UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have the money!"
                });
            }
        }
        else if (choice == "m") MakeOwn();
        else if (choice == "0") Tavern.Menu();
        Menu();
    }

    private void BuyBeer()
    {
        Create.p.drinks++;
        Room.ActionWait(new List<int> { 0, 1, 0 }, new List<string>
        {
            "",
            Color.ENERGY,"You feel ",Create.p.drinkText[Create.p.drinks],"",
            "",
        }, Color.HEALTH + "Drinking" + Color.RESET, "Ahhh");
        if (Create.p.drinks > 4)
        {
            UI.Keypress(new List<int> { 1, 0, 1, 0, 3 }, new List<string>
                {
                    Color.BLOOD,"","Uh Oh",", that was one too many",
                    "",
                    Color.DEATH,"You feel the room ","spinning"," as you slump back in your stool",
                    "",
                    Color.BLOOD,Color.XP,Color.HEALTH,"Your last thought as you ","pass out", " is that you hope someone can help you get ","home"," to your nice warm ","bed",""
                });
            House.Sleep();
            House.Menu();
        }
        else
        {
            if (Create.p.drinks % 2 == 0)
            {
                Create.p.tempAgility--;
                Create.p.tempIntelligence--;
                Create.p.tempStrength += 2;
                Create.p.Update();
                UI.Keypress(new List<int> { 1, 0, 2, 0, 2, 0, 2, 0, 0 }, new List<string>
                {
                    Color.DEATH,"You are more ","inebriated"," than before",
                    "",
                    Color.DAMAGE,Color.DAMAGE,"Your ","Strength"," increases by ","2","",
                    "",
                    Color.HIT,Color.HIT,"Your ","Agility"," decreases by ","1","",
                    "",
                    Color.ENERGY,Color.ENERGY,"Your ","Intelligence"," decreases by ","1","",
                    "",
                    "This will last until you sleep it off"
                });
            }
            if(GameState.location != Location.House)if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.GOLD, "Would you like to buy another beer for ", $"40", " gold?" })) BuyBeer();
        }    
    }

    private void MakeOwn()
    {
        Console.Clear();
        if (GameState.phase2b || GameState.phase3)
        {
            Utilities.Buttons(Button.ListOfBuyDrinkOptions);
            UI.Choice(new List<int> { 0, 2, 0, 0, 0, 1, 0, 0, 0, 1 }, new List<string>
            {

            },
            Button.list1, Button.button1);
        }
        else
        {
            UI.Keypress(new List<int> { 0, 1, 0, 1 }, new List<string>
            {
                "",
                Color.SPEAK,"", "'I'm sorry, but I don't know you very well and we're still rebuilding", "",
                "",
                Color.SPEAK,"", "If you make a mistake, my whole bar could go up. Maybe Later'", ""
            });
        }
        
    }
}