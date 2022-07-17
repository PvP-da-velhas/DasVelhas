using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testando
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iniciar [ini]");
            string inicio = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Green;
            if (inicio == "ini" || inicio == "iniciar") new JogoDaVelha().Iniciar();

        }

    }
}