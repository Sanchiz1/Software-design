using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Iterator;
public class LightNodeDepthIterator : IEnumerator<ILightNode>
{
    private readonly LightNodeAggregate _lightNodeAggregate;
    private int position = 0;

    public List<ILightNode> LightNodes;

    public LightNodeDepthIterator(LightNodeAggregate lightNodeAggregate)
    {
        _lightNodeAggregate = lightNodeAggregate;
        LightNodes = lightNodeAggregate.LightNodes;
    }

    public bool MoveNext()
    {
        if (LightNodes.Count < 1) return false;

        if (Current is LightElementNode lightNode)
        {
            int index = position + 1;
            foreach (var item in lightNode.Children)
            {
                if (LightNodes.Count <= index)
                {
                    LightNodes.Add(item);
                    index++;
                }
                else
                {
                    LightNodes.Insert(index++, item);
                }
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
