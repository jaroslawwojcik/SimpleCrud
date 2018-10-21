using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//20. Tworzymy interface walidacji
// ValidateResult Validate<T>(T param, string key); - interface szablonowy
namespace SimpleCrud.Validator
{
    public interface IValidator<TModel>
    {
        //zwravamy liste validation result
        IEnumerable<ValidateResult> Validate(TModel param);
    }

    public class ValidateResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
