using Dominio;
using Dominio.Entidades;

namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                MostrarTitulo("Menu");
                opcion = PedirNumero(
                    "Ingrese la opción\n" +
                    "1-Agregar Cliente\n" +
                    "2-Agregar Cuenta \n" +
                    "3-Listar Clientes\n" +
                    "4-Listar Cuentas\n" +
                    "0-salir");
                switch (opcion)
                {
                    case 1:
                        AgregarCliente();
                        break;
                    case 2:
                        AgregarCuenta();
                        break;
                    case 3:
                        ListarClientes();
                        break;
                    case 4:
                        ListarCuentas();
                        break;
                    default:
                        break;
                }
            }
            while (opcion != 0);
        }

        private static void ListarCuentas()
        {

        }

        private static void ListarClientes()
        {
            foreach (Cliente item in _sistema.Clientes)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void AgregarCuenta()
        {
            try
            {
                MostrarTitulo("Agregar Cuenta");
                string cedula = PedirString("Ingrese cedula del empleado");
                Cliente unC = _sistema.ObtenerCliente(cedula);
                if (unC == null)
                {
                    MostrarError("No existe el empleado");
                }
                int tipoMoneda = PedirNumero("Ingrese tipo de moneda: 1- pesos 2-dolares");
                int saldoActual = PedirNumero("Ingrese saldo actual");

                Cuenta unaCuenta = new Cuenta(tipoMoneda, saldoActual);
                _sistema.AgregarCuentaAlCliente(cedula, unaCuenta);
            }
            catch (Exception e)
            {

                MostrarError(e.Message);
            }
        }

        private static void AgregarCliente()
        {
            try
            {
                MostrarTitulo("Agregar Cliente");
                string cedula = PedirString("Ingrese su documento de identidad");
                string nombre = PedirString("Ingrese su nombre");
                Cliente unCliente = new Cliente(cedula, nombre);
                _sistema.AgregarCliente(unCliente);
            }
            catch (Exception e)
            {

                MostrarError(e.Message);
            }
        }
        private static int PedirNumero(string mensaje)
        {
            int numero = 0;
            bool seguir = false;
            do
            {
                try
                {
                    Console.WriteLine(mensaje);
                    numero = int.Parse(Console.ReadLine());
                    seguir = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Solo debe ingresar numeros.");
                    seguir = true;
                }
            } while (seguir);
            return numero;
        }
        private static string PedirString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }
        private static void MostrarError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void MostrarTitulo(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("");
            Console.WriteLine(mensaje);
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
