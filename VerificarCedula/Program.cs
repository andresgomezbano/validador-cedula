using System;
using System.Linq;

namespace VerificarCedula
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //const string cedula = "2400118390";
            Console.WriteLine("Cedula:");
            var cedula = Console.ReadLine();
            Console.WriteLine(Validar(cedula) ? "correcto" : "incorrecto");
            Console.ReadLine();
        }

        public static bool Validar(string cedula)
        {
            if (string.IsNullOrEmpty(cedula) || cedula.Length != 10)
            {
                return false;
            }
            var index = 1;
            var suma = 0;
            var digito = (int) char.GetNumericValue(cedula[9]);
            foreach (var numero in cedula.Substring(0,9).Select(caracter => (int)char.GetNumericValue(caracter)))
            {
                if (index%2 == 0)
                {
                    suma += numero;
                }
                else
                {
                    var valor = numero * 2;
                    if (valor > 9)
                    {
                        valor -= 9;
                    }
                    suma += valor;
                }
                index ++;
            }
            var modulo = suma%10;
            return (digito == 0 && 0 == modulo) || digito == 10 - modulo;
        }
    }
}
