using L01_2020MZ602_2019TM602.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2020MZ602_2019TM602.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2020MZ602_2019TM602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly blogContext _blogContext;

        public UsuariosController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Usuarios> ListadoUsuario = (from e in _blogContext.Usuarios
                                           select e).ToList();
            if (ListadoUsuario.Count == 0)
            { return NotFound(); }

            return Ok(ListadoUsuario);

        }



        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Usuarios? usuario = (from e in _blogContext?.Usuarios where e.usuarioId == id select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);



        }

        //BUSCAR POR DESCRIPCION 
        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByNombre(string filtro)
        {
            Usuarios? usuarioNombre = (from e in _blogContext.Usuarios where e.nombreUsuario.Contains(filtro) select e).FirstOrDefault();
           
           

            if (usuarioNombre == null)
            { return NotFound(); }

            return Ok(usuarioNombre);
        }


        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByApellido(string filtro)
        {
           
            Usuarios? usuarioApellido = (from e in _blogContext.Usuarios where e.apellido.Contains(filtro) select e).FirstOrDefault();
            

            if (usuarioApellido == null)
            { return NotFound(); }

            return Ok(usuarioApellido);
        }


        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByRol(int filtro)
        {

            Usuarios? usuarioRol = (from e in _blogContext.Usuarios where e.rolId ==filtro select e).FirstOrDefault();


            if (usuarioRol == null)
            { return NotFound(); }

            return Ok(usuarioRol);
        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] Usuarios usuarios)
        {
            try

            {

                _blogContext.Usuarios.Add(usuarios);
                _blogContext.SaveChanges();

                return Ok(usuarios);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] Usuarios usuarioModificar)
        {
            Usuarios? usuarioActual = (from e in _blogContext.Usuarios where e.rolId == id select e).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }

            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.apellido = usuarioModificar.apellido;
            usuarioActual.usuarioId = usuarioModificar.usuarioId;
            usuarioActual.clave = usuarioModificar.clave;
            usuarioActual.nombreUsuario = usuarioModificar.nombreUsuario;
            usuarioActual.rolId = usuarioModificar.rolId;

            _blogContext.Entry(usuarioActual).State = EntityState.Modified;

            _blogContext.SaveChanges();

            return Ok(usuarioActual);
        }



        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarEquipo(int id)
        {
            Usuarios? usuarios = (from e in _blogContext.Usuarios where e.rolId == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (usuarios == null)
            {
                return NotFound();
            }

            _blogContext.Usuarios.Attach(usuarios);
            _blogContext.Usuarios.Remove(usuarios);
            _blogContext.SaveChanges();

            return Ok(usuarios);
        }

    }

}

    
