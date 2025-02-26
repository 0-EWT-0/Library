using Library.Models.Domain;
using Library.Services.IServices;
using Library.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRolServices _rolServices;

        // constructor
        public UserController(IUserServices userServices, IRolServices rolServices)
        {
            _userServices = userServices;
            _rolServices = rolServices;
        }

        public IActionResult Index()
        {
            var result = _userServices.GetUsers();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Rol> result = await _rolServices.GettAll();
            ViewBag.Roles = result.Select(p => new SelectListItem()
            {
                Text = p.Pk_rol_name,
                Value = p.Pk_rol_id.ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User request)
        {
            var result = _userServices.CreateUser(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]

        public IActionResult UpdateUser(User request)
        {
            var result = _userServices.UpdateUser(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id) {

            List<Rol> rol = await _rolServices.GettAll();
            ViewBag.Roles = rol.Select(p => new SelectListItem()
            {
                Text = p.Pk_rol_name,
                Value = p.Pk_rol_id.ToString()
            });

            var result = _userServices.GetById(id);
            return View(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _userServices.DeleteUser(id);
        
            if(response != null)
            {
                return Json(new { success = true });
            } else
            {
                return Json(new { success = false });
            }
                
        }

    }
}
