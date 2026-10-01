using FirstCrudOperation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationdbContext _applicationdbContext;
        public UserController(ApplicationdbContext applicationdbContext)
        {
            _applicationdbContext = applicationdbContext;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var user = _applicationdbContext.Userabc.AsNoTracking().ToList();
            return Ok(user);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var user = _applicationdbContext.Userabc.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("Add")]
        public IActionResult add(User user)
        {
            _applicationdbContext.Userabc.Add(user);
            _applicationdbContext.SaveChanges();
            return Ok(user);
        }


        [HttpPut("Update")]
        public IActionResult update(int id, User user)
        {
            var existingUser = _applicationdbContext.Userabc.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            _applicationdbContext.SaveChanges();
            return Ok(existingUser);
        }
        [HttpDelete("Delete")]
        public IActionResult delete(int id)
        {
            var user = _applicationdbContext.Userabc.Find(id);
            if (user == null) 
            {
                return NotFound();
            }
            _applicationdbContext.Userabc.Remove(user);
            _applicationdbContext.SaveChanges();
            return Ok(user);
        }
    }
}
