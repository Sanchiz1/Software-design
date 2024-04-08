﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento;
public class EditorApplication
{
    private TextEditor Editor;

    private TextHistory History;

    public EditorApplication()
    {
        Editor = new TextEditor();
        History = new TextHistory(Editor);
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Editor:\n1 - Create new file\n2 - Load file\n0 - Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    CreateFile();
                    break;
                case "2":
                    EditFile();
                    break;
                case "0":
                    return;
            }
        }
    }

    private void CreateFile()
    {
        Edit(null, []);
    }

    private void EditFile()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("WARNING! Due to early version file managment works only in current folder");
            Console.WriteLine("Enter file name (0 to exit): ");

            var fileName = Console.ReadLine();

            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Invalid filename");
                Console.ReadKey();
                return;
            }

            try
            {
                var lines = File.ReadAllLines(fileName);
                Console.WriteLine("Opened file {0}", fileName);

                Console.ReadKey();

                Edit(fileName, lines.ToList());
            }
            catch
            {
                Console.WriteLine("Failed to open file");
                Console.ReadKey();
                continue;
            }
        }
    }

    private void Edit(string? fileName, List<string> defaultText)
    {
        Editor.SetText(defaultText);
        while (true)
        {
            Console.Clear();
            foreach (string line in Editor.Text)
            {
                Console.WriteLine(line);
            }
            Console.SetCursorPosition(Editor.CursorX, Editor.CursorY);

            var info = Console.ReadKey(true);

            if (info.Key == ConsoleKey.Backspace)
            {
                Editor.Delete();
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                Editor.NewLine();
            }
            else if (info.Key == ConsoleKey.UpArrow)
            {
                Editor.MoveUp();
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                Editor.MoveDown();
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                Editor.MoveLeft();
            }
            else if (info.Key == ConsoleKey.RightArrow)
            {
                Editor.MoveRight();
            }
            else if (info.Key == ConsoleKey.S && info.Modifiers == ConsoleModifiers.Control)
            {
                SaveFile(fileName, Editor.Text.ToArray());
            }
            else
            {
                Editor.Type(info.KeyChar.ToString());
            }
        }
    }

    private void SaveFile(string? fileName, string[] lines)
    {
        while (true)
        {
            Console.Clear();
            if (fileName == null)
            {
                Console.WriteLine("Enter file name to save (0 to exit): ");

                fileName = Console.ReadLine();

                if (string.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("Invalid filename");
                    Console.ReadKey();
                    return;
                }
            }


            try
            {
                File.WriteAllLines(fileName, lines);
            }
            catch
            {
                Console.WriteLine("Failed to save file");
                Console.ReadKey();
                continue;
            }


            Console.WriteLine("File {0} saved", fileName);
            Console.ReadKey();
            return;
        }

    }
}
