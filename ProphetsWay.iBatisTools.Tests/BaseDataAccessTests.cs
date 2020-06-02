using ProphetsWay.Example.DataAccess;
using ProphetsWay.Example.Tests;

namespace ProphetsWay.iBatisTools.Tests
{
    public class Take1BaseDataAccessTests : BaseDataAccessTests
    {
        protected override IExampleDataAccess GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);
    }

    public class Take2BaseDataAccessTests : BaseDataAccessTests
    {
        protected override IExampleDataAccess GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);
    }

    public class Take3BaseDataAccessTests : BaseDataAccessTests
    {
        protected override IExampleDataAccess GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);
    }
}
