using Lab3API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUser<User> _user;

        public UsersController(IUser<User> user)
        {
            this._user = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _user.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _user.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");                
            }          

        }
               
        [HttpPost]
        public async Task<ActionResult<User>> AddNewUser(User newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest();
                }
                var createdUser = await _user.Add(newUser);
                return CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.UserID }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create new object to the database");                
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser (int id)
        {
            try
            {
                var userToDelete = await _user.GetSingle(id);
                if (userToDelete == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return await _user.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");                
            }
                      
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.UserID)
                {
                    return BadRequest($"Order with ID {id} does not match");
                }
                var userToUpdate = await _user.GetSingle(id);
                if (userToUpdate == null)
                {
                    return NotFound();
                }
                return await _user.Update(user);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update database");               
            }
        }

    }
}
