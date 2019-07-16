using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class WeatherAPI : MonoBehaviour
{
    public string url = "http://api.openweathermap.org/data/2.5/weather?q=Vancouver&APPID=8c04c7b03919fa07c29c450c382db950";
    public string url2 = "http://api.openweathermap.org/data/2.5/weather?q=London&APPID=8c04c7b03919fa07c29c450c382db950";
    public string url3 = "http://api.openweathermap.org/data/2.5/weather?q=MexicoCity&APPID=8c04c7b03919fa07c29c450c382db950";

    public string city;
    public string weatherDescription;
    public float temp;
    public float temp_min;
    public float temp_max;
    public float rain;
    public float wind;
    public float clouds;
    private string response;
    public Text CityDisplay;
    public Text TempDisplay;
    public Text DescriptionDisplay;
    public Text minTemp;
    public Text maxTemp;
    private float KelvinToCelsius = 273.15f;


    // Use this for initialization
    IEnumerator Start()
    {
        
        WWW request = new WWW(url);
        yield return request;
        if (request.error == null || request.error == "")
        {
            
            //Debug.Log("Response: " + request.text);
            response = request.text;
         
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }

        setWeatherAttributes(response);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void setWeatherAttributes(string jsonString)
    {
        var weatherJson = JSON.Parse(jsonString);
        city = weatherJson["name"].Value;
        weatherDescription = weatherJson["weather"][0]["description"].Value;
        temp = weatherJson["main"]["temp"].AsFloat;
        temp_min = weatherJson["main"]["temp_min"].AsFloat;
        temp_max = weatherJson["main"]["temp_max"].AsFloat;
        rain = weatherJson["rain"]["3h"].AsFloat;
        clouds = weatherJson["clouds"]["all"].AsInt;
        wind = weatherJson["wind"]["speed"].AsFloat;

        temp = Mathf.Round(temp - KelvinToCelsius);
        temp_min = Mathf.Round(temp_min - KelvinToCelsius);
        temp_max = Mathf.Round(temp_max - KelvinToCelsius);

        CityDisplay.text = city;
        TempDisplay.text = temp.ToString() + "°C";
        DescriptionDisplay.text = weatherDescription;
        minTemp.text = "Min " + temp_min.ToString() + "°C";
        maxTemp.text = "Max " + temp_max.ToString() + "°C";
    }
}
