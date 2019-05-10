using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using FluentAssert;
using Xunit;

namespace ProphetsWay.iBatisTools.Tests
{
    [Collection("Uses Logger")]
    public class CompanyDaoTests
    {
        [Theory]
        [InlineData(ObjectFactory.DataAccessTypes.Take1)]
        [InlineData(ObjectFactory.DataAccessTypes.Take2)]
        [InlineData(ObjectFactory.DataAccessTypes.Take3)]
        public void ExerciseCompanyCRUD(ObjectFactory.DataAccessTypes type)
        {
            var db = ObjectFactory.GetDataAccess(type);

            var co = ObjectFactory.Get<Company>();
            co.Id.ShouldBeEqualTo(default);

            //Create/Insert
            db.Insert(co);
            co.Id.ShouldNotBeEqualTo(default);

            //Read/Get
            var co2 = db.Get(co);
            co2.ShouldNotBeNull();
            co2.Id.ShouldBeEqualTo(co.Id);
            co2.Name.ShouldBeEqualTo(co.Name);
            co2.Other.ShouldBeEqualTo(co.Other);

            var newCo = ObjectFactory.Get<Company>();
            newCo.Name.ShouldNotBeEqualTo(co.Name);
            newCo.Other.ShouldNotBeEqualTo(co.Other);
            co.Name = newCo.Name;
            co.Other = newCo.Other;

            //Update
            var uCount = db.Update(co);
            uCount.ShouldBeEqualTo(1);

            var co3 = db.Get(co);
            co3.Id.ShouldBeEqualTo(co.Id);
            co3.Name.ShouldBeEqualTo(newCo.Name);
            co3.Other.ShouldBeEqualTo(newCo.Other);
            
            //Delete
            var dCount = db.Delete(co);
            dCount.ShouldBeEqualTo(1);

            var co4 = db.Get(co);
            co4.ShouldBeNull();
        }
    }
}
