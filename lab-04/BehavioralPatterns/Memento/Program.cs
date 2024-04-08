using Memento;

internal class Program
{
    private static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        editor.setCursor(0, 0);
        TextHistory editorHistory = new TextHistory(editor);


        foreach (string line in editor.Text)
        {
            Console.WriteLine(line);
        }
        ConsoleKeyInfo info;

        while (true)
        {
            Console.SetCursorPosition(0, 0);
            foreach (string line in editor.Text)
            {
                Console.WriteLine(line);
            }
            Console.SetCursorPosition(editor.CursorX, editor.CursorY);

            info = Console.ReadKey(true);

            if (info.Key == ConsoleKey.Backspace)
            {
                if (editor.CursorX == 0)
                {
                    var line = editor.Text[editor.CursorY];
                    editor.Text.RemoveAt(editor.CursorY);
                    editor.setCursor(editor.CursorX, editor.CursorY - 1);
                    editor.Text[editor.CursorY] += line;
                    editor.setCursor(editor.Text[editor.CursorY].Length, editor.CursorY);
                    continue;
                }

                editor.Text[editor.CursorY] = editor.Text[editor.CursorY].Remove(editor.CursorX - 1 , 1);
                editor.setCursor(editor.CursorX - 1, editor.CursorY);
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                var line = editor.Text[editor.CursorY].Substring(editor.CursorX);
                editor.Text[editor.CursorY].Remove(editor.CursorY);

                Console.Write(Environment.NewLine + line);
                editor.Text.Add(line);
            }
            else if (info.Key == ConsoleKey.UpArrow)
            {
                editor.CursorY -= 1;
                editor.CursorX = editor.Text[editor.CursorY].Length;
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (editor.CursorY + 1 >= editor.Text.Count && editor.Text[editor.CursorY] == string.Empty)
                {
                    continue;
                }

                editor.setCursor(editor.Text[editor.CursorY].Length, editor.CursorY + 1);
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                editor.setCursor(editor.CursorX - 1, editor.CursorY);
            }
            else if (info.Key == ConsoleKey.RightArrow)
            {
                editor.setCursor(editor.CursorX + 1, editor.CursorY);
            }

            else
            {
                editor.Text[editor.CursorY] = editor.Text[editor.CursorY].Insert(editor.CursorX, info.KeyChar.ToString());
                editor.setCursor(editor.CursorX + 1, editor.CursorY);
            }
        }
    }
}