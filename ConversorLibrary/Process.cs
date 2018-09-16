using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Web.Script.Serialization;

namespace ConversorLibrary
{
    public class Process
    {
        private static readonly HttpClient client = new HttpClient();

        private static async Task<string> ProcessImage(string image_path)
        {
            // Meus dados
            //Publishable Key: pk_da54560a9a1a84e34dae5f8a
            //     Secret Key: sk_7f56dbc6840f93eb20bad30d


            string SECRET_KEY = "sk_7f56dbc6840f93eb20bad30d"; //"sk_DEMODEMODEMODEMODEMODEMO";

            Byte[] bytes = File.ReadAllBytes(image_path);
            string imagebase64 = Convert.ToBase64String(bytes);

            var content = new StringContent(imagebase64);

            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=us&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);


            var byteArray = buffer.ToArray();



            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return responseString;
        }


        public string GetPlate(string image_path)
        {

            Task<string> recognizeTask = Task.Run(() => ProcessImage(image_path));
            recognizeTask.Wait();
            string task_result = recognizeTask.Result;

            System.Console.WriteLine(task_result);

            Task<string> resultado = ProcessImage(image_path);

            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            dynamic resultado2 = serializer.DeserializeObject(resultado.Result);

            StringBuilder sb = new StringBuilder();

            int _count = 0;

            string plate = string.Empty;

            foreach (KeyValuePair<string, object> entry in resultado2)
            {
                if (_count == 6)
                {
                    dynamic resultadoDados = entry.Value;
                    foreach (Dictionary<string, object> entryb in resultadoDados)
                    {
                        var keyf = entryb.Keys.FirstOrDefault();
                        var valuef = entryb.Values.FirstOrDefault();

                        sb.Append(String.Format("{0} : {1}", keyf, valuef) + Environment.NewLine);
                        plate = valuef.ToString().Substring(0, 3) + "-" + valuef.ToString().Substring(3, 4);
                    }
                }
                _count++;
            }

            return plate;

        }


    }
}
