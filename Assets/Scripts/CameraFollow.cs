using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothValue;
    public static CameraFollow instance;
    private Vector3 distance;

    // Camera Game Location
    public Vector3 cameraGamePosition = new Vector3(-4.96180296f, 5.63000011f, -5.98980999f);
    public Vector3 cameraGameRotation = new Vector3(25.920002f, 39.6369934f, 9.49264575e-07f);

    // Camera Menu Location
    public Vector3 cameraMenuPosition = new Vector3(-4.96180296f, 5.63000011f, -5.98980999f);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        distance = target.position - transform.position;
        // transform.position = cameraMenuPosition;
        SetOrtographic(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Follow();
        }
    }

    public void SetOrtographic(bool value)
    {
        Camera camera = GetComponent<Camera>();

        camera.orthographic = value;

        if (value)
        {
            camera.nearClipPlane = -20f;
            camera.fieldOfView = 113f;
        }
        else
        {
            camera.nearClipPlane = 1f;
            camera.fieldOfView = 60f;
        }
    }

    private void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;
        /*Debug.Log("currentPos: " + currentPos.ToString());
        Debug.Log("targetPos: " + targetPos.ToString());*/

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}