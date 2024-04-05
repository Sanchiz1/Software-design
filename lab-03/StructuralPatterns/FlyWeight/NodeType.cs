using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight;
public class NodeType
{
    public string Name { get; } = default!;
    public TagDisplayType DisplayType { get; }
    public TagClosingType ClosingType { get; }

    public NodeType(
        string name,
        TagDisplayType displayType,
        TagClosingType closingType)
    {
        this.Name = name;
        this.DisplayType = displayType;
        this.ClosingType = closingType;
    }

    private string OpeningPart
        => this.ClosingType == TagClosingType.Single ? $"<{this.Name}" : $"<{this.Name}>";

    private string ClosingPart
        => this.ClosingType == TagClosingType.Single ? $"/>" : $"</{this.Name}>";
    private string TabStringBeforeText()
        => this.DisplayType == TagDisplayType.Column
        ? "\n" + "  "
        : string.Empty;

    private string TabStringAfterText()
        => this.DisplayType == TagDisplayType.Column
        ? "\n"
        : string.Empty;
    private string TextWithTabs(string text)
        => !string.IsNullOrEmpty(text) ? $"{TabStringBeforeText()}{text}{TabStringAfterText()}" : string.Empty;

    public string GetHTML(string text)
    {
        if(this.ClosingType == TagClosingType.Single && !string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Cannot have self-closing tag with text");
        }

        return $"{this.OpeningPart}{TextWithTabs(text)}{this.ClosingPart}";
    }
}
