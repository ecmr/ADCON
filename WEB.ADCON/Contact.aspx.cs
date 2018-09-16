using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

using ConversorLibrary;

namespace WEB.ADCON
{
    public partial class Contact : Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadPlaca_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);

                            FileUploadControl.SaveAs(Server.MapPath("~/Placas/") + filename);

                            Process process = new Process();

                            Task<string> recognizeTask = Task.Run(() => process.GetPlate(Server.MapPath("~/Placas/") + filename));
                            recognizeTask.Wait();
                            string task_result = recognizeTask.Result;

                            System.Console.WriteLine(task_result);



                            StatusLabel.Text = "Upload status: File uploaded!";
                            Image1.ImageUrl = "~/Placas/" + filename;

                            Task<string> resultado = ProcessImage(Server.MapPath("~/Placas/") + filename);

                            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                            dynamic resultado2 = serializer.DeserializeObject(resultado.Result);

                            StringBuilder sb = new StringBuilder();

                            int _count = 0;

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
                                        this.txtPlaca.Text = valuef.ToString().Substring(0, 3) + "-" + valuef.ToString().Substring(3, 4);
                                    }
                                }
                                _count++;
                            }
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        public static async Task<string> ProcessImage(string image_path)
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


    }
}