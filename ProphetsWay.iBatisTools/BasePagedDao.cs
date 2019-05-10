using IBatisNet.DataMapper;
using ProphetsWay.BaseDataAccess;
using System;
using System.Collections.Generic;

namespace ProphetsWay.iBatisTools
{
    public abstract class BasePagedDao<T> : BaseDao<T>, IBasePagedDao<T> where T: IBaseEntity
    {
        public BasePagedDao(ISqlMapper mapper) : base(mapper) { }

    #region Statement Ids

        private string _countStmtId;
        private string countStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_countStmtId))
                    _countStmtId = $"{_typeName}.GetCount";

                return _countStmtId;
            }
        }

        private string _pagedStmtId;
        private string pagedStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_pagedStmtId))
                    _pagedStmtId = $"{_typeName}.GetPaged";

                return _pagedStmtId;
            }
        }
    
    #endregion


        public int GetCount(T item)
        {
            try
            {
                return Mapper.QueryForObject<int>(countStmtId, item);
            }
            catch(Exception ex)
            {
                throw HandleException("GetCount", item, ex);
            }
        }

        public IList<T> GetPaged(T item, int skip, int take)
        {
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("Offset", skip);
                param.Add("PageSize", take);
                return Mapper.QueryForList<T>(pagedStmtId, param);
            }
            catch(Exception ex)
            {
                throw HandleException("GetPaged", item, ex);
            }
        }
    }
}
