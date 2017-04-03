using UnityEngine;

public class CubeGen : MonoBehaviour
{
	public int numberOfCubes;
	public int rowNumber;

    void Start()
    {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        int cubeSize = 1;

        #region Vertices
		int numberOfVerticesPerCube = 8;
        var vertices = new Vector3[numberOfVerticesPerCube * numberOfCubes];

		for (int i = 0; i < numberOfCubes; i++)
		{
			var p0 = new Vector3(-cubeSize * .5f, -cubeSize * .5f, cubeSize * .5f + i);
			var p1 = new Vector3(cubeSize * .5f, -cubeSize * .5f, cubeSize * .5f + i);
			var p2 = new Vector3(cubeSize * .5f, -cubeSize * .5f, -cubeSize * .5f + i);
			var p3 = new Vector3(-cubeSize * .5f, -cubeSize * .5f, -cubeSize * .5f + i);

			var p4 = new Vector3(-cubeSize * .5f, cubeSize * .5f, cubeSize * .5f + i);
			var p5 = new Vector3(cubeSize * .5f, cubeSize * .5f, cubeSize * .5f + i);
			var p6 = new Vector3(cubeSize * .5f, cubeSize * .5f, -cubeSize * .5f + i);
			var p7 = new Vector3(-cubeSize * .5f, cubeSize * .5f, -cubeSize * .5f + i);

			vertices[(i * numberOfVerticesPerCube) + 0] = p0;
			vertices[(i * numberOfVerticesPerCube) + 1] = p1;
			vertices[(i * numberOfVerticesPerCube) + 2] = p2;
			vertices[(i * numberOfVerticesPerCube) + 3] = p3;
			vertices[(i * numberOfVerticesPerCube) + 4] = p4;
			vertices[(i * numberOfVerticesPerCube) + 5] = p5;
			vertices[(i * numberOfVerticesPerCube) + 6] = p6;
			vertices[(i * numberOfVerticesPerCube) + 7] = p7;
        }
        #endregion

        #region Triangles
        int numberOfTrianglesPerCube = 12;
        int[] triangles = new int[numberOfTrianglesPerCube * 3 * numberOfCubes];

		for (int i = 0; i < numberOfCubes; i++)
		{
			triangles[(i * numberOfTrianglesPerCube * 3) + 0] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 1] = 3 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 2] = 2 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 3] = 2 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 4] = 1 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 5] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 6] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 7] = 1 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 8] = 5 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 9] = 5 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 10] = 4 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 11] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 12] = 1 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 13] = 2 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 14] = 6 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 15] = 6 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 16] = 5 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 17] = 1 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 18] = 2 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 19] = 3 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 20] = 7 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 21] = 7 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 22] = 6 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 23] = 2 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 24] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 25] = 4 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 26] = 7 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 27] = 7 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 28] = 3 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 29] = 0 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 30] = 4 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 31] = 5 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 32] = 6 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 33] = 6 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 34] = 7 + (i * numberOfVerticesPerCube);
			triangles[(i * numberOfTrianglesPerCube * 3) + 35] = 4 + (i * numberOfVerticesPerCube);
		}
        #endregion

        #region Colors
		var colors = new Color32[vertices.Length];

		for (int i = 0; i < numberOfCubes; i++)
		{
			for (int j = 0; j < numberOfVerticesPerCube; j++)
			{
				int colorNumber = Master.Instance.PlaceBitmap.GetByte(i, rowNumber);

				colors[(i * numberOfVerticesPerCube) + j] = RedditColors.intToColorMap[colorNumber];
			}
		}
        #endregion

        mesh.vertices = vertices;
        mesh.triangles = triangles;
		mesh.colors32 = colors;

        mesh.RecalculateBounds();
        mesh.Optimize();
    }
}
