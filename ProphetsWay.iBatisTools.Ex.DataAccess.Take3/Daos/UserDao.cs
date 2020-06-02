using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools;
using ProphetsWay.Example.DataAccess.Entities;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take3.Daos
{
    internal class UserDao : BaseDao<User>, IUserDao
    {
        public UserDao(ISqlMapper mapper) : base(mapper)
        {

        }

        public void CustomUserFunctionality(User user)
        {
            user.Whatever = "custom functionality triggered";
            Update(user);
        }
    }
}
