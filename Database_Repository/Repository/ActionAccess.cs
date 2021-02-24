using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database_Repository.Repository
{
    public class ActionAccess
    {
        private readonly BankDbContext _bankDbContext;
        public ActionAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public ActionData AddAction(ActionData data)
        {
            _bankDbContext.Actions.Add(data);
            _bankDbContext.SaveChanges();
            return data;
        }
        public ActionResult<ActionData> DeleteAction(int actionId)
        {
            var deleteAction = _bankDbContext.Actions.FirstOrDefault(x => x.ActionId == actionId);
            if(deleteAction != null)
            {
                _bankDbContext.Actions.Remove(deleteAction);
                _bankDbContext.SaveChanges();
                return deleteAction;
            }
            return null;
        }
        public ActionResult<ActionData> EditAction(ActionData action)
        {
            var editData = _bankDbContext.Actions.FirstOrDefault(x => x.ActionId == action.ActionId);

            if(editData != null)
            {
                editData.ActionName = action.ActionName;
                _bankDbContext.Actions.Update(editData);
                _bankDbContext.SaveChanges();
                return editData;
            }
            return null;
        }
        public ActionResult<ActionData> GetAction(int actionId)
        {
            var getAction = _bankDbContext.Actions.FirstOrDefault(x => x.ActionId == actionId);
            return getAction;
        }
        public ICollection<ActionData> GetAllActions()
        {
            var getAllActions = _bankDbContext.Actions;
            return getAllActions.ToList();
        }
    }
}
