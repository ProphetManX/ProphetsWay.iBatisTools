using ProphetsWay.BaseDataAccess;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.IDaos
{
    public interface IUserDao : IBaseDao<User>
    {
        void CustomUserFunctionality(User user);
    }
}
