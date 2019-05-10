using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using ProphetsWay.iBatisTools.Ex.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take1.Daos
{
    internal class CompanyDao : BasePagedDao<Company>, ICompanyDao
    {
        public CompanyDao(ISqlMapper mapper) : base(mapper) { }

        public Company GetCustomCompanyFunction(int id)
        {
            const string stmtId = "Company.CustomFunction";
            return Mapper.QueryForObject<Company>(stmtId, id);
        }
    }
}
