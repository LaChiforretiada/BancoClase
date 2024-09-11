using Dominio;
using Dominio.Entidades;

namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            



        }
        private void AgregarCliente()
        {
            try
            {
                string cedula = PedirString("Ingrese su documento de identidad");
                string nombre = PedirString("Ingrese su nombre");
                Cliente unCliente = new Cliente(cedula, nombre);
                _sistema.AgregarCliente(unCliente);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        private static string PedirString(string mensaje) { 
        
        Console.WriteLine(mensaje); 
        return Console.ReadLine();
        }
    }
}
