﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicoPedidos.Dominio;
using ServicoPedidos.Dominio.Abstracoes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoPedidos.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        IDiretorDeRequisicoesDePedidos _diretorDeRequisicoes;

        public ClientesController(IDiretorDeRequisicoesDePedidos diretorDeRequisicoes)
        {
            _diretorDeRequisicoes = diretorDeRequisicoes;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            IEnumerable<IClienteDTO> clientes;

            try
            {
                clientes = await _diretorDeRequisicoes.ObterClientes();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return base.Ok(clientes);
        }
    }
}
