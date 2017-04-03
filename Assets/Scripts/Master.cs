using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Master : MonoBehaviour
{
    public static Master Instance;

    public readonly int canvasWidth = 1000;
    public readonly int maxCanvasWidth = 1000;

    public RPlaceBitmap PlaceBitmap;

    readonly string _url = "http://plac3d.adenflorian.com/";

    void Start()
    {
        Instance = this;
        BoardRetreiver.I.GetBitmapFromServerAsync((byte[] rawBytesFromServer) => {
            Foo(rawBytesFromServer);
        });
    }

    void Foo(byte[] rawBytesFromServer)
    {

        // Remove first 4 bytes
        var trimmedBytes = new byte[rawBytesFromServer.Length - 4];

        for (int i = 0; i < trimmedBytes.Length; i++)
        {
            trimmedBytes[i] = rawBytesFromServer[i + 4];
        }

        // Convert so each byte has one Color (4 bits)
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

        PlaceBitmap = new RPlaceBitmap(expandedBytes);

        Spawner.Instance.StartCoroutine(Spawner.Instance.StartSpawning());
    }
}
