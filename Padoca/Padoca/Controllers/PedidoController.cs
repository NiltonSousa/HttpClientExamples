using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Padoca.Data;
using Padoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Padoca.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController: ControllerBase
    {
        #region Constructors
        public PedidoController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            //Usando INNER JOIN
            var pedidos = _dataContext.Pedido
                            .Include(p => p.Prato).ToList();

            return Ok(pedidos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Pedido>> GetById(int id)
        {
            var pedido = _dataContext.Pedido.Include(p => p.Prato).Where(x => x.PedidoId == id).FirstOrDefault();

            if (pedido == null)
                return BadRequest(new { message = "Pedido não encontrado" });

            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Pedido.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar o pedido." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Pedido> Put([FromBody] Pedido model, int id)
        {
            if (id != model.PedidoId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Pedido>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o pedido." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Pedido> Delete(int id)
        {
            var pedido = _dataContext.Pedido.Where(idIngre => idIngre.PedidoId == id).FirstOrDefault();

            if (pedido == null)
                return BadRequest(new { message = "Pedido não encontrado." });

            try
            {
                _dataContext.Pedido.Remove(pedido);
                _dataContext.SaveChanges();

                return Ok(new { message = "Pedido excluido com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o pedido." });
            }
        }
        #endregion
    }
}
