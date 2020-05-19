using GamesMania.Data;
using GamesMania.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesMania.Controllers
{
    [Route("api/fabricantes")]
    public class FabricanteController: ControllerBase
    {

        #region Constructors
        public FabricanteController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Properties
        private DataContext _dataContext;
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<List<Fabricante>> Get()
        {
            var fabricantes = _dataContext.Fabricante.ToList();
            return Ok(fabricantes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Fabricante>> GetById(int id)
        {
            var fabricante = _dataContext.Fabricante.Where(x => x.FabricanteId == id).FirstOrDefault();

            if (fabricante == null)
                return BadRequest(new { message = "Fabricante não encontrado." });

            return Ok(fabricante);
        }

        [HttpPost]
        public ActionResult<Fabricante> Post([FromBody] Fabricante model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Fabricante.Add(model);
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível adicionar o fabricante." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Fabricante> Put([FromBody] Fabricante model, int id)
        {
            if (id != model.FabricanteId)
                return BadRequest("ID não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _dataContext.Entry<Fabricante>(model).State = EntityState.Modified;
                _dataContext.SaveChanges();

                return Ok(model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível atualizar o fabricante." });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Fabricante> Delete(int id)
        {
            var fabricante = _dataContext.Fabricante.Where(idFabri => idFabri.FabricanteId == id).FirstOrDefault();

            if (fabricante == null)
                return BadRequest(new { message = "Fabricante não encontrado." });

            try
            {
                _dataContext.Fabricante.Remove(fabricante);
                _dataContext.SaveChanges();

                return Ok(new { message = "Fabricante excluido com sucesso!" });


            }
            catch (Exception error)
            {
                return BadRequest(new { message = "Não foi possível excluir o Fabricante." });
            }
        }
        #endregion
    }
}
