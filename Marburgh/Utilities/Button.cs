using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Buttons
{
    public static List<string> adventureButton = new List<string> { Colour.MONSTER + "1" + Colour.RESET };
    public static List<string> adventureList = new List<string> { "Orc Hideout" };
    public static List<string> shopButton = new List<string> { Colour.ITEM + "M" + Colour.RESET, Colour.ITEM + "W" + Colour.RESET, Colour.ITEM + "A" + Colour.RESET };
    public static List<string> shopList = new List<string> { "agic Shop", "eapon Shop", "rmor Shop" };
    public static List<string> serviceButton = new List<string> { Colour.TIME + "T" + Colour.RESET, Colour.TIME + "L" + Colour.RESET, Colour.TIME + "B" + Colour.RESET };
    public static List<string> serviceList = new List<string> { "avern", "evel Master","ank" };
    public static List<string> otherButton = new List<string> { Colour.XP + "Y" + Colour.RESET, Colour.XP + "O" + Colour.RESET, "","", "","?"  };
    public static List<string> otherList = new List<string> { "our House", "ther Places", "","","", Colour.BLOOD + "MORE INFO" + Colour.RESET };
}