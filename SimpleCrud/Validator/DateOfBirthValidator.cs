using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//21. Tworzymy klasę inplementującą interface IValidator
namespace SimpleCrud.Validator
{
    public class DateOfBirthValidator : IValidator<DateTime>
    {
        public ValidateResult Validate(DateTime param, string key)
        {
            var now = DateTime.UtcNow;
            var yearsDifference = now.Year - param.Year;

            if(yearsDifference <= 10)
            {
                return new ValidateResult
                {
                    Key = key,
                    Message = "Użytkownik musi być starszy niż 10 lat"
                };
            }

            return null;
        }
    }
}