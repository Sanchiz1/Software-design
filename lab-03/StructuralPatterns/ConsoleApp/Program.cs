using Adapter;
using Adapter.Loggers;
using Bridge.Drawing;
using Bridge.Shapes;
using Composite;
using Composite.Iterator;
using Decorator.Characters;
using Decorator.Items;
using FlyWeight;
using Proxy.SmartText;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        DemonstrateIterator();/*
        DemonstrateAdapter();
        DemonstrateDecorator();
        DemonstrateBridge();
        DemonstrateProxy();
        DemonstrateComposite();
        DemonstrateFlyweight();*/
    }

    public static void DemonstrateAdapter()
    {
        Console.WriteLine("Adapter:");
        Logger logger = new Logger();

        logger.Log("Application working on thread {0}", Thread.CurrentThread.ManagedThreadId);
        logger.Error("Something is wrong");
        logger.Warn("You should be aware");

        FileWriter fileWriter = new FileWriter("output.txt");

        FileLogger fileLogger = new FileLogger(fileWriter);

        fileLogger.Log("Application working on thread {0}", Thread.CurrentThread.ManagedThreadId);
        fileLogger.Error("Something is wrong");
        fileLogger.Warn("You should be aware");

        Console.WriteLine("-------------------------------------\n\n");
    }

    public static void DemonstrateDecorator()
    {
        Console.WriteLine("Decorator:");

        ICharacter mage = new Mage();
        ICharacter palladin = new Palladin();
        ICharacter warrior = new Warrior();

        Console.WriteLine();

        Console.WriteLine(mage.GetDatails());
        Console.WriteLine(palladin.GetDatails());
        Console.WriteLine(warrior.GetDatails());

        Console.WriteLine();

        Armor mageWithArmor = new Armor(mage, 50, "Magic Armor");
        Weapon mageWithArmorAndWeapon = new Weapon(mageWithArmor, 50, "Magic Stick");
        Weapon palladinWithWeapon = new Weapon(palladin, 50, "Axe");

        Console.WriteLine(mageWithArmorAndWeapon.GetDatails());
        Console.WriteLine(palladinWithWeapon.GetDatails());

        Console.WriteLine("\n\nTaking damage:\n");

        warrior.Attack(mageWithArmorAndWeapon);
        palladinWithWeapon.Attack(warrior);

        Console.WriteLine(mageWithArmorAndWeapon.GetDatails());
        Console.WriteLine(warrior.GetDatails());

        Console.WriteLine("-------------------------------------\n\n");
    }

    public static void DemonstrateBridge()
    {
        Console.WriteLine("Bridge:");

        IDrawingAPI rasterDrawingAPI = new RasterDrawingAPI();
        IDrawingAPI vectorDrawingAPI = new VectorDrawingAPI();

        Shape circle = new Circle(rasterDrawingAPI);
        Shape square = new Square(vectorDrawingAPI);
        Shape triangle = new Triangle(rasterDrawingAPI);

        circle.Draw();
        square.Draw();
        triangle.Draw();

        Console.WriteLine("-------------------------------------\n\n");
    }

    public static void DemonstrateProxy()
    {
        Console.WriteLine("Proxy:");

        File.Delete("example.txt");

        StreamWriter file = new StreamWriter("example.txt", true);
        file.WriteLine("Hello, world!!!");
        file.WriteLine("This is me!");
        file.Close();

        ConsoleLogger consoleLogger = new ConsoleLogger();
        SmartTextReader reader = new SmartTextReader();
        char[][] text = reader.ReadTextFile("example.txt");
        if (text != null)
        {
            Console.WriteLine("Content of example.txt:");
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine();
        SmartTextChecker checker = new SmartTextChecker(reader, consoleLogger);
        text = checker.ReadTextFile("example.txt");

        Console.WriteLine();

        SmartTextReaderLocker locker = new SmartTextReaderLocker(reader, consoleLogger, @"example.txt");
        text = locker.ReadTextFile("example.txt");

        Console.WriteLine("-------------------------------------\n\n");
    }

    public static void DemonstrateComposite()
    {
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

        Console.WriteLine("-------------------------------------\n\n");
    }

    public static void DemonstrateFlyweight()
    {
        Console.WriteLine("Flyweight:");

        HttpClient httpClient = new HttpClient();

        using HttpResponseMessage response = httpClient.GetAsync("https://www.gutenberg.org/cache/epub/1513/pg1513.txt").Result;

        response.EnsureSuccessStatusCode();

        var text = response.Content.ReadAsStringAsync().Result;

        var mem1 = CreateLightNodeLayout(text);

        Console.WriteLine();

        var mem2 = CreateFlyweightNodeLayout(text);

        Console.WriteLine("Saved memory: {0} bytes", mem1 - mem2);

        Console.WriteLine("-------------------------------------\n\n");
    }

    private static long CreateLightNodeLayout(string text)
    {
        GC.Collect();
        Console.WriteLine("Creating LightNode HTML Layout:");

        var layout = new HTMLLayout(text);

        int memUsageInMB = 0;

        long memBefore = GC.GetTotalMemory(true);

        int numGen0Collections = GC.CollectionCount(0);

        var lightNode = layout.GetLightNodeFromLayout();

        long memAfter = GC.GetTotalMemory(false);

        Console.WriteLine("Did a GC occur while measuring?  {0}", numGen0Collections == GC.CollectionCount(0));

        long memUsage = (memAfter - memBefore);
        if (memUsage < 0)
        {
            Console.WriteLine("GC's occurred while measuring memory usage.  Try measuring again.");
            memUsage = 1 << 20;
        }

        memUsageInMB = (int)(1 + (memUsage >> 20));
        Console.WriteLine("Memory usage estimate: {0} bytes, rounded to {1} MB", memUsage, memUsageInMB);

        return memUsage;
    }

    private static long CreateFlyweightNodeLayout(string text)
    {
        GC.Collect();
        Console.WriteLine("Creating FlyweightNode HTML Layout:");

        var layout = new HTMLLayout(text);

        int memUsageInMB = 0;

        long memBefore = GC.GetTotalMemory(true);

        int numGen0Collections = GC.CollectionCount(0);

        var flyweightNodes = layout.GetFlyweightNodesFromLayout();

        long memAfter = GC.GetTotalMemory(false);

        Console.WriteLine("Did a GC occur while measuring?  {0}", numGen0Collections == GC.CollectionCount(0));

        long memUsage = (memAfter - memBefore);
        if (memUsage < 0)
        {
            Console.WriteLine("GC's occurred while measuring memory usage.  Try measuring again.");
            memUsage = 1 << 20;
        }

        memUsageInMB = (int)(1 + (memUsage >> 20));
        Console.WriteLine("Memory usage estimate: {0} bytes, rounded to {1} MB", memUsage, memUsageInMB);

        return memUsage;
    }


    public static void DemonstrateIterator()
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

public class ConsoleLogger : Proxy.ILogger
{
    private static string LogMessage = string.Format("{0, 10}", "info: ");
    private static string ErrorMessage = string.Format("{0, 10}", "error: ");
    public void Info(string message, params object?[] arg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ConsoleLogger.LogMessage + message, arg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Error(string message, params object?[] arg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ConsoleLogger.ErrorMessage + message, arg);
        Console.ForegroundColor = ConsoleColor.White;
    }
}