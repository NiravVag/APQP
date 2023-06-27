// <copyright file="EFExtensions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class EFExtensions.
    /// </summary>
    public static class EFExtensions
    {
        /// <summary>
        /// Loads the stored proc.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="storedProcName">Name of the stored proc.</param>
        /// <param name="prependDefaultSchema">if set to <c>true</c> [prepend default schema].</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>DbCommand.</returns>
        public static DbCommand LoadStoredProc(this DbContext context, string storedProcName, bool prependDefaultSchema = true, short commandTimeout = 30)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandTimeout = commandTimeout;

            if (prependDefaultSchema)
            {
                var schemaName = context.Model["DefaultSchema"];
                if (schemaName != null)
                {
                    storedProcName = $"{schemaName}.{storedProcName}";
                }
            }

            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        /// <summary>
        /// Creates a DbParameter object and adds it to a DbCommand.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="configureParam">The configure parameter.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="InvalidOperationException">Call LoadStoredProc before using this method.</exception>
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
            {
                throw new InvalidOperationException("Call LoadStoredProc before using this method");
            }

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue ?? DBNull.Value;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }

        /// <summary>
        /// Creates a DbParameter object and adds it to a DbCommand.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="configureParam">The configure parameter.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="InvalidOperationException">Call LoadStoredProc before using this method.</exception>
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != CommandType.StoredProcedure)
            {
                throw new InvalidOperationException("Call LoadStoredProc before using this method");
            }

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }

        /// <summary>
        /// Adds a SqlParameter to a DbCommand.
        /// This enabled the ability to provide custom types for SQL-parameters.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="InvalidOperationException">Call LoadStoredProc before using this method.</exception>
        public static DbCommand WithSqlParam(this DbCommand cmd, IDbDataParameter parameter)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
            {
                throw new InvalidOperationException("Call LoadStoredProc before using this method");
            }

            cmd.Parameters.Add(parameter);

            return cmd;
        }

        /// <summary>
        /// Adds an array of SqlParameters to a DbCommand.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="InvalidOperationException">Call LoadStoredProc before using this method.</exception>
        public static DbCommand WithSqlParams(this DbCommand cmd, IDbDataParameter[] parameters)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
            {
                throw new InvalidOperationException("Call LoadStoredProc before using this method");
            }

            cmd.Parameters.AddRange(parameters);

            return cmd;
        }

        /// <summary>
        /// Class SprocResults.
        /// </summary>
        public class SprocResults
        {
            /// <summary>
            /// The reader.
            /// </summary>
            private readonly DbDataReader reader;

            /// <summary>
            /// Initializes a new instance of the <see cref="SprocResults"/> class.
            /// </summary>
            /// <param name="reader">The reader.</param>
            public SprocResults(DbDataReader reader)
            {
                this.reader = reader;
            }

            /// <summary>
            /// Reads to list.
            /// </summary>
            /// <typeparam name="T">type.</typeparam>
            /// <returns>
            /// IList.
            /// </returns>
            public IList<T> ReadToList<T>()
                where T : new()
            {
                return MapToList<T>(this.reader);
            }

            /// <summary>
            /// Reads to value.
            /// </summary>
            /// <typeparam name="T">type.</typeparam>
            /// <returns>type.</returns>
            public T? ReadToValue<T>()
                where T : struct
            {
                return MapToValue<T>(this.reader);
            }

            /// <summary>
            /// Nexts the result asynchronous.
            /// </summary>
            /// <returns>bool.</returns>
            public Task<bool> NextResultAsync()
            {
                return this.reader.NextResultAsync();
            }

            /// <summary>
            /// Nexts the result asynchronous.
            /// </summary>
            /// <param name="ct">The ct.</param>
            /// <returns>bool.</returns>
            public Task<bool> NextResultAsync(CancellationToken ct)
            {
                return this.reader.NextResultAsync(ct);
            }

            /// <summary>
            /// Nexts the result.
            /// </summary>
            /// <returns>bool.</returns>
            public bool NextResult()
            {
                return this.reader.NextResult();
            }

            /// <summary>
            /// Retrieves the column values from the stored procedure and maps them to <typeparamref name="T"/>'s properties.
            /// </summary>
            /// <typeparam name="T">type.</typeparam>
            /// <param name="dr">DbDataReader.</param>
            /// <returns>IList&lt;.<typeparam name="T">&gt;</typeparam></returns>
            private static IList<T> MapToList<T>(DbDataReader dr)
                where T : new()
            {
                var objList = new List<T>();
                var props = typeof(T).GetRuntimeProperties().ToList();

                var colMapping = dr.GetColumnSchema()
                    .Where(x => props.Any(y =>
                        string.Equals(y.Name, x.ColumnName, StringComparison.CurrentCultureIgnoreCase)))
                    .ToDictionary(key => key.ColumnName.ToUpper());

                if (!dr.HasRows)
                {
                    return objList;
                }

                while (dr.Read())
                {
                    var obj = new T();
                    foreach (var prop in props)
                    {
                        var upperName = prop.Name.ToUpper();

                        if (!colMapping.ContainsKey(upperName))
                        {
                            continue;
                        }

                        var column = colMapping[upperName];

                        if (column?.ColumnOrdinal == null)
                        {
                            continue;
                        }

                        var val = dr.GetValue(column.ColumnOrdinal.Value);
                        var realType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        if (realType.IsEnum && val != DBNull.Value)
                        {
                            var convertedValue = realType.IsEnum && val != null ? Enum.ToObject(realType, val) : val;
                            prop.SetValue(obj, convertedValue, null);
                        }
                        else
                        {
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                    }

                    objList.Add(obj);
                }

                return objList;
            }

            /// <summary>
            /// Attempts to read the first value of the first row of the result set.
            /// </summary>
            /// <typeparam name="T">type.</typeparam>
            /// <param name="dr">The dr.</param>
            /// <returns>type.</returns>
            private static T? MapToValue<T>(DbDataReader dr)
                where T : struct
            {
                if (!dr.HasRows)
                {
                    return new T?();
                }

                if (dr.Read())
                {
                    return dr.IsDBNull(0) ? new T?() : dr.GetFieldValue<T>(0);
                }

                return new T?();
            }
        }

        /// <summary>
        /// Executes a DbDataReader and passes the results to <paramref name="handleResults" />.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="handleResults">SprocResults.</param>
        /// <param name="commandBehaviour">CommandBehavior.</param>
        /// <param name="manageConnection">bool.</param>
        /// <exception cref="ArgumentNullException">handleResults.</exception>
        public static void ExecuteStoredProc(this DbCommand command, Action<SprocResults> handleResults, CommandBehavior commandBehaviour = CommandBehavior.Default, bool manageConnection = true)
        {
            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (manageConnection && command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                try
                {
                    using (var reader = command.ExecuteReader(commandBehaviour))
                    {
                        var sprocResults = new SprocResults(reader);
                        handleResults(sprocResults);
                    }
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Executes a DbDataReader asynchronously and passes the results to <paramref name="handleResults" />.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="handleResults">The handle results.</param>
        /// <param name="commandBehaviour">The command behaviour.</param>
        /// <param name="ct">The ct.</param>
        /// <param name="manageConnection">if set to <c>true</c> [manage connection].</param>
        /// <exception cref="ArgumentNullException">handleResults.</exception>
        /// <returns>Task. representing the asynchronous operation.</placeholder></returns>
        public static async Task ExecuteStoredProcAsync(this DbCommand command, Action<SprocResults> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default, CancellationToken ct = default, bool manageConnection = true)
        {
            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (manageConnection && command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    await command.Connection.OpenAsync(ct).ConfigureAwait(false);
                }

                try
                {
                    using (var reader = await command.ExecuteReaderAsync(commandBehaviour, ct)
                        .ConfigureAwait(false))
                    {
                        var sprocResults = new SprocResults(reader);
                        handleResults(sprocResults);
                    }
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Executes a DbDataReader asynchronously and passes the results thru all <paramref name="resultActions" />.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="commandBehaviour">The command behaviour.</param>
        /// <param name="ct">The ct.</param>
        /// <param name="manageConnection">if set to <c>true</c> [manage connection].</param>
        /// <param name="resultActions">The result actions.</param>
        /// <exception cref="ArgumentNullException">resultActions.</exception>
        /// <returns>Task representing the asynchronous operation.</returns>
        public static async Task ExecuteStoredProcAsync(this DbCommand command, CommandBehavior commandBehaviour = CommandBehavior.Default, CancellationToken ct = default, bool manageConnection = true, params Action<SprocResults>[] resultActions)
        {
            if (resultActions == null)
            {
                throw new ArgumentNullException(nameof(resultActions));
            }

            using (command)
            {
                if (manageConnection && command.Connection.State == ConnectionState.Closed)
                {
                    await command.Connection.OpenAsync(ct).ConfigureAwait(false);
                }

                try
                {
                    using (var reader = await command.ExecuteReaderAsync(commandBehaviour, ct)
                        .ConfigureAwait(false))
                    {
                        var sprocResults = new SprocResults(reader);

                        foreach (var t in resultActions)
                        {
                            t(sprocResults);
                        }
                    }
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Executes a non-query.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="manageConnection">if set to <c>true</c> [manage connection].</param>
        /// <returns>int.</returns>
        public static int ExecuteStoredNonQuery(this DbCommand command, bool manageConnection = true)
        {
            var numberOfRecordsAffected = -1;

            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                try
                {
                    numberOfRecordsAffected = command.ExecuteNonQuery();
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }

            return numberOfRecordsAffected;
        }

        /// <summary>
        /// Executes a non-query asynchronously.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="ct">The ct.</param>
        /// <param name="manageConnection">if set to <c>true</c> [manage connection].</param>
        /// <returns>int.</returns>
        public static async Task<int> ExecuteStoredNonQueryAsync(this DbCommand command, CancellationToken ct = default,            bool manageConnection = true)
        {
            var numberOfRecordsAffected = -1;

            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    await command.Connection.OpenAsync(ct).ConfigureAwait(false);
                }

                try
                {
                    numberOfRecordsAffected = await command.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }

            return numberOfRecordsAffected;
        }
    }
}
