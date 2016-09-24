 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirPortRomanOOP
{ 
    class Program
    {                    
        static void Main(string[] args)
        {             
            Generator gn = Generator.getSingleExample();
            Menu mymenu = new Menu();          
            gn.InitialDataGenerator();            
            mymenu.ApplicationAll(gn);
            Console.ReadLine();
        }      
    }
}
