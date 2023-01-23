using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectKlix.Models;

namespace ProjectKlix.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    { 

        DbKlixContext db = new DbKlixContext();


        [HttpGet("{id}")]
        public IActionResult UserAccount(string id)
        {
            List<User> data = db.Users.OrderByDescending(r => r.UserId.Equals(id)).ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult SingUp([FromBody] User data)
        {

            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult UpdateAccount([FromBody] User data)
        {

            User result = db.Users.Where(a => a.Email == data.Email).FirstOrDefault();
            if (result != null && data.Password == result.Password)
            {
                result.UserName = (data.UserName != null) ? data.UserName : result.UserName;
                
                db.SaveChanges();
            }
            else
            {
                return NotFound($"Email  {data.Email} nije pronadjena");
            }

            return Ok(result);
        }



        [HttpDelete("{id:int}")]
        public IActionResult Delete(string id)
        {
           
            User result = db.Users.Where(r => r.Email == id).FirstOrDefault();
            if (result == null)
            { return NotFound($"Trazeni podatak nije pronaden!"); }
            else
            {
                db.Remove(result);
                db.SaveChanges();
            }
            return Ok(result);
        }
       
        [HttpPost]
        public IActionResult PostCommetn([FromBody] User user)
        {
            User result = db.Users.Where(a => a.Email == user.Email).FirstOrDefault();
            News news = db.News.Where(v => v.NewsId == user.Comment.NewsId).FirstOrDefault();
            if (result != null && user.Password == result.Password)
            {
                result.Comment.Text = (user.Comment.Text != null) ? user.Comment.Text : result.Comment.Text;
                result.Comment.NewsId = user.Comment.NewsId;
                result.UserName = user.UserName;
                result.Comment.UserId = user.UserId;
                

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Korisnik {user.UserName} nije pronadjena");
            }

            return Ok(result);

        }


    }
}
