
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Graveyard
{
    public static void Menu()
    {
        GameState.location = Location.Graveyard;
        Console.Clear();
        if (Family.dead.Count == 0)
            UI.Keypress(new List<int> { 0, 0 }, new List<string>
            {
                "As you arrive at the family plot you see one grave, your mother's.",
                "It is still fresh, the memories still vivid."
            });
        else if (Family.dead.Count == 1)
            UI.Keypress(new List<int> { 0, 0, 1, 1, 4, 0, 0 }, new List<string>
            {
                "As you arrive at the family plot, you see two graves",
                "",
                Color.NAME,  "", $"{Family.dead[0]}","",
                Color.MONSTER, "", $"Killed by {Family.cause[0]}","",
                Color.TIME, Color.TIME, Color.TIME, Color.TIME, "On day ", $"{Family.timeOfDeath[0,0]}", ", the ", $"{Time.weeks[Family.timeOfDeath[0, 1]]}", " week of ", $"{Time.months[Family.timeOfDeath[0, 2]]}", ", ", $"{Family.timeOfDeath[0, 3]}", ".",
                "",
                "Next to it lies the grave of your mother"
            });
        else
        {
            UI.Keypress(new List<int> { 0, 0, 1, 1, 4, 0, 1, 1, 4, 0, 0 }, new List<string>
            {
                "You arrive at the graveyard to visit the only family you've ever known.",
                "",
                Color.NAME,  "", $"{Family.dead[0]}","",
                Color.MONSTER, "", $"Killed by {Family.cause[0]}","",
                Color.TIME, Color.TIME, Color.TIME, Color.TIME, "On day ", $"{Family.timeOfDeath[0,0]}", ", the ", $"{Time.weeks[Family.timeOfDeath[0, 1]]}", " week of ", $"{Time.months[Family.timeOfDeath[0, 2]]}", ", ", $"{Family.timeOfDeath[0, 3]}", ".",
                "",
                Color.NAME,  "", $"{Family.dead[1]}","",
                Color.MONSTER, "", $"Killed by {Family.cause[1]}","",
                Color.TIME, Color.TIME, Color.TIME, Color.TIME, "On day ", $"{Family.timeOfDeath[1,0]}", ", the ", $"{Time.weeks[Family.timeOfDeath[1, 1]]}", " week of ", $"{Time.months[Family.timeOfDeath[1, 2]]}", ", ", $"{Family.timeOfDeath[1, 3]}", ".",
                "",
                "Your siblings lay next to your Mother. At least they can be together."
            });
        }
    }
}
