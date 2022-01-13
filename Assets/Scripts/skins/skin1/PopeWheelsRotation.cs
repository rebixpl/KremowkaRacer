using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopeWheelsRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted) {
            AnimateWheels();
        }
    }

    private void AnimateWheels()
    {
        gameObject.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, -6f, 0);
    }
}
