﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;
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


        public async Task<IEnumerable<LocationList>> GetPlaces()
        {
            var sql = "SELECT DISTINCT a.businessname, a.descript, e.neighborhood, e.address, e.city, e.state, e.zip, e.LICCATDESC, e.ENDTIME, e.long, e.lat" +
                " FROM [dbo].[tblbostonactive] a INNER JOIN [dbo].[tblbostonentertainment] e ON e.dbaname = a.businessname where e.ENDTIME != 'NULL'";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<LocationList>(sql);
            }
        }

        public async Task<IEnumerable<UserList>> GetUserList()
        {
            var sql = "select distinct username from [dbo].[tblUserInfo]";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<UserList>(sql);
            }
        }


        public bool CreateNewUser(UserInfo info)
        {
            try
            {
                var sql = "insert into [dbo].[tblUserInfo] (Username, PasswordHash, FirstName, LastName, Email, Phone#, Active) " +
                    " values ('" + info.UserName + "','" + info.Password + "','" + info.FirstName + "','" + info.LastName + "','" + info.Email + "','" + info.Phone + "', 1 )";

                

                using (var conn = RepositoryBase.GetConnection())
                {
                    SqlConnection con = new SqlConnection(conn.ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }

            catch (Exception ex)
            {
                return false;
            }

          
        }

        public async Task<IEnumerable<NewEvent>> CreateNewEvent(NewEvent eve)
        {
            var sql = "";

            using (var conn = RepositoryBase.GetConnection())
            {
                return await conn.QueryAsync<NewEvent>(sql);
            }
        }


        public async Task<IEnumerable<FreindGroups>> GetUserGroups(int userid)
        {
            var sql = "select * from [dbo].[tblFriendGroups] where userid = " + userid;

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

        public async Task<List<Business>> YelpBusiness(YelpSearch usersearch) {

            YelpSharp.Options y = new YelpSharp.Options();
            y.AccessToken = "2-8vixRSeanKoNGqI0zCwxuF4jFAxis3";
            y.AccessTokenSecret = "SBY3bD2kuL8ShZzk0ft5rLNRYec";
            y.ConsumerKey = "dZ-2cPotY2h2KBZn0lvjMw";
            y.ConsumerSecret = "7Wtt3EvIDRcyee8jsDSzvPPtOCk";

            Yelp yelp = new YelpSharp.Yelp(y);

            SearchOptions searchOptions = new SearchOptions();

            CoordinateOptions longlat = new CoordinateOptions()
            {
                longitude = usersearch.longitude,
                latitude = usersearch.latitude,
            };

            searchOptions.LocationOptions = new LocationOptions()
            {
                coordinates = longlat,
                location = usersearch.city + " " + usersearch.state
                
            };

            searchOptions.GeneralOptions = new GeneralOptions()
            {
                term = usersearch.searchterm,
           
            };



            SearchResults results = new SearchResults(); 
                
                results = await yelp.Search(searchOptions).ConfigureAwait(false);
            

            return  results.businesses;
          }

    }
}
