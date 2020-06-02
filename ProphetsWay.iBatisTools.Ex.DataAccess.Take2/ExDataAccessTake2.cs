using ProphetsWay.BaseDataAccess;
using ProphetsWay.Example.DataAccess.IDaos;
using ProphetsWay.iBatisTools.Ex.DataAccess.Take2.Daos;
using ProphetsWay.Example.DataAccess.Entities;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using ProphetsWay.Example.DataAccess;

namespace ProphetsWay.iBatisTools.Ex.DataAccess.Take2
{
    public class ExDataAccessTake2 : BaseDataAccess<int>, IExampleDataAccess
    {
        private readonly ISqlMapper _mapper;
        private readonly ICompanyDao _companyDao;
        private readonly IJobDao _jobDao;
        private readonly IUserDao _userDao;

        public ExDataAccessTake2(string connString)
        {
            _mapper = GetType().Assembly.GenerateMapper(connString);
            _companyDao = new CompanyDao(_mapper);
            _jobDao = new JobDao(_mapper);
            _userDao = new UserDao(_mapper);
        }

        public void CustomUserFunctionality(User user)
        {
            _userDao.CustomUserFunctionality(user);
        }

        public int Delete(Company item)
        {
            return _companyDao.Delete(item);
        }

        public int Delete(Job item)
        {
            return _jobDao.Delete(item);
        }

        public int Delete(User item)
        {
            return _userDao.Delete(item);
        }

        public  Company Get(Company item)
        {
            return _companyDao.Get(item);
        }

        public  Job Get(Job item)
        {
            return _jobDao.Get(item);
        }

        public User Get(User item)
        {
            return _userDao.Get(item);
        }

        public IList<Job> GetAll(Job item)
        {
            return _jobDao.GetAll(item);
        }

        public  int GetCount(Company item)
        {
            return _companyDao.GetCount(item);
        }

        public Company GetCustomCompanyFunction(int id)
        {
            return _companyDao.GetCustomCompanyFunction(id);
        }

        public  IList<Company> GetPaged(Company item, int skip, int take)
        {
            return _companyDao.GetPaged(item, skip, take);
        }

        public void Insert(Company item)
        {
            _companyDao.Insert(item);
        }

        public void Insert(Job item)
        {
            _jobDao.Insert(item);
        }

        public void Insert(User item)
        {
            _userDao.Insert(item);
        }

        public override void TransactionCommit()
        {
            _mapper.CommitTransaction();
        }

        public override void TransactionRollBack()
        {
            _mapper.RollBackTransaction();
        }

        public override void TransactionStart()
        {
            _mapper.BeginTransaction();
        }

        public int Update(Company item)
        {
            return _companyDao.Update(item);
        }

        public int Update(Job item)
        {
            return _jobDao.Update(item);
        }

        public int Update(User item)
        {
            return _userDao.Update(item);
        }
    }
}
