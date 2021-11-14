using Core.DataAccess;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.SMS.Abstraction;
using Core.Services.Notification.SMS.Serializers.Submit.Individual;
using Services.Notification.SMS.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions.String;
using Core.Constants.Notification.SMS;
using Core.Services.Notification.SMS.Serializers.Submit.Bulk;
using Core.Services.Notification.SMS;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Business.Data.Implementations
{
    public class SmsOperationResultService : ISmsOperationResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseCodes _responseCodes;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;

        public SmsOperationResultService(IUnitOfWork unitOfWork, IBackgroundTaskQueue backgroundTaskQueue)
        {
            _unitOfWork = unitOfWork;
            _responseCodes = new ResponseCodes();
            _backgroundTaskQueue = backgroundTaskQueue;
        }

        public async Task CreateAsync(SmsOperationResult smsOperationResult)
        {
            await _unitOfWork.SmsOperationResults.CreateAsync(smsOperationResult);
            await _unitOfWork.CommitAsync();
        }

        public void CreateInBackground(SmsOperationResult smsOperationResult)
        {
            _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
            {
                // Get services
                using var scope = serviceScopeFactory.CreateScope();
                var smsService = scope.ServiceProvider.GetRequiredService<ISmsOperationResultService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SmsOperationResultService>>();

                try
                {
                    await smsService.CreateAsync(smsOperationResult);

                    logger.LogInformation("Nurlan xiyar success " + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Could not do something expensive");
                }
            });
        }

        public async Task<List<SmsOperationResult>> GetAllAsync()
        {
            var smsOperationResults = await _unitOfWork.SmsOperationResults.GetAllAsync();

            foreach (var smsOperationResult in smsOperationResults)
            {
                switch (smsOperationResult.Type)
                {
                    case SmsType.Individual:
                        smsOperationResult.SerializedIndividualRequest = smsOperationResult.RequestBody.Deserialize<OperationSubmitIndividualRequestSerializer>();
                        smsOperationResult.SerializedIndividualResponse = smsOperationResult.ResponseBody.Deserialize<OperationSubmitIndividualResponseSerializer>();
                        smsOperationResult.ResponseMessage = _responseCodes.Codes.GetValueOrDefault(smsOperationResult.SerializedIndividualResponse.Head.ResponseCode);
                        break;
                    case SmsType.Bulk:
                        smsOperationResult.SerializedBulkRequest = smsOperationResult.RequestBody.Deserialize<OperationSubmitBulkRequestSerializer>();
                        smsOperationResult.SerializedBulkResponse = smsOperationResult.ResponseBody.Deserialize<OperationSubmitBulkResponseSerializer>();
                        smsOperationResult.ResponseMessage = _responseCodes.Codes.GetValueOrDefault(smsOperationResult.SerializedBulkResponse.Head.ResponseCode);
                        break;
                    default:
                        break;
                }
            }

            return smsOperationResults;
        }

        public async Task<SmsOperationResult> GetAsync(int id)
        {
            return await _unitOfWork.SmsOperationResults.GetAsync(id);
        }
    }
}
