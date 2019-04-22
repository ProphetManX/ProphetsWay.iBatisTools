using ProphetsWay.BaseDataAccess;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Job Job { get; set; }

        public string Whatever { get; set; }
    }
}
