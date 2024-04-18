using Composite.Iterator;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.TemplateMethod;

namespace ConsoleApp;
internal static class DemonstrateIterator
{
    public static void Execute()
    {

        Console.WriteLine("Iterator:");

        PairedElementNode div = new PairedElementNode(
            "div",
            TagDisplayType.Column,
            [],
            []
        );

        PairedElementNode div1 = new PairedElementNode(
            "div1",
            TagDisplayType.Column,
            [],
            []
        );

        PairedElementNode div2 = new PairedElementNode(
            "div2",
            TagDisplayType.Column,
            [],
            []
        );

        PairedElementNode div1_1 = new PairedElementNode(
            "div1_1",
            TagDisplayType.Column,
            [],
            []
        );

        PairedElementNode div1_2 = new PairedElementNode(
                    "div1_2",
                    TagDisplayType.Column,
                    [],
                    []
        );

        PairedElementNode div2_1 = new PairedElementNode(
            "div2_1",
            TagDisplayType.Column,
            [],
            []
        );

        PairedElementNode div2_2 = new PairedElementNode(
                    "div2_2",
                    TagDisplayType.Column,
                    [],
                    []
        );

        div.AddChildElement(
            div1
                .AddChildElement(div1_1)
                .AddChildElement(div1_2)
        ).AddChildElement(
            div2
                .AddChildElement(div2_1)
                .AddChildElement(div2_2)
        );

        Console.WriteLine(div.GetOuterHTML());

        Console.WriteLine("\n\n\nDepth:");

        var aggregate = new LightNodeAggregate([div], LightNodeAggregate.IterationType.Depth);

        foreach (var el in aggregate)
        {
            if (el is LightElementNode element)
            {
                Console.WriteLine(element.Name);
            }
            if (el is LightTextNode text)
            {
                Console.WriteLine(text);
            }
        }

        Console.WriteLine("\n\n\nBreadth:");

        var aggregate2 = new LightNodeAggregate([div], LightNodeAggregate.IterationType.Breadth);

        foreach (var el in aggregate2)
        {
            if (el is LightElementNode element)
            {
                Console.WriteLine(element.Name);
            }
            if (el is LightTextNode text)
            {
                Console.WriteLine(text);
            }
        }


        Console.WriteLine("-------------------------------------\n\n");
    }
}
