using NetSevenCommerece.DataAccess.Data;
using NetSevenCommerece.DataAccess.Repository.IRepository;
using NetSevenCommerece.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSevenCommerece.DataAccess.Repository
{
    public class TestCategoryRepository : Repository<TestCategory>, ITestCategoryRespository
    {
        protected readonly ApplicationDBContext _dbContext;
        public TestCategoryRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }
    }
}
