using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Product.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[]
            {
                "Book", "Pencil", "Eraser", "Notebook", "Ruler"
            };
        }
    }
}