using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancariaRest.Models
{
    public class Conta
    {
        public string Mensagem { get; set; }
        public int Numero { get; set; }
        public float Saldo { get; set; }

        public string Titular { get; set; }
        public float Depositar { get; set; }
        public float Sacar { get; set; }

        public static List<Conta> Contas = new List<Conta>();
    }
}