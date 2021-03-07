using Corex.Model.Infrastructure;
using Corex.Sample.Data.Infrastructure.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using System.Linq;

namespace Corex.Sample.Data.Derived.EFSQL.Users.User
{
    public class UserRepository : CorexBaseEntityIntRepository<UserEntity>, IUserRepository
    {
        protected override IQueryable<UserEntity> ListExpression(IQueryable<UserEntity> query, IPagerInputModel input)
        {
            UserPagerInputModel pagerInputModel = (UserPagerInputModel)input;
            query = SetSearchTextQuery(query, pagerInputModel);
            return query;
        }

        private static IQueryable<UserEntity> SetSearchTextQuery(IQueryable<UserEntity> query, UserPagerInputModel pagerInputModel)
        {
            if (!string.IsNullOrEmpty(pagerInputModel.SearchText))
                query = query.Where(s => s.Name.Contains(pagerInputModel.SearchText) || s.Surname.Contains(pagerInputModel.SearchText));
            return query;
        }
    }
}
