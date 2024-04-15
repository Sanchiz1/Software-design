using ChainOfResponsibility;
using ChainOfResponsibility.ResetPasswordHandler;
using Mediator;
using Observer;
using Observer.LightNode;
using Strategy;
using Strategy.ImageProvider;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(
                "1 - ChainOfResponsibility\n2 - Mediator\n3 - Observer\n4 - Strategy\n0 - close");

            var choice = Console.ReadLine() ?? string.Empty;

            switch(choice)
            {
                case "1":
                    DemostrateChainOfResponsibility();
                    break;
                case "2":
                    DemostrateMediator();
                    break;
                case "3":
                    DemostrateObserver();
                    break;
                case "4":
                    DemostrateStrategy();
                    break;
                case "0":
                    return;
            }
        }
    }

    private static void DemostrateChainOfResponsibility()
    {
        Console.WriteLine("\n\n");
        IPasswordResetManager passwordResetManager = new PasswordResetManager();

        ResetUsingEmailHandler resetUsingEmailHandler = new ResetUsingEmailHandler(passwordResetManager); 
        ResetUsingBackupEmailHandler resetUsingBackupEmailHandler = new ResetUsingBackupEmailHandler(passwordResetManager);
        ResetUsingPhoneNumberHandler resetUsingPhoneNumberHandler = new ResetUsingPhoneNumberHandler(passwordResetManager);
        ResetUsingSecretQuestionHandler resetUsingSecretQuestionHandler = new ResetUsingSecretQuestionHandler(passwordResetManager);
        
        resetUsingEmailHandler.SetNext(resetUsingBackupEmailHandler)
            .SetNext(resetUsingPhoneNumberHandler)
            .SetNext(resetUsingSecretQuestionHandler);


        Console.WriteLine("Enter username: ");
        var username = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter new password: ");
        var newPassword = Console.ReadLine() ?? string.Empty;

        var request = new ResetPasswordRequest(username, newPassword);

        Console.WriteLine("Trying reset user password: Username - {0}, New password - {1}", request.Username, request.NewPassword);

        var res = resetUsingEmailHandler.Handle(request);

        Console.WriteLine(res);
        Console.WriteLine("\n\n");
    }

    private static void DemostrateMediator()
    {
        Console.WriteLine("\n\n");
        CommandCentre commandCentre = new CommandCentre();

        Aircraft aircraft_1 = new Aircraft("Aircraft 1", commandCentre);
        Aircraft aircraft_2 = new Aircraft("Aircraft 1", commandCentre);
        Aircraft aircraft_3 = new Aircraft("Aircraft 1", commandCentre);

        Runway runway_1 = new Runway(commandCentre);
        Runway runway_2 = new Runway(commandCentre);

        Console.WriteLine("\nTrying to land aircraft 1 on runway 1");
        aircraft_1.Land();

        Console.WriteLine("\nTrying to land aircraft 2 on runway 2");
        aircraft_2.Land();

        Console.WriteLine("\nTrying to land aircraft 3 on runway 1");
        aircraft_3.Land();

        Console.WriteLine("\nTrying to take off aircraft 1");
        aircraft_1.TakeOff();

        Console.WriteLine("\nTrying to land aircraft 3 on runway 1");
        aircraft_3.Land();

        Console.WriteLine("\nCheking if runway 2 is active: {0}", runway_2.CheckIsActive());

        aircraft_2.IsTakingOff = true;

        Console.WriteLine("\nCheking if runway 1 is active (aircraft 2 is taking off): {0}", runway_2.CheckIsActive());

        Console.WriteLine("\n\n");
    }

    private static void DemostrateObserver()
    {
        Console.WriteLine("\n\n");

        Console.WriteLine("Created layout:");

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

        Console.WriteLine(divElement.GetOuterHTML());

        Console.WriteLine("\nAdding two event listeners onClick and one event listener onHover to paragraph:\n");

        pElement.AddEventListener(
            new LightNodeEventListener("onClick", () => Console.WriteLine("You clicked on paragraph!")));

        pElement.AddEventListener(
            new LightNodeEventListener("onClick", () => Console.WriteLine("Paragraph is clicked on!")));

        pElement.AddEventListener(
            new LightNodeEventListener("onHover", () => Console.WriteLine("Your mouse is over paragraph!")));

        Console.WriteLine("\nClicking on the paragraph:\n");

        pElement.Notify("onClick");

        Console.WriteLine("\nHovering over the paragraph:\n");

        pElement.Notify("onHover");

        Console.WriteLine("\n\n");
    }

    private static void DemostrateStrategy()
    {
        Console.WriteLine("\n\n");

        IImageProvider urlImageProvider = new UrlImageProvider();
        IImageProvider fileImageProvider = new FileImageProvider();

        LightImageNode lightImageNode1 = new LightImageNode(
            "https://huggingface.co/hgarg/fruits/resolve/main/images/apple.jpg",
            "apple",
            TagDisplayType.Row,
            TagClosingType.Single,
            [],
            urlImageProvider
            );


        Console.WriteLine("Image with url:");
        Console.WriteLine(lightImageNode1.GetOuterHTML());

        Console.WriteLine("Getting image bytes and writing to the file (apple.jpg):");
        var image = lightImageNode1.GetImageBytes();
        System.IO.File.WriteAllBytes("apple.jpg", image);


        LightImageNode lightImageNode2 = new LightImageNode(
            "apple.jpg",
            "apple",
            TagDisplayType.Column,
            TagClosingType.Double,
            [],
            fileImageProvider
            );

        Console.WriteLine("Image with file path (apple.jpg):");
        Console.WriteLine(lightImageNode2.GetOuterHTML());

        var image2 = lightImageNode2.GetImageBytes();
        //Console.WriteLine(string.Join(", ", image2));

        Console.WriteLine("\n\n");
    }
}