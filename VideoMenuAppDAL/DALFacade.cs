using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL
{
    using VideoMenuAppDAL.Context;
    using VideoMenuAppDAL.Repositories;
    using VideoMenuAppDAL.UOW;

    public class DALFacade
    {
 

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }

        
    }
}