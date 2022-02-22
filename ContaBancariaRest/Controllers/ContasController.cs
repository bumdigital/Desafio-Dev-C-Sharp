using ContaBancariaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancariaRest.Controllers
{
    [ApiController]
    public class ContasController : ControllerBase
    {
        [HttpGet]
        [Route("/contas")]
        public IActionResult Index()
        {
            var contas = Conta.Contas;
            return StatusCode(200, contas);
        }

        [HttpPost]
        [Route("/contas")]
        public IActionResult Create([FromBody] Conta conta)
        {
            Conta.Contas.Add(conta);
            return StatusCode(201, conta);
        }


        [HttpPut]
        [Route("/contas/depositar/{id}")]
        public IActionResult Update(int id, [FromBody] Conta depositar )
        {
            var achei = false;
            foreach (var c in Conta.Contas)
            {
                if (c.Numero == id)
                {
                    c.Saldo += depositar.Depositar;
                    c.Mensagem = "Deposito realizado com sucesso!";
                    achei = true;
                }
            }

            if (!achei) return StatusCode(404);
            else return StatusCode(204);
        }

        [HttpPut]
        [Route("/contas/sacar/{id}")]
        public IActionResult UpdateSacar(int id, [FromBody] Conta sacar)
        {
            var achei = false;
            foreach (var c in Conta.Contas)
            {
                if (c.Numero == id && sacar.Sacar <= c.Saldo)
                {
                    c.Saldo -= sacar.Sacar;
                    c.Mensagem = "Saque realizado com sucesso!";
                    achei = true;
                } else if (c.Numero == id && sacar.Sacar > c.Saldo)
                {
                    c.Mensagem = "Saldo insuficiente para essa operação";
                }
            }

            if (!achei) return StatusCode(404);
            else return StatusCode(204);
        }
    }
}       
            
        

