using System.Net;
using System.Text;
using System.IO;
using UnityEngine;

public class ColorMindAPI
{
    public ColorMindResponse GetRandomColorPaletteRawResponse()
    {
        HttpWebRequest request = CreateWebRequest();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return ColorMindResponse.CreateFromJSON(reader.ReadToEnd());
        }

        return null;
    }

    private HttpWebRequest CreateWebRequest()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://colormind.io/api/");

        string body = "{\"model\":\"default\"}";
        var encodedBody = Encoding.ASCII.GetBytes(body);

        request.Method = "POST";
        request.ContentType = "text/json";
        request.ContentLength = encodedBody.Length;

        var newStream = request.GetRequestStream();
        newStream.Write(encodedBody, 0, encodedBody.Length);
        newStream.Close();

        return request;
    }
}

[System.Serializable]
public class ColorMindResponse
{
    public Color[] colors;

    public ColorMindResponse(int size)
    {
        colors = new Color[size];
    }

    // NOTE: The JsonUtility cannot parse int[][] so we have to convert the response manually
    public static ColorMindResponse CreateFromJSON(string jsonString)
    {
        ColorMindResponse response = new ColorMindResponse(5);

        string[] c = jsonString.Split(':')[1]
            .Replace('{', ' ').Replace('}', ' ')
            .Replace('[', ' ').Replace(']', ' ')
            .Split(',');

        int i = 0;
        for (int f = 0; f < c.Length; f+=3)
        {
            float r = int.Parse(c[f]) / 255f;
            float g = int.Parse(c[f+1]) / 255f;
            float b = int.Parse(c[f+2]) / 255f;

            response.colors[i] = new Color(r, g, b);
            i += 1;
        }

        return response;
    }
}
