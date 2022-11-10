using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone
{
    public interface IColorable
    {
        public static void Color(string message, ConsoleColor color)
        {           
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;         
        }
    }
}
