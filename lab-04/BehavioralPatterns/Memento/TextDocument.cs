namespace Memento;
public class TextDocument
{
    public List<string> Text { get; set; }
    public int CursorX { get; set; }
    public int CursorY { get; set; }

    public TextDocument(List<string> text, int cursorX, int cursorY)
    {
        Text = text;
        CursorX = cursorX;
        CursorY = cursorY;
    }
}
