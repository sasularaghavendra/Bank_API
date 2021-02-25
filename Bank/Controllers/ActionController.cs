using Bank_Models.Models;
using Bank_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionData _action;
        public ActionController(IActionData action)
        {
            _action = action;
        }

        [HttpPost("AddAction")]
        public async Task<ServiceResponse<ActionData>> AddAction(ActionData action)
        {
            return await _action.AddAction(action);
        }
        [HttpPut("EditAction")]
        public async Task<ServiceResponse<ActionData>> EditAction(ActionData action)
        {
            return await _action.EditAction(action);
        }
        [HttpDelete("{actionId}")]
        public async Task<ServiceResponse<ActionData>> DeleteAction(int actionId)
        {
            return await _action.DeleteAction(actionId);
        }
        [HttpGet("GetAllActions")]
        public async Task<ServiceResponse<List<ActionData>>> GetAllActions()
        {
            return await _action.GetAllActions();
        }
        [HttpGet("{actionId}")]
        public async Task<ServiceResponse<ActionData>> GetAction(int actionId)
        {
            return await _action.GetAction(actionId);
        }
    }
}
