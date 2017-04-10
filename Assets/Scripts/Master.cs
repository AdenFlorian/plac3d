using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Master : MonoBehaviour
{
    public static Master I;

    public GameObject CubeGenPrefab;
    public MainCameraScript MainCameraScript;
    public RPlaceBitmap FoundationBitmap;

    readonly string _url = "http://plac3d.adenflorian.com/";
    
    void Start()
    {
        I = this;
        BoardRetreiver.I.GetBitmapFromServerAsync((RPlaceBitmap placeBitmap) => {
            FoundationBitmap = placeBitmap;
            MainCameraScript.enabled = true;
            StartCoroutine(SpawnFoundation(() => {
                //StartCoroutine(Updater());
            }));
        });
    }

    public IEnumerator SpawnFoundation(Action callback)
    {
        Debug.Log("SpawnFoundation Start!");
        for (int i = 0; i < FoundationBitmap.Height; i++)
        {
            var go = GameObject.Instantiate(CubeGenPrefab, Vector3.right * i, Quaternion.identity) as GameObject;
            go.GetComponent<CubeGen>().rowNumber = i;
            go.GetComponent<CubeGen>().numberOfCubes = FoundationBitmap.Width;
            yield return null;
        }

        callback.Invoke();
    }

    public IEnumerator Updater()
    {
        Debug.Log("Updater Start!");
        yield return new WaitForSeconds(10f);

        BoardRetreiver.I.GetBitmapFromServerAsync((RPlaceBitmap newBitmap) => {
            Debug.Log("Hash of newBitmap: " + newBitmap._bytes.GetHashCode());
            Debug.Log("Hash of FoundationBitmap: " + FoundationBitmap._bytes.GetHashCode());
            Debug.Log("Updater End!");
            StartCoroutine(SpawnDiff(newBitmap));
        });
    }

    public IEnumerator SpawnDiff(RPlaceBitmap newBitmap)
    {
        Debug.Log("SpawnDiff Start!");
        // calc and spawn diff

        // for each pixel, 
        for (int y = 0; y < newBitmap.Height; y++)
        {
            for (int x = 0; x < newBitmap.Width; x++)
            {
                if (newBitmap.GetByte(x, y) != FoundationBitmap.GetByte(x, y))
                {
                    Debug.Log("Found a diff!");
                    var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.position = new Vector3(y, 10, x);
                    go.GetComponent<MeshRenderer>().material.color = RedditColors.intToColorMap[newBitmap.GetByte(x, y)];

                    yield return null;
                }
            }
        }
        Debug.Log("SpawnDiff End!");

        StartCoroutine(Updater());
    }
}
