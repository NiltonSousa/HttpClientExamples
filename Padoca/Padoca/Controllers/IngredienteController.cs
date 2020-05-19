using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Padoca.Data;
using Padoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Padoca.Controllers
{
    [Route("api/ingredientes")]
    public class IngredienteController : ControllerBase  
    {
        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Constructors
        public IngredienteController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Ingrediente>> Get()
        {
            var ingredientes = _dataContext.Ingredientes.ToList();
            return Ok(ingredientes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Ingrediente>> GetById(int id)
        {
            var ingrediente = _dataContext.Ingredientes.Where(x => x.IngredienteId == id).FirstOrDefault();

            if (ingrediente == null)
                return BadRequest(new { message = "Ingrediente não encontrado" });

            return Ok(ingrediente);
        }

        [HttpPost]
        public ActionResult<Ingrediente> Post([FromBody] Ingrediente model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Ingredientes.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }catch(Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar o ingrediente." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Ingrediente> Put([FromBody] Ingrediente model, int id)
        {
            if (id != model.IngredienteId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Ingrediente>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o ingrediente." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Ingrediente> Delete(int id)
        {
            var ingrediente = _dataContext.Ingredientes.Where(idIngre => idIngre.IngredienteId == id).FirstOrDefault();

            if (ingrediente == null)
                return BadRequest(new { message = "Ingrediente não encontrado." });

            try
            {
                _dataContext.Ingredientes.Remove(ingrediente);
                _dataContext.SaveChanges();

                return Ok(new { message = "Ingrediente excluido com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o ingrediente." });
            }
        }
        #endregion
    }
}
