using SimpleCrud.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{//21. Dalej do validacji tworzymy klasę abstrakcyjną, po której dziedziczyć będą ...
    public abstract class BaseController : Controller
    {
        public void Validate<TModel>(IValidator<TModel> validator, TModel model)
        {
            var result = validator.Validate(model);

            foreach (var res in result)
            {
                ModelState.AddModelError(
                    res.Key,
                    res.Message
                    );
            }
        }
    }
}