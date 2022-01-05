using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fallTime = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", fallTime);
        }
    }

    private void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        SoundsManager.instance.PlayStoneBreak();
        Destroy(gameObject, 1f);
    }
}