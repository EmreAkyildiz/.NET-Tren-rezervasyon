using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        ITrainService _trainService;
        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpPost("reserve")]
        public IActionResult Reserve(Root root)
        {
            var result = _trainService.Reserve(root);
            if (result.RezervasyonYapilabilir)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
