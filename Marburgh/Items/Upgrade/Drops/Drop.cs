using System;
using System.Collections.Generic;
using System.Text;

public class Drop
{
    //Variables, self explanatory
    public string name;
    public int amount;
    public int rare;
    public Drop(string name, int amount, int rare)
    {
        this.rare = rare;
        this.name = name;
        this.amount = amount;
    }
}