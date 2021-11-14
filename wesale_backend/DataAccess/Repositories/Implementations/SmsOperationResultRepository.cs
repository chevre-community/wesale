using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class SmsOperationResultRepository : ISmsOperationResultRepository
    {
        private readonly WeSaleContext _context;

        public SmsOperationResultRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SmsOperationResult smsOperationResult)
        {
            await _context.SmsOperationResults.AddAsync(smsOperationResult);
        }

        public async Task<List<SmsOperationResult>> GetAllAsync()
        {
            return await _context.SmsOperationResults
                                                    .OrderByDescending(sr => sr.Id)
                                                    .ToListAsync();
        }

        public async Task<SmsOperationResult> GetAsync(int id)
        {
            return await _context.SmsOperationResults.FindAsync(id);
        }
    }
}
