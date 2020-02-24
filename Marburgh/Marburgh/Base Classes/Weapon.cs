using System;
using System.Collections.Generic;
using System.Text;

public class Weapon : Equipment
{    
    protected bool splash;
    protected bool oneHand;
    protected string type;

    public Weapon()
    : base()
    {

    }

    public bool OneHand { get { return oneHand; } set { oneHand = value; } }
    
    public string Type { get { return type; } set { type = value; } }
    
    public bool Splash { get { return splash; } set { splash = value; } }
}