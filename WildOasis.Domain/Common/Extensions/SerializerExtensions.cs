using System.Text.Json;

namespace WildOasis.Domain.Common.Extensions;

public static class SerializerExtensions
{
    public static readonly JsonSerializerOptions DefaultOptions = new();

    public static readonly JsonSerializerOptions SettingsWebOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //PropertyNamingPolicy na koji ce nacin property iz clase prebaciti u json
    };

    public static readonly JsonSerializerOptions SettingsGeneralOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
    };

    public static readonly JsonSerializerOptions SettingsTestCreateOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        MaxDepth = 10
    };
    
    
    
    public static string Serialaze(this object? json, JsonSerializerOptions settings)
    {
        return JsonSerializer.Serialize(json, settings);
    }
    
    public static  T? Deserialize<T>(this string json, JsonSerializerOptions settings)
    {

        return JsonSerializer.Deserialize<T>(json, settings);
    }


    public static bool TryDeserialaize<T>(this string obj, out T? result, JsonSerializerOptions settings)
    {
        try
        {
            result = JsonSerializer.Deserialize<T>(obj, settings);
            return true;

        }
        catch (Exception )
        {
            result = default;
            return false;
        }
    }

}