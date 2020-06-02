using IBatisNet.DataMapper;
using ProphetsWay.Example.DataAccess.Entities;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take1.Daos
{
    internal class UserDao : BaseDao<User>, IUserDao
    {
        public UserDao(ISqlMapper mapper) : base(mapper)
        {

        }

        public void CustomUserFunctionality(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
