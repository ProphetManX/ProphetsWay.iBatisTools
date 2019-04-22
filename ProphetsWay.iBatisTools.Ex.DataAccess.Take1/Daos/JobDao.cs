using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using ProphetsWay.iBatisTools.Ex.DataAccess.IDaos;
using System.Collections.Generic;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take1.Daos
{
    internal class JobDao : BaseDao<Job>, IJobDao
    {
        public JobDao(ISqlMapper mapper) : base(mapper)
        {

        }

        public IList<Job> GetAll(Job item)
        {
            throw new System.NotImplementedException();
        }
    }
}
