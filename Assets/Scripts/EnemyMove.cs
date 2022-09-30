using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    WaveConfigs waveConfig = null;
    List<Transform> path = null;
    private float moveSpeed = 0.1f;
    private int targetPoint = 1;
    private float fireCounter;
    [SerializeField] GameObject enemyBullet = null;
    [SerializeField] float myFireCounter=5;
    [SerializeField] private float bulletVelocity=0;
    public ParticleSystem deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        fireCounter = myFireCounter;
        //moveSpeed = waveConfig.moveSpeed;
        //path = waveConfig.getWayPoints();
        //print(path.Count);
        //transform.position = path[0].transform.position;
    }

    public void setWaveConfig(WaveConfigs waveConfig)
    {
        moveSpeed = waveConfig.moveSpeed;
        path = waveConfig.getWayPoints();
        transform.position = path[0].transform.position;
        this.waveConfig = waveConfig;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position=Vector3.MoveTowards(transform.position, path[targetPoint].transform.position, moveSpeed * Time.deltaTime * PlayerPrefs.GetFloat("difficulty"));
        if ((transform.position == path[targetPoint].transform.position) && (targetPoint < path.Count)) {
            targetPoint++;
        }
        //if (transform.position==path[path.Count-1].transform.position)
        if (targetPoint==path.Count)
        {
            Destroy(gameObject);
        }
        fireCounter -= Random.Range(0f, 0.2f)*(PlayerPrefs.GetFloat("difficulty"));
    
        //Debug.Log(fireCounter);
        if (fireCounter <= 0)
        {
            fireCounter = myFireCounter;
            GameObject bullet=Instantiate(enemyBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletVelocity);
        }
    }
}
