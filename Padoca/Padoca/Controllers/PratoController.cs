using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Padoca.Data;
using Padoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padoca.Controllers
{
    [Route("api/pratos")]
    public class PratoController: ControllerBase
    {
        #region Constructors
        public PratoController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Prato>> Get()
        {
            //Usando INNER JOIN
            var pratos = _dataContext.Prato
                            .Include(c => c.Categoria).ToList();

            return Ok(pratos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Prato>> GetById(int id)
        {
            var prato = _dataContext.Prato.Include(c => c.Categoria).Where(x => x.PratoId == id).FirstOrDefault();

            if (prato == null)
                return BadRequest(new { message = "Prato não encontrado" });

            return Ok(prato);
        }

        [HttpPost]
        public ActionResult<Prato> Post([FromBody] Prato model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Prato.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar o prato." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Prato> Put([FromBody] Prato model, int id)
        {
            if (id != model.PratoId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Prato>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o prato." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Prato> Delete(int id)
        {
            var prato = _dataContext.Prato.Where(p => p.PratoId== id).FirstOrDefault();

            if (prato == null)
                return BadRequest(new { message = "Prato não encontrado." });

            try
            {
                _dataContext.Prato.Remove(prato);
                _dataContext.SaveChanges();

                return Ok(new { message = "Prato excluido com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o Prato." });
            }
        }
        #endregion
    }
}
