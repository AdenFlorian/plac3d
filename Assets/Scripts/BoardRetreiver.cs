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

    public void GetBitmapFromServerAsync(Action<byte[]> callback)
    {
         StartCoroutine(GetBitmapFromServerCoroutine(callback));
    }

    IEnumerator GetBitmapFromServerCoroutine(Action<byte[]> callback)
    {
        byte[] rawBytesFromServer;

        // Get place bitmap from Server
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

		callback.Invoke(rawBytesFromServer);
    }
}
