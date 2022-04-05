namespace WebApiHW;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }

    public WeatherForecast() { }

    public WeatherForecast(string date, int tempC, string str)
    {
        Date = FromString(date);
        TemperatureC = tempC;
        Summary = str;
    }

    private DateTime FromString(string date)
    {
        string[] temp = date.Split('.', StringSplitOptions.RemoveEmptyEntries);
        int day, month, year;
        day = month = year = 1;
        if (temp.Length == 3)
        {
            int.TryParse(temp[0], out day);
            int.TryParse(temp[1], out month);
            int.TryParse(temp[2], out year);
        }
        return new DateTime(day: day, month: month, year: year);
    }

    public static bool operator ==(WeatherForecast wf1, WeatherForecast wf2)
    {
        return wf1.Date == wf2.Date && wf1.TemperatureC == wf2.TemperatureC && wf1.Summary == wf2.Summary;
    }

    public static bool operator !=(WeatherForecast wf1, WeatherForecast wf2)
    {
        return !(wf1.Date == wf2.Date && wf1.TemperatureC == wf2.TemperatureC && wf1.Summary == wf2.Summary);
    }
}
