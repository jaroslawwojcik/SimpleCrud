using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validator
{
    public class EditUserModelValidator : IValidator<EditUserModel>
    {
        public IEnumerable<ValidateResult> Validate(EditUserModel model)
        {
            var result = new List<ValidateResult>();

            var firstName = model.FirstName?.Trim();
            var lastName = model.LastName?.Trim();
            
            if (HasStringContainsDigit(firstName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.FirstName),
                    Message = "Imie nie może zawierać cyfry"
                });
            }
            if (HasStringContainsDigit(lastName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.LastName),
                    Message = "Nazwisko nie może zawierać cyfry"
                });
            }


            return result;
        }

        private bool HasStringContainsDigit(string word)
        {
            return word?.Any(char.IsDigit) ?? false;
        }
    }
}