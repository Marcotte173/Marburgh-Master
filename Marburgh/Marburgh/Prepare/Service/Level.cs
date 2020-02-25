using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level:Location
{
    Player p = Create.p;
    public static int[] xpRequired = new int[] { 0, 30, 75, 125, 185, 255, 315, 385, 475, 575, 700, 830, 1000 };
    public Level()
    : base() { }
    public override void Menu()
    {
        Console.Clear();
        {
            
            if (UI.Confirm(new List<int> { 1, 1 }, new List<string>
                {
                    Colour.SPEAK, "", "The Level Master is meditating. He looks up at you.","",
                    Colour.SPEAK, "",  "'Are you here to level up?'", ""
                }))
            {
                if (p.XP < p.XPNeeded[p.Level])
                {
                    UI.Keypress(new List<int> { 0, 1, 1 }, new List<string>
                        {
                        "He looks at you thoughtfully.",
                        Colour.SPEAK, "","'Hmmm... You're not QUITE ready yet'","",
                        Colour.SPEAK, "","'Come back when you are more experienced'",""
                        });
                    Utilities.ToTown();
                }                    
                else LevelUp(p);
            }
            else
            {
                UI.Keypress(new List<int> { 1 }, new List<string>
                {
                Colour.SPEAK, "","Quit wasting my time!",""
                });
                Utilities.ToTown();
            }
                
        }
    }

    private void LevelUp(Player p)
    {
        Console.Clear();
        p.MaxEnergy += p.LvlEnergy[p.Level];
        p.MaxHealth += p.LvlHealth[p.Level];
        p.Health = p.MaxHealth;
        p.Energy = p.MaxEnergy;
        p.PlayerDamage += p.LvlDamage[p.Level];
        p.PlayerMitigation += p.LvlMitigation[p.Level];
        p.PlayerHit += p.LvlHit[p.Level];
        p.PlayerCrit += p.LvlCrit[p.Level];
        p.PlayerDefence += p.LvlDefence[p.Level];
        p.XP -= p.XPNeeded[p.Level];
        p.Level += 1;             
        if (p.PlayerSpellpower > 0)
        {
            p.PlayerSpellpower += p.LvlSpellpower[p.Level];
            UI.Keypress(new List<int> { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 }, new List<string>
            {
                Colour.XP, "Congrats! You are level ", $"{p.Level}", "!",
                "",
                Colour.HEALTH, "Max health increased by ", $"{p.LvlHealth[p.Level-1]}", "!",
                Colour.ENERGY, "Max energy increased by ", $"{p.LvlEnergy[p.Level-1]}", "!",
                "",
                Colour.DAMAGE, "Damage increased by ", $"{p.LvlDamage[p.Level-1]}", "!",
                Colour.HIT, "Hit increased by ", $"{p.LvlHit[p.Level-1]}", "!",
                Colour.CRIT, "Crit increased by ", $"{p.LvlCrit[p.Level-1]}", "!",
                "",
                Colour.MITIGATION, "Mitigation increased by ", $"{p.LvlMitigation[p.Level-1]}", "!",
                Colour.DEFENCE, "Defence increased by ", $"{p.LvlDefence[p.Level-1]}", "!",
                "",
                Colour.ABILITY, "Spellpower increased by ", $"{p.LvlSpellpower[p.Level-1]}", "!"
            });            
        }
        else
        {
            UI.Keypress(new List<int> { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1 }, new List<string>
                {
                    Colour.XP, "Congrats! You are level ", $"{p.Level}", "!",
                    "",
                    Colour.HEALTH, "Max health increased by ", $"{p.LvlHealth[p.Level-1]}", "!",
                    Colour.ENERGY, "Max energy increased by ", $"{p.LvlEnergy[p.Level-1]}", "!",
                    "",
                    Colour.DAMAGE, "Damage increased by ", $"{p.LvlDamage[p.Level-1]}", "!",
                    Colour.HIT, "Hit increased by ", $"{p.LvlHit[p.Level-1]}", "!",
                    Colour.CRIT, "Crit increased by ", $"{p.LvlCrit[p.Level-1]}", "!",
                    "",
                    Colour.MITIGATION, "Mitigation increased by ", $"{p.LvlMitigation[p.Level-1]}", "!",
                    Colour.DEFENCE, "Defence increased by ", $"{p.LvlDefence[p.Level-1]}", "!"
                });
        }
        if (p.Level == 2)
        {
            p.CanAttack3 = true;
            CombatUI.option.Add(Colour.ABILITY + p.Option3 + Colour.RESET);
            CombatUI.button.Add("3");
            UI.Keypress(new List<int> { 1}, new List<string>
                {
                    Colour.ABILITY, "You have learned ", $"{p.Option3}", "!",
                });
        }
        if (p.Level == 4)
        {
            p.CanAttack4 = true;
            CombatUI.option.Add(Colour.ABILITY + p.Option4 + Colour.RESET);
            CombatUI.button.Add("4");
            UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Colour.ABILITY, "You have learned ", $"{p.Option4}", "!",
                });
        }
        Utilities.ToTown();
    }
}