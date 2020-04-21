using Expense_Manager.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.EntityService
{
    public interface IEntityService
    {
        object addEntity(EntityAddDto entityAddDto);

        object updateEntity(int entityId, string entityName);

        MySqlDataReader getAllEntities();

        object deleteEntity(string entityId);
    }
}
