﻿using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAcces : IDataAcces
    {
        private readonly IConfiguration config;

        public DataAcces(IConfiguration _Config)
        {
            config = _Config;



        }
        public SqlConnection DbConnection => new SqlConnection(
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString
            );
        public async Task<IEnumerable<T>> QueryAsync<T>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<dynamic>> QueryAsync(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(String sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> QueryFirstAsync<T>(String sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> ExecuteAsync(String sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    await result.ReadAsync();
                    return new()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
