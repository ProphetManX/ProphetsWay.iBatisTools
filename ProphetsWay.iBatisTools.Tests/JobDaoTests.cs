using ProphetsWay.Example.Tests;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Tests
{
    public class Take1JobDaoTests : JobDaoTests
    {
        protected override IJobDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);
    }

    public class Take2JobDaoTests : JobDaoTests
    {
        protected override IJobDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);
    }

    public class Take3JobDaoTests : JobDaoTests
    {
        protected override IJobDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);
    }
}
