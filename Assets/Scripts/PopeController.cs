using UnityEngine;

public class PopeController : MonoBehaviour
{
    public float moveSpeed = 8f;
    private bool isLeft = false;

    public GameObject wheels;


    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckDirection();
        }

        if (transform.position.y <= -10) {
            GameManager.instance.GameOver();
        }
    }

    private void CheckDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (isLeft)
        {
            transform.rotation = Quaternion.Euler(0, 270f, 0);
            isLeft = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isLeft = true;
        }
    }

    private void Move()
    {
        transform.position += transform.forward * -moveSpeed * Time.deltaTime;
        AnimateWheels();
    }

    private void AnimateWheels() {
        wheels.transform.rotation = wheels.transform.rotation * Quaternion.Euler(0, moveSpeed / 2, 0);
    }
}