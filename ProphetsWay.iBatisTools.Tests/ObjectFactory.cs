using ProphetsWay.Example.DataAccess;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take1;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take2;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take3;

namespace ProphetsWay.iBatisTools.Tests
{
    public static class ObjectFactory
    {
        public enum DataAccessTypes
        {
            Take1,
            Take2,
            Take3
        }

        public static IExampleDataAccess GetDataAccess(DataAccessTypes type)
        {
            const string connString = "Initial Catalog=ProphetsWay.Example;Data Source=localhost;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            const string userName = "testUser";
            const string userPass = "testUser1!";

            switch (type)
            {
                case DataAccessTypes.Take1:
                    return new ExDataAccessTake1();

                case DataAccessTypes.Take2:
                    return new ExDataAccessTake2(connString);

                case DataAccessTypes.Take3:
                    return new ExDataAccessTake3(userName, userPass);

                default:
                    return null;
            }

        }
    }
}
