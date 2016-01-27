using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Service.HooGoin;
using Service.Repositories;
using YelpSharp.Data;

namespace Service
{
    public class WiGoService 
    {
        private HooGoinRepository _hooRepo;

        public WiGoService()
        {
            _hooRepo = new HooGoinRepository();
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfo(UserInfo info)
        {
            return await _hooRepo.GetUserInfo(info);
        }

        public async Task<IEnumerable<LocationList>>GetPlaces()
        {
            return await _hooRepo.GetPlaces();
        }
        public async Task<IEnumerable<UserList>> GetUserList()
        {
            return await _hooRepo.GetUserList();
        }

        public async Task<IEnumerable<NewEvent>> CreateNewEvent(NewEvent eve)
        {
            return await _hooRepo.CreateNewEvent(eve);
        }

        public async Task<IEnumerable<FreindGroups>> GetUserGroups(int userid)
        {
            return await _hooRepo.GetUserGroups(userid);
        }

        public bool CreaeNewUser(UserInfo info)
        {
            bool success = _hooRepo.CreateNewUser(info);

            return success;
        }

        public async Task<List<Business>> YelpBusiness(YelpSearch usersearch)
        {

            return await _hooRepo.YelpBusiness(usersearch);
        }
    }
}
