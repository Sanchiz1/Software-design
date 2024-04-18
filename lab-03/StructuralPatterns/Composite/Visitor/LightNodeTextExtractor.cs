using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Visitor;
public class LightNodeTextExtractor : ILightNodeVisitor
{
    private List<string> _lines = new List<string>();

    public void VisitSelfClosingElementNode(SelfClosingElementNode node)
    {
        return;
    }

    public void VisitPairedElementNode(PairedElementNode node)
    {
        node.Children.ForEach(child => 
        child.Accept(this));
    }

    public void VisitLightTextNode(LightTextNode node)
    {
        _lines.Add(node.Text);
    }

    public void ResetText()
    {
        _lines.Clear();
    }

    public List<string> GetLines()
    {
        return _lines;
    }
}
