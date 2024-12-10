using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public float SpawnRadious;
    public float startSpawnTime;

    private float SpawnTime;
    public Vector2 Pos;

    [SerializeField]
    private float InitialWaveTime, WaveTime;
    public int Wave; 
    [HideInInspector] public int PreWave;
    private float Enemies;

    GameObject Player;
    public GameObject Yuju;
    public float LessWaveTime;

    PlayerHealth ph;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        WaveTime = InitialWaveTime;
        SpawnTime = startSpawnTime;
        PreWave = Wave;
    }

    private void Update()
    {
        ph = FindObjectOfType<PlayerHealth>();
        Pos = transform.position;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        spawning();
        WaveSystem();
    }

    void spawning()
    {
        if (PreWave == Wave && WaveTime > 0f)
        {
            Pos += Random.insideUnitCircle.normalized * SpawnRadious;
            if (ph.Health > 0)
            {
                if (SpawnTime <= 0)
                {
                    Instantiate(EnemyPrefabs[RandEnemy()], Pos, Quaternion.identity);

                    SpawnTime = startSpawnTime;
                }
                else
                {
                    SpawnTime = SpawnTime - Time.deltaTime;
                }
            }
        }
    }

    void WaveSystem()
    {
        if(WaveTime > 0 && PreWave == Wave)
        {
            WaveTime -= Time.deltaTime;
        }
        else if(WaveTime < 0)
        {
            if(Enemies == 0)
            {
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach (GameObject bullet in bullets) Destroy(bullet);
                StartCoroutine(Waiting());
            }
        }
    }

    IEnumerator Waiting()
    {
        PreWave++;
        InitialWaveTime += LessWaveTime;
        WaveTime = InitialWaveTime;
        if(startSpawnTime > 0.2)
        {
            startSpawnTime -= 0.03f;
        }
        FindObjectOfType<PlayerHealth>().trailsD();
        FindObjectOfType<PlayerMovement>().StopMoving();

        if(FindObjectOfType<PlayerHealth>().Health > 0)
        {
            Destroy(Instantiate(Yuju, transform.position, Quaternion.identity), 3f);
            FindObjectOfType<AudioManager>().Play("Wave");
            FindObjectOfType<WaveCompleted>().WaveCompletedText();
            Player.transform.position = new Vector2(0, 0);
            FindObjectOfType<WeaponSystem>().Intermission(Wave);
        }
        yield return new WaitForSeconds(5f);
        FindObjectOfType<PlayerHealth>().trailsA();
        Wave = PreWave;
    }

    int RandEnemy()
    {
        float Enemy = Random.Range(0, 101);

        int Common = Random.Range(0, 2);
        int Rare = Random.Range(2, 5);
        int Special = Random.Range(5, 8);

        if(Wave <= 2)
        {
            if (Enemy <= 70) return 0;
            else return 1;
        }
        else if(Wave <= 6)
        {
            if (Enemy <= 50) return Common;
            else if (Enemy <= 95) return Rare;
            else return Special;
        }
        else if(Wave <= 10)
        {
            if (Enemy <= 45) return Common;
            else if (Enemy <= 75) return Rare;
            else return Special;
        }
        else if(Wave <= 16)
        {
            if (Enemy <= 30) return Common;
            else if (Enemy <= 70) return Rare;
            else return Special;
        }
        else if (Wave <= 28)
        {
            if (Enemy <= 20) return Common;
            else if (Enemy <= 60) return Rare;
            else return Special;
        }
        else
        {
            if (Enemy <= 10) return Common;
            else if (Enemy <= 35) return Rare;
            else return Special;
        }
    }

}
