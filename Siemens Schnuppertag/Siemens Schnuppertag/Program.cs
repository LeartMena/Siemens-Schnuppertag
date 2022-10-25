using System.Linq.Expressions;
using static System.Net.WebRequestMethods;

var _client = new HttpClient();

Console.WriteLine("What do you want to translate?");
var text = Console.ReadLine();
Console.WriteLine("In witch languege?");
var language = Console.ReadLine();

Console.WriteLine("To be translate: " + text + "\nlanguage " + language);

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

Console.WriteLine(content.Result);

