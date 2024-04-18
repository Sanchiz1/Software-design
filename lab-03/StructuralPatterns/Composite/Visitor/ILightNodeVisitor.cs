using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Visitor;
public interface ILightNodeVisitor
{
    void VisitSelfClosingElementNode(SelfClosingElementNode node);
    void VisitPairedElementNode(PairedElementNode node);
    void VisitLightTextNode(LightTextNode node);
}
