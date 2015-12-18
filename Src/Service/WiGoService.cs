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

namespace Service
{
    public class WiGoService 
    {
        private HooGoinRepository _hooRepo;

        public WiGoService()
        {
            _hooRepo = new HooGoinRepository();
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfo(string username)
        {
            return await _hooRepo.GetUserInfo(username);
        }


    }
}
