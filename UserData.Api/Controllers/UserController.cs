using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IExpenseService _expenseService;
        public UserController(IUserService userService, IExpenseService expenseService)
        {
            _userService = userService;
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            var created = await _userService.Create(user);
            if(created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpPut("int:id")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody]User user, CancellationToken cancellationToken)
        {
            var updated = await _userService.UpdateUser(id, user, cancellationToken);
            if(updated == null)
            {
                return BadRequest();
            }
            return Ok(updated);
        }

        [HttpGet("int:id")]
        public async Task<ActionResult<User>> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(id, cancellationToken);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);                        
        }

        [HttpGet("int:id/expenses")]
        public ActionResult<IEnumerable<Expense>> GetUserExpenses(int id, CancellationToken cancellationToken)
        {
            var expenses = _expenseService.GetUserExpenses(id, cancellationToken);
            return Ok(expenses);
        }

        [HttpDelete("int: id")]
        public async Task<ActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(id, cancellationToken);
            return Ok();
        }
    }
}