using Composite.Command.ChildCommand;
using Composite.Command.Editor;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.State;
using Composite.TemplateMethod;

namespace ConsoleApp;
internal static class DemonstrateTemplateMethod
{
    public static void Execute()
    {
        Console.WriteLine("Template method:");

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

        SelfClosingElementNode imgElement = new SelfClosingElementNode(
                "img",
                ["image"]
            );

        SelfClosingElementNode brElement = new SelfClosingElementNode(
                "br",
                []
            );

        divElement.AddChildElement(
            ulElement
                .AddChildElement(liElement1
                        .AddChildElement(new LightTextNode("This is li text.")))
                .AddChildElement(liElement2
                        .AddChildElement(pElement))
                .AddChildElement(brElement)
                .AddChildElement(liElement3
                        .AddChildElement(imgElement))
        );

        Console.WriteLine("\n\nCreated two nodes with self-closing types: img, br\n\n");
        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("-------------------------------------\n\n");
    }
}
