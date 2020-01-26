﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class UIComponent
{
    public static void DisplayText(List<int> colourArray, List<string> descriptions)
    {
        int colourArrayCheck = 0;
        if (descriptions != null)
        {
            for (int i = 0; i < descriptions.Count; i++)
            {
                Console.SetCursorPosition(0, (8 - colourArray.Count / 2) + i);
                if (colourArray[i] == 0) Write.CenterText(descriptions[colourArrayCheck]);
                else if (colourArray[i] == 1) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3]);
                else if (colourArray[i] == 2) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6]);
                else if (colourArray[i] == 3) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6], descriptions[colourArrayCheck + 7], descriptions[colourArrayCheck + 8], descriptions[colourArrayCheck + 9]);
                else if (colourArray[i] == 4) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6], descriptions[colourArrayCheck + 7], descriptions[colourArrayCheck + 8], descriptions[colourArrayCheck + 9], descriptions[colourArrayCheck + 10], descriptions[colourArrayCheck + 11], descriptions[colourArrayCheck + 12]);
                colourArrayCheck += (colourArray[i] == 0) ? 1 : colourArray[i] == 1 ? 4 : colourArray[i] == 2 ? 7 : colourArray[i] == 3 ? 10 : 13;
                if (colourArrayCheck >= descriptions.Count) break;
            }
        }
    }
    public static void DisplayTextWait(List<int> colourArray, List<string> descriptions)
    {
        int colourArrayCheck = 0;
        for (int i = 0; i < descriptions.Count; i++)
        {
            Thread.Sleep(400);
            Console.SetCursorPosition(0, (8 - colourArray.Count / 2) + i);
            if (colourArray[i] == 0) Write.CenterText(descriptions[colourArrayCheck]);
            else if (colourArray[i] == 1) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3]);
            else if (colourArray[i] == 2) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6]);
            else if (colourArray[i] == 3) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6], descriptions[colourArrayCheck + 7], descriptions[colourArrayCheck + 8], descriptions[colourArrayCheck + 9]);
            else if (colourArray[i] == 4) Write.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6], descriptions[colourArrayCheck + 7], descriptions[colourArrayCheck + 8], descriptions[colourArrayCheck + 9], descriptions[colourArrayCheck + 10], descriptions[colourArrayCheck + 11], descriptions[colourArrayCheck + 12]);
            colourArrayCheck += (colourArray[i] == 0) ? 1 : colourArray[i] == 1 ? 4 : colourArray[i] == 2 ? 7 : colourArray[i] == 3 ? 10 : 13;
            if (colourArrayCheck >= descriptions.Count) break;
        }
    }
    internal static void OptionsText(List<string> options, List<string> optionButton)
    {
        int height = 22;
        if (options.Count == 1)
        {
            Console.SetCursorPosition(Return.Width(50) - (options[0].Length + 3) / 2, height);
            Console.WriteLine($"[{optionButton[0]}]{options[0]}");
        }
        else if (options.Count == 2)
        {
            Console.SetCursorPosition(Return.Width(33) - (options[0].Length + 3) / 2, height);
            if (optionButton[0] != "") Console.WriteLine($"[{optionButton[0]}]{options[0]}");
            Console.SetCursorPosition(Return.Width(66) - (options[1].Length + 3) / 2, height);
            if (optionButton[1] != "") Console.WriteLine($"[{ optionButton[1]}]{ options[1]}");
        }
        else if (options.Count == 3)
        {
            Console.SetCursorPosition(Return.Width(25) - (options[0].Length + 3) / 2, height);
            if (optionButton[0] != "") Console.WriteLine($"[{optionButton[0]}]{options[0]}");
            Console.SetCursorPosition(Return.Width(50) - (options[1].Length + 3) / 2, height);
            if (optionButton[1] != "") Console.WriteLine($"[{ optionButton[1]}]{ options[1]}");
            Console.SetCursorPosition(Return.Width(75) - (options[2].Length + 3) / 2, height);
            if (optionButton[2] != "") Console.WriteLine($"[{optionButton[2]}]{options[2]}");
        }
        else
        {
            Console.SetCursorPosition(Return.Width(33) - (options[0].Length + 3) / 2, height-2);
            if (optionButton[0] != "") Console.WriteLine($"[{optionButton[0]}]{options[0]}");
            Console.SetCursorPosition(Return.Width(66) - (options[1].Length + 3) / 2, height-2);
            if (optionButton[1] != "") Console.WriteLine($"[{ optionButton[1]}]{ options[1]}");
            Console.SetCursorPosition(Return.Width(33) - (options[0].Length + 3) / 2, height + 1);
            if (optionButton[2] != "") Console.WriteLine($"[{optionButton[2]}]{options[2]}");
            Console.SetCursorPosition(Return.Width(66) - (options[1].Length + 3) / 2, height + 1);
            if (optionButton[3] != "") Console.WriteLine($"[{ optionButton[3]}]{ options[3]}");
        }
    }

    internal static void TopBar()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(20), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(40), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(60), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.Width(80), Console.CursorTop);
        Console.Write("|");
        Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
        Console.Write("|\n");
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.SetCursorPosition(Return.Width(10) - Create.p.Name.Length / 2, 16);
        Console.WriteLine(Colour.NAME + $"{Create.p.Name}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Colour.XP + $"{Create.p.Level}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("Gold:" + Colour.GOLD + $"{Create.p.Gold}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Colour.CLASS + "C" + Colour.RESET + "]haracter");
        Console.SetCursorPosition(Return.Width(88), 16);
        if (Location.now == Location.list[0]) Console.WriteLine("[" + Colour.MITIGATION + "Q" + Colour.RESET + "]uit");
        else Console.WriteLine("[" + Colour.MITIGATION + "R" + Colour.RESET + "]eturn");
    }

    internal static void BarBlank()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.Write("|");
        Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
        Console.Write("|\n");
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
    }

    internal static void StandardMiddle(int amount)
    {
        for (int P = 0; P < amount; P++)
        {
            Console.Write("|");
            for (int i = 0; i < Return.Width(14); i++)
            {
                Console.Write("x");
            }
            Console.SetCursorPosition(Return.Width(15), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(85), Console.CursorTop);
            Console.Write("|");
            for (int i = 0; i < Return.Width(14); i++)
            {
                Console.Write("x");
            }
            Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
            Console.Write("|\n");
        }
    }

    internal static void ShopMiddle(int amount)
    {
        for (int P = 0; P < amount; P++)
        {
            Console.Write("|");
            for (int i = 0; i < Return.Width(14); i++)
            {
                Console.Write("x");
            }
            Console.SetCursorPosition(Return.Width(15), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(50), Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Return.Width(85), Console.CursorTop);
            Console.Write("|");
            for (int i = 0; i < Return.Width(14); i++)
            {
                Console.Write("x");
            }
            Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
            Console.Write("|\n");
        }
    }
    public static void TimeDisplay()
    {
        Console.SetCursorPosition(35, 27);
        Write.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, "It is day ", $"{Time.day}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "");
    }

    internal static void BottomBar()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.Write("|");
        Console.SetCursorPosition(Return.MaxWidth(), Console.CursorTop);
        Console.Write("|\n");
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        TimeDisplay();
    }
}