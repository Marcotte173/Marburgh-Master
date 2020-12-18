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
    public Bartender(string job)
    :base(job)
    {
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
        else if (choice == "a" && Button.tavernJobButton.active) Job();
        else if (choice == "c" && Button.chatUpBartenderButton.active) ChatUp();
        else if (choice == "w" && Button.bartenderInfoButton.active) Help();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Tavern.Menu();
        Menu();
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
        
    }

    private void Job()
    {
        
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
            if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.GOLD, "Would you like to buy a beer for ", $"40", " gold?" })) BuyBeer();
        }
        else if (choice == "r" && Button.roundButton.active)
        {
            if (Return.HaveGold(600))
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.ITEM, "Would you like to buy everyone in the bar a round for ", $"600", " gold?" }))
                {
                    Create.p.Gold -= 600;
                    int repBoost = Return.RandomInt(4, 9);
                    Create.p.Reputation += repBoost;
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
        if (Return.HaveGold(40))
        {
            Create.p.Gold -= 40;
            Create.p.drinks++;
            Room.ActionWait(new List<int> { 0, 1, 0 }, new List<string>
                {
                    "",
                    Color.ENERGY,"You feel ",Create.p.drinkText[Create.p.drinks],"",
                    "",
                }, Color.HEALTH+"Drinking"+Color.RESET, "Ahhh");
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
                    UI.Keypress(new List<int> { 1,0,2,0,2,0,2,0,0 }, new List<string>
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
                    }) ;
                }
                if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.GOLD, "Would you like to buy another beer for ", $"40", " gold?" })) BuyBeer();
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