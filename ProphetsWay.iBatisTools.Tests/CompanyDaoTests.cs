using ProphetsWay.Example.Tests;
using ProphetsWay.Example.DataAccess.IDaos;

namespace ProphetsWay.iBatisTools.Tests
{

    public class Take1CompanyDaoTests : CompanyDaoTests
    {
        protected override ICompanyDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);
    }

    public class Take2CompanyDaoTests : CompanyDaoTests
    {
        protected override ICompanyDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);
    }

    public class Take3CompanyDaoTests : CompanyDaoTests
    {
        protected override ICompanyDao GetIExampleDataAccess => ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);
    }
}
