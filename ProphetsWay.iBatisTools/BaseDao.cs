using IBatisNet.DataMapper;
using ProphetsWay.BaseDataAccess;
using System;
using System.Reflection;

namespace ProphetsWay.iBatisTools
{
    public abstract class BaseDao
    {
        protected BaseDao(ISqlMapper mapper)
        {
            Mapper = mapper;
        }

        protected ISqlMapper Mapper { get; }
    }

    public abstract class BaseDao<T> : BaseDao, IBaseDao<T> where T : IBaseEntity
    {
        protected readonly string _typeName;

        protected BaseDao(ISqlMapper mapper) : base(mapper) {
            _typeName = typeof(T).Name;
        }

    #region Statement Ids

        private string _getStmtId;
        private string getStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_getStmtId))
                    _getStmtId = $"{_typeName}.Get{_typeName}ById";

                return _getStmtId;
            }
        }

        private string _insertStmtId;
        private string insertStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_insertStmtId))
                    _insertStmtId = $"{_typeName}.Insert{_typeName}";

                return _insertStmtId;
            }
        }

        private string _updateStmtId;
        private string updateStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_updateStmtId))
                    _updateStmtId = $"{_typeName}.Update{_typeName}";

                return _updateStmtId;
            }
        }

        private string _deleteStmtId;
        private string deleteStmtId
        {
            get
            {
                if (string.IsNullOrEmpty(_deleteStmtId))
                    _deleteStmtId = $"{_typeName}.Delete{_typeName}ById";

                return _deleteStmtId;
            }
        }
    
    #endregion

        public T Get(T item)
        {
            try
            {
                return Mapper.QueryForObject<T>(getStmtId, item);
            }
            catch(Exception ex)
            {
                throw HandleException("Get", item, ex);
            }
        }

        public int Delete(T item)
        {
            try
            {
                return Mapper.Delete(deleteStmtId, item);
            }
            catch (Exception ex)
            {
                throw HandleException("Delete", item, ex);
            }
        }

        public void Insert(T item)
        {
            try
            {
                Mapper.Insert(insertStmtId, item);
            }
            catch (Exception ex)
            {
                throw HandleException("Insert", item, ex);
            }
        }

        public int Update(T item)
        {
            try
            {
                return Mapper.Update(updateStmtId, item);
            }
            catch (Exception ex)
            {
                throw HandleException("Update", item, ex);
            }
        }

    #region Exception Handling 

        protected Exception HandleException(string actionType, object item, Exception ex)
        {
            if (item == null)
                return ex;

            var idProp = GetIdProperty(item);
            if (idProp == null)
                return ex;

            var id = idProp.GetValue(item, null);
            return new Exception(GetExceptionMessage(actionType, item, id), ex);
        }

        private PropertyInfo GetIdProperty(object item)
        {
            return item.GetType().GetProperty(string.Format("{0}Id", item.GetType().Name));
        }

        private string GetExceptionMessage(string actionType, object item, object id)
        {
            return $"Unable to '{actionType}' item of type [{item.GetType().Name}] from the database with the id: {id}";
        }

    #endregion

    }
}