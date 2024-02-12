using UnityEngine;

public class FireworkSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    private bool autoMode = false;
    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnRocket();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            autoMode = !autoMode;
        }

        if (autoMode && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + Random.Range(0.3f, 1.5f);
            SpawnRocket();
        }
    }

    void SpawnRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab);
        float randomX = Random.Range(-22.5f, 22.5f);
        float randomY = Random.Range(-3f, 0f);
        rocket.transform.position = new Vector3(randomX, randomY, 0);
    }
}
