using System;
using System.Collections.Generic;
using System.Text;

public class Weapon : Equipment
{           
    protected int[] priceArray = new int[] { 0, 500, 1500, 3000, 5000, 7500 };
    protected int[] damageBoost = new int[] {0, 2, 4, 6, 8, 10 };    

    public Weapon()
    : base()
    {

    }
    
    public int[] DamageBoost { get { return damageBoost; } set { damageBoost = value; } }

}