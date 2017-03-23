using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        ExcelAutomate automate = new ExcelAutomate();
        automate.readExcel("c:\\usertest.xlsx");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {

      }
    }
  }


}
