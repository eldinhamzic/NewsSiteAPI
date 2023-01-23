using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectKlix.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectKlix.Controllers
{
   
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class NewsController : ControllerBase
        {
            DbKlixContext db = new DbKlixContext();

            [HttpGet]
             public IActionResult GetNews()
            {   
                  List<News> data = db.News.ToList();
                  return Ok(data);
            }

            [HttpGet("{id}")]
            public IActionResult GetNewsById(string id)
            {
                List<News> data = db.News.OrderByDescending(r => r.NewsId.Equals(id)).ToList();
                return Ok(data);
            }

            [HttpPost]
            public IActionResult Publishing([FromBody] News data)
            {
                
                db.Add(data);
                db.SaveChanges();
                return Ok(data);
            }

            [HttpPost]
            public IActionResult Update([FromBody] News data)
            {
            
                News result = db.News.Where(a => a.NewsId == data.NewsId).FirstOrDefault();
                if (result != null && data.Author.AuthorId == result.Author.AuthorId)
                {
                    result.Title = (data.Title != null) ? data.Title : result.Title;
                    result.Description = (data.Description != null) ? data.Description : result.Description;
                    result.Content = (data.Content != null) ? data.Content : result.Content;
                   // result.Author = (data.Author != null) ? data.Author : result.Author;
                    result.DateAndTime = data.DateAndTime;
                    result.Photo = (data.Photo != null) ? data.Photo : result.Photo;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound($"Osoba sa id {data.Title} nije pronadjena");
                }

                return Ok(result);
            }



            [HttpDelete("{data:int}")]
            public IActionResult Delete(int data)  
            {
                News result = db.News.Where(r => r.NewsId == data).FirstOrDefault();
                if (result == null)
                { return NotFound($"Trazeni podatak nije pronaden!"); }
                else
                {
                    db.Remove(result);
                    db.SaveChanges();
                }
                return Ok(data);
            }

        }


    
}
