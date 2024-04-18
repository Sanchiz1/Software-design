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
internal static class DemonstrateState
{
    public static void Execute()
    {
        Console.WriteLine("State:");

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

        liElement3.ChangeState(new HiddenChildrenState(liElement3));
        Console.WriteLine("\n\nVisible children state for ul:\n");
        Console.WriteLine(divElement.GetOuterHTML());

        ulElement.ChangeState(new HiddenChildrenState(ulElement));

        Console.WriteLine("\n\nHidden children state for ul:\n");
        Console.WriteLine(divElement.GetOuterHTML());

        ulElement.ChangeState(new VisibleChildrenState(ulElement));

        Console.WriteLine("\n\nBack to visible children state for ul:\n");
        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("-------------------------------------\n\n");
    }
}
