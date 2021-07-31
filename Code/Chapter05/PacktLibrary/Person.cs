using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person : IComparable<Person>
    {
      // read-only fields
      public readonly string HomePlanet = "Earth";
      public readonly DateTime Instantiated;
      // constructors
      public Person()
      {
        // set default values for fields
        // including read-only fields 
        Name = "Unknown"; 
        Instantiated = DateTime.Now;
      }

      public Person(string initialName, string homePlanet)
      {
        Name = initialName; 
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
      }
      public List<Person> Children = new List<Person>();
      // fields
      public string Name;
      public DateTime DateOfBirth;
      public WondersOfTheAncientWorld FavoriteAncientWonder;
      public WondersOfTheAncientWorld BucketList;
      public void TimeTravel(DateTime when) 
      { 
        if (when <= DateOfBirth) 
        { 
          throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!"); 
        } 
        else 
        { 
          WriteLine($"Welcome to {when:yyyy}!"); 
        } 
      }
      // overridden methods 
      public override string ToString() 
      { 
        return $"{Name} is a {base.ToString()}"; 
      }

      // methods     
      public void WriteToConsole()
      {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
      }
      public string GetOrigin()
      {
        return $"{Name} was born on {HomePlanet}.";
      }
      //Tuples
      public (string, int) GetFruit()
      {
        return ("Apples", 5);
      }

      public (string Name, int Number) GetNamedFruit()
      {
        return (Name: "Apples", Number: 5);
      }

      public void PassingParameters(int x, ref int y, out int z)
      {
        // out parameters cannot have a default
        // AND must be initialized inside the method 
        z = 99;
        // increment each parameter 
        x++;
        y++;
        z++;
      }
      // static method to "multiply" 
      public static Person Procreate(Person p1, Person p2)
      { 
        var baby = new Person 
        { 
          Name = $"Baby of {p1.Name} and {p2.Name}" 
        };
        p1.Children.Add(baby); 
        p2.Children.Add(baby);
        return baby; 
      }
      // instance method to "multiply" 
      public Person ProcreateWith(Person partner)
      {
        return Procreate(this, partner);
      }
      
      // operator to "multiply"
      public static Person operator *(Person p1, Person p2)
      {
        return Person.Procreate(p1, p2);
      }
      // method with a local function 
      public static int Factorial(int number) 
      { 
        if (number < 0) 
        { 
          throw new ArgumentException( 
            $"{nameof(number)} cannot be less than zero."); 
        }
        return localFactorial(number);
        int localFactorial(int localNumber) // local function
        {
          if (localNumber < 1) return 1;
          return localNumber * localFactorial(localNumber - 1);
        }
      }

      // event delegate field
      public event EventHandler Shout;
      // data field 
      public int AngerLevel; 
      // method 
      public void Poke() 
      { 
        AngerLevel++; 
        if (AngerLevel >= 3) 
        { 
          // if something is listening... 
          if (Shout != null) 
          { 
            // ...then call the delegate
            Shout(this, EventArgs.Empty); 
          } 
        }
      }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
