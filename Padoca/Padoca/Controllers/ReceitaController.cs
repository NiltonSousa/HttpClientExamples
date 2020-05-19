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
    [Route("api/receitas")]
    public class ReceitaController : ControllerBase
    {
        #region Constructors
        public ReceitaController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Receita>> Get()
        {
            //Usando INNER JOIN
            var receitas = _dataContext.Receita
                            .Include(i => i.Ingrediente)
                            .Include(p => p.Prato).ToList();

            return Ok(receitas);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Receita>> GetById(int id)
        {
            var receita = _dataContext.Receita
                            .Include(i => i.Ingrediente)
                            .Include(p => p.Prato).Where(x => x.ReceitaId == id).FirstOrDefault();

            if (receita == null)
                return BadRequest(new { message = "Receita não encontrada." });

            return Ok(receita);
        }

        [HttpPost]
        public ActionResult<Receita> Post([FromBody] Receita model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Receita.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar a receita." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Receita> Put([FromBody] Receita model, int id)
        {
            if (id != model.ReceitaId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Receita>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar a receita." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Receita> Delete(int id)
        {
            var receita = _dataContext.Receita.Where(p => p.ReceitaId == id).FirstOrDefault();

            if (receita == null)
                return BadRequest(new { message = "Receita não encontrado." });

            try
            {
                _dataContext.Receita.Remove(receita);
                _dataContext.SaveChanges();

                return Ok(new { message = "Receita excluida com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar a receita." });
            }
        }
        #endregion

    }
}
