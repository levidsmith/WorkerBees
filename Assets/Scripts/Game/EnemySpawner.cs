//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public Enemy EnemyPrefab;

    public float fSpawnCountdown;
    float fMaxCountdown = 5f;

    public GameObject Room;
    int iWave;

    // Start is called before the first frame update
    void Start() {
        fSpawnCountdown = fMaxCountdown;
        iWave = 0;
        
    }

    public void reset() {
        iWave = 0;
    }

    // Update is called once per frame
    void Update() {
        fSpawnCountdown -= Time.deltaTime;
        if (fSpawnCountdown <= 0f) {
            spawnEnemy(Mathf.FloorToInt(iWave / 3) + 1);
            fSpawnCountdown += fMaxCountdown;
            iWave++;
        }
        
    }

    private void spawnEnemy(int iCount) {
        int i;

        for (i = 0; i < iCount; i++) {
            int iRandomSide = Random.Range(0, 4);
            Vector3 pos = Vector3.zero;
            switch (iRandomSide) {
                case 0:
                    pos = new Vector3(10f, Random.Range(-5f, 5f), 0f);
                    break;
                case 1:
                    pos = new Vector3(-10f, Random.Range(-5f, 5f), 0f);
                    break;
                case 2:
                    pos = new Vector3(Random.Range(-10f, 10f), 5f);
                    break;
                case 3:
                    pos = new Vector3(Random.Range(-10f, 10f), -5f);
                    break;
            }

            Enemy enemy = Instantiate(EnemyPrefab, pos, Quaternion.identity).GetComponent<Enemy>();
            enemy.transform.SetParent(Room.transform);
            FindObjectOfType<SoundEffects>().soundEnemySpawn.Play();
        }


    }
}
