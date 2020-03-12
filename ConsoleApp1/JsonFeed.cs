using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class JsonFeed
    {
      
        static readonly string RANDOM_JOKES_URL = "jokes/random";
        static readonly string CATEGORIES_JOKES_URL = "jokes/categories";
        static readonly string CHUCK_NORRIS = "Chuck Norris";
        static readonly string CHUCK_NORRIS_API = "https://api.chucknorris.io";
        static readonly string NAME_API = "http://uinames.com/api/";
        public JsonFeed() { }
  
		public static string[] GetRandomJokes(string firstname, string lastname, string category)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(CHUCK_NORRIS_API);
            string url = RANDOM_JOKES_URL;

            if (category != null)
			{
				if (url.Contains('?'))
					url += "&";
				else url += "?";
				url += "category=";
				url += category;
			}

            string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

            if (firstname != null && lastname != null)
            {
                int index = joke.IndexOf(CHUCK_NORRIS_API);
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + CHUCK_NORRIS.Length, joke.Length - (index + CHUCK_NORRIS.Length));
                joke = firstPart + " " + firstname + " " + lastname + secondPart;
            }
            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }
        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
		public static dynamic Getnames()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(NAME_API);
            return JsonConvert.DeserializeObject<dynamic>(client.GetStringAsync("").Result);
        }
		public static string[] GetCategories()
		{
            HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(CHUCK_NORRIS_API);
			return new string[] { Task.FromResult(client.GetStringAsync(CATEGORIES_JOKES_URL).Result).Result };
		}
    }
}
