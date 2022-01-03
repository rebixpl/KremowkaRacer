using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fallTime = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Invoke("Fall", fallTime);
        }
    }

    void Fall() {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
