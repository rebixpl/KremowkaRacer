using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parakopter_rotator : MonoBehaviour
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
            AnimateHelikopter();
        }
    }

    private void AnimateHelikopter()
    {
        gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation,
         gameObject.transform.localRotation * Quaternion.Euler(0, 0, 100f),
          Time.deltaTime * 8);
    }
}
