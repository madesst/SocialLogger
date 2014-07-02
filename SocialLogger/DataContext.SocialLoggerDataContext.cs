//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 02.07.2014 20:57:11
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace SocialLogger
{

    [DatabaseAttribute(Name = "main")]
    [ProviderAttribute(typeof(Devart.Data.SQLite.Linq.Provider.SQLiteDataProvider))]
    public partial class SocialLoggerDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(SocialLoggerDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertLogEntry(LogEntry instance);
        partial void UpdateLogEntry(LogEntry instance);
        partial void DeleteLogEntry(LogEntry instance);

        #endregion

        public SocialLoggerDataContext() :
        base(GetConnectionString("DataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public SocialLoggerDataContext(MappingSource mappingSource) :
        base(GetConnectionString("DataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        public SocialLoggerDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SocialLoggerDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SocialLoggerDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SocialLoggerDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<LogEntry> LogEntries
        {
            get
            {
                return this.GetTable<LogEntry>();
            }
        }
    }
}