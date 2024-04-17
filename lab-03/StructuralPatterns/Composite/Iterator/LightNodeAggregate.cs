using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Iterator;
public class LightNodeAggregate : IEnumerable<ILightNode>
{
    public IterationType _type;
    public List<ILightNode> LightNodes;

    public LightNodeAggregate(List<ILightNode> lightNodes, IterationType type)
    {
        LightNodes = lightNodes;
        _type = type;
    }

    public IEnumerator<ILightNode> GetEnumerator()
    {
        if (_type is IterationType.Breadth)
        {
            return new LightNodeBreadthIterator(this);
        }
        else if (_type is IterationType.Depth)
        {
            return new LightNodeDepthIterator(this);
        }

        throw new ArgumentException("Unsupported iteration type");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public enum IterationType
    {
        Breadth,
        Depth
    }
}