using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monster : Creature
{
    protected string intention;
    protected int action;
    public override void Attack1(Creature target)
    {
        if (AttemptToHit(target, 0) == false) Miss(target);
        else Console.WriteLine($"The {Name} hits you for {Damage} damage");
        target.TakeDamage(Damage);
    }

    public virtual void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (action != 0) intention = "Ready";
        else Declare3();
    }

    public virtual void Declare3()
    {

    }

    public virtual void MakeAttack()
    {
        if (action == 0) Attack3(Create.p);
        else Attack1(Create.p);
    }
}
