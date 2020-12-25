using System;
using System.Threading;
using System.Collections.Generic;
public class DiceGame
{
    public static void Dice(Creature p, int wager)
    {
        int playerRoll = Return.RandomInt(1, 7);
        int opponentRoll = Return.RandomInt(1, 7);
        Console.Clear();
        Write.SetY(15);
        UI.StandardBoxBlank();
        Console.SetCursorPosition(0, 7);
        Write.CenterColourText(Color.GOLD, "Confident, you set ", $"{wager}", " gold on the table");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 16, 9);
        Console.Write($"You roll a die, it comes up.");
        RollDice(playerRoll);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 21, 11);
        Console.Write($"Your opponent rolls a die, it comes up.");
        RollDice(opponentRoll);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 21);
        Write.Line(Color.ENERGY, "Press any key to continue");
        Console.ReadKey(true);
        if (playerRoll == opponentRoll)
            UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
        {
            "It's a tie!",
            "",
            "You take your money back"
        });
        else if (playerRoll > opponentRoll)
            UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
        {
            "You win!",
            "",
            Color.GOLD, "You receive ", $"{wager * 2 }" ," gold!",
        });
        else
            UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
        {
            "You lose",
            "",
            "The man takes your money with a smile"
        });
        p.Gold = (playerRoll == opponentRoll) ? p.Gold + wager : (playerRoll > opponentRoll) ? p.Gold + 2 * wager : p.Gold;
        return;
    }
    public static void RollDice(int roll)
    {
        Thread.Sleep(300);
        Console.Write($".");
        Thread.Sleep(300);
        Console.Write($".");
        Thread.Sleep(300);
        Console.Write(Color.NAME + $"{roll}" + Color.RESET + "!");
        Thread.Sleep(400);
    }
}