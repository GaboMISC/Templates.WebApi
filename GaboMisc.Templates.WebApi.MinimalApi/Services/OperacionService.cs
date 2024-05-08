using GaboMisc.Templates.WebApi.MinimalApi.Services.Contracts;

namespace GaboMisc.Templates.WebApi.MinimalApi.Services
{
    public class OperacionService : IOperacionService
    {
        public int Addtion(int a, int b)
        {
            return a + b;
        }
    }
}