using AutoMapper;
using GaboMisc.Templates.WebApi.Microservice._01.Domain.Models.Dtos;
using GaboMisc.Templates.WebApi.Microservice._01.Domain.Models.Entities;
using GaboMisc.Templates.WebApi.Microservice._01.Domain.Models.Exceptions;
using GaboMisc.Templates.WebApi.Microservice._02.Application.Business.Contracts;

namespace GaboMisc.Templates.WebApi.Microservice._02.Application.Business
{
    public class ValidationBusiness : IValidationBusiness
    {
        private readonly IMapper _mapper;

        public ValidationBusiness(IMapper mapper) => _mapper = mapper;

        public async Task<ResultDto> ValidateProcess(RequestDto request)
        {
            ResultDto result;
            ValidationResponseEntity response;

            ValidationRequestEntity contentRequest = _mapper.Map<ValidationRequestEntity>(request);

            if (contentRequest.Version == 4)
                throw new NotImplementedException();
            else if (contentRequest.Version == 3)
                throw new CustomException("Incorrecto");
            else
                response = new ValidationResponseEntity()
                {
                    Success = true,
                    Message = $"Exito"
                };

            // Auto Mapper
            result = _mapper.Map<ResultDto>(response);

            return await Task.FromResult(result);
        }
    }
}