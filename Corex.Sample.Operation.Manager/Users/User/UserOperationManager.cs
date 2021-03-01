using Corex.Operation.Infrastructure;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;
using Corex.Sample.Operation.DataOperation.Users.User;
using Corex.Sample.Operation.ValidationOperation.Users.User;

namespace Corex.Sample.Operation.Manager.Users.User
{
    public class UserOperationManager : CorexIntOperationManager<UserEntity, UserDto>, IUserOperationManager
    {
        public override IDataOperation<UserEntity, int> SetDataOperation()
        {
            return IoCManager.Resolve<IUserDataOperation>();
        }
        public override IValidationOperation<UserDto> SetInsertValidationOperation(UserDto dto)
        {
            var validationOperation = IoCManager.Resolve<IUserDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
        public override IValidationOperation<UserDto> SetUpdateValidation(UserDto dto)
        {
            var validationOperation = IoCManager.Resolve<IUserDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
    }
}
