using ProphetsWay.iBatisTools.Ex.DataAccess.Entities;
using FluentAssert;
using Xunit;

namespace ProphetsWay.iBatisTools.Tests
{
    [Collection("Uses Logger")]
    public class UserDaoTests
    {
        [Theory]
        [InlineData(ObjectFactory.DataAccessTypes.Take1)]
        [InlineData(ObjectFactory.DataAccessTypes.Take2)]
        [InlineData(ObjectFactory.DataAccessTypes.Take3)]
        public void ExerciseUserCRUD(ObjectFactory.DataAccessTypes type)
        {
            var db = ObjectFactory.GetDataAccess(type);

            var co = ObjectFactory.Get<User>();
            co.RoleInt = Ex.DataAccess.Enums.Roles.Admin;
            co.RoleStr = co.RoleInt;
            co.Id.ShouldBeEqualTo(default);

            //Create/Insert
            db.Insert(co);
            co.Id.ShouldNotBeEqualTo(default);

            //Read/Get
            var co2 = db.Get(co);
            co2.ShouldNotBeNull();
            co2.Id.ShouldBeEqualTo(co.Id);
            co2.Name.ShouldBeEqualTo(co.Name);
            co2.Whatever.ShouldBeEqualTo(co.Whatever);
            co2.RoleInt.ShouldBeEqualTo(co.RoleInt);
            co2.RoleStr.ShouldBeEqualTo(co.RoleStr);

            var newCo = ObjectFactory.Get<User>();
            newCo.Name.ShouldNotBeEqualTo(co.Name);
            newCo.Whatever.ShouldNotBeEqualTo(co.Whatever);
            newCo.RoleInt = Ex.DataAccess.Enums.Roles.Developer;
            newCo.RoleStr = co.RoleInt;

            co.Name = newCo.Name;
            co.Whatever = newCo.Whatever;
            co.RoleInt = newCo.RoleInt;
            co.RoleStr = newCo.RoleStr;


            //Update
            var uCount = db.Update(co);
            uCount.ShouldBeEqualTo(1);

            var co3 = db.Get(co);
            co3.Id.ShouldBeEqualTo(co.Id);
            co3.Name.ShouldBeEqualTo(newCo.Name);
            co3.Whatever.ShouldBeEqualTo(newCo.Whatever);
            co3.RoleInt.ShouldBeEqualTo(newCo.RoleInt);
            co3.RoleStr.ShouldBeEqualTo(newCo.RoleStr);

            //Delete
            var dCount = db.Delete(co);
            dCount.ShouldBeEqualTo(1);

            var co4 = db.Get(co);
            co4.ShouldBeNull();
        }
    }
}
