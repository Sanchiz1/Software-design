namespace Memento;
public class TextHistory
{
    private Stack<TextDocument> _snapshots = new Stack<TextDocument>();

    private TextEditor _editor = default!;

    public TextHistory(TextEditor editor)
    {
        _editor = editor;
    }

    public void Backup()
    {
        this._snapshots.Push(this._editor.CreateSnapshot());
    }

    public void Undo()
    {
        if (this._snapshots.Count == 0)
        {
            return;
        }

        var memento = this._snapshots.Pop();
        
        this._editor.Restore(memento);
    }

    public void ClearHistory()
    {
        this._snapshots.Clear();
    }
}
