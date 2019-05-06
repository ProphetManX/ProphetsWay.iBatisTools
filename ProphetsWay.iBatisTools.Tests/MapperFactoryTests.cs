using ProphetsWay.iBatisTools.Ex.DataAccess;
using Xunit;
using FluentAssert;

namespace ProphetsWay.iBatisTools.Tests
{
    [Collection("Uses Logger")]
    public class MapperFactoryTests
    {
        public MapperFactoryTests()
        {
            //Logger.AddDestination(new ConsoleDestination());
        }


        [Fact]
        public void GenerateMapperOnAssemblyTest()
        {
            IExDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take1);

            db.ShouldNotBeNull();
        }

        [Fact]
        public void GenerateMapperWithConnectionString()
        {
            IExDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take2);

            db.ShouldNotBeNull();
        }

        [Fact]
        public void GenerateMapperWithValues()
        {
            IExDataAccess db;
            db = ObjectFactory.GetDataAccess(ObjectFactory.DataAccessTypes.Take3);

            db.ShouldNotBeNull();
        }
    }
}
