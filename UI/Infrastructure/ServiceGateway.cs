
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using DAL.Entities;


namespace UI.Infrastructure
{
    public class ServiceGateway
    {
        HttpResponseMessage response;
        HttpClient client;
        public ServiceGateway()
        {
            string baseAddress = WebConfigurationManager.AppSettings["baseAddress"];
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public HttpResponseMessage CreateProduct(PostContent post)
        {
           return response = client.PostAsJsonAsync("api/posts", post).Result;
        }

        public IEnumerable<PostContent> GetAll()
        {
            response = client.GetAsync("api/posts").Result;
            var list = response.Content.ReadAsAsync<IEnumerable<PostContent>>().Result;
            return list;
        }
    }
}