using Microsoft.AspNetCore.Mvc;
using Registro.Datos;
using Registro.Models;

namespace Registro.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //mostrara una lista de usuarios
            var olista = _ContactoDatos.Listar();
            return View(olista);
        }
        public IActionResult Guardar()
        {
            //solo devuelve la vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(UsersModel ocontacto)
        {
            //RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Guardar(ocontacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdUsers)
        {
            //edita el usuario
            var ocontacto = _ContactoDatos.Obtener(IdUsers);
            return View(ocontacto);
        }
        //Revisar la edicion
        [HttpPost]
        public IActionResult Editar(UsersModel ocontacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(ocontacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdUsers)
        {
            //edita el usuario
            var ocontacto = _ContactoDatos.Obtener(IdUsers);
            return View(ocontacto);
        }
        //Revisar la edicion
        [HttpPost]
        public IActionResult Eliminar(UsersModel ocontacto)
        {
            var respuesta = _ContactoDatos.Eliminar(ocontacto.IdUsers);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
