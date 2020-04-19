using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.SQL
{
    public class SQLResult
    {
        public string SQL { get; set; }
        public DynamicParameters Param { get; set; } 
    }
}
