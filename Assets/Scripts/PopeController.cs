using UnityEngine;

public class PopeController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject wheels;

    private bool isLeft = false;

    // Start is called before the first frame update
    private void Start()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckDirection();
        }

        // Player fell off the platforms
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    private void CheckDirection()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y >= 1)
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
        //transform.position += transform.forward * -moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);

        AnimateWheels();
    }

    private void AnimateWheels()
    {
        wheels.transform.rotation = wheels.transform.rotation * Quaternion.Euler(0, moveSpeed / 1.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kremowka") {
            ScoreManager.instance.KremowkaCollected(1);
            other.gameObject.SetActive(false);
        }
    }
}