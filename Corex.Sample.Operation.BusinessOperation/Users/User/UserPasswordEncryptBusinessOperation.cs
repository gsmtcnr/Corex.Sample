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
                userDto.Password = cipherTextEncryption.Encrypt(GetPasswordSignature(), userDto.Password);
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
            IConfigurationRoot configurationRoot = IoCManager.Resolve<IConfigurationRoot>();
            return configurationRoot["PasswordSignature"].ToString();
        }
    }
}
