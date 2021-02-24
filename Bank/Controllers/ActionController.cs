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
        public ActionResult<ActionData> AddAction(ActionData action)
        {
            var actionDetails = _actionService.AddAction(action);

            if (actionDetails != null)
            {
                return actionDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
        [HttpPut("EditAction")]
        public ActionResult<ActionData> EditAction(ActionData action)
        {
            var actionDetails = _actionService.EditAction(action);

            if (actionDetails != null)
            {
                return actionDetails;
            }
            else
            {
                return Ok("Error occured..No data found.");
            }
        }
        [HttpDelete("{actionId}, Name = DeleteAction")]
        public ActionResult<ActionData> DeleteAction(int actionId)
        {
            var actionDetails = _actionService.DeleteAction(actionId);

            if (actionDetails != null)
            {
                return actionDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
        [HttpGet("GetAllActions")]
        public ICollection<ActionData> GetAllActions()
        {
            var actionDetails = _actionService.GetAllActions();
            if (actionDetails.Count != 0)
            {
                return actionDetails.ToList();
            }
            return null;
        }
        [HttpGet("{actionId}, Name = GetAction")]
        public ActionResult<ActionData> GetAction(int actionId)
        {
            var actionDetails = _actionService.GetAction(actionId);
            if (actionDetails.Value != null)
            {
                return actionDetails;
            }
            return Ok("No Data Found");
        }
    }
}
