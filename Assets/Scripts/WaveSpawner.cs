using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;

    private int WaveMoney = 0;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText;
    

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() 
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            WaveMoney += 10;
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        PlayerStats.Money += WaveMoney;
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
