using UnityEngine;

public class FireworkController : MonoBehaviour
{
    [SerializeField]
    private float rocketSpeed = 8f;
    [SerializeField]
    private float rocketDuration = 2f;
    public GameObject explosionPrefab;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        // Debug.Log("Start was called");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update was called");
        transform.Translate(rocketSpeed * Time.deltaTime * Vector3.up);

        if (Time.time >= spawnTime + rocketDuration)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        } 
    }
}
