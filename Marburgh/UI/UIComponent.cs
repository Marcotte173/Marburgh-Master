using System;
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
    internal static void OptionsText(List<string> options, List<string> optionButton, int x)
    {
        int height = 22;
        if (options.Count == 0) { }
        else if (options.Count == 1)
        {
            Write.Line(68 - (options[0].Length + x) / 2, height, $"[{optionButton[0]}]{options[0]}");
        }
        else if (options.Count == 2)
        {
            if (optionButton[0] != "") Write.Line(51 - (options[0].Length + x) / 2, height,$"[{optionButton[0]}]{options[0]}");
            if (optionButton[1] != "") Write.Line(88 - (options[1].Length + x) / 2, height, $"[{optionButton[1]}]{options[1]}");
        }                                                                   
        else if (options.Count == 3)                                        
        {                                                                   
            if (optionButton[0] != "") Write.Line(51 - (options[0].Length + x) / 2, height-2, $"[{optionButton[0]}]{options[0]}");
            if (optionButton[1] != "") Write.Line(88 - (options[1].Length + x) / 2, height-2, $"[{optionButton[1]}]{options[1]}");
            if (optionButton[2] != "") Write.Line(68 - (options[2].Length + x) / 2, height+2, $"[{optionButton[2]}]{options[2]}");
        }                                                                  
        else if (options.Count == 4)                                       
        {                                                                  
            if (optionButton[0] != "") Write.Line(51 - (options[0].Length + x) / 2, height - 3, $"[{optionButton[0]}]{options[0]}");
            if (optionButton[1] != "") Write.Line(88 - (options[1].Length + x) / 2, height - 3, $"[{optionButton[1]}]{options[1]}");
            if (optionButton[2] != "") Write.Line(51 - (options[0].Length + x) / 2, height + 2, $"[{optionButton[2]}]{options[2]}");
            if (optionButton[3] != "") Write.Line(88 - (options[1].Length + x) / 2, height + 2, $"[{optionButton[3]}]{options[3]}");
        }                                                                   
        else if (options.Count == 5)                                        
        {                                                                   
            if (optionButton[0] != "") Write.Line(51 - (options[0].Length + x) / 2, height - 2, $"[{optionButton[0]}]{options[0]}");
            if (optionButton[1] != "") Write.Line(88 - (options[1].Length + x) / 2, height - 2, $"[{optionButton[1]}]{options[1]}");
            if (optionButton[2] != "") Write.Line(51 - (options[0].Length + x) / 2, height + 1,    $"[{optionButton[2]}]{options[2]}");
            if (optionButton[3] != "") Write.Line(88 - (options[1].Length + x) / 2, height + 1,    $"[{optionButton[3]}]{options[3]}");
            if (optionButton[4] != "") Write.Line(68 - (options[4].Length + x) / 2, height + 3, $"[{optionButton[4]}]{options[4]}");
        }                                                                   
        else                                                                
        {                                                                   
            if (optionButton[0] != "") Write.Line(51 - (options[0].Length + x) / 2, height - 3, $"[{optionButton[0]}]{options[0]}");
            if (optionButton[1] != "") Write.Line(88 - (options[1].Length + x) / 2, height - 3, $"[{optionButton[1]}]{options[1]}");
            if (optionButton[2] != "") Write.Line(51 - (options[0].Length + x) / 2, height , $"[{optionButton[2]}]{options[2]}");
            if (optionButton[3] != "") Write.Line(88 - (options[1].Length + x) / 2, height , $"[{optionButton[3]}]{options[3]}");
            if (optionButton[4] != "") Write.Line(51 - (options[0].Length + x) / 2, height + 3, $"[{optionButton[4]}]{options[4]}");
            if (optionButton[5] != "") Write.Line(88 - (options[1].Length + x) / 2, height + 3, $"[{optionButton[5]}]{options[5]}");
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
        Console.WriteLine(Color.NAME + $"{Create.p.Name}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Color.XP + $"{Create.p.Level}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("Gold:" + Color.GOLD + $"{Create.p.Gold}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Color.CLASS + "9" + Color.RESET + "]Character");
        Console.SetCursorPosition(Return.Width(88), 16);
        if (GameState.location == Location.Town) Console.WriteLine("[" + Color.MITIGATION + "0" + Color.RESET + "]Quit");
        else Console.WriteLine("[" + Color.MITIGATION + "0" + Color.RESET + "]Return");
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
        string a = $"It is day {Color.TIME+Time.day+Color.RESET}, the {Color.TIME + Time.weeks[Time.week] + Color.RESET} week of {Color.TIME + Time.months[Time.month] + Color.RESET}, {Color.TIME + Time.year + Color.RESET}";
        if (Time.Events[0].active && Time.week == 2)
        {
            a += $" - {Color.BLOOD + (5 - Time.day) } days remaining" + Color.RESET;
            Write.Line(20, 27, a);
        }
        else Write.Line(35, 27, a);
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