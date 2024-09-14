using Dominio.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        private List<Cliente> _clientes = new List<Cliente>();

        private List<Cuenta> _cuentas = new List<Cuenta>();
        public List<Cliente> Clientes
        {
            get
            {
                return _clientes;
            }
        }
        public List<Cuenta> Cuentas
        {
            get
            {
                return _cuentas;
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new Exception("No se recibieron valores");
            }
            cliente.Validar();
            _clientes.Add(cliente);
        }

        public Cliente ObtenerCliente(string cedula)
        {
            foreach (Cliente item in _clientes)
            {
                if (item.Cedula == cedula)
                {
                    return item;
                }
            }
            return null;
        }

        public void AgregarCuentaAlCliente(string cedula, Cuenta cuenta) 
        { 
          Cliente unC = ObtenerCliente(cedula);
            if(unC == null)
            {
                throw new Exception($"La cedula {cedula} no existe");
            }
            unC.AgregarCuenta(cuenta);
            _cuentas.Add(cuenta);
        }


    }
}
