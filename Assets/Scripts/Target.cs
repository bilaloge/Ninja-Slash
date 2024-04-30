using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem expoParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb= GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -2);
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }
    float RandomTorque()
    {
        return Random.Range(-10, 10);
    }
    private void OnMouseDown()
    {
        if (gameManager.gameactive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(expoParticle, transform.position, expoParticle.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
