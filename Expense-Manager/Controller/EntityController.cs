using Expense_Manager.DTO;
using Expense_Manager.Services.EntityService;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Controller
{
    public class EntityController
    {
        private IEntityService entityService;
        public EntityController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        public object addEntity(EntityAddDto entityAddDto)
        {
            object response = entityService.addEntity(entityAddDto);
            return response;

        }

        public MySqlDataReader getAllEntities()
        {
            MySqlDataReader response = entityService.getAllEntities();
            return response;
        }

        public object deleteEntity(string entityId)
        {
            object response = entityService.deleteEntity(entityId);
            return response;

        }

        public object updateEntity(int entityId, string entityName)
        {
            object response = entityService.updateEntity(entityId, entityName);
            return response;

        }
    }

}
