﻿using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, DataContext>, IMessageDal
    {
    }
}
