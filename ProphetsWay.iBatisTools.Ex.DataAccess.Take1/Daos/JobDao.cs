using IBatisNet.DataMapper;
using ProphetsWay.Example.DataAccess.Entities;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take1.Daos
{
    internal class JobDao : BaseGetAllDao<Job>, IJobDao
    {
        public JobDao(ISqlMapper mapper) : base(mapper)
        {

        }
    }
}
