using AbstractFactory.Devices.Implementations.BalaxyDevices;
using AbstractFactory.Factories;
using Builder;
using FactoryMethod.Providers;
using FactoryMethod.Subscriptions;
using Prototype;
using Singleton;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        DemonstrateFactoryMethod();
        DemonstrateAbstractFactory();
        DemonstrateSingleton();
        DemonstratePrototype();
        DemonstrateBuilder();
    }

    private static void DemonstrateFactoryMethod()
    {
        Console.WriteLine("Factory method:");

        int userId = 1;

        MobileApp mobileApp = new MobileApp();
        WebSite webSite = new WebSite();
        ManagerCall managerCall = new ManagerCall();

        Console.WriteLine("\nCreating subscriptions:");

        var domesticSubscription = mobileApp.CreateSubscription(userId, SubscriptionType.Domestic);
        var educationalSubscription = webSite.CreateSubscription(userId, SubscriptionType.Educational);
        var premiumSubscription = managerCall.CreateSubscription(userId, SubscriptionType.Premium);

        Console.WriteLine(domesticSubscription);
        Console.WriteLine(educationalSubscription);
        Console.WriteLine(premiumSubscription);

        Console.WriteLine("-------------------------------------\n\n");
    }


    private static void DemonstrateAbstractFactory()
    {
        Console.WriteLine("Abstract factory:");

        IDeviceFactory kiaomiFactory = new KiaomiFactory();
        IDeviceFactory IProneFactory = new IProneFactory();
        IDeviceFactory balaxyFactory = new BalaxyFactory();

        Console.WriteLine("\nCreating smartphones:");

        var kiaomiSmartphone = kiaomiFactory.CreateSmartphone();
        var iProneSmartphone = IProneFactory.CreateSmartphone();
        var balaxySmartphone = balaxyFactory.CreateSmartphone();

        Console.WriteLine(kiaomiSmartphone.GetDetails());
        Console.WriteLine(iProneSmartphone.GetDetails());
        Console.WriteLine(balaxySmartphone.GetDetails());

        Console.WriteLine("\nCreating laptops:");

        var kiaomiLaptop = kiaomiFactory.CreateLaptop();
        var iProneLaptop = IProneFactory.CreateLaptop();
        var balaxyLaptop = balaxyFactory.CreateLaptop();

        Console.WriteLine(kiaomiLaptop.GetDetails());
        Console.WriteLine(iProneLaptop.GetDetails());
        Console.WriteLine(balaxyLaptop.GetDetails());

        Console.WriteLine("\nCreating ebooks:");

        var kiaomiEBook = kiaomiFactory.CreateEBook();
        var iProneEBook = IProneFactory.CreateEBook();
        var balaxyEBook = balaxyFactory.CreateEBook();

        Console.WriteLine(kiaomiEBook.GetDetails());
        Console.WriteLine(iProneEBook.GetDetails());
        Console.WriteLine(balaxyEBook.GetDetails());

        Console.WriteLine("-------------------------------------\n\n");
    }

    private static void DemonstrateSingleton()
    {
        Console.WriteLine("Singleton:");

        Console.WriteLine("\nCreating in the same thread:");
        var auth_1 = Authenticator.Instance;
        var auth_2 = Authenticator.Instance;

        Console.WriteLine(auth_1);
        Console.WriteLine(auth_2);

        Console.WriteLine("\nCreating in different threads:");

        var t1 = new Thread( () =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            var auth = Authenticator.Instance;
            Console.WriteLine(auth);
        });

        var t2 = new Thread(() =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            var auth = Authenticator.Instance;
            Console.WriteLine(auth);
        });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine("-------------------------------------\n\n");
    }

    private static void DemonstratePrototype()
    {
        Console.WriteLine("Prototype:");

        var v1 = new Virus(1, 1, "Virus 1", "Generation 3 Coronavirus", []);
        var v2 = new Virus(1, 2, "Virus 2", "Generation 3 Coronavirus", []);
        var v3 = new Virus(1, 2, "Virus 3", "Generation 3 Coronavirus", []);
        var v4 = new Virus(1, 3, "Virus 4", "Generation 3 Coronavirus", []);

        var v5 = new Virus(1, 3, "Virus 5", "Generation 2 Coronavirus", [v1, v2]);
        var v6 = new Virus(1, 4, "Virus 6", "Generation 2 Coronavirus", [v3, v4]);

        var v7 = new Virus(1, 5, "Virus 7", "Generation 1 Coronavirus", [v5, v6]);

        Console.WriteLine("\nVirus:");
        Console.WriteLine(v7);

        var virusClone = v7.Clone();

        Console.WriteLine("\nVirus clone:");
        Console.WriteLine(virusClone);

        Console.WriteLine("-------------------------------------\n\n");
    }

    private static void DemonstrateBuilder()
    {
        Console.WriteLine("Builder:");

        CharacterDirector director = new CharacterDirector();

        var hero = director.BuildDreamHero();
        var enemy = director.BuildNightmareEnemy();

        Console.WriteLine(hero);

        Console.WriteLine();

        Console.WriteLine(enemy);

        Console.WriteLine("\n\nTrying defeat enemy:\n");
        hero.TryDefeatEnemy(enemy);

        Console.WriteLine(hero);

        Console.WriteLine();

        Console.WriteLine(enemy);

        Console.WriteLine("\n\nTrying defeat enemy again:\n");
        hero.TryDefeatEnemy(enemy);

        Console.WriteLine(hero);

        Console.WriteLine();

        Console.WriteLine(enemy);

        Console.WriteLine("-------------------------------------\n\n");
    }
}