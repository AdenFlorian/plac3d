using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class CubeManager : MonoBehaviour
{
    public static CubeManager Instance;

    public GameObject CubePrefab;
    public readonly int canvasWidth = 1000;
    public readonly int maxCanvasWidth = 1000;

    readonly string _url = "http://plac3d.adenflorian.com/";

    public byte[] _originalBytes;
    
    public Dictionary<int, Color> intToColorMap = new Dictionary<int, Color>()
    {
        {0, new Color32(255, 255, 255, 255)},   // white
        {1, new Color32(228, 228, 228, 255)},   // lightgray
        {2, new Color32(136, 136, 136, 255)},   // darkgray
        {3, new Color32(34, 34, 34, 255)},      // black
        {4, new Color32(255, 167, 209, 255)},   // lightpink
        {5, new Color32(229, 0, 0, 255)},       // red
        {6, new Color32(229, 149, 0, 255)},     // orange
        {7, new Color32(160, 106, 66, 255)},    // brown
        {8, new Color32(229, 217, 0, 255)},     // yellow
        {9, new Color32(148, 224, 68, 255)},    // lightgreen
        {10, new Color32(2, 190, 1, 255)},      // green
        {11, new Color32(0, 211, 221, 255)},    // cyan
        {12, new Color32(0, 131, 199, 255)},    // grayblue
        {13, new Color32(0, 0, 234, 255)},      // blue
        {14, new Color32(207, 110, 228, 255)},  // pink
        {15, new Color32(130, 0, 128, 255)}     // purple
    };

    void Start()
    {
        Instance = this;

        StartCoroutine(GetBitmapFromReddit());
    }

    IEnumerator GetBitmapFromReddit()
    {
        using (UnityWebRequest www2 = UnityWebRequest.Get(_url))
        {
            yield return www2.Send();

            if (www2.isError)
            {
                Debug.Log("Error: " + www2.error);
                _originalBytes = www2.downloadHandler.data;
            }
            else
            {
                Debug.Log("Data length: " + www2.downloadHandler.data.Length);

                _originalBytes = www2.downloadHandler.data;

                PlaceStartingCubes();
            }
        }
    }

    void PlaceStartingCubes()
    {
        //var i = 4;

        // for (var y = 0; y < canvasWidth; y++)
        // {
        //     for (var x = 0; x < canvasWidth / 2; x++)
        //     {
        //         //var int1 = _originalBytes[i] >> 4;
        //         //var int2 = _originalBytes[i] & 0x0F;

        //         //var go1 = GameObject.Instantiate(CubePrefab, new Vector3(x * 2, 0, -y), Quaternion.identity) as GameObject;
        //         //go1.GetComponent<Renderer>().material.color = intToColorMap[int1];

        //         //var go2 = GameObject.Instantiate(CubePrefab, new Vector3(x * 2 + 1, 0, -y), Quaternion.identity) as GameObject;
        //         //go2.GetComponent<Renderer>().material.color = intToColorMap[int2];

        //         i++;
        //     }
        //     //i += ((maxCanvasWidth / 2) - (canvasWidth / 2));
        //     //yield return null;
        // }

        // for (int x = 0; x < canvasWidth; x++)
        // {
        //     for (int y = 0; y < canvasWidth; y++)
        //     {
        //         Spawner.Instance.pixelArrays = new byte[canvasWidth][];
        //         for (int i = 0; i < canvasWidth; i++)
        //         {
        //             Spawner.Instance.pixelArrays[i] = new byte[canvasWidth];
        //         }
        //         Spawner.Instance.pixelArrays[x][y] = _originalBytes[(x * canvasWidth) + y];
        //     }
        // }

        Spawner.Instance.StartCoroutine(Spawner.Instance.StartSpawning());
    }
}
