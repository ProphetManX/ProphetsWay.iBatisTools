using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using ProphetsWay.iBatisTools.Ex.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take2.Daos
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
