﻿using RestSharp;
using Task10.RestInfrastructure.ApiClients;
using Task10.RestInfrastructure.DataModels;

namespace Task10.RestInfrastructure.Services
{
    public class UserService
    {
        readonly ApiReadRestClient _apiReadRestClientInstance = ApiReadRestClient.Instance();
        readonly ApiWriteRestClient _apiWriteRestClientInstance = ApiWriteRestClient.Instance();

        public List<UserDto> GetUsers(string sex = "", int olderThan = 0, int yongerThan = 0)
        {
            var request = _apiReadRestClientInstance.CreateRestRequest("http://localhost:49000/users", Method.Get);
            if (sex != string.Empty)
            {
                request.AddQueryParameter("sex", sex);
            }
            if (olderThan != 0)
            {
                request.AddQueryParameter("olderThan", olderThan);
            }
            if (yongerThan != 0)
            {
                request.AddQueryParameter("yongerThan", yongerThan);
            }
            
            var response = _apiReadRestClientInstance.ExecuteRequest<List<UserDto>>(request);

            return response.Data;
        }
    }
}
