using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class BoardRetreiver : MonoBehaviour
{
	public static BoardRetreiver I;

    readonly string _url = "http://plac3d.adenflorian.com/";

	void Awake()
	{
		I = this;
	}

    public void GetBitmapFromServerAsync(Action<RPlaceBitmap> callback)
    {
         StartCoroutine(GetBitmapFromServerCoroutine(callback));
    }

    IEnumerator GetBitmapFromServerCoroutine(Action<RPlaceBitmap> callback)
    {
        byte[] rawBytesFromServer;

        // Get /r/place bitmap from Server
        using (UnityWebRequest www = UnityWebRequest.Get(_url))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log("Error: " + www.error);
                rawBytesFromServer = www.downloadHandler.data;
            }
            else
            {
                Debug.Log("Data length: " + www.downloadHandler.data.Length);

                rawBytesFromServer = www.downloadHandler.data;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i + ": " + rawBytesFromServer[i]);
        }


        // Remove first 4 bytes
        var trimmedBytes = new byte[rawBytesFromServer.Length - 4];

        for (int i = 0; i < trimmedBytes.Length; i++)
        {
            trimmedBytes[i] = rawBytesFromServer[i + 4];
        }

        // Convert so each byte has one Color (4 low order bits)
        var expandedBytes = new byte[trimmedBytes.Length * 2];

        for (int i = 0; i < expandedBytes.Length; i++)
        {
            if (i % 2 == 0)
            {
                expandedBytes[i] = (byte)(trimmedBytes[i / 2] >> 4);
            }
            else
            {
                expandedBytes[i] = (byte)(trimmedBytes[i / 2] & 0x0F);
            }
        }

        var placeBitmap = new RPlaceBitmap(expandedBytes, 1000, 1000);

		callback.Invoke(placeBitmap);
    }
}
