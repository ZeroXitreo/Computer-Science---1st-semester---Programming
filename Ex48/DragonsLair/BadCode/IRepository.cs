using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCode
{
    interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);

        T GetByName(string name);
    }
}
