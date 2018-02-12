using Microsoft.EntityFrameworkCore;
using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace AbpBasic.DB2.EntityFrameworkCore
{
    public static class DB2DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DB2DbContext> builder, string connectionString)
        {
            builder.UseDb2(connectionString, p => p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.None));
        }

        public static void Configure(DbContextOptionsBuilder<DB2DbContext> builder, DbConnection connection)
        {
            builder.UseDb2(connection, p => p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.None));
        }
    }
}
