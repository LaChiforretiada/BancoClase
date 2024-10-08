﻿namespace Dominio.Entidades
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int TipoMoneda { get; set; }
        public int SaldoActual { get; set; }

        private static int _ultimoId;

        public Cuenta(int tipoMoneda, int saldoActual)
        {
            Id = _ultimoId++;
            TipoMoneda = tipoMoneda;
            SaldoActual = saldoActual;
        }

        public void Validar()
        {
            ValidarMoneda(TipoMoneda);

        }
        private string ValidarMoneda(int tipoMoneda)
        {

            if (tipoMoneda == 1)
            {
                return "pesos";
            }
            if (tipoMoneda == 2)
            {
                return "dolares";
            }
            else
            {
                return "moneda invalida";
            }
        }
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Tipo de moneda: {ValidarMoneda(TipoMoneda)} Saldo actual: {SaldoActual}\n";
            return respuesta;   
        }
    }
}
