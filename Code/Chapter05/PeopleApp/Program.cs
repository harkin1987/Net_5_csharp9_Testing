using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
      private static void Harry_Shout(object sender, EventArgs e)
      {
        Person p = (Person)sender;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
      }
      static void Main(string[] args)
      {
        
        var bob = new Person();
        bob.Name = "Bob Smith";
        bob.DateOfBirth = new DateTime(1987,3,7);
        WriteLine($"{bob.Name} was born on {bob.DateOfBirth.ToString("dd/MM/yyyy")}");
        var alice = new Person
        {
            Name = "Alice",
            DateOfBirth = new DateTime(1987,3,8)
        };
        WriteLine(
          format: "{0} was born on {1:dd MMM yy}",
          arg0: alice.Name,
          arg1: alice.DateOfBirth);

        bob.FavoriteAncientWonder = 
          WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        WriteLine(format: 
          "{0}'s favorite wonder is {1}. Its integer is {2}.",
          arg0: bob.Name,
          arg1: bob.FavoriteAncientWonder,
          arg2: (int)bob.FavoriteAncientWonder);
        // Using bitwise OR to have 2 or more options selected
        bob.BucketList = 
          WondersOfTheAncientWorld.HangingGardensOfBabylon
          | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
        // bob.BucketList = (WondersOfTheAncientWorld)18; 
        WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

        bob.Children.Add(new Person { Name = "Alfred" }); 
        bob.Children.Add(new Person { Name = "Zoe" });
        WriteLine(
          $"{bob.Name} has {bob.Children.Count} children:");
        foreach(Person p in bob.Children)
        {
            WriteLine($"{p.Name}");
        }

        BankAccount.InterestRate = 0.012M; // store a shared value

        var jonesAccount = new BankAccount();
        jonesAccount.AccountName = "Mrs. Jones";
        jonesAccount.Balance = 2400;
        WriteLine(format: "{0} earned {1:C} interest.",
          arg0: jonesAccount.AccountName,
          arg1: jonesAccount.Balance * BankAccount.InterestRate);
        var gerrierAccount = new BankAccount();
        gerrierAccount.AccountName = "Ms. Gerrier";
        gerrierAccount.Balance = 98;
        WriteLine(format: "{0} earned {1:C} interest.",
          arg0: gerrierAccount.AccountName,
          arg1: gerrierAccount.Balance * BankAccount.InterestRate);

        WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

        bob.WriteToConsole();
        WriteLine(bob.GetOrigin());

        var blankPerson = new Person();
        WriteLine(format: 
          "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
          arg0: blankPerson.Name,
          arg1: blankPerson.HomePlanet,
          arg2: blankPerson.Instantiated); 

        var gunny = new Person("Gunny", "Mars");
        WriteLine(format: 
          "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
          arg0: gunny.Name,
          arg1: gunny.HomePlanet,
          arg2: gunny.Instantiated);

        (string, int) fruit = bob.GetFruit();
        WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

        var fruitNamed = bob.GetNamedFruit();
        WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

        (string fruitName, int fruitNumber) = bob.GetFruit();
        WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

        int a = 10;
        int b = 20;
        int c = 30;
        WriteLine($"Before: a = {a}, b = {b}, c = {c}");
        bob.PassingParameters(a, ref b, out c);
        WriteLine($"After: a = {a}, b = {b}, c = {c}");

        var sam = new Person
        {
          Name = "Sam",
          DateOfBirth = new DateTime(1972, 1, 27)
        };
        WriteLine(sam.Origin);
        WriteLine(sam.Greeting);
        WriteLine(sam.Age);

        sam.FavoriteIceCream = "Chocolate Fudge";
        WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
        sam.FavoritePrimaryColor = "Red";
        WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

        sam.Children.Add(new Person { Name = "Charlie" });
        sam.Children.Add(new Person { Name = "Ella" });
        WriteLine($"Sam's first child is {sam.Children[0].Name}");
        WriteLine($"Sam's second child is {sam.Children[1].Name}");
        WriteLine($"Sam's first child is {sam[0].Name}");
        WriteLine($"Sam's second child is {sam[1].Name}");
        object[] passengers = {
          new FirstClassPassenger{ AirMiles = 1_419},
          new FirstClassPassenger { AirMiles = 16_562 },
          new BusinessClassPassenger(),
          new CoachClassPassenger { CarryOnKG = 25.7 },
          new CoachClassPassenger { CarryOnKG = 0 }
        };

        foreach (object passenger in passengers)
        {
          decimal flightCost = passenger switch
          {
            /* C# 8 syntax
            FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
            FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
            FirstClassPassenger                           => 2000M, */
            // C# 9 syntax
            FirstClassPassenger p => p.AirMiles switch
            {
              > 35000 => 1500M,
              > 15000 => 1750M,
              _       => 2000M
            },
            BusinessClassPassenger                        => 1000M,
            CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
            CoachClassPassenger                           => 650M,
            _                                             => 800M
          };
          WriteLine($"Flight costs {flightCost:C} for {passenger}");
        }
        var jeff = new ImmutablePerson
        {
          FirstName = "Jeff",
          LastName = "Winger"
        };
        var car = new ImmutableVehicle
        {
          Brand = "Mazda MX-5 RF",
          Color = "Soul Red Crystal Metallic",
          Wheels = 4
        };
        var repaintedCar = car with { Color = "Polymetal Grey Metallic" };
        WriteLine("Original color was {0}, new color is {1}.",
          arg0: car.Color, arg1: repaintedCar.Color);

        var oscar = new ImmutableAnimal("Oscar", "Labrador");
        var (who, what) = oscar; // calls Deconstruct method
        WriteLine($"{who} is a {what}.");

        var harry = new Person { Name = "Harry" };
        var mary = new Person { Name = "Mary" };
        var jill = new Person { Name = "Jill" };
        // call instance method
        var baby1 = mary.ProcreateWith(harry);
        baby1.Name = "Gary";
        // call static method
        WriteLine($"{harry.Name} has {harry.Children.Count} children.");
        WriteLine($"{mary.Name} has {mary.Children.Count} children.");
        WriteLine($"{jill.Name} has {jill.Children.Count} children.");
        WriteLine(
          format: "{0}'s first child is named \"{1}\".",
          arg0: harry.Name,
          arg1: harry.Children[0].Name);
        // call static method
        var baby2 = Person.Procreate(harry, jill);
        // call an operator
        var baby3 = harry * mary;
        

        WriteLine($"5! is {Person.Factorial(5)}");
        harry.Shout += Harry_Shout;
        harry.Poke();
        harry.Poke();
        harry.Poke();
        harry.Poke();


        Person[] people = 
        { 
          new Person { Name = "Simon" }, 
          new Person { Name = "Jenny" }, 
          new Person { Name = "Adam" }, 
          new Person { Name = "Richard" } 
        };
 
        WriteLine("Initial list of people:"); 
        foreach (var person in people) 
        { 
          WriteLine($"  {person.Name}"); 
        } 
        WriteLine("Use Person's IComparable implementation to sort:"); 
        Array.Sort(people); 
        foreach (var person in people) 
        { 
          WriteLine($"  {person.Name}");
        }
        
        WriteLine("Use PersonComparer's IComparer implementation to sort:"); 
        Array.Sort(people, new PersonComparer()); 
        foreach (var person in people) 
        { 
          WriteLine($"  {person.Name}");
        }

        var t1 = new Thing();
        t1.Data = 42;
        WriteLine($"Thing with an integer: {t1.Process(42)}");
        var t2 = new Thing();
        t2.Data = "apple";
        WriteLine($"Thing with a string: {t2.Process("apple")}");


        var gt1 = new GenericThing<int>();
        gt1.Data = 42;
        WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
        var gt2 = new GenericThing<string>();
        gt2.Data = "apple";
        WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

        string number1 = "4";
        WriteLine("{0} squared is {1}",
          arg0: number1,
          arg1: Squarer.Square<string>(number1));
        byte number2 = 3;
        WriteLine("{0} squared is {1}",
          arg0: number2,
          arg1: Squarer.Square(number2));

        var dv1 = new DisplacementVector(3, 5);
        var dv2 = new DisplacementVector(-2, 7);
        var dv3 = dv1 + dv2;
        WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

        Employee john = new Employee 
        { 
          Name = "John Jones", 
          DateOfBirth = new DateTime(1990, 7, 28) 
        };
        
        john.WriteToConsole();

        john.EmployeeCode = "JJ001";
        john.HireDate = new DateTime(2014, 11, 23);
        WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

        WriteLine(john.ToString());

        Employee aliceInEmployee = new Employee 
          { Name = "Alice", EmployeeCode = "AA123" };
        Person aliceInPerson = aliceInEmployee;
        aliceInEmployee.WriteToConsole();
        aliceInPerson.WriteToConsole();
        WriteLine(aliceInEmployee.ToString());
        WriteLine(aliceInPerson.ToString());

        if (aliceInPerson is Employee) 
        { 
          WriteLine($"{nameof(aliceInPerson)} IS an Employee");
          Employee explicitAlice = (Employee)aliceInPerson;
          // safely do something with explicitAlice
        }
        Employee aliceAsEmployee = aliceInPerson as Employee;
        if (aliceAsEmployee != null) 
        { 
          WriteLine($"{nameof(aliceInPerson)} AS an Employee"); 
          // do something with aliceAsEmployee
        }

        try 
        { 
          john.TimeTravel(new DateTime(1999, 12, 31)); 
          john.TimeTravel(new DateTime(1950, 12, 25)); 
        }
        catch (PersonException ex) 
        { 
          WriteLine(ex.Message); 
        }
        string email1 = "pamela@test.com";
        string email2 = "ian&test.com";
        WriteLine(
          "{0} is a valid e-mail address: {1}",
          arg0: email1,
          arg1: StringExtensions.IsValidEmail(email1));
        WriteLine(
          "{0} is a valid e-mail address: {1}",
          arg0: email2,
          arg1: StringExtensions.IsValidEmail(email2)); 
        //Using as static class with (this string input)
        WriteLine(
          "{0} is a valid e-mail address: {1}",
          arg0: email1,
          arg1: email1.IsValidEmail());
        WriteLine(
          "{0} is a valid e-mail address: {1}",
          arg0: email2,
          arg1: email2.IsValidEmail()); 

        
        // End of main
      } 
    }
}
