using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Configs")]
public class WaveConfigs : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawns;
    public float spawnRandomFasctor;
    public int numberOfEnemies;
    public float moveSpeed;
    //private List<Transform> wayPoints;
    public List<Transform> getWayPoints()
    {
        var wayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    
}
