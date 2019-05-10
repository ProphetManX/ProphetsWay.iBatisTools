using ProphetsWay.BaseDataAccess;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Entities
{
    public class Job : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Something { get; set; }

    }
}
