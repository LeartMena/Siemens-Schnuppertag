using System.Linq.Expressions;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

var _client = new HttpClient();

Console.WriteLine("What do you want to translate?");
var text = Console.ReadLine();
Console.WriteLine("In which language?");
var language = Console.ReadLine();

Console.WriteLine("To be translate: " + text + "\nlanguage " + language + "\n");

var key = System.Environment.GetEnvironmentVariable("keydeeplapi"); 
var url = "https://api-free.deepl.com/v2/translate";
var value = new Dictionary<string, string>
{
    {"target_lang",language},
    {"text", text},
};

_client.DefaultRequestHeaders.Add("Authorization", key);

var valueJson = new FormUrlEncodedContent(value);



var response = await _client.PostAsync(url, valueJson);

var content = response.Content.ReadAsStringAsync();

var contentSerialized = JsonConvert.DeserializeObject<DeeplResponse>(content.Result);

Console.WriteLine(contentSerialized.translations[0].text);

Console.WriteLine(contentSerialized.translations[0].detected_source_language);


public class DeeplResponse
{
    public List<DeeplTranslation> translations { get; set; }
}

public class DeeplTranslation
{
    public string detected_source_language { get; set; }
    public string text { get; set; }
}
