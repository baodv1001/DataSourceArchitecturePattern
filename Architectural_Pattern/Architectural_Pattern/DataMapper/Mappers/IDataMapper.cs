using Architectural_Pattern.DataMapper.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.DataMapper.Mappers
{
    interface IDataMapper<T>
    {
        void Update(T entity);
        void Insert(T entity);
        T FindByGuId(Guid uniqueID);
        List<T> FindAll();
    }
}
