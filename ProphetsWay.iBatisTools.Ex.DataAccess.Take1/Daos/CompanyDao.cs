using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using ProphetsWay.iBatisTools.Ex.DataAccess.IDaos;
using System.Collections.Generic;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take1.Daos
{
    internal class CompanyDao : BaseDao<Company>, ICompanyDao
    {
        public CompanyDao(ISqlMapper mapper) : base(mapper) { }

        public int GetCount(Company item)
        {
            const string stmtId = "Company.GetCount";
            return Mapper.QueryForObject<int>(stmtId, null);
        }

        public Company GetCustomCompanyFunction(int id)
        {
            const string stmtId = "Company.CustomFunction";
            return Mapper.QueryForObject<Company>(stmtId, id);
        }

        public IList<Company> GetPaged(Company item, int skip, int take)
        {
            const string stmtId = "Company.GetPaged";
            var param = new Dictionary<string, object>();
            param.Add("Offset", skip);
            param.Add("PageSize", take);

            return Mapper.QueryForList<Company>(stmtId, param);
        }
    }
}
