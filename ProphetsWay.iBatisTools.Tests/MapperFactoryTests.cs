using Xunit;
using FluentAssert;
using ProphetsWay.Example.DataAccess;

namespace ProphetsWay.iBatisTools.Tests
{
    public class MapperFactoryTests
    {
        [Fact]
        public void GenerateMapperOnAssemblyTest()
        {
            IExampleDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);

            db.ShouldNotBeNull();
        }

        [Fact]
        public void GenerateMapperWithConnectionString()
        {
            IExampleDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);

            db.ShouldNotBeNull();
        }

        [Fact]
        public void GenerateMapperWithValues()
        {
            IExampleDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);

            db.ShouldNotBeNull();
        }
    }
}
