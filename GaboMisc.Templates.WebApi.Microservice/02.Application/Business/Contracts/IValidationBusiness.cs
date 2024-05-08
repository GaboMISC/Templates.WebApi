using GaboMisc.Templates.WebApi.Microservice._01.Domain.Models.Dtos;

namespace GaboMisc.Templates.WebApi.Microservice._02.Application.Business.Contracts
{
    public interface IValidationBusiness
    {
        public Task<ResultDto> ValidateProcess(RequestDto request);
    }
}