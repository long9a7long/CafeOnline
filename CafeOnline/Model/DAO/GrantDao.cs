using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class GrantDao
    {
        private ShopDbContext db = null;

        public GrantDao()
        {
            db = new ShopDbContext();
        }

        private static GrantDao instance;

        public static GrantDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GrantDao();
                }
                return instance;
            }
        }
        public List<Grant> ListAll()
        {
            return db.Grant.ToList();
        }
    }
}
