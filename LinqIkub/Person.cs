using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqIkub
{
  class Person
  {
    public string name { get; set; }
    public double weight { get; set; }
    public double height { get; set; }
    public char gender { get; set; }

    public Person(string n, double w, double h, char g)
    {
      name = n;
      weight = w;
      height = h;
      gender = g;
    }

  }
}
