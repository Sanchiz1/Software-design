using static System.Net.Mime.MediaTypeNames;

namespace Memento;
public class TextEditor
{
    public List<string> Text { get; set; } = [string.Empty];
    public int CursorX {  get; set; }
    public int CursorY {  get; set; }
    public void SetText(List<string> text) {
        Text= new List<string>(text);
    }
    public void SetLineText(string text, int line) {
        Text[line] = text;
    }
    public void SetCursor(int x, int y)
    {
        if(x < 0) x= 0;
        if(y < 0) y = 0;
        CursorX = x;
        CursorY = y;
    }

    public TextDocument CreateSnapshot()
    {
        return new TextDocument(new List<string>(Text), CursorX, CursorY);
    }


    public void Type(string text)
    {
        SetLineText(
            Text[CursorY].Insert(CursorX, text),
            CursorY);

        SetCursor(CursorX + text.Length, CursorY);
    }

    public void Delete()
    {
        if (CursorX > 0)
        {
            SetLineText(
                Text[CursorY].Remove(CursorX - 1, 1),
            CursorY);

            SetCursor(CursorX - 1, CursorY);

            return;
        }

        if (CursorY == 0) return;

        var line = Text[CursorY];

        Text.RemoveAt(CursorY);

        SetLineText(Text[CursorY - 1] + line, CursorY - 1);

        SetCursor(CursorX, CursorY - 1);
    }

    public void MoveUp()
    {
        if (CursorY == 0) return;

        if (Text[CursorY - 1].Length < CursorX + 1)
        {
            SetCursor(Text[CursorY - 1].Length, CursorY - 1);

            return;
        }

        SetCursor(CursorX, CursorY - 1);
    }

    public void MoveDown()
    {
        if (Text[CursorY] == string.Empty) return;

        if (Text.Count <= CursorY + 1)
        {
            SetText(Text.Append(string.Empty).ToList());

            SetCursor(0, CursorY + 1);

            return;
        }

        if (Text[CursorY + 1].Length < CursorX + 1)
        {
            SetCursor(Text[CursorY + 1].Length, CursorY + 1);

            return;
        }

        SetCursor(CursorX, CursorY + 1);
    }

    public void MoveLeft()
    {
        if (CursorX == 0 && CursorY != 0)
        {
            SetCursor(Text[CursorY - 1].Length, CursorY - 1);
            return;
        }


        SetCursor(CursorX - 1, CursorY);
    }

    public void MoveRight()
    {
        if (CursorX == Text[CursorY].Length && CursorY + 1 < Text.Count())
        {
            SetCursor(0, CursorY + 1);
            return;
        }

        if (CursorX + 1 > Text[CursorY].Length)
        {
            return;
        }

        SetCursor(CursorX + 1, CursorY);
    }

    public void NewLine()
    {
        var line = Text[CursorY].Substring(CursorX);

        SetLineText(Text[CursorY].Remove(CursorX), CursorY);

        Text.Insert(CursorY + 1, line);

        SetCursor(0, CursorY + 1);

        return;
    }

    public void Restore(TextDocument snapshot)
    {
        this.SetText(snapshot.Text);
        this.SetCursor(snapshot.CursorX, snapshot.CursorY);
    }
}
