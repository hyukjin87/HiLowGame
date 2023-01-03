/*
* DESCRIPTION		:
* 	A server program that uses TCP Listener 
* 	to exchange data with clients and play hi low games
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Listener listener = new Listener();
            listener.StartListener();

            Console.WriteLine("Press Enter to End");
            Console.ReadLine();
        }
    }
}
