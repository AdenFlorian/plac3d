using UnityEngine;

public class CubeGen : MonoBehaviour
{
	public int numberOfCubes;
	public int rowNumber;

    // Use this for initialization
    void Start()
    {
        // You can change that line to provide another MeshFilter
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        int length = 1;
        int width = 1;
        int height = 1;

        #region Vertices

        var vertices = new Vector3[24 * numberOfCubes];

		for (int i = 0; i < numberOfCubes; i++)
		{
			//Debug.Log(i + " / " + canvasWidth + ": " + i / canvasWidth);

			int hozMod = i - (numberOfCubes * (i / numberOfCubes));
			int vertMod = (i / numberOfCubes) * length;

			//Debug.Log("hozMod: " + hozMod);
			//Debug.Log("vertMod: " + vertMod);

			var p0 = new Vector3(-length * .5f + vertMod, -width * .5f, height * .5f + hozMod);
			var p1 = new Vector3(length * .5f + vertMod, -width * .5f, height * .5f + hozMod);
			var p2 = new Vector3(length * .5f + vertMod, -width * .5f, -height * .5f + hozMod);
			var p3 = new Vector3(-length * .5f + vertMod, -width * .5f, -height * .5f + hozMod);

			var p4 = new Vector3(-length * .5f + vertMod, width * .5f, height * .5f + hozMod);
			var p5 = new Vector3(length * .5f + vertMod, width * .5f, height * .5f + hozMod);
			var p6 = new Vector3(length * .5f + vertMod, width * .5f, -height * .5f + hozMod);
			var p7 = new Vector3(-length * .5f + vertMod, width * .5f, -height * .5f + hozMod);

			vertices[(i * 24) + 0] = p0;
			vertices[(i * 24) + 1] = p1;
			vertices[(i * 24) + 2] = p2;
			vertices[(i * 24) + 3] = p3;
			vertices[(i * 24) + 4] = p7;
			vertices[(i * 24) + 5] = p4;
			vertices[(i * 24) + 6] = p0;
			vertices[(i * 24) + 7] = p3;
			vertices[(i * 24) + 8] = p4;
			vertices[(i * 24) + 9] = p5;
			vertices[(i * 24) + 10] = p1;
			vertices[(i * 24) + 11] = p0;
			vertices[(i * 24) + 12] = p6;
			vertices[(i * 24) + 13] = p7;
			vertices[(i * 24) + 14] = p3;
			vertices[(i * 24) + 15] = p2;
			vertices[(i * 24) + 16] = p5;
			vertices[(i * 24) + 17] = p6;
			vertices[(i * 24) + 18] = p2;
			vertices[(i * 24) + 19] = p1;
			vertices[(i * 24) + 20] = p7;
			vertices[(i * 24) + 21] = p6;
			vertices[(i * 24) + 22] = p5;
			vertices[(i * 24) + 23] = p4;
		}
        #endregion

        // #region Normales
        // var up = Vector3.up;
        // var down = Vector3.down;
        // var front = Vector3.forward;
        // var back = Vector3.back;
        // var left = Vector3.left;
        // var right = Vector3.right;

		// var normales = new Vector3[24 * numberOfCubes];

		// for (int i = 0; i < numberOfCubes; i++)
		// {
		// 	normales[(i * 24) + 0] = down;
		// 	normales[(i * 24) + 1] = down;
		// 	normales[(i * 24) + 2] = down;
		// 	normales[(i * 24) + 3] = down;
		// 	normales[(i * 24) + 4] = left;
		// 	normales[(i * 24) + 5] = left;
		// 	normales[(i * 24) + 6] = left;
		// 	normales[(i * 24) + 7] = left;
		// 	normales[(i * 24) + 8] = front;
		// 	normales[(i * 24) + 9] = front;
		// 	normales[(i * 24) + 10] = front;
		// 	normales[(i * 24) + 11] = front;
		// 	normales[(i * 24) + 12] = back;
		// 	normales[(i * 24) + 13] = back;
		// 	normales[(i * 24) + 14] = back;
		// 	normales[(i * 24) + 15] = back;
		// 	normales[(i * 24) + 16] = right;
		// 	normales[(i * 24) + 17] = right;
		// 	normales[(i * 24) + 18] = right;
		// 	normales[(i * 24) + 19] = right;
		// 	normales[(i * 24) + 20] = up;
		// 	normales[(i * 24) + 21] = up;
		// 	normales[(i * 24) + 22] = up;
		// 	normales[(i * 24) + 23] = up;
		// }
        // #endregion

        // #region UVs
        // var _00 = new Vector2(0f, 0f);
        // var _10 = new Vector2(1f, 0f);
        // var _01 = new Vector2(0f, 1f);
        // var _11 = new Vector2(1f, 1f);

        // var uvs = new Vector2[24 * numberOfCubes];

		// for (int i = 0; i < numberOfCubes; i++)
		// {
		// 	uvs[(i * 24) + 0] = _11;
		// 	uvs[(i * 24) + 1] = _01;
		// 	uvs[(i * 24) + 2] = _00;
		// 	uvs[(i * 24) + 3] = _10;
		// 	uvs[(i * 24) + 4] = _11;
		// 	uvs[(i * 24) + 5] = _01;
		// 	uvs[(i * 24) + 6] = _00;
		// 	uvs[(i * 24) + 7] = _10;
		// 	uvs[(i * 24) + 8] = _11;
		// 	uvs[(i * 24) + 9] = _01;
		// 	uvs[(i * 24) + 10] = _00;
		// 	uvs[(i * 24) + 11] = _10;
		// 	uvs[(i * 24) + 12] = _11;
		// 	uvs[(i * 24) + 13] = _01;
		// 	uvs[(i * 24) + 14] = _00;
		// 	uvs[(i * 24) + 15] = _10;
		// 	uvs[(i * 24) + 16] = _11;
		// 	uvs[(i * 24) + 17] = _01;
		// 	uvs[(i * 24) + 18] = _00;
		// 	uvs[(i * 24) + 19] = _10;
		// 	uvs[(i * 24) + 20] = _11;
		// 	uvs[(i * 24) + 21] = _01;
		// 	uvs[(i * 24) + 22] = _00;
		// 	uvs[(i * 24) + 23] = _10;
		// }
        // #endregion

        #region Triangles
        int[] triangles = new int[36 * numberOfCubes];

		for (int i = 0; i < numberOfCubes; i++)
		{
			triangles[(i * 36) + 0] = 3 + (i * 24);
			triangles[(i * 36) + 1] = 1 + (i * 24);
			triangles[(i * 36) + 2] = 0 + (i * 24);
			triangles[(i * 36) + 3] = 3 + (i * 24);
			triangles[(i * 36) + 4] = 2 + (i * 24);
			triangles[(i * 36) + 5] = 1 + (i * 24);
			triangles[(i * 36) + 6] = (3 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 7] = (1 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 8] = (0 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 9] = (3 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 10] = (2 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 11] = (1 + 4 * 1) + (i * 24);
			triangles[(i * 36) + 12] = (3 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 13] = (1 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 14] = (0 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 15] = (3 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 16] = (2 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 17] = (1 + 4 * 2) + (i * 24);
			triangles[(i * 36) + 18] = (3 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 19] = (1 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 20] = (0 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 21] = (3 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 22] = (2 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 23] = (1 + 4 * 3) + (i * 24);
			triangles[(i * 36) + 24] = (3 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 25] = (1 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 26] = (0 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 27] = (3 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 28] = (2 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 29] = (1 + 4 * 4) + (i * 24);
			triangles[(i * 36) + 30] = (3 + 4 * 5) + (i * 24);
			triangles[(i * 36) + 31] = (1 + 4 * 5) + (i * 24);
			triangles[(i * 36) + 32] = (0 + 4 * 5) + (i * 24);
			triangles[(i * 36) + 33] = (3 + 4 * 5) + (i * 24);
			triangles[(i * 36) + 34] = (2 + 4 * 5) + (i * 24);
			triangles[(i * 36) + 35] = (1 + 4 * 5) + (i * 24);
		}
        #endregion

        #region Colors
		var colors = new Color32[vertices.Length];

		var colorChunk = colors.Length / numberOfCubes;

		for (int i = 0; i < numberOfCubes; i++)
		{
			for (int j = 0; j < colorChunk; j++)
			{
				int colorNumber;
				if (i % 2 == 0)
				{
					colorNumber = CubeManager.Instance._originalBytes[((i + (rowNumber * numberOfCubes)) / 2)] >> 4;
				}
				else
				{
                	colorNumber = CubeManager.Instance._originalBytes[((i + (rowNumber * numberOfCubes)) / 2)] & 0x0F;
				}

				colors[(i * colorChunk) + j] = CubeManager.Instance.intToColorMap[colorNumber];
			}
		}
        #endregion

        mesh.vertices = vertices;
        //mesh.normals = normales;
        //mesh.uv = uvs;
        mesh.triangles = triangles;
		mesh.colors32 = colors;

        mesh.RecalculateBounds();
        mesh.Optimize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
