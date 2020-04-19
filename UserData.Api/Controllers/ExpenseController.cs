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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("int:id")]
        public async Task<ActionResult<Expense>> GetExpense(int id, CancellationToken cancellationToken)
        {
            var expense = await _expenseService.GetExpense(id, cancellationToken);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> CreateExpense([FromBody] Expense expense, CancellationToken cancellationToken)
        {
            var created = await _expenseService.CreateExpense(expense, cancellationToken);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(expense);
        }

        [HttpPut("int:id")]
        public async Task<ActionResult<Expense>> UpdateExpense(int id, [FromBody]Expense expense, CancellationToken cancellationToken)
        {
            var updated = await _expenseService.UpdateExpense(id, expense, cancellationToken);
            if(updated == null)
            {
                return BadRequest();
            }
            return Ok(updated);
        }

        [HttpDelete("int:id")]
        public async Task<ActionResult<Expense>> DeleteExpense(int id, CancellationToken cancellationToken)
        {
            await _expenseService.DeleteExpense(id, cancellationToken);
            return Ok();
        }
    }
}