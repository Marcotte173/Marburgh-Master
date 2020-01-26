using System;
using System.Collections.Generic;
using System.Threading;
public class ThreeCardMonteGame
{
    public static void ThreeCardMonte(Creature p, int wager)
    {
        Console.Clear();
        UI.Choice(new List<int> { 0, 0, 0, 0, 1 }, new List<string>
            {
                "You walk up to the table. You recognize the man behind the table, showing onlookers his cups and ball.",
                "He's a cheat but he's so sure he's going to win he's offered 3 to 1 odds!",
                "After moving the balls around, you are pretty sure you've kept track",
                "",
                Colour.SPEAK,"","'Well, what do you think? Which cup is it in?'",""
            },
            new List<string> { "", "", "" }, new List<string> { "1", "2", "3" });
        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 12);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (int.TryParse(choice, out int intChoice))
        {
            UI.DotDotDot(new List<string> { "", "", "" }, new List<string> { "1", "2", "3" });
            int ball = Return.RandomInt(1, 4);
            if (intChoice == ball)
            {
                UI.Keypress(new List<int> { 0, 0, 0, 0, 1 }, new List<string>
                {
                    "The ball is there!",
                    "",
                    "You win! The man looks shocked.",
                    "",
                    Colour.GOLD, "", $"Clearly unhappy, he gives you {wager * 3} gold",""
                });
                p.Gold += wager * 3;
            }
            else
            {
                UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                {
                    "There's nothing there!",
                    "",
                    Colour.GOLD, "You lose! Smiling smugly, the man takes your ", "gold",""
                });
            }
        }
        else ThreeCardMonte(p, wager);
    }
}