using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechFileUpdater.Models;

namespace SpeechFileUpdater.Utils
{
    public class ChatGptTalker
    {
        private static readonly string chatGptUri = @"https://api.openai.com/v1/completions";
        private static JObject jsonTemplate = new JObject()
        {
            ["model"] = "text-davinci-003",
            ["prompt"] = "",
            ["max_tokens"] = 100,
            ["temperature"] = 0.5F,
            ["n"] = 1,
            ["stream"] = false,
            ["logprobs"] = null,
            ["stop"] = @"\n"
        };

        public static async Task<string> GetChatGptResponseForPrompt(string apiKey, string prompt, float randomness)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(chatGptUri);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["Authorization"] = $"Bearer {apiKey}";
            httpWebRequest.Timeout = 1000 * 10; // 10 seconds

            JObject jsonBodyWithKey = (JObject)jsonTemplate.DeepClone();
            jsonBodyWithKey["prompt"] = prompt;
            jsonBodyWithKey["temperature"] = randomness;
            string jsonString = jsonBodyWithKey.ToString();

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }

            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)await Task.Run(() => httpWebRequest.GetResponseAsync());

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    ChatGptResponseModel chatGptResponse = JsonConvert.DeserializeObject<ChatGptResponseModel>(result);
                    string chatGptActualResponse = chatGptResponse.Choices[0].Text;
                    return chatGptActualResponse.TrimStart().TrimEnd().Trim('"');
                }
            }
            catch (WebException wex)
            {
                if (wex == null || wex.Response == null)
                {
                    return null;
                }

                using (StreamReader streamReader = new StreamReader(wex.Response.GetResponseStream()))
                {
                    string errResponse = streamReader.ReadToEnd();
                    ChatGptResponseModel errMessage = JsonConvert.DeserializeObject<ChatGptResponseModel>(errResponse);
                    MessageBox.Show(null, errMessage.Error.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (ex == null || ex.Message == null)
                {
                    return null;
                }

                MessageBox.Show(null, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return null;
        }
    }
}
