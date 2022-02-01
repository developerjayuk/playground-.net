using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

//#error version

namespace helloWorld
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Hello C#!");
      Console.WriteLine();

      try
      {
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }

  internal class MyClass
  {
    private string _test;

    public MyClass(string test)
    {
      _test = test;
    }
  }
}