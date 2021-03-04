using Corex.ExceptionHandling.Derived.Business;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Operation.Derived.BusinessOperation;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Encryptor.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Microsoft.Extensions.Configuration;
using System;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public class UserPasswordEncryptBusinessOperation : BaseBusinessOperation, IUserPasswordEncryptBusinessOperation
    {
        public UserDto Encrypt(UserDto userDto)
        {
            NullCheck(userDto);
            try
            {
                ICorexEncryptor cipherTextEncryption = IoCManager.Resolve<ICorexEncryptor>();
                userDto.Password = cipherTextEncryption.Encrypt(userDto.Email, userDto.Password);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new BusinessOperationException(new BusinesOperationExceptionModel
                {
                    ClassName = "UserPasswordEncryptBusinessOperation",
                    MethodName = "Encrypt",
                    OriginalMessage = ex.Message
                }, ex);
            }
        }
        private string GetPasswordSignature()
        {
            //Standart bir şifre kullanmak istersen bunu da belirtebiliriz.
            //Şifreleme işlemlerinde kullanıcının bir unique bilgisi ile şifrelemek daha doğru olacaktır.
            IConfigurationRoot configurationRoot = IoCManager.Resolve<IConfigurationRoot>();
            return configurationRoot["PasswordSignature"].ToString();
        }
    }
}
