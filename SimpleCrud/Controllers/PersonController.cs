﻿using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{   //1. Każdy kontroler dziedziczy po klasie controller
    //2. Dodajemy akcje np. Index do której mamy dostęp przez url Person/Index
    //3. Edit dostaje id przez co url bedzie Person/Index/id
    // >Entities/User
    //
    public class PersonController : Controller
    {
        //4.
        private readonly IPersonsRepository _personsRepository = new PersonsRepository();
        private readonly IValidator<DateTime> _validator = new DateOfBirthValidator();


        public ActionResult Index()
        {
            //7. pobieramy wszystkich userów i zwracamy ich w view
            var userList = _personsRepository.GetAllUsers();
            return View(userList);
        }

        public ActionResult Edit(long id)
        {
            var model = _personsRepository.GetUser(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            _personsRepository.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            //10. Dodajemy usera, przekazujemy go do widoku
            var userModel = new AddUserModel();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Add(AddUserModel user)
        {
            //10. Dodajemy akcje do zapisania usera w repository
            // Najpierw robimy walidację, poźniej sprawdzamy modalstate, walidacja jest utworzona w folderze validate
            var validationResult = _validator.Validate(user.DateOfBirth, nameof(user.DateOfBirth));

            if(validationResult != null)
            {
                ModelState.AddModelError(
                    validationResult.Key,
                    validationResult.Message
                    );
            }

            if (ModelState.IsValid)
            {
                _personsRepository.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
            
        }

        public ActionResult Delete(long id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _personsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}