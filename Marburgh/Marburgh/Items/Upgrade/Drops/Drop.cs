using System;
using System.Collections.Generic;
using System.Text;

public class Drop
{
    //Variables, self explanatory
    public string name;
    public int amount;
    public bool rare;
    public Drop(string name, int amount, bool rare)
    {
        this.rare = rare;
        this.name = name;
        this.amount = amount;
    }
}