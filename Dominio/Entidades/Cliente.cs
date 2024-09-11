
namespace Dominio.Entidades
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        private List<Cuenta> _cuentas = new List<Cuenta>();


        public List<Cuenta> Cuentas
        {
            get { return _cuentas; }
        }

        public Cliente(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;

        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
            {
                throw new Exception("No se recibieron valores");

            }
            cuenta.Validar();
            _cuentas.Add(cuenta);
        }

        public void Validar()
        {
            ValidarCedula();


        }

        private void ValidarCedula()
        {
            if (string.IsNullOrEmpty(Cedula) || Cedula.Length != 8)
            {
                throw new Exception("Cedula invalida");
            }
        }

        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Cedula: {Cedula} \n:";
            respuesta += $"Nombre Completo: {NombreCompleto} \n:";
            foreach (Cuenta item in _cuentas)
            {
                respuesta += $"Cuentas - - >{item.TipoMoneda} (Saldo: {item.SaldoActual})";
            }
            return respuesta;
        }
        public override bool Equals(object? obj)
        {
            Cliente unCliente = obj as Cliente;
            return unCliente != null && Cedula == unCliente.Cedula;
        }
    }
}
