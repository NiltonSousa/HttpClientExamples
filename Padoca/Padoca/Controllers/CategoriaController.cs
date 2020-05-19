using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Padoca.Data;
using Padoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Padoca.Controllers
{
    [Route("api/categoria")]
    public class CategoriaController: ControllerBase
    {
        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Constructors
        public CategoriaController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            var categorias = _dataContext.Categoria.ToList();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Categoria>> GetById(int id)
        {
            var categoria = _dataContext.Categoria.Where(x => x.CategoriaId == id).FirstOrDefault();

            if (categoria == null)
                return BadRequest(new { message = "Categoria não encontrada." });

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Categoria.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar a categoria." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Categoria> Put([FromBody] Categoria model, int id)
        {
            if (id != model.CategoriaId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Categoria>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _dataContext.Categoria.Where(c => c.CategoriaId== id).FirstOrDefault();

            if (categoria == null)
                return BadRequest(new { message = "Categoria não encontrada." });

            try
            {
                _dataContext.Categoria.Remove(categoria);
                _dataContext.SaveChanges();

                return Ok(new { message = "Categoria excluida com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }
        }
        #endregion
    }
}
