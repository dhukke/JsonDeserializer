using System.Text.Json;

namespace JsonDeserialize;

public class Deserializer
{
    public List<MyObject> Deserialize()
    {
        var myObjectList = new List<MyObject>();

        using var fs = File.OpenRead("data.json");
        // Create a JsonDocument from the stream
        using var document = JsonDocument.Parse(fs);

        // Get the root element
        var root = document.RootElement;

        // Check if the root element is an object
        if (root.ValueKind == JsonValueKind.Object)
        {
            // Get the inner array by property name
            var innerArray = root.GetProperty("innerArray");

            // Check if the inner array is an array
            if (innerArray.ValueKind == JsonValueKind.Array)
            {
                // Iterate over each item in the array
                foreach (JsonElement item in innerArray.EnumerateArray())
                {
                    // Deserialize the item into an object
                    var myObject = JsonSerializer.Deserialize<MyObject>(item.GetRawText());

                    myObjectList.Add(myObject!);

                    Console.WriteLine($"Name: {myObject.Name}, Age: {myObject.Age}");
                }
            }
        }

        return myObjectList;
    }
}
