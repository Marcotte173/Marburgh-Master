using System;
using System.Collections.Generic;
using System.Text;

public class Location
{
    internal static List<Location> list = new List<Location>
    {
        new Town(),
        new MagicShop(),    //1 
        new WeaponShop(),   //2
        new ArmorShop(),    //3
        new Level(),        //4
        new Tavern(),       //5
        new Help(),         //6
        new OtherPlaces(),  //7 
        new House(),        //8
        new Bank(),         //9
        new Combat(),        //10 
    };

    internal static Location now = new Location();

    public Location()
    {
         
    }

    public void Go() { Menu(); }

    public virtual void Menu() { }
}