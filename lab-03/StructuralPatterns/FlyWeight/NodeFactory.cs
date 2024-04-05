using Composite;
using FlyWeight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight;
public class NodeFactory
{
    private List<NodeType> NodeTypes = new List<NodeType>();

    public NodeFactory(params NodeType[] args)
    {
        this.NodeTypes = args.ToList();
    }

    public NodeType GetFlyweightType(string name, TagDisplayType displayType, TagClosingType closingType)
    {
        var type = NodeTypes.FirstOrDefault(node
            => node.Name == name
            && node.DisplayType == displayType
            && node.ClosingType == closingType);

        if (type == null)
        {
            type = new NodeType(name, displayType, closingType);

            NodeTypes.Add(type);
        }

        return type;
    }
}
