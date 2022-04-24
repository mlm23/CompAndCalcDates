using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclui.CompAndCalcDates
{
    class Menu
    {
        /// <summary>
        /// Función para que el usuario determine el idioma del programa
        /// </summary>
        /// <returns></returns>
        public static string OpcionUsuario()
        {
            string Idioma = "";
            ConsoleKeyInfo option;
            Console.Clear();
            while (Idioma == "")
            {
                MenuMostrar();
                option = Console.ReadKey(true);
                switch (option.KeyChar)
                {
                    case '1': Idioma = "Español"; break; //Español
                    case '2': Idioma = "Ingles"; break; //Ingles
                }

                if (Idioma == "")
                {
                    Console.WriteLine();
                }
            }

            return Idioma;

        }

        /// <summary>
        /// Mostrado de Menú al usuario
        /// </summary>
        private static void MenuMostrar()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("- Selección de Idioma -");
            Console.WriteLine("- Language selection  -");
            Console.WriteLine("-----------------------");
            Console.WriteLine("-   Pulsar opciones   -");
            Console.WriteLine("-    Press options    -");
            Console.WriteLine("-----------------------");
            Console.WriteLine("- 1. Español.         -");
            Console.WriteLine("- 2. English.         -");
            Console.WriteLine("-----------------------");
        }
    }
}
