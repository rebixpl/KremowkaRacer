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
        if (GameManager.instance.gameStarted)
        {
            AnimateWheels();
        }
    }

    private void AnimateWheels()
    {
        gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation,
        gameObject.transform.localRotation * Quaternion.Euler(0, 100f, 0),
          Time.deltaTime * 4);
    }
}
