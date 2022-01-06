using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fallTime = 0.5f;
    public GameObject kremowka;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnKremowka();
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

    private void SpawnKremowka()
    {
        int randKremowka = Random.Range(0, 7);

        Vector3 kremowkaPos = transform.position;
        kremowkaPos.y += 1.5f;

        if (randKremowka < 1)
        {
            GameObject kremowkaInstance = Instantiate(kremowka, kremowkaPos, kremowka.transform.rotation);
            kremowkaInstance.transform.SetParent(gameObject.transform);
        }
    }

    private void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        SoundsManager.instance.PlayStoneBreak();
        Destroy(gameObject, 1f);
    }
}