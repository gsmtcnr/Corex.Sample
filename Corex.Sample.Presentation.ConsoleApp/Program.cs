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

            //new CorexStartup();
            Console.WriteLine("Hello World!");
            //DummyUser();
         
            Console.ReadLine();
        }

        private static void DummyUser(int count = 50)
        {
            for (int i = 0; i < count; i++)
            {
                RegisterUser("deneme" + i + "@corex.com", "deneme" + i);
            }
        }

        private static void GetUser(int id)
        {
            IUserOperationManager userManager = IoCManager.Resolve<IUserOperationManager>();
            IResultObjectModel<UserDto> userResult = userManager.Get(id);
            SetResult("GetUser", userResult);
            if (userResult.IsSuccess)
                Console.WriteLine("Email :" + userResult.Data.Email);
        }

        private static void GetListUser()
        {
            IUserOperationManager userManager = IoCManager.Resolve<IUserOperationManager>();
            var pagedList = userManager.GetList(new UserPagerInputModel
            {
                //SearchText="sa"
            });
            SetResult("GetListUser", pagedList);
            if (pagedList.IsSuccess)
            {
                foreach (var item in pagedList.Data)
                {
                    Console.WriteLine("Email :" + item.Email);
                }
            }
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
