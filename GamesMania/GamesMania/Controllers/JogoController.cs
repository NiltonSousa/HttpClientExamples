using GamesMania.Data;
using GamesMania.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesMania.Controllers
{
    [Route("api/jogos")]
    public class JogoController: ControllerBase
    {
        #region Constructors
        public JogoController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Jogo>> Get()
        {
            var jogos = _dataContext.Jogo
                    .Include(f => f.Fabricante).ToList();

            return Ok(jogos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Jogo>> GetById(int id)
        {
            var jogo = _dataContext.Jogo.Include(f=>f.Fabricante).Where(x => x.JogoId == id).FirstOrDefault();

            if (jogo == null)
                return BadRequest(new { message = "Jogo não encontrado." });

            return Ok(jogo);
        }

        [HttpPost]
        public ActionResult<Jogo> Post([FromBody] Jogo model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Jogo.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar o jogo." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Jogo> Put([FromBody] Jogo model, int id)
        {
            if (id != model.JogoId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Jogo>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o jogo." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Jogo> Delete(int id)
        {
            var ingrediente = _dataContext.Jogo.Where(idIngre => idIngre.JogoId == id).FirstOrDefault();

            if (ingrediente == null)
                return BadRequest(new { message = "Jogo não encontrado." });

            try
            {
                _dataContext.Jogo.Remove(ingrediente);
                _dataContext.SaveChanges();

                return Ok(new { message = "Jogo excluido com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível excluir o ingrediente." });
            }
        }
        #endregion
    }
}
