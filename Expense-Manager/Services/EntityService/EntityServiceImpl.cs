using Expense_Manager.DTO;
using Expense_Manager.Repository;
using Expense_Manager.Response;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.EntityService
{
    public class EntityServiceImpl : IEntityService
    {
        DBAccess dBAccess = new DBAccess();
        public object addEntity(EntityAddDto entityAddDto)
        {
            MySqlCommand insertCommand = new MySqlCommand("insert into entity(entityName) values(@entityName)");

            insertCommand.Parameters.AddWithValue("@entityName", entityAddDto.entityName);
            int row = dBAccess.executeQuery(insertCommand);

            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }
        }

        public object deleteEntity(string entityId)
        {
            string sql = "delete from entity where entityId=@entityId";
            MySqlCommand deleteEntity = new MySqlCommand(sql);
            deleteEntity.Parameters.AddWithValue("@entityId", entityId);
            int row = dBAccess.executeQuery(deleteEntity);

            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }
        }

        public MySqlDataReader getAllEntities()
        {
            String query = "select * from entity";
            MySqlDataReader reader = dBAccess.readDatathroughReader(query);
            return reader;

        }

        public object updateEntity(int entityId, string entityName)
        {
            string sql = "update entity set entityName=@entityName where entityId =@entityId ";
            MySqlCommand updateEntity = new MySqlCommand(sql);
            updateEntity.Parameters.AddWithValue("@entityName", entityName);
            updateEntity.Parameters.AddWithValue("@entityId", entityId);

            int row = dBAccess.executeQuery(updateEntity);
            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }

        }
    }
}
