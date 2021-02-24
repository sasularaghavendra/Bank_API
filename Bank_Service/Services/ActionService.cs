using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Services
{
    public class ActionService : IActionData
    {
        private readonly ActionAccess _actionAccess;
        public ActionService(ActionAccess actionAccess)
        {
            _actionAccess = actionAccess;
        }
        public async Task<ServiceResponse<ActionData>> AddAction(ActionData action)
        {
            return await _actionAccess.AddAction(action);
        }
        public async Task<ServiceResponse<ActionData>> DeleteAction(int actionId)
        {       
            return await _actionAccess.DeleteAction(actionId);
        }
        public async Task<ServiceResponse<ActionData>> EditAction(ActionData action)
        {
            return await _actionAccess.EditAction(action);
        }
        public async Task<ServiceResponse<ActionData>> GetAction(int actionId)
        {
            return await _actionAccess.GetAction(actionId);
        }
        public async Task<ServiceResponse<List<ActionData>>> GetAllActions()
        {
            return await _actionAccess.GetAllActions();
        }
    }
}
