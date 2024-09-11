using Dominio.Entidades;

namespace Dominio
{
    public class Sistema
    {
        private List<Cliente> _clientes = new List<Cliente>();
        public List<Cliente> Clientes { get { return _clientes; } }  

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new Exception("No se recibieron valores");
            }
           cliente.Validar();   
            _clientes.Add(cliente); 
        }
    }
}
