using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.SQL
{
    internal class EntitySQL
    {
        public static EntitySQL NewSQL(EntityBase entity) {
            return new EntitySQL(entity);
        }
        EntityBase entity;

        public EntitySQL(EntityBase entity)
        {
            this.entity = entity;
        }
        public SQLResult ToSqlSelectt()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
        public SQLResult ToSqlInsert()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
        public SQLResult ToSqlUpdate()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
        public SQLResult ToSqlDelete()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
        public SQLResult ToSqlSave()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
    }
}
