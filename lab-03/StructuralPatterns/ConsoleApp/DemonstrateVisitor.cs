using Composite.Iterator;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.Command.Editor;
using Composite.Command.ChildCommand;
using Composite.TemplateMethod;
using Composite.Visitor;

namespace ConsoleApp;
internal static class DemonstrateVisitor
{
    public static void Execute()
    {

        Console.WriteLine("Visitor:");

        PairedElementNode pElement = new PairedElementNode(
            "p",
            TagDisplayType.Row,
            ["paragraph"],
            [new LightTextNode("This is paragraph text.")]
        );

        PairedElementNode divElement = new PairedElementNode(
            "div",
            TagDisplayType.Column,
            ["container", "box"],
            [new LightTextNode("This is container text.")]
        );

        PairedElementNode ulElement = new PairedElementNode(
                "ul",
                TagDisplayType.Column,
                [],
                []
            );

        PairedElementNode liElement1 = new PairedElementNode(
                "li",
                TagDisplayType.Row,
                ["paragraph"],
                []
            );

        PairedElementNode liElement2 = new PairedElementNode(
                "li",
                TagDisplayType.Column,
                [],
                []
            );

        PairedElementNode liElement3 = new PairedElementNode(
                "li",
                TagDisplayType.Row,
                [],
                []
            );

        PairedElementNode imgElement = new PairedElementNode(
                "img",
                TagDisplayType.Row,
                ["image"],
                []
            );


        divElement.AddChildElement(
            ulElement
                .AddChildElement(liElement1
                        .AddChildElement(new LightTextNode("This is li text.")))
                .AddChildElement(liElement2
                        .AddChildElement(pElement))
                .AddChildElement(liElement3
                        .AddChildElement(imgElement))
        );


        Console.WriteLine(divElement.GetOuterHTML());


        Console.WriteLine("\n\nExtracting all text from node tree using visitor:\n");
        var textExtractor = new LightNodeTextExtractor();
        divElement.Accept(textExtractor);

        textExtractor.GetLines().ForEach(line => Console.WriteLine(line));

        Console.WriteLine("\n\nExtracting statistics from node tree using visitor (tags count):\n");
        var statisticsExtractor = new LightNodeStatisticsExtractor();
        divElement.Accept(statisticsExtractor);

        foreach (var item in statisticsExtractor.GetStatistics())
        {
            Console.WriteLine("\"{0}\" - {1}", item.Key, item.Value);
        }

        Console.WriteLine("-------------------------------------\n\n");
    }
}
