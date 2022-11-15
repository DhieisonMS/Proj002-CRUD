using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Context;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class UserControl : ControllerBase
    {  
        private readonly DbConnect _context;
        public UserControl(DbConnect context)
        {
            _context = context;
        }

        [HttpGet("GetUserNameID{id}")]
        public IActionResult GetUSerName(int id){
            var user = _context.User.Find(id);
            
            if (user == null)
            {
                return NotFound();
            }
            else{
                return Ok(user);
            }
                 
        }

        [HttpGet("GetUserName{name}")]
        public IActionResult GetName(string name){
            var user = _context.User.Where(props => props.Name.Contains(name));
            
            if (user == null)
            {
                return NotFound();
            }
            else{
                return Ok(user);
            }
                   
        } 

        [HttpPut("Updateuser")]

        public IActionResult UpdateUser(int id, User user)
        {
            var FindUser = _context.User.Find(id);

            if (FindUser == null){
                return NotFound();
            }

            FindUser.Name = user.Name;
            FindUser.Password = user.Password;

            _context.User.Update(FindUser);
            _context.SaveChanges();

            return Ok("ok");

        }

        [HttpPost("NewUser")]
        public IActionResult AtualizaNAme(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        
        [HttpDelete("DeleteName")]
        public IActionResult DeleteName(int id)
        {
            var FindUser = _context.User.Find(id);

            if (FindUser == null){
                return NotFound();
            }

            _context.User.Remove(FindUser);
            _context.SaveChanges();

            return NoContent();
        }

    }
    
   

    
}