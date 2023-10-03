using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salmon_Cookies.Data;
using Salmon_Cookies.Dto;
using Salmon_Cookies.Interface;
using Salmon_Cookies.Model;

namespace Salmon_Cookies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CookieStandController : Controller
    {
        private readonly IStandCookies _dbContext;

        public CookieStandController(IStandCookies dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<CookieStand>> CreateCookieStand(CreateStand stand)
        {
            await _dbContext.Create(stand);

            return Ok("The stand cookies is added");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewStandCookies>>>GetCookieStands()
        {
            var AllStandCookies = await _dbContext.Get();
            return Ok(AllStandCookies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStand>> GetCookieStandById(int id)
        {
            var cookieStand =await _dbContext.GetById(id);
            if (cookieStand == null)
            {
                return NotFound();
            }

            return Ok(cookieStand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCookieStand(int id)
        {
            var cookieStand = await _dbContext.Delete(id);

            if (cookieStand == null)
            {
                return NotFound();
            }

            //_dbContext.CookieStands.Remove(cookieStand);


            return Ok("the stand cookies is removed" );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CookieStand>> UpdateCookieStand(int id, CreateStand updatedStand)
        {
            //var cookieStand = _dbContext.CookieStands.Find(id);
            //cookieStand.Location = cookieStand.Location;
            //cookieStand.Description = cookieStand.Description;
            //cookieStand.Description = cookieStand.Description;

           await _dbContext.Put(id, updatedStand);

            return Ok(updatedStand);
        }
    }
}
