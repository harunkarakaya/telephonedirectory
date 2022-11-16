using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        protected static object kilit = new object();


        public RepositoryBase()
        {
            CreateContext();
        }

        private void CreateContext()
        {
            if(context == null)
            {
                lock(kilit)
                {
                    if(context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }


    }
}
