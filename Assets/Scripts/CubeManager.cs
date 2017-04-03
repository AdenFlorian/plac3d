using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CubeManager : MonoBehaviour
{
    public static CubeManager Instance;

    public GameObject CubePrefab;
    public readonly int canvasWidth = 1000;
    public readonly int maxCanvasWidth = 1000;

    public byte[] OriginalBytes;
    public byte[] ConvertedBytes;
    public RPlaceBitmap PlaceBitmap;

    readonly string _url = "http://plac3d.adenflorian.com/";

    void Start()
    {
        Instance = this;
        StartCoroutine(GetBitmapFromReddit());
    }

    IEnumerator GetBitmapFromReddit()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(_url))
        {
            yield return www.Send();

            byte[] myArr;

            if (www.isError)
            {
                Debug.Log("Error: " + www.error);
                myArr = www.downloadHandler.data;
            }
            else
            {
                Debug.Log("Data length: " + www.downloadHandler.data.Length);

                myArr = www.downloadHandler.data;
            }

            // Remove first 4 bytes
            OriginalBytes = new byte[myArr.Length - 4];

            for (int i = 0; i < OriginalBytes.Length; i++)
            {
                OriginalBytes[i] = myArr[i + 4];
            }

            // Convert so each byte as one Color
            ConvertedBytes = new byte[OriginalBytes.Length * 2];

            for (int i = 0; i < ConvertedBytes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ConvertedBytes[i] = (byte)(OriginalBytes[i / 2] >> 4);
                }
                else
                {
                    ConvertedBytes[i] = (byte)(OriginalBytes[i / 2] & 0x0F);
                }
            }

            PlaceBitmap = new RPlaceBitmap(ConvertedBytes);

            Spawner.Instance.StartCoroutine(Spawner.Instance.StartSpawning());
        }
    }
}
