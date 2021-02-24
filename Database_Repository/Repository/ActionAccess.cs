using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Repository.Repository
{
    public class ActionAccess
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ServiceResponse<ActionData> serviceResponse = new ServiceResponse<ActionData>();
        public ActionAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ServiceResponse<ActionData>> AddAction(ActionData actionData)
        {
            try
            {
                actionData.ActionId = 0; // Identity column
                await _bankDbContext.Actions.AddAsync(actionData);
                await _bankDbContext.SaveChangesAsync();
                serviceResponse.Message = "Record added successfully";
                serviceResponse.Data = actionData;
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<ActionData>> DeleteAction(int actionId)
        {
            try
            {
                var deleteAction = await _bankDbContext.Actions.FirstOrDefaultAsync(x => x.ActionId == actionId);
                if (deleteAction != null)
                {
                    _bankDbContext.Actions.Remove(deleteAction);
                    await _bankDbContext.SaveChangesAsync();
                    serviceResponse.Data = deleteAction;
                    serviceResponse.Message = "Record deleted successfully";
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"Record {actionId} not found to delete.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<ActionData>> EditAction(ActionData action)
        {
            try
            {
                var editData = await _bankDbContext.Actions.FirstOrDefaultAsync(x => x.ActionId == action.ActionId);
                if (editData != null)
                {
                    editData.ActionName = action.ActionName;
                    _bankDbContext.Actions.Update(editData);
                    await _bankDbContext.SaveChangesAsync();
                    serviceResponse.Message = "Record updated successfuly";
                    serviceResponse.Data = editData;
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"Record {action.ActionId} not found to edit";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<ActionData>> GetAction(int actionId)
        {
            try
            {
                var getAction = await _bankDbContext.Actions.FirstOrDefaultAsync(x => x.ActionId == actionId);
                if(getAction != null)
                {
                    serviceResponse.Data = getAction;
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"Record {actionId} not found.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<ActionData>>> GetAllActions()
        {
            ServiceResponse<List<ActionData>> services = new ServiceResponse<List<ActionData>>();
            try
            {
               var getAllActions =await _bankDbContext.Actions.ToListAsync();
               if(getAllActions != null)
                {
                    services.Data = getAllActions;
                    return services;
                }
                services.Success = false;
                services.Message = "No records found.";
                return services;
            }
            catch(Exception ex)
            {
                services.Success = false;
                services.Message = ex.Message;
                return services;
            }
        }
    }
}
