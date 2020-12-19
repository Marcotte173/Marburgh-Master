using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monster : Creature
{
    protected string intention;
    protected int action;
    protected Drop drop;
    protected int dropRate;
    
    
    static List<string> text = Combat.combatText;
    public virtual void Attack1(Player target)
    {
        if (AttemptToHit(target, 0) == false) Miss(target);
        else
        {
            text.Add(Color.MONSTER + name + Color.RESET + $" hits you for {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage");
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
    }
    public Monster(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina)
    {
        this.level = level;
        damage = strength * 2;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 6 * stamina;
    }
    public Monster(int level)
    : base()
    {
        this.level = level;      
    }
    public virtual void Attack2(Player target)
    {

    }
    public virtual void Attack3(Player target)
    {

    }
    public virtual void Attack4(Player target)
    {

    }
    public virtual void Attack5(Player target)
    {

    }
    public virtual void Attack6(Player target)
    {

    }

    public virtual void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if (action != 0) intention = "Ready";
        else Declare2();
    }

    public void Update()
    {
        damage = strength * 2;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 6 * stamina;
    }

    public virtual void Declare2()
    {

    }
    public virtual void Declare3()
    {

    }
    public virtual void Declare4()
    {

    }
    public Monster MonsterCopy()
    {
        return (Monster)MemberwiseClone();
    }

    public virtual void MakeAttack()
    {
        if (bleed > 0)
        {
            text.Add(Color.MONSTER + name + Color.BLOOD + " bleeds " + Color.RESET + "for " + Color.DAMAGE + bleedDam + Color.RESET + " damage!");
            TakeDamage(bleedDam);
            bleed--;
            if (bleed <= 0 && status.Contains("Bleeding")) status.Remove("Bleeding");
        }
        if (burning > 0)
        {
            text.Add(Color.MONSTER + name + Color.BURNING+ " burns " + Color.RESET + "for " + Color.DAMAGE + burnDam + Color.RESET + " damage!");
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
        if (action == 0) Attack2(Create.p);
        else Attack1(Create.p);
    }
    public override void Death()
    {
        text.Add($"You have killed "+Color.MONSTER + name + Color.RESET +"!");
        text.Add("");
        Create.p.combatMonsters.Remove(this);
        Combat.goldReward += gold;
        Combat.xpReward += xp;
        Drop();
    }

    public override void Miss(Creature target)
    {
        text.Add(Color.MONSTER + name + Color.RESET +" misses you!");
    }
    public string Intention { get { return intention; } set { intention = value; } }
    public virtual void Drop()
    {
        if (Return.RandomInt(1, 101) <= dropRate)
        {
            Create.p.combatDropList.Add(ChooseDrop());
        }
    }

    public virtual Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 2) == 0) return DropList.monsterEye.Copy();
        else return DropList.monsterTooth.Copy();
    }

    public int DropRate { get { return dropRate; } set { dropRate = value; } }
    public int Action { get { return action; } set { action = value; } }    
}