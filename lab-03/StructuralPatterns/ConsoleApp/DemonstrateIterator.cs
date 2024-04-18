using Composite.Iterator;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;
internal static class DemonstrateIterator
{
    public static void Execute()
    {

        Console.WriteLine("Iterator:");

        LightElementNode div = new LightElementNode(
            "div",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            []
        );

        LightElementNode div1 = new LightElementNode(
            "div1",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            []
        );

        LightElementNode div2 = new LightElementNode(
            "div2",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            []
        );

        LightElementNode div1_1 = new LightElementNode(
            "div1_1",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            []
        );

        LightElementNode div1_2 = new LightElementNode(
                    "div1_2",
                    TagDisplayType.Column,
                    TagClosingType.Double,
                    [],
                    []
        );

        LightElementNode div2_1 = new LightElementNode(
            "div2_1",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            []
        );

        LightElementNode div2_2 = new LightElementNode(
                    "div2_2",
                    TagDisplayType.Column,
                    TagClosingType.Double,
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
