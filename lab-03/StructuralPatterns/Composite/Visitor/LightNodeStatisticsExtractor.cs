using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Visitor;
public class LightNodeStatisticsExtractor : ILightNodeVisitor
{
    private Dictionary<string, int> _tags = new Dictionary<string, int>();

    public void VisitSelfClosingElementNode(SelfClosingElementNode node)
    {
        if (_tags.ContainsKey(node.Name))
        {
            _tags[node.Name] += 1;
        }
        else
        {
            _tags.Add(node.Name, 1);
        }
    }

    public void VisitPairedElementNode(PairedElementNode node)
    {
        if (_tags.ContainsKey(node.Name))
        {
            _tags[node.Name] += 1;
        }
        else
        {
            _tags.Add(node.Name, 1);
        }
        node.Children.ForEach(child =>
        child.Accept(this));
    }

    public void VisitLightTextNode(LightTextNode node)
    {
        return;
    }

    public void ResetStatistics()
    {
        _tags.Clear();
    }

    public Dictionary<string, int> GetStatistics()
    {
        return _tags;
    }
}
