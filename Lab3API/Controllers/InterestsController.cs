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
    public class InterestsController : ControllerBase
    {
        private IInterest<Interest> _interest;

        public InterestsController(IInterest<Interest> interest)
        {
            this._interest = interest;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interest.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var result = await _interest.GetSingle(id);
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
        public async Task<ActionResult<Interest>> CreateNewInterest (Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }

                var createdInterest = await _interest.Add(newInterest);
                return CreatedAtAction(nameof(GetInterest),
                    new { id = createdInterest.InterestID }, createdInterest);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create new object to the database....");                
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var interestToDelete = await _interest.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Interest with ID {id} not found....");
                }
                return await _interest.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");               
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if ( id != interest.InterestID)
                {
                    return BadRequest($"Interest with ID {id} does not match");
                }
                var interestToUpdate = await _interest.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound();
                }
                return await _interest.Update(interest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update database");                
            }            
          
        }
    }

}
