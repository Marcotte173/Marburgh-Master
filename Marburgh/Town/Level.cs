using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level
{
    public static int[] xpRequired = new int[] { 0, 30, 75, 125, 185, 255, 315, 385, 475, 575, 700, 830, 1000 };
    public static void Menu()
    {
        Console.Clear();
        {
            GameState.location = Location.Level;
            if (UI.Confirm(new List<int> { 1, 1 }, new List<string>
                {
                    Color.SPEAK, "", "The Level Master is meditating. He looks up at you.","",
                    Color.SPEAK, "",  "'Are you here to level up?'", ""
                }))
            {
                if(Create.p.Level == 5)
                {
                    UI.Keypress(new List<int> { 1 }, new List<string>
                        {
                        
                        Color.XP, "You are currently at"," MAX ","level",
                        });
                    Utilities.ToTown();
                }
                else if (Create.p.XP < Create.p.XPNeeded[Create.p.Level])
                {
                    UI.Keypress(new List<int> { 0, 1, 1 }, new List<string>
                        {
                        "He looks at you thoughtfully.",
                        Color.SPEAK, "","'Hmmm... You're not QUITE ready yet'","",
                        Color.SPEAK, "","'Come back when you are more experienced'",""
                        });
                    Utilities.ToTown();
                }                    
                else LevelUp(Create.p);
            }
            else
            {
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                Color.SPEAK, "","Quit wasting my time!",""
                });
                Utilities.ToTown();
            }
                
        }
    }

    private static void LevelUp(Player p)
    {
        Console.Clear();
        p.XP -= p.XPNeeded[p.Level];
        p.Level ++;
        UI.Keypress(new List<int> {1,0,2,0,2,0,2,0,2 }, new List<string>
        {
            Color.XP, "Congrats! You are level ", $"{p.Level}", "!",
            "",
            Color.DAMAGE,Color.DAMAGE,"Your ","Strength"," is increased by ", $"{p.StrengthLvl[p.Level]}","",
            "",
            Color.HIT, Color.HIT,"Your ","Agility"," is increased by ", $"{p.AgilityLvl[p.Level]}","",
            "",
            Color.HEALTH,Color.HEALTH,"Your ","Stamina"," is increased by ", $"{p.StaminaLvl[p.Level]}","",
            "",
            Color.ENERGY,Color.ENERGY,"Your ","Intelligence"," is increased by ", $"{p.IntelligenceLvl[p.Level]}",""
        }) ;
        p.Strength += p.StrengthLvl[p.Level];
        p.Agility += p.AgilityLvl[p.Level];
        p.Stamina += p.StaminaLvl[p.Level];
        p.Intelilgence += p.IntelligenceLvl[p.Level];
        p.Update();
        if (p.Level == 2)
        {
            if (p.pClass == PlayerClass.Mage)
            {
                Button.fireBlastButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "You have learned ", "Fireblast", "!",
                });
            }
            else if (p.pClass == PlayerClass.Rogue)
            {
                Button.stunButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.STUNNED, "You have learned ", "Stun", "!",
                });
            }
            else if (p.pClass == PlayerClass.Warrior)
            {
                Button.rendButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.BLOOD, "You have learned ", "Rend", "!",
                });
            }
        }
        if (p.Level == 4)
        {
            if (p.pClass == PlayerClass.Mage)
            {
                Button.fireBlastButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.ENERGY, "You have learned ", "Magic Missile", "!",
                });
            }
            else if (p.pClass == PlayerClass.Rogue)
            {
                Button.stunButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.DAMAGE, "You have learned ", "Backstab", "!",
                });
            }
            else if (p.pClass == PlayerClass.Warrior)
            {
                Button.rendButton.active = true;
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.BLOOD, "You have learned ", "Cleave", "!",
                });
            }
        }
        Utilities.ToTown();
    }
}