using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqIkub
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Person> peopleList = new List<Person>
      {
        new Person("Ana", 52, 1.7, 'f'),
        new Person("Dani", 82, 1.8, 'm'),
        new Person("Dean", 90, 1.9,'m'),
        new Person("John", 40, 1.6,'m'),
        new Person("Ciara", 60, 1.8, 'f'),
        new Person("Justin", 65, 1.8,'m')
      };
      Console.WriteLine("\nNames with exactly 4 letters:\n");
      List<Person> names4 = peopleList.Where(p => p.name.Length == 4).ToList<Person>();
      names4.ForEach(n => Console.WriteLine(n.name));

      Console.WriteLine("\nNames with exactly 4 letters ordered by weight:\n");
     var names4Weight = peopleList.Where(p => p.name.Length == 4).OrderBy(p => p.weight).ToList();
      names4Weight.ForEach(n => Console.WriteLine("Name: "+ n.name+"  Weight: "+n.weight));

      Console.WriteLine("\nNames with exactly 4 letters ordered by name and height:\n");
      var orderNameHeight = peopleList.Where(p => p.name.Length == 4).OrderBy(p => p.name).ThenBy(p => p.height).ToList();
      orderNameHeight.ForEach(n => Console.WriteLine("Name: " + n.name + "  Height: " + n.height));

      Console.WriteLine("\nAverage height:");
      var avgHeight = peopleList.Average(p => p.height);
      Console.WriteLine(avgHeight);

      Console.WriteLine("\nAverage weight of all males:");
      var avgmale = peopleList.Where(p => p.gender == 'm').Average(p => p.weight);
      Console.WriteLine(avgmale);

      Console.WriteLine("\nGroup by:");
      var group = from p in peopleList
                  group p by p.gender;
      foreach (var i in group)
      {
        Console.WriteLine(i.Key);
        foreach (Person p in i)
        {
          Console.WriteLine("   {0}, {1}, {2}, {3}",
                    p.name, p.gender, p.weight, p.height);
        }
      }
      var group2 = from p in peopleList
                  group p by p.gender into peoplegroup
                  where peoplegroup.Count()>2
                  select peoplegroup;

      Console.WriteLine("\nGroup by for genders that contain more than 2 people:");
      foreach (var i in group2)
      {
        Console.WriteLine(i.Key);
        foreach (Person p in i)
        {
          Console.WriteLine("   {0}, {1}, {2}, {3}",
                    p.name, p.gender, p.weight, p.height);
        }
      }

      var group3 = from p in peopleList
                   where p.weight>80
                   group p by p.gender into peoplegroup
                   where peoplegroup.Count() >= 2
                   select peoplegroup;

      Console.WriteLine("\nPeople with weight more than 80 grouped by gender, for genders that contain more than 2 people:");
      foreach (var i in group3)
      {
        Console.WriteLine(i.Key);
        foreach (Person p in i)
        {
          Console.WriteLine("   {0}, {1}, {2}, {3}",
                    p.name, p.gender, p.weight, p.height);
        }
      }
    }
  }
}
