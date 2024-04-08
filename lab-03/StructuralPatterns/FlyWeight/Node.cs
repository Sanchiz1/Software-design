using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight;
public class Node
{
    public string Text { get; } = default!;
    public NodeType NodeType { get; }
    public List<Node> Children { get; }

    public Node(string text, NodeType nodeType, List<Node> children)
    {
        this.Text = text;
        this.NodeType = nodeType;
        Children = children;
    }

    public string GetHTML()
    {
        return this.NodeType.GetHTML(this.Text);
    }
}
