using Core.DataAccess.Repositories.Base;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface ISmsOperationResultRepository
    {
        Task<List<SmsOperationResult>> GetAllAsync();
        Task<SmsOperationResult> GetAsync(int id);
        Task CreateAsync(SmsOperationResult smsOperationResult);
    }
}
