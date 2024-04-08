using Composite;
using Flyweight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight;
public class HTMLLayout
{
    public string Text { get; set; }

    private string[] GetLines => Text.Split('\n');

    public HTMLLayout(string text)
    {
        this.Text = text;
    }

    public ILightNode GetLightNodeFromLayout()
    {
        LightElementNode parentElement = new LightElementNode(
           string.Empty,
           TagDisplayType.Column,
           TagClosingType.Double,
           [],
           []
        );

        var lines = this.GetLines;

        parentElement.AddChildElement(new LightElementNode(
            "h1",
            TagDisplayType.Row,
            TagClosingType.Double,
            [],
            [new LightTextNode(lines[0].Trim())]
        ));

        for (int i = 1; i < lines.Length; i++)
        {
            string elementTag = "p";

            if (lines[i].Length < 20)
            {
                elementTag = "h2";
            }

            if (lines[i].StartsWith(' '))
            {
                elementTag = "blockquote";
            }

            parentElement.AddChildElement(new LightElementNode(
                elementTag,
                TagDisplayType.Row,
                TagClosingType.Double,
                [],
                [new LightTextNode(lines[i].Trim())]
            ));
        }

        return parentElement;
    }
    public List<Node> GetFlyweightNodesFromLayout()
    {
        var lines = this.GetLines;

        List<Node> nodes = new List<Node>();

        var h1Type = NodeFactory.GetNodeType("h1", TagDisplayType.Row, TagClosingType.Double);
        nodes.Add(new Node(lines[0].Trim(), h1Type, []));

        for (int i = 1; i < lines.Length; i++)
        {
            string elementTag = "p";

            if (lines[i].Length < 20)
            {
                elementTag = "h2";
            }

            if (lines[i].StartsWith(' '))
            {
                elementTag = "blockquote";
            }

            var nodeType = NodeFactory.GetNodeType(elementTag, TagDisplayType.Row, TagClosingType.Double);
            nodes.Add(new Node(lines[i].Trim(), nodeType, []));
        }

        return nodes;
    }
}
