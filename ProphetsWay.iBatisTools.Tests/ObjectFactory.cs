using ProphetsWay.Example.DataAccess;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take1;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take2;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProphetsWay.iBatisTools.Tests
{
    public static class ObjectFactory
    {
        private static readonly Random Rand = new Random();

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

        public static T Get<T>() where T : class, new()
        {
            var rslt = new T();

            var props = rslt.GetType().GetProperties();
            foreach (var prop in props)
            {
                object val = null;

                if (prop.GetSetMethod() == null)
                    continue;

                switch (prop.PropertyType.Name.ToLower())
                {
                    case "string":
                        val = $"{Rand.Next(1000000000, int.MaxValue)}";
                        break;

                    case "int32":
                        val = Rand.Next();
                        break;

                    case "datetime":
                        val = new DateTime(DateTime.Now.Ticks - Rand.Next());
                        break;

                    case "decimal":
                        val = decimal.Round((decimal)Rand.NextDouble(), 2);
                        break;

                    case "boolean":
                        val = Rand.Next() % 2 == 0;
                        break;

                    default:
                        break;
                }

                if (prop.Name == $"{typeof(T).Name}Id" || prop.Name == "Id")
                    val = default(int);

                prop.SetValue(rslt, val);
            }

            return rslt;
        }
    }
}
