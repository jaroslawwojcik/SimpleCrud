using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validator
{
    public class AddUserModelValidator : IValidator<AddUserModel>
    {
        public IEnumerable<ValidateResult> Validate(AddUserModel model)
        {
            var result = new List<ValidateResult>();
            var now = DateTime.UtcNow;
            var dateOfBirth = model.DateOfBirth;
            var yearsDifference = now.Year - dateOfBirth.Year;

            if(yearsDifference <= 10)
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.DateOfBirth),
                    Message = "Użytkownik musi mieć więcej niż 10 lat"
                });
            };

            return result;
        }
    }
}