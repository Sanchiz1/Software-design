using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento;
public class TextDocument
{
    public TextEditor Editor { get; set; } = default!;
    public List<string> Text { get; set; }
    public int CursorX { get; set; }
    public int CursorY { get; set; }

    public TextDocument(TextEditor editor, List<string> text, int cursorX, int cursorY)
    {
        Editor = editor;
        Text = text;
        CursorX = cursorX;
        CursorY = cursorY;
    }

    public void Restore()
    {
        Editor.SetText(Text);
        Editor.SetCursor(CursorX, CursorY);
    }
}
