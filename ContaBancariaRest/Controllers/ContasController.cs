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
        private DBContexto _contexto;
        public ContasController(DBContexto contexto)
        {
            this._contexto = contexto;
        }
        [HttpGet]
        [Route("/contas")]
        public IActionResult Index()
        {
            //SOLUÇÃO PARA GRAVAR DADOS EM MEMÓRIA
            //var contas = Conta.Contas;
            //return StatusCode(200, contas);

            //SOLUÇÃO PARA GRAVAR DADOS NO SQL
            var contas = _contexto.Contas.ToList();
            return StatusCode(200, contas);
        }

        [HttpPost]
        [Route("/contas")]
        public IActionResult Create([FromBody] Conta conta)
        {
            //SOLUÇÃO PARA GRAVAR DADOS EM MEMÓRIA
            //Conta.Contas.Add(conta);

            //SOLUÇÃO PARA GRAVAR DADOS NO SQL
            _contexto.Contas.Add(conta);
            _contexto.SaveChanges();
            return StatusCode(201, conta);
        }


        [HttpPut]
        [Route("/contas/depositar/{id}")]
        public IActionResult Update(int id, [FromBody] Conta depositar )
        {
            /* SOLUÇÃO PARA GRAVAR DADOS EM MEMÓRIA
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
            else return StatusCode(200, depositar);*/

            //SOLUÇÃO PARA GRAVAR DADOS NO SQL
            var conta = _contexto.Contas.Where(c => c.Numero == id).First();
            if (conta == null) 
            {
                return StatusCode(404);
            }

            conta.Saldo += (decimal)depositar.Depositar;
            conta.Mensagem = "Deposito realizado com sucesso!";
            _contexto.Contas.Update(conta);
            _contexto.SaveChanges();
            return StatusCode(200, conta);
        }

        [HttpPut]
        [Route("/contas/sacar/{id}")]
        public IActionResult UpdateSacar(int id, [FromBody] Conta sacar)
        {
            /* SOLUÇÃO PARA GRAVAR DADOS EM MEMÓRIA
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
            else return StatusCode(200, sacar);*/

            //SOLUÇÃO PARA GRAVAR DADOS NO SQL
            var conta = _contexto.Contas.Where(c => c.Numero == id).First();
            if (conta == null)
            {
                return StatusCode(404);
            }

            if (conta.Saldo >= (decimal)sacar.Sacar) 
            {
                conta.Saldo -= (decimal)sacar.Sacar;
                conta.Mensagem = "Saque realizado com sucesso!";
                _contexto.Contas.Update(conta);
                _contexto.SaveChanges();
                return StatusCode(200, conta);
            } else
            {
                return StatusCode(400, "Saldo insuficiente para essa transação");
            }
        }
    }
}       
            
        

