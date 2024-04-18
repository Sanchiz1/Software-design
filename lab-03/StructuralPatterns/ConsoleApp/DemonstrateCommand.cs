using Composite.Iterator;
using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.Command.Editor;
using Composite.Command.ChildCommand;

namespace ConsoleApp;
internal static class DemonstrateCommand
{
    public static void Execute()
    {

        Console.WriteLine("Command:");

        Console.WriteLine("Composite:");

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

        var editor = new LightHTMLEditor();

        var addChild1 = new AddChildCommand(divElement, ulElement);
        var addChild2 = new AddChildCommand(ulElement, liElement1);
        var addText = new AddTextCommand(liElement1, "This is li text.");
        var addChild3 = new AddChildCommand(ulElement, liElement2);
        var addChild4 = new AddChildCommand(liElement2, pElement);
        var removeChild = new RemoveChildCommand(liElement2, pElement);

        Console.WriteLine("\n\n\nExecuting building commands, result:\n");

        editor.Execute(addChild1);
        editor.Execute(addChild2);
        editor.Execute(addChild3);
        editor.Execute(addChild4);
        editor.Execute(addText);

        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("\n\n\nExecuting removing command(Remove p child from li), result:\n");
        editor.Execute(removeChild);
        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("\n\n\nUndo once(Return p child to li), result:\n");
        editor.Undo();
        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("\n\n\nUndo twice(Remove text from li), result:\n");
        editor.Undo();
        Console.WriteLine(divElement.GetOuterHTML());


        Console.WriteLine("-------------------------------------\n\n");
    }
}
