using ProphetsWay.BaseDataAccess;
using ProphetsWay.iBatisTools.Ex.DataAccess.Enums;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Job Job { get; set; }

        public string Whatever { get; set; }

        public Roles RoleStr { get; set; }

        public Roles RoleInt { get; set; }
    }
}
