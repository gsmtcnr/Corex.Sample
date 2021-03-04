using Corex.Model.Infrastructure;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Sample.Operation.Manager.Users.User;
using System;

namespace Corex.Sample.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            new CorexStartup();
            Console.WriteLine("Hello World!");
            RegisterUser("sametcinar@msn.com", "Samet123");

            Console.ReadLine();
        }

        private static IResultObjectModel<UserDto> RegisterUser(string email, string password)
        {
            IUserOperationManager userManager = IoCManager.Resolve<IUserOperationManager>();
            IResultObjectModel<UserDto> result = userManager.Register(new UserRegisterInputModel
            {
                Email = email,
                Password = password
            });
            SetResult("RegisterUser", result);
            return result;
        }
        private static void SetResult(string operationName, IResultModel resultModel)
        {
            Console.WriteLine("Operation : " + operationName);
            if (resultModel.IsSuccess)
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Error");
                foreach (var item in resultModel.Messages)
                {
                    Console.WriteLine("ErrorCode: " + item.Code + " - ErrorMessage: " + item.Message);
                }
            }
        }
    }
}
