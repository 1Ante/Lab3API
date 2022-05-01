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
    [Route("api/[controller]")]
    [ApiController]
    public class UserInterestController : ControllerBase
    {
        private IUserInterest<UserInterests> _userInterests;

        public UserInterestController(IUserInterest<UserInterests> userInterests)
        {
            this._userInterests = userInterests;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUserInterests()
        {
            try
            {
                return Ok(await _userInterests.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");              
            }
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserInterests>> GetUserInterest(int id)
        {
            try
            {
                var result = await _userInterests.GetSingle(id);
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
        public async Task<ActionResult<UserInterests>> CreateNewUserInterest(UserInterests newuserInterest)
        {
            try
            {
                if (newuserInterest == null)
                {
                    return BadRequest();
                }

                var createdUserInterest = await _userInterests.Add(newuserInterest);
                return CreatedAtAction(nameof(GetUserInterest),
                    new { id = createdUserInterest.UserInterestID }, createdUserInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create new object to the database.....");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInterests>> DeleteUserInterest(int id)
        {
            try
            {
                var userInterestToDelete = await _userInterests.GetSingle(id);
                if (userInterestToDelete == null)
                {
                    return NotFound($"User with ID {id} not found.....");
                }
                return await _userInterests.Delete(id);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserInterests>> UpdateUserInterest(int id, UserInterests userInterests)
        {
            try
            {
                if (id != userInterests.UserInterestID)
                {
                    return BadRequest($"UserInterest with ID {id} does not match");
                }

                var userInterestToUpdate = await _userInterests.GetSingle(id);
                if (userInterestToUpdate == null)
                {
                    return NotFound();
                }
                return await _userInterests.Update(userInterests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update database");
            }
        }
    }
}
