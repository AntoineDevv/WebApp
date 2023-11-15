using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyTest.Api.Models;

namespace MyTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartementController : ControllerBase
    {
        [HttpGet("{pays}")]
        public ActionResult<IEnumerable<DepartementModel>> GetDepartements(string pays)
        {
            if (pays.ToLower() == "france")
            {
                var departements = new List<DepartementModel>
                {
                    new DepartementModel { Name = "Ain", Code = "01" },
                    new DepartementModel { Name = "Bouches-du-Rhône", Code = "13" },
                    new DepartementModel { Name = "Indre", Code = "36" },
                    new DepartementModel { Name = "Nord", Code = "59" },
                    
                };

                return Ok(departements);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
