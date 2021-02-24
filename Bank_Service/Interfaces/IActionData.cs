using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Interfaces
{
    public interface IActionData
    {
        ActionResult<ActionData> AddAction(ActionData action);
        ActionResult<ActionData> EditAction(ActionData action);
        ActionResult<ActionData> DeleteAction(int actionId);

        ICollection<ActionData> GetAllActions();
        ActionResult<ActionData> GetAction(int actionId);
    }
}
