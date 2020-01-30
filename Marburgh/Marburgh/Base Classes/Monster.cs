﻿using System;
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
    protected Drop monsterEye = new Drop("Monster Eye", 1, false);
    protected Drop monsterTooth = new Drop("Monster Tooth", 1, false);
    public virtual void Attack1(Creature target)
    {
        if (AttemptToHit(target, 0) == false) Miss(target);
        else Console.WriteLine($"The {Name} hits you for {Damage} damage");
        target.TakeDamage(Damage);
    }
    public virtual void Attack2(Creature target)
    {

    }
    public virtual void Attack3(Creature target)
    {
        
    }
    public virtual void Attack4(Creature target)
    {

    }
    public virtual void Attack5(Creature target)
    {

    }
    public virtual void Attack6(Creature target)
    {

    }

    public virtual void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (action != 0) intention = "Ready";
        else Declare2();
    }

    public virtual void Declare2()
    {

    }
    public Monster MonsterCopy()
    {
        return (Monster)MemberwiseClone();
    }

    public virtual void MakeAttack()
    {
        if (action == 0) Attack2(Create.p);
        else Attack1(Create.p);
    }
    public override void Death()
    {
        Console.WriteLine($"You have killed the {name}!");
        Combat.monsters.Remove(this);
        Combat.goldReward += gold;
        Combat.xpReward += xp;
    }

    public override void Miss(Creature target)
    {
        Console.WriteLine($"The {Name} misses you!");
    }
    public string Intention { get { return intention; } set { intention = value; } }
    public virtual void Drop() 
    { 
        if (dropRate <= Return.RandomInt(1, 101))
        {
            Create.p.Drops.Add(ChooseDrop());
        }        
    }

    public virtual Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 2) == 0) return monsterEye;
        else return monsterTooth;
    }

    public int Action { get { return action; } set { action = value; } }
}
