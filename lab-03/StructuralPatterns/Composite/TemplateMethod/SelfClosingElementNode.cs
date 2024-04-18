using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.TemplateMethod;
public class SelfClosingElementNode : LightElementNode
{
    public SelfClosingElementNode(string name, List<string> classes) : base(name, TagDisplayType.Row, classes)
    {
    }

    protected override string GetOpeningPart()
    {
        return $"<{Name}{GetClassesPart()}";
    }
    protected override string GetClosingPart()
    {
        return $"/>";
    }
}
