﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace HabiticaSimpleToDo
{
    class HabiticaHttpClient : HttpClient
    {
        private static HabiticaHttpClient instance;

        public static HabiticaHttpClient getInstance()
        {
            if(instance == null)
            {
                instance = new HabiticaHttpClient();
            }

            return instance;
        }

        HabiticaHttpClient()
        {
            BaseAddress = new Uri("https://habitica.com/api/v3/");
            DefaultRequestHeaders.Add("x-api-user", Properties.settings.Default.userID);
            DefaultRequestHeaders.Add("x-api-key", Properties.settings.Default.apiToken);
        }

        public async void createNewTodo(String Title, String Description)
        {
            Uri url = new Uri("tasks/user");

            //TODO: Stringbuilder ersetzen wenn json eingebunden ist
            StringBuilder jsonText = new StringBuilder();
            jsonText.Append("{");
            jsonText.Append("\"text\": \"");
            jsonText.Append(Title);
            jsonText.Append("\",");
            jsonText.Append("\"type\": ");
            jsonText.Append("\"todo\"");
            jsonText.Append("}");
            StringContent requestContent = new StringContent(jsonText.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await PostAsync(url,requestContent);

            Stream stream = await response.Content.ReadAsStreamAsync();

            //TODO: parse Json and return result instead of writing to console
            Console.WriteLine(new StreamReader(stream).ReadToEnd());
        }

        public async void getTodos()
        {
            string url = "tasks/user?type=todos";
            
            HttpResponseMessage response = await GetAsync(url);

            Stream stream = await response.Content.ReadAsStreamAsync();

            //TODO: parse Json and return list instead of writing to console
            Console.WriteLine(new StreamReader(stream).ReadToEnd());
        }
    }
}