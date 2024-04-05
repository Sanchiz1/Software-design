using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite;
public class LightElementNode : ILightNode
{
    public string Name { get; } = default!;
    public TagDisplayType DisplayType { get; }
    public TagClosingType ClosingType { get; }
    public List<string> Classes { get; } = new List<string>();
    public List<ILightNode> Children { get; } = new List<ILightNode>();
    private string TabString(int depth)
        => this.DisplayType == TagDisplayType.Column
        ? "\n" + string.Concat(Enumerable.Repeat("  ", depth))
        : string.Empty;

    public LightElementNode(
        string name,
        TagDisplayType displayType,
        TagClosingType closingType,
        List<string> classes,
        List<ILightNode> children)
    {
        if (closingType == TagClosingType.Single && children.Count > 0)
            throw new ArgumentException("Cannot create self-closing tag with children");

        this.Name = name;
        this.DisplayType = displayType;
        this.ClosingType = closingType;
        this.Classes = classes;
        this.Children = children;
    }

    public LightElementNode AddChildElement(ILightNode node)
    {
        this.Children.Add(node);

        return this;
    }

    private string ClassesPart
        => this.Classes.Count() > 0 ? $" class=\"{string.Join(' ', this.Classes)}\"" : string.Empty;

    private string OpeningPart
        => this.ClosingType == TagClosingType.Single ? $"<{this.Name}{this.ClassesPart}" : $"<{this.Name}{this.ClassesPart}>";

    private string ClosingPart
        => this.ClosingType == TagClosingType.Single ? $"/>" : $"</{this.Name}>";

    public string GetOuterHTML(int depth = 0)
    {
        return $"{this.OpeningPart}{this.GetInnerHTML(depth + 1)}{TabString(depth)}{this.ClosingPart}";
    }

    public string GetInnerHTML(int depth = 0)
    {
        StringBuilder innerHtml = new StringBuilder();
        this.Children.ForEach(
            node => innerHtml.Append(TabString(depth) + node.GetOuterHTML(depth)));

        return innerHtml.ToString();
    }
}

public enum TagDisplayType
{
    Row,
    Column,
}

public enum TagClosingType
{
    Single,
    Double
}
