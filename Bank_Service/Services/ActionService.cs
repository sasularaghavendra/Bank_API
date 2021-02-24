using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Services
{
    public class ActionService : IActionData
    {
        private readonly ActionAccess _actionAccess;
        public ActionService(ActionAccess actionAccess)
        {
            _actionAccess = actionAccess;
        }
        public ActionResult<ActionData> AddAction(ActionData action)
        {
            var actionDetails = _actionAccess.AddAction(action);
            return actionDetails;
        }

        public ActionResult<ActionData> DeleteAction(int actionId)
        {       
            var deletedActionDetails = _actionAccess.DeleteAction(actionId);
            return deletedActionDetails;
        }
        public ActionResult<ActionData> EditAction(ActionData action)
        {
            if(action != null)
            {
                var editAction = _actionAccess.EditAction(action);
                return editAction;
            }
            return null;           
        }
        public ActionResult<ActionData> GetAction(int actionId)
        {
            var getAction = _actionAccess.GetAction(actionId);
            return getAction;

        }

        public ICollection<ActionData> GetAllActions()
        {
            var getAllActions = _actionAccess.GetAllActions();
            return getAllActions;
        }
    }
}
