using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    static class InputUtil
    {        
        //Enter a date with time
        public static DateTime TimeEnter()
        {
            Console.WriteLine("Enter a year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a month(1-12):");
            int montrh = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a day(1-30):");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an hour(0-23):");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an minute(0-59):");
            int minute = int.Parse(Console.ReadLine());
            DateTime timedata = new DateTime(year, montrh, day, hour, minute, 0);
            return timedata;
        }                
    }
}
