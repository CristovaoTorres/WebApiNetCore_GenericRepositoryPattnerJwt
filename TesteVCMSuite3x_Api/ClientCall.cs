using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TesteVCMSuite3x_Api
{
    public class ClientCall
    {
        private readonly string _baseAddress = "http://localhost:63373/";

        public async System.Threading.Tasks.Task<HttpResponseMessage> Detail(string method)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.GetAsync(method);
            }

        }

        public async System.Threading.Tasks.Task<HttpResponseMessage> Save(string method, string obj)
        {

            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(_baseAddress) };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, method)
                {
                    Content = new StringContent(obj, Encoding.UTF8, "application/json")
                };

                return await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task<HttpResponseMessage> Delete(string method)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.DeleteAsync(method);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

    }
}
