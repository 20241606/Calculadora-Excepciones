
using System;

class Program
{
    static void Main()
    {
        string continuar = "s";

        // Repetimos el programa mientras el usuario quiera
        while (continuar.ToLower() == "s")
        {
            try
            {
                Console.WriteLine("\n=== CALCULADORA BASICA ===");

                // Solicitamos el primer numero
                int numero1 = LeerNumero("Ingrese el primer numero: ");

                // Solicitamos el segundo numero
                int numero2 = LeerNumero("Ingrese el segundo numero: ");

                // Solicitamos la operacion matematica
                Console.Write("Ingrese la operacion (+, -, *, /): ");
                string operacion = Console.ReadLine() ?? "";

                int resultado = 0;

                // Verificamos que operacion eligio el usuario
                switch (operacion)
                {
                    case "+":
                        resultado = checked(numero1 + numero2);
                        break;

                    case "-":
                        resultado = checked(numero1 - numero2);
                        break;

                    case "*":
                        resultado = checked(numero1 * numero2);
                        break;

                    case "/":
                        resultado = numero1 / numero2;
                        break;

                    default:
                        // Lanzamos una excepcion personalizada
                        throw new OperacionInvalidaException(
                            "La operacion ingresada no es valida.");
                }

                // Mostramos el resultado
                Console.WriteLine("Resultado: " + resultado);
            }
            catch (DivideByZeroException)
            {
                // Error cuando se intenta dividir entre cero
                Console.WriteLine("Error: No se puede dividir entre cero.");
            }
            catch (OverflowException)
            {
                // Error cuando el resultado supera el rango de int
                Console.WriteLine("Error: Numero fuera del rango permitido.");
            }
            catch (OperacionInvalidaException ex)
            {
                // Error cuando se ingresa un operador incorrecto
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Este bloque se ejecuta siempre
                Console.WriteLine("Fin de la ejecucion.");
            }

            // Preguntamos si desea realizar otro calculo
            Console.Write("\nDesea realizar otro calculo? (s/n): ");
            continuar = (Console.ReadLine() ?? "").Trim();
        }

        Console.WriteLine("Programa finalizado.");
    }

    // Metodo para solicitar numeros enteros
    static int LeerNumero(string mensaje)
    {
        while (true)
        {
            try
            {
                Console.Write(mensaje);

                // Convertimos el texto ingresado a entero
                return int.Parse(Console.ReadLine() ?? "");
            }
            catch (FormatException)
            {
                // Se ejecuta si el usuario escribe letras
                Console.WriteLine("Error: Debe ingresar un numero entero.");
            }
            catch (OverflowException)
            {
                // Se ejecuta si el numero es demasiado grande
                Console.WriteLine("Error: Numero fuera del rango permitido.");
            }
        }
    }
}

// Excepcion personalizada para operadores invalidos
public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string mensaje)
        : base(mensaje)
    {
    }
}
