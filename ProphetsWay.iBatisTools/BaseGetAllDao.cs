using IBatisNet.DataMapper;
using ProphetsWay.BaseDataAccess;
using System;
using System.Collections.Generic;

namespace ProphetsWay.iBatisTools
{
    public abstract class BaseGetAllDao<T> : BaseDao<T>, IBaseGetAllDao<T> where T : IBaseEntity
    {
        protected BaseGetAllDao(ISqlMapper mapper) : base(mapper) { }

    #region Statement Ids

        private string _getAllStmtId;
        private string getAllStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_getAllStmtId))
                    _getAllStmtId = $"{_typeName}.GetAll";

                return _getAllStmtId;
            }
        }

    #endregion

        public IList<T> GetAll(T item)
        {
            try
            {
                return Mapper.QueryForList<T>(getAllStmtId, item);
            }
            catch(Exception ex)
            {
                throw HandleException("GetAll", item, ex);
            }
        }
    }
}
