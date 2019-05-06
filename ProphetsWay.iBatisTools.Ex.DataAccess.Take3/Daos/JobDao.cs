using IBatisNet.DataMapper;
using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using ProphetsWay.iBatisTools.Ex.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take3.Daos
{
    internal class JobDao : BaseGetAllDao<Job>, IJobDao
    {
        public JobDao(ISqlMapper mapper) : base(mapper)
        {

        }
    }
}
