using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancariaRest.Models
{
    public class Conta
    {
        [Key]
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public string Titular { get; set; }




        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public float Depositar { get; set; }
        [NotMapped]
        public float Sacar { get; set; }

        public static List<Conta> Contas = new List<Conta>();
    }
}