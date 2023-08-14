using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using HNTest.Models;
using HNTest.ViewModels;
using Newtonsoft.Json;

namespace HNTest.DataSource
{
    public class DataSourceService : IDataSourceService
    {
        List<double> IDataSourceService.GetBestStories()
        {
            List<double> result;
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("https://hacker-news.firebaseio.com/v0/beststories.json");
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    result = JsonConvert.DeserializeObject<List<double>>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }

                throw;
            }

            return result;

        }


        async Task<HNItem> IDataSourceService.GetHNById(string id)
        { 
            HNItem result = (HNItem) GET($"https://hacker-news.firebaseio.com/v0/item/{id}.json");

            return result;
        }


        // Returns JSON string
        HNItem GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    return JsonConvert.DeserializeObject<HNItem>(reader.ReadToEnd()); ;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }


    }
}