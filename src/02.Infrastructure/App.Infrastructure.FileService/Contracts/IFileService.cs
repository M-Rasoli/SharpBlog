using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.FileService.Contracts
{
    public interface IFileService
    { 
        public string Upload(IFormFile file, string folder);
    }
}
