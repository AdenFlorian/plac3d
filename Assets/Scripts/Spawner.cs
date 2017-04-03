using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public static Spawner Instance;

    public GameObject prefab;
    public int height = 10;

	void Start()
	{
		Instance = this;
	}

    public IEnumerator StartSpawning()
    {
        for (int i = 0; i < height; i++)
        {
            var go = GameObject.Instantiate(prefab, Vector3.right * i, Quaternion.identity) as GameObject;
            //go.GetComponent<CubeGen>().pixels = pixelArrays[i];
            go.GetComponent<CubeGen>().rowNumber = i;
            go.GetComponent<CubeGen>().numberOfCubes = 1000;
            yield return null;
        }
    }
}
