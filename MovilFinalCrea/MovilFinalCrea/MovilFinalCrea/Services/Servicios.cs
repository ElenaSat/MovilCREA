using MovilFinalCrea.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovilFinalCrea.Services
{
    public class Servicios
    {
        public int  Registro(clsUsers users)
        {
            try
            {
                RestClient _Cliente = new RestClient("http://192.168.1.2/ApiCrea/api/User");
                RestRequest _Request = new RestRequest("/RegistreUsers", Method.POST) { RequestFormat = DataFormat.Json };
                //_Request.AddHeader("Content-type", "application/json");
                _Request.AddObject(users);
               // _Request.AddJsonBody(new { users });
               var _response = _Cliente.Execute(_Request);
                int contenido = JsonConvert.DeserializeObject<int>(_response.Content);
                return contenido;
            }
            catch (Exception e) { return 0; }
        }
    }
}
