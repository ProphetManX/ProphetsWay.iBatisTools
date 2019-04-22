using ProphetsWay.BaseDataAccess;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.IDaos
{
    public interface ICompanyDao : IBasePagedDao<Company>
    {
        Company GetCustomCompanyFunction(int id);
    }
}
