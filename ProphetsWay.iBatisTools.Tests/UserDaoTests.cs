using ProphetsWay.Example.Tests;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Tests
{
    public class Take1UserDaoTests : UserDaoTests
    {
        protected override IUserDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);
    }

    public class Take2UserDaoTests : UserDaoTests
    {
        protected override IUserDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);
    }

    public class Take3UserDaoTests : UserDaoTests
    {
        protected override IUserDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);
    }
}
