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
    public class ClientesController : ControllerBase
    {
        public ClientesController(DBContexto contexto)
        {
            this._contexto = contexto;
        }
        private DBContexto _contexto;

        [HttpGet]
        [Route("/clientes")]
        public IActionResult Index()
        {
            //var clientes = Cliente.Clientes;
            var clientes = _contexto.Clientes.ToList();
            return StatusCode(200, clientes);
        }

        [HttpPost]
        [Route("/clientes")]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            Cliente.Clientes.Add(cliente);
            return StatusCode(201, cliente);
        }


        [HttpPut]
        [Route("/clientes/{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            var achei = false;
            foreach (var c in Cliente.Clientes)
            {
                if (c.Id == id)
                {
                    c.Nome = cliente.Nome;
                    c.Cpf = cliente.Cpf;
                    achei = true;
                }
            }

            if (!achei) return StatusCode(404);
            else return StatusCode(404, cliente);
        }

        [HttpDelete]
        [Route("/clientes/{id}")]
        public IActionResult Delete(int id)
        {
            Cliente cliente = null;
            foreach (var c in Cliente.Clientes)
            {
                if (c.Id == id)
                {
                    cliente = c;
                }
            }

            if(cliente == null) return StatusCode(404);

            Cliente.Clientes.Remove(cliente);

            return StatusCode(204);
        }
    }
}
