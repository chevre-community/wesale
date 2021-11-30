using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface ISmsOperationResultService
    {
        Task<List<SmsOperationResult>> GetAllAsync();
        Task<SmsOperationResult> GetAsync(int id);
        Task CreateAsync(SmsOperationResult smsOperationResult);
        void CreateInBackground(SmsOperationResult smsOperationResult);
    }
}
