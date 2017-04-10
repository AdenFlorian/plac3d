using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public float MouseYSpeed = 0.1F;
    public float MouseXSpeed = 0.1F;
    public float ScrollSpeed = 50.0F;

    public float HorizontalSpeed = 10F;
    public float VerticalSpeed = 10F;

	float _radius;
	float _theta = 0;
	float _phi = 0.2f;

	Vector3 _centerOfFocus;

    void Start()
    {
        _radius = Master.I.FoundationBitmap.Width;
		_centerOfFocus = new Vector3(_radius / 2, 0, _radius / 2);
    }

    void Update()
    {
        UpdateCenterOfFocus();

		transform.position = _centerOfFocus + CaluculateLookVector();

		transform.LookAt(_centerOfFocus);
    }

    void UpdateCenterOfFocus()
    {
        var xMov = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
        var yMov = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;

        _centerOfFocus += new Vector3(-yMov, 0, xMov);
    }

    Vector3 CaluculateLookVector()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseXSpeed;
        float MouseY = Input.GetAxis("Mouse Y") * MouseYSpeed;
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        _theta += -MouseX;
        _phi += -MouseY;
        _radius += -ScrollWheel;

        _phi = Mathf.Max(_phi, 0.01f);
        _phi = Mathf.Min(_phi, Mathf.PI / 2);

        _radius = Mathf.Max(_radius, 0);

        var x = _radius * Mathf.Sin(_phi) * Mathf.Cos(_theta);
        var y = _radius * Mathf.Sin(_phi) * Mathf.Sin(_theta);
        var z = _radius * Mathf.Cos(_phi);

        return new Vector3(x, z, y);
    }
}
