using System.Text.Json;

namespace JsonIO;

public static class JsonReadWrite
{
	public static object? ReadJson(string filepass)
	{
		using var fs = new FileStream(filepass, FileMode.OpenOrCreate);
		return  JsonSerializer.Deserialize<object>(fs);
	}

	public static void WriteJson(string filepass, object obj)
	{
		using var fs = new FileStream(filepass, FileMode.OpenOrCreate);
		JsonSerializer.SerializeAsync<object>(fs, obj);
	}
}
