using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;


namespace Business.Helper.ApiHelper
{
    public class ApiHelper : IApiHelper
    {
        readonly IRestClient _client;
        private readonly IHttpContextAccessor _accessor;

        public ApiHelper(IRestClient client, IConfiguration config, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _client = client;
            client.BaseUrl = new Uri(config.GetValue<string>("ApiSettings:Host"));
        }

        public ResultDTO<T> GetObjectResponseFromApi<T>(Method _method, string _url, object _body = null, string _token = "", bool _stringify = false) where T : new()
        {
            try
            {
                var request = new RestRequest(_url, _method);

                if (!string.IsNullOrEmpty(_token))
                {
                    request.AddHeader("Authorization", "Bearer " + _token);
                }
                request.OnBeforeDeserialization = resp => { resp.ContentType = ",/json"; };
                request.AddHeader("Accept-Language", "en-us");
                request.AddHeader("Content-Type", "application/json");

                request.UseDefaultCredentials = true;

                request.AddParameter("application\\json", JsonConvert.SerializeObject(_body), ParameterType.RequestBody);

                request.AddJsonBody(_body);
                IRestResponse response = _client.Execute(request);

                if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        _accessor.HttpContext.Response.Redirect("/Security/Logoff");
                    }
                    return new ResultDTO<T>
                    {
                        Success = false,
                        Message = response.ErrorMessage
                    };
                }

                var resultData = default(ResultDTO<T>);

                resultData = JsonConvert.DeserializeObject<ResultDTO<T>>(response.Content, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                if (_stringify)
                {
                    if (typeof(BaseDTO).IsAssignableFrom(typeof(T)))
                    {
                        BaseDTO baseDTO = resultData.Data as BaseDTO;
                    }
                }
                return resultData;

            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
            }
            return default(ResultDTO<T>);
        }
    }
}
