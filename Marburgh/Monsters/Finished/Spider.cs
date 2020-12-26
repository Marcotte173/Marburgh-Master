using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Spider : Monster
{
    public Spider(int level)
    : base(level)
    {
        this.level = level;
        if (level >5 )
        {
            type = "Spider Queen";
            name = "Spider Queen";
        }
        else if (level > 3)
        {
            type = "Giant Spider";
            name = "Giant Spider";
        }
        else
        {
            type = "Spider";
            name = "Spider";
        }
        xp = Balance.spiderXp * level + Return.RandomInt(Balance.spiderXp / 2, Balance.spiderXp + Balance.spiderXp / 2);
        gold = Balance.spiderGold * level + Return.RandomInt(Balance.spiderGold / 2, Balance.spiderGold + Balance.spiderGold / 2);
        strength = Balance.spiderStrength + Balance.spiderStrength * level * 2 / 3;
        agility = Balance.spiderAgility + Balance.spiderAgility * level / 2;
        stamina = Balance.spiderStamina + Balance.spiderStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level * 3 / 2;
        if (level > 5) dropRate = 100;
        else dropRate = 30;
    }

    public override void Declare()
    {
        if (burning > 0 && !Status.Contains(Color.BURNING + "Burning" + Color.RESET)) Status.Add(Color.BURNING + "Burning" + Color.RESET);
        if (bleed > 0 && !Status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains(Color.STUNNED + "Stunned" + Color.RESET)) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if (level >5 && Create.p.combatMonsters.Count <4 && Return.RandomInt(0,10) == 0)
        {
            action = 5;
            Declare4();
        }
        else if(level >3 && Create.p.combatMonsters.Count<5 && Return.RandomInt(0,10) == 0)
        {
            action = 4;
            Declare4();
        }
        else if(Return.RandomInt(0, 10) == 0)
        {
            action = 3;
            Declare3();
        }
        else if (Return.RandomInt(0, 10) == 0)
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

    public override void Declare2()
    {
        intention = "Biting";
    }
    public override void Declare3()
    {
        intention = "Webbing";
    }
    public override void Declare4()
    {
        intention = "Summoning";
    }

    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            int newDamage = damage * 3/2;
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - newDamage / 2 <= 0) ? 0 : target.Energy - newDamage / 2;
                if(level >5) Combat.AddCombatText(Color.BOSS + name + Color.RESET + $" tries to " + Color.ABILITY + "bite " + Color.RESET + "you but it is absorbed by your" + Color.SHIELD + "shield");
                else Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" tries to " + Color.ABILITY + "bite " + Color.RESET + "you but it is absorbed by your" + Color.SHIELD + "shield");

            }
            else
            {
                target.TakeDamage(Return.MitigatedDamage(newDamage, target.Mitigation), this);
                if(level >5 ) Combat.AddCombatText(Color.BOSS + name + Color.ABILITY + " bites" + Color.RESET + $" you for {Color.DAMAGE + Return.MitigatedDamage(newDamage, target.Mitigation) + Color.RESET} damage!");
                else Combat.AddCombatText(Color.MONSTER + name + Color.ABILITY + " bites" + Color.RESET + $" you for {Color.DAMAGE + Return.MitigatedDamage(newDamage, target.Mitigation) + Color.RESET} damage!");
            }
        }
        else Miss(target);
    }

    public override void Attack3(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
                if (level > 5) Combat.AddCombatText(Color.BOSS + name + Color.RESET + $" tries to web you but it bounces harmlessly off your " + Color.SHIELD + "shield");
                else Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" tries to web you but it bounces harmlessly off your " + Color.SHIELD + "shield");
            }
            else
            {
                target.Stun = level;
                target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                if (level > 5) Combat.AddCombatText(Color.BOSS + name + Color.RESET + $" covers you in sticky webbing, " + Color.STUNNED + "immobilizing" + Color.RESET + $" you!");
                else Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" covers you in sticky webbing, " + Color.STUNNED + "immobilizing" + Color.RESET + $" you!");
            }
        }
        else Miss(target);
    }

    public override void Attack4(Player target)
    {
        Dungeon.Summon(new Spider(2));
        if (level > 5) Combat.AddCombatText(Color.BOSS + name + Color.RESET + " lets out a terrible screech! You hear an answering call as a " + Color.MONSTER + "Spider" + Color.RESET + " joins the fray!");
        else Combat.AddCombatText(Color.MONSTER + name + Color.RESET + " lets out a terrible screech! You hear an answering call as a " + Color.MONSTER + "Spider" + Color.RESET + " joins the fray!");
    }

    public override void Attack5(Player target)
    {
        Dungeon.Summon(new Spider(4));
        Combat.AddCombatText(Color.BOSS + name + Color.RESET + " lets out a terrible screech! You hear an answering call as a " + Color.MONSTER + "Giant Spider" + Color.RESET + " joins the fray!");
    }
    public override void MakeAttack()
    {
        if (action == 2) Attack2(Create.p);
        else if (action == 3) Attack3(Create.p);
        else if (action == 4) Attack4(Create.p);
        else if (action == 5) Attack5(Create.p);
        else Attack1(Create.p);
    }

    public override void Death()
    {
        Combat.AddCombatText($"You have killed " + Color.MONSTER + name + Color.RESET + "!");
        Create.p.combatMonsters.Remove(this);
        Combat.goldReward += gold;
        Combat.xpReward += xp;
        Drop();
        if (level > 5)
        {
            UI.Keypress(new List<int> {2,0,3,0,1,0,1 }, new List<string> 
            { 
                Color.BOSS,Color.DAMAGE,"The ","spider queen"," starts ","writhing and shreiking","",
                "",
                Color.BOSS,Color.MONSTER,Color.CRIT,"As ","she"," dies, the other ","spiders"," start acting ","uncoordinated","",
                "",
                Color.BOSS,"Without the ","Queen",", it is clear they don't know what to do",
                "",
                Color.MONSTER,"The remaining ","spiders"," lose interest in you, they have more pressing matters on their mind"
            });
            Create.p.combatMonsters.Clear();
        }
    }
    public override Drop ChooseDrop()
    {
        if (level > 5) return DropList.spiderEgg;
        else
        {
            if (Return.RandomInt(0, 2) == 0) return DropList.monsterEye.Copy();
            else return DropList.monsterTooth.Copy();
        }
    }

}
