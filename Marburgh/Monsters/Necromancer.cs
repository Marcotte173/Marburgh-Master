using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Necromancer : Monster
{
    public Necromancer(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Necromancer";
        type = "Necromancer";
        mitigation = 1;
        xp = 6;
        gold = 22;
        dropRate = 30;
        undead = true;
        intelligence = level;
    }

    public override void Attack2(Player target)
    {
        Monster summon = (Return.RandomInt(0, 2) == 0) ? Dungeon.skeleton2 : Dungeon.zombie3;
        Combat.combatText.Add($"The " + Color.MONSTER + "Necromancer " + Color.RESET + "mumbles something you can't quite hear ");
        Combat.combatText.Add($"The ground in front of him moves ");
        Combat.combatText.Add($"A {Color.MONSTER + summon.Name + Color.RESET} crawls out of the ground");
        Dungeon.Summon(summon);
    }
    public override void Attack3(Player target)
    {
        Monster a = null;
        Monster b = null;
        string aGlow = "";
        string bGlow = "";
        foreach(Monster m in Create.p.combatMonsters)
        {
            if (m.Type != "Necromancer")
            {
                int x = Return.RandomInt(0, 3);
                if(x == 0)
                {
                    m.Strength++;
                    
                    if (aGlow == "") aGlow = Color.DAMAGE+"red"+Color.RESET;
                    else bGlow = Color.DAMAGE + "red" + Color.RESET;
                }
                else if (x== 1)
                {
                    m.Agility++;
                    if (aGlow == "") aGlow = Color.HIT + "yellow" + Color.RESET;
                    else bGlow = Color.HIT + "yellow" + Color.RESET;
                }
                else
                {
                    m.Stamina++;
                    if (aGlow == "") aGlow = Color.HEALTH + "green" + Color.RESET;
                    else bGlow = Color.HEALTH + "green" + Color.RESET;
                }
                m.Update();
                if (a == null) a = m;
                else if (b == null) b = m;
            }
        }
        Combat.combatText.Add($"The " + Color.MONSTER + "Necromancer " + Color.RESET + "whispers a word of "+Color.DEATH+"power "+Color.RESET);
        if(a==null) Combat.combatText.Add($"But nothing happens!");
        if (a!=null)Combat.combatText.Add($"The {Color.MONSTER+ a.Name + Color.RESET} is filled with a {aGlow} glow");
        if(b != null)Combat.combatText.Add($"The {Color.MONSTER + b.Name + Color.RESET} is filled with a {bGlow} glow");

    }
    public override void Attack4(Player target)
    {
        Combat.combatText.Add($"The " + Color.MONSTER + "Necromancer " + Color.RESET + "whispers a word of " + Color.DEATH + "power " + Color.RESET);
        Combat.combatText.Add($"You feel a stabbing pain in your chest. "+Color.DEATH+"Green"+Color.RESET+ " fog comes out of your chest and flows into the " + Color.DEATH + "Necromancer" + Color.RESET + "'s mouth");
        Combat.combatText.Add($"You take {Color.DAMAGE + (intelligence * 4 + intelligence) + Color.RESET} damage and the " + Color.DEATH + "Necromancer" + Color.RESET + " heals himself");
        target.TakeDamage(intelligence * 4 + intelligence, this);
        AddHealth((intelligence * 4 + intelligence)/2);
    }
    public override void Attack5(Player target)
    {
        while(Create.p.combatMonsters.Count < 3)
        {
            Monster summon = (Return.RandomInt(0, 2) == 0) ? Dungeon.skeleton2 : Dungeon.zombie3;
            Combat.combatText.Add($"The " + Color.MONSTER + "Necromancer " + Color.RESET + "mumbles something you can't quite hear ");
            Combat.combatText.Add($"The ground in front of him moves ");
            Combat.combatText.Add($"A {Color.MONSTER + summon.Name + Color.RESET} crawls out of the ground");
            Dungeon.Summon(summon);
        }        
    }

    public override void Declare2()
    {
        intention = "Summoning";
    }
    public override void Declare3()
    {
        intention = "Word of Power";
    }
    public override void Declare4()
    {
        intention = "Word of Power";
    }
    public override Drop ChooseDrop()
    {
        if (level == 5) return new Drop("Old Rotting Brain", 1, 0);
        return DropList.necromancerBrain;
    }

    public override void Declare()
    {
        if (level > 4)
        {
            action = Return.RandomInt(0, 6);
            if (action == 1 && Create.p.combatMonsters.Count < 3)
            {
                action = 5;
                Declare2();
            }
            else if (action == 2 && Create.p.combatMonsters.Count > 1)
            {
                action = 3;
                Declare3();
            }
            else if (action == 3)
            {
                action = 4;
                Declare4();
            }
            else
            {
                action = 0;
                intention = "Ready";
            }

        }
        else if (level == 4)
        {
            action = Return.RandomInt(0, 5);
            if (action == 1 && Create.p.combatMonsters.Count < 3)
            {
                action = 5;
                Declare2();
            }
            else if (action == 2 && Create.p.combatMonsters.Count > 1)
            {
                action = 4;
                Declare4();
            }
            else
            {
                action = 1;
                intention = "Ready";
            }
            Console.WriteLine("");
        }
        else
        {
            action = Return.RandomInt(0, 4);
            if (action == 0 && Create.p.combatMonsters.Count < 3)
            {
                action = 2;
                Declare2();
            }
            else
            {
                action = 1;
                intention = "Ready";
            }
        }        
    }
    public override void MakeAttack()
    {
        if (bleed > 0)
        {
            Combat.combatText.Add($"The " + Color.MONSTER + Name + Color.BLOOD + " bleeds " + Color.RESET + "for " + Color.DAMAGE + bleedDam + Color.RESET + " damage!");
            TakeDamage(bleedDam);
            bleed--;
            if (bleed <= 0 && status.Contains("Bleeding")) status.Remove("Bleeding");
        }
        if (burning > 0)
        {
            Combat.combatText.Add($"The " + Color.MONSTER + Name + Color.BURNING + " burns " + Color.RESET + "for " + Color.DAMAGE + burnDam + Color.RESET + " damage!");
            TakeDamage(burnDam);
            burning--;
            if (burning <= 0 && status.Contains("Burning")) status.Remove("Burning");
        }
        if (stun > 0)
        {
            canAct = false;
            stun--;
            if (stun <= 0 && status.Contains("Stunned")) status.Remove("Stunned");
        }
        if (action == 2) Attack2(Create.p);
        else if (action == 3) Attack3(Create.p);
        else if (action == 4) Attack4(Create.p);
        else if (action == 5) Attack5(Create.p);
        else Attack1(Create.p);
    }
}

