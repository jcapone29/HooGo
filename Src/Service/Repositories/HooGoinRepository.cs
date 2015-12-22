using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Service.HooGoin;

namespace Service.Repositories
{
   public class HooGoinRepository
    {

        public async Task<IEnumerable<UserInfo>> GetUserInfo(UserInfo info)
        {
            var sql = "SELECT * FROM tblUserInfo  WHERE [Username] = '" + info.UserName + "' and [PasswordHash] = '" + info.Password + "'";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<UserInfo>(sql);
            }
        }

        //public bool GetUserInfo(UserInfo info)
        //{
        //    var sql = "select case when [Username] = '" + info.UserName + "' and [PasswordHash] = '" + info.Password + "'" + "then 'True' else 'False' end from [dbo].[tblUserInfo]";
        //    bool login;

        //    using (var conn = RepositoryBase.GetConnection())
        //    {
        //        SqlCommand cmd = new SqlCommand(sql);

        //        login = ((bool?)cmd.ExecuteScalar()).GetValueOrDefault();


        //    }

        //    return login;
        //}

        public async Task<IEnumerable<UserInfo>> CreaeNewUser(string usernmae)
        {
            var sql = "";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<UserInfo>(sql);
            }
        }

        public async Task<IEnumerable<FreindGroups>> GetUserGroups(int userid)
        {
            var sql = "";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<FreindGroups>(sql);
            }
        }

        public async Task<IEnumerable<EventList>> GetEventList(int userid)
        {
            var sql = "SELECT TOP 10 FROM [dbo].[tblWeGoinOut] WHERE [UserID] = " + userid ;

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<EventList>(sql);
            }
        }

    }
}
