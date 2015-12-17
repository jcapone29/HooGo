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
    class HooGoinRepository
    {

        public async Task<IEnumerable<UserInfo>>GetUserInfo(string username, string password)
        {
            var sql = " SELECT * FROM tblUserInfo WHERE  WHERE [UserID] = " + username;

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<UserInfo>(sql);
            }
        }

        public async Task<IEnumerable<UserInfo>> CreaeNewUser(string usernmae, string password)
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
