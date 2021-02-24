using Bank_Models.Models;
using Bank_Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly ActionService _actionService;
        public ActionController(ActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpPost("AddAction")]
        public async Task<ServiceResponse<ActionData>> AddAction(ActionData action)
        {
            return await _actionService.AddAction(action);
        }
        [HttpPut("EditAction")]
        public async Task<ServiceResponse<ActionData>> EditAction(ActionData action)
        {
            return await _actionService.EditAction(action);
        }
        [HttpDelete("{actionId}")]
        public async Task<ServiceResponse<ActionData>> DeleteAction(int actionId)
        {
            return await _actionService.DeleteAction(actionId);
        }
        [HttpGet("GetAllActions")]
        public async Task<ServiceResponse<List<ActionData>>> GetAllActions()
        {
            return await _actionService.GetAllActions();
        }
        [HttpGet("{actionId}")]
        public async Task<ServiceResponse<ActionData>> GetAction(int actionId)
        {
            return await _actionService.GetAction(actionId);
        }
    }
}
