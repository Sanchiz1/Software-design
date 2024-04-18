using Composite.Command.ChildCommand;
using Composite.Command.Editor;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.State;

namespace ConsoleApp;
internal static class DemonstrateState
{
    public static void Execute()
    {
        Console.WriteLine("State:");

        LightElementNode pElement = new LightElementNode(
            "p",
            TagDisplayType.Row,
            TagClosingType.Double,
            ["paragraph"],
            [new LightTextNode("This is paragraph text.")]
        );

        LightElementNode divElement = new LightElementNode(
            "div",
            TagDisplayType.Column,
            TagClosingType.Double,
            ["container", "box"],
            [new LightTextNode("This is container text.")]
        );

        LightElementNode ulElement = new LightElementNode(
                "ul",
                TagDisplayType.Column,
                TagClosingType.Double,
                [],
                []
            );

        LightElementNode liElement1 = new LightElementNode(
                "li",
                TagDisplayType.Row,
                TagClosingType.Double,
                ["paragraph"],
                []
            );

        LightElementNode liElement2 = new LightElementNode(
                "li",
                TagDisplayType.Column,
                TagClosingType.Double,
                [],
                []
            );

        LightElementNode liElement3 = new LightElementNode(
                "li",
                TagDisplayType.Row,
                TagClosingType.Double,
                [],
                []
            );

        LightElementNode imgElement = new LightElementNode(
                "img",
                TagDisplayType.Row,
                TagClosingType.Single,
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

        Console.WriteLine("\n\nVisible children state:\n");
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
