using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento;
public class TextEditor
{
    public List<string> Text { get; set; } = [string.Empty];
    public int CursorX {  get; set; }
    public int CursorY {  get; set; }
    public void setText(List<string> text) {
        Text = text;
    }
    public void setCursor(int x, int y)
    {
        if(x < 0) x= 0;
        if(y < 0) y = 0;
        CursorX = x;
        CursorY = y;
    }

    public TextDocument CreateSnapshot()
    {
        return new TextDocument(this, Text, CursorX, CursorY);
    }

    public void Restore(TextDocument snapshot)
    {
        this.setText(snapshot.Text);
        this.setCursor(snapshot.CursorX, snapshot.CursorY);
    }
}
