using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class FeatureCollection
{
    public List<Feature> features { get; set; }

    public static async Task<List<string>> EarthquakeDailySummary()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using HttpClient client = new HttpClient();
        string json = await client.GetStringAsync(url);

        var data = JsonSerializer.Deserialize<FeatureCollection>(json);

        List<string> summary = new List<string>();
        foreach (var feature in data.features)
        {
            string place = feature.properties.place;
            double mag = feature.properties.mag;
            summary.Add($"{place} - Mag {mag}");
        }

        return summary;
    }
}

public class Feature
{
    public EarthquakeProperties properties { get; set; }
}

public class EarthquakeProperties
{
    public string place { get; set; }
    public double mag { get; set; }
}
