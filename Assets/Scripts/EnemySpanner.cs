using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpanner : MonoBehaviour
{
    [SerializeField] List<WaveConfigs> waves = null;
    private int startwave = 0;
    private bool looping = true;
    private float deathDelay = 1f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (SceneManager.GetActiveScene().name=="Endless Mode")
        {
            do
            {
                yield return SpawnAllEnemiesInWave(waves[Random.Range(0, waves.Count)]);
            }
            while (looping);
        }
        else
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startwave; waveIndex < waves.Count; waveIndex++)
        {
            yield return SpawnAllEnemiesInWave(waves[waveIndex]);
        }
        if (SceneManager.GetActiveScene().name!="Last Level")
        {
            
            if (!PlayerPrefs.GetString("Locker").Contains((SceneManager.GetActiveScene().buildIndex - 2).ToString())){
                PlayerPrefs.SetString("Locker", PlayerPrefs.GetString("Locker") + (SceneManager.GetActiveScene().buildIndex - 2).ToString());
            }
            StartCoroutine(DelayRoutine());
            
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
            SceneManager.LoadScene("Win");
        }
        
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfigs currentWave)
    {
        for(int i = 0; i < currentWave.numberOfEnemies; i++)
        {
            var curEnemy=Instantiate(currentWave.enemyPrefab, currentWave.getWayPoints()[0].transform.position, Quaternion.identity);
            curEnemy.GetComponent<EnemyMove>().setWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    IEnumerator DelayRoutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerControl>().controlAllowed = false;
        yield return new WaitForSeconds(deathDelay);
        player.GetComponent<PlayerControl>().controlAllowed = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
