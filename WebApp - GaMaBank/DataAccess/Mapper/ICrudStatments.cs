using DataAccess.Dao;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ICrudStatments
    {

        SqlOperation GetCreateStatements(BaseEntity entityPojo);

        SqlOperation GetUpdateStatements(BaseEntity entityPojo);

        SqlOperation DeleteStatements(BaseEntity entityPojo);

        SqlOperation GetRetrieveByIdStatements(string Id);

        SqlOperation GetRetriveAllStatement();


    }
}
