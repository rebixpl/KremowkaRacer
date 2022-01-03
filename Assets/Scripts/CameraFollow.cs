using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothValue;

    private Vector3 distance;

    // Start is called before the first frame update
    private void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Follow();
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