using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float MouseYSpeed = 0.1F;
    public float MouseXSpeed = 0.1F;
    public float ScrollSpeed = 50.0F;

    public float HorizontalSpeed = 10F;
    public float VerticalSpeed = 10F;

	float radius;
	float theta = 0;
	float phi = 0.2f;

	Vector3 centerOfFocus;

    // Use this for initialization
    void Start()
    {
        radius = Master.Instance.canvasWidth;
		centerOfFocus = new Vector3(Master.Instance.canvasWidth / 2, 0, Master.Instance.canvasWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y") * -MouseYSpeed;
        float MouseX = Input.GetAxis("Mouse X") * -MouseXSpeed;
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * -ScrollSpeed;

		theta += MouseX;
		phi += MouseY;
		radius += ScrollWheel;

        phi = Mathf.Max(phi, 0.01f);
        phi = Mathf.Min(phi, Mathf.PI / 2);

        radius = Mathf.Max(radius, 0);

		var x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
		var y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
        var z = radius * Mathf.Cos(phi);

        var xMov = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
        var yMov = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;

        centerOfFocus += new Vector3(-yMov, 0, xMov);

		transform.position = centerOfFocus + new Vector3(x, z, y);

		transform.LookAt(centerOfFocus);
    }
}
