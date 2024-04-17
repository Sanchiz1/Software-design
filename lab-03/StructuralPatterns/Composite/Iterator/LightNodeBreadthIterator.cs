using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Iterator;
public class LightNodeBreadthIterator : IEnumerator<ILightNode>
{
    private readonly LightNodeAggregate _lightNodeAggregate;
    private int position = 0;

    public List<ILightNode> LightNodes;

    public LightNodeBreadthIterator(LightNodeAggregate lightNodeAggregate)
    {
        _lightNodeAggregate = lightNodeAggregate;
        LightNodes = lightNodeAggregate.LightNodes;
    }

    public bool MoveNext()
    {
        if (LightNodes.Count < 1) return false;

        if (Current is LightElementNode lightNode)
        {
            foreach (var item in lightNode.Children)
            {
                LightNodes.Add(item);
            }
        }

        position++;
        return LightNodes.Count > position;
    }

    public void Reset()
    {
        position = 0;

        LightNodes.Clear();
    }

    public void Dispose()
    {
    }

    public ILightNode Current => LightNodes[position];

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
}
