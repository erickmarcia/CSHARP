using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class ArticuloController : ApiController
    {
        private POSEntities Context = new POSEntities();

        /// <summary>
        /// Para visualizar todos los registros (api/articulos)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Articulo> Get()
        {
            using (POSEntities db = new POSEntities())
            {
                return db.Articulo.ToList();
            }
        }

        /// <summary>
        /// Para visualizar los registros filtrados por idArticulo (api/articulos/1)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Articulo Get(int id)
        {
            using (POSEntities db = new POSEntities())
            {
                return db.Articulo.FirstOrDefault(x => x.idArticulo == id);
            }
        }


        /// <summary>
        /// Guarda nuevos registros en la Base de Datos en la Tabla Articulo
        /// </summary>
        /// <param name="articulo"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AgregarArticulo([FromBody]Articulo articulo)
        {
            if(ModelState.IsValid)
            {
                Context.Articulo.Add(articulo);
                Context.SaveChanges();
                return Ok(articulo);
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Actualiza los registros en la Base de Datos en la Tabla Articulo
        /// </summary>
        /// <param name="articulo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult ActualizarArticulo(int id, [FromBody] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                var articuloExiste = Context.Articulo.Count(e => e.idArticulo == id) > 0;
                if (articuloExiste)
                {
                    Context.Entry(articulo).State = EntityState.Modified;
                    Context.SaveChanges();

                    return Ok(articulo);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina los registros en la Base de Datos de la Tabla Articulo que concidan con el idArticulo
        /// </summary>
        /// <param name="articulo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult EliminarArticulo(int id)
        {
            var articulo = Context.Articulo.Find(id);

            if (articulo != null)
            {
                Context.Articulo.Remove(articulo);
                Context.SaveChanges();

                return Ok(articulo);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
