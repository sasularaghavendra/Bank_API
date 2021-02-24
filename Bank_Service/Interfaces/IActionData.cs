using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Interfaces
{
    public interface IActionData
    {
        Task<ServiceResponse<ActionData>> AddAction(ActionData action);
        Task<ServiceResponse<ActionData>> EditAction(ActionData action);
        Task<ServiceResponse<ActionData>> DeleteAction(int actionId);
        Task<ServiceResponse<List<ActionData>>> GetAllActions();
        Task<ServiceResponse<ActionData>> GetAction(int actionId);
    }
}
