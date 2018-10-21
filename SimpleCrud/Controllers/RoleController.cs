using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public ActionResult Index()
        {
            var roleList = _roleRepository.GetAll();
            return View(roleList);
        }

        public ActionResult Add()
        {
            var roleModel = new AddRoleModel();
            return View(roleModel);
        }

        [HttpPost]
        public ActionResult Add(AddRoleModel model)
        {
            //Validate(model);


            if (ModelState.IsValid)
            {
                _roleRepository.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Delete(long id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}