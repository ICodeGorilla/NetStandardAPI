using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service.DTO
{
    public static class ServiceResponseFactory
    {
        public static ServiceResponse<T> CreateFailedResponse<T>(string message)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message
            };
        }

        public static ServiceResponse<T> CreateSuccessResponse<T>(T value)
        {
            return new ServiceResponse<T>
            {
                Success = true,
                Value = value
            };
        }

        public static ServiceResponse<T> CreateFailedResponse<T>(DbUpdateException ex)
        {
            var errorMessages = (from SqlError sqlError in ex.Entries select sqlError.Message).ToList();
            var fullErrorMessage = string.Join(" ", errorMessages);
            return new ServiceResponse<T>
            {
                Success = false,
                Message = fullErrorMessage
            };
        }

        internal static ServiceResponse<T> CreateFailedResponse<T>(SqlException ex)
        {
            var errorMessages = (from SqlError sqlError in ex.Errors select sqlError.Message).ToList();
            var fullErrorMessage = string.Join(" ", errorMessages);
            return new ServiceResponse<T>
            {
                Success = false,
                Message = fullErrorMessage
            };
        }

       
        public static ServiceResponse<T> CreateFailedResponse<T>(InvalidOperationException ex)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = ex.Message
            };
        }

        public static ServiceResponse<T> CreateFailedResponse<T>(Exception ex)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }
}
