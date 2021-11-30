using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators.FileValidator.PhotoValidator
{
    public interface IPhotoProperty
    {
        public IFormFile Photo { get; set; }
    }
}
