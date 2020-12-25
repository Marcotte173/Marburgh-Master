using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Necromancer : Monster
{
    public Necromancer(int level)
    : base(level)
    {
        this.level = level;
        type = "Necromancer";
        name = "Necromancer";
        xp = Balance.necromancerXp * level + Return.RandomInt(Balance.necromancerXp / 2, Balance.necromancerXp + Balance.necromancerXp / 2);
        gold = Balance.necromancerGold * level + Return.RandomInt(Balance.necromancerGold / 2, Balance.necromancerGold + Balance.necromancerGold / 2);
        strength = Balance.necromancerStrength + Balance.necromancerStrength * level * 2 / 3;
        agility = Balance.necromancerAgility + Balance.necromancerAgility * level / 2;
        stamina = Balance.necromancerStamina + Balance.necromancerStamina * level / 2;
        intelligence = Balance.necromancerIntelligence + Balance.necromancerIntelligence * level / 2;
        defence = 2 * agility + agility - 1;
        damage = strength ;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level;
        dropRate = 30;
    }

    public override void Attack2(Player target)
    {
        Monster skeleton = new Skeleton(4);
        Monster zombie = new Zombie(4);
        Monster summon = (Return.RandomInt(0, 2) == 0) ? skeleton :zombie;
        Combat.AddCombatText(Color.DEATH + name + Color.RESET + Color.RESET + " mumbles something you can't quite hear ");
        Combat.AddCombatText($"The ground in front of him moves ");
        Combat.AddCombatText(Color.MONSTER + summon.Name + Color.RESET +" crawls out of the ground");
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
        Combat.AddCombatText(Color.DEATH + name + Color.RESET + Color.RESET + " whispers a word of "+Color.DEATH+"power "+Color.RESET);
        if(a==null) Combat.AddCombatText($"But nothing happens!");
        if (a!=null)Combat.AddCombatText(Color.MONSTER + name + Color.RESET +$" is filled with a {aGlow} glow");
        if(b != null)Combat.AddCombatText(Color.MONSTER + name + Color.RESET +$" is filled with a {bGlow} glow");

    }
    public override void Attack4(Player target)
    {
        Combat.AddCombatText(Color.DEATH + name + Color.RESET + " whispers a word of " + Color.DEATH + "power " + Color.RESET);

        int spellDamage = intelligence * 4 + intelligence;
        if (target.PersonalShield)
        {
            target.Energy = (target.Energy - spellDamage / 2 <= 0) ? 0 : target.Energy - spellDamage / 2;
            Combat.AddCombatText("A " + Color.HEALTH + "green" + Color.RESET + " light flows from the " + Color.DEATH + "Necromancer" + Color.RESET + " to you but is interupted by your" + Color.ENERGY + " shield" + Color.RESET );
        }
        else
        {
            target.TakeDamage(spellDamage, this);
            AddHealth((spellDamage / 2));
            Combat.AddCombatText($"You feel a stabbing pain in your chest. " + Color.HEALTH + "Green" + Color.RESET + " fog comes out of your chest and flows into " + Color.DEATH + name + Color.RESET + "'s mouth");
            Combat.AddCombatText($"You take {Color.DAMAGE + spellDamage + Color.RESET} damage and " + Color.DEATH + name + Color.RESET + " heals himself");            
        }       
    }
    public override void Attack5(Player target)
    {
        while(Create.p.combatMonsters.Count < 3)
        {
            Monster skeleton = new Skeleton(4);
            Monster zombie = new Zombie(4);
            Monster summon = (Return.RandomInt(0, 2) == 0) ? skeleton : zombie;
            Combat.AddCombatText(Color.DEATH + name + Color.RESET + "mumbles something you can't quite hear ");
            Combat.AddCombatText($"The ground in front of him moves ");
            Combat.AddCombatText(Color.MONSTER + name + Color.RESET + " crawls out of the ground");
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
        if (action == 2) Attack2(Create.p);
        else if (action == 3) Attack3(Create.p);
        else if (action == 4) Attack4(Create.p);
        else if (action == 5) Attack5(Create.p);
        else Attack1(Create.p);
    }
}

