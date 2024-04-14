//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public EnemySpawner enemyspawner;
    bool isGameOver;
    public GameObject PanelGameOver;

    public Hive HivePrefab; 
    public Bee BeePrefab;
    public Camera camera;
    public GameObject Room;

    // Start is called before the first frame update
    void Start() {
        gameRestart();
        
    }

    // Update is called once per frame
    void Update() {
        Hive hive = FindObjectOfType<Hive>();
        if (!isGameOver && hive == null) {
            isGameOver = true;
            PanelGameOver.SetActive(true);
            enemyspawner.gameObject.SetActive(false);
        }

        if (!isGameOver) {
            handleMouseInput();
        }

        
    }

    public void gameRestart () {
        int i;
        for (i = 0; i < Room.transform.childCount; i++) {
            Destroy(Room.transform.GetChild(i).gameObject);
        }

        //enemyspawner.gameObject.SetActive(true);
        //hive.iHealth = 5;
        Hive hive = Instantiate(HivePrefab, Vector3.zero, Quaternion.identity).GetComponent<Hive>();
        hive.transform.SetParent(Room.transform);
        
        enemyspawner.gameObject.SetActive(true);
        enemyspawner.reset();
        PanelGameOver.SetActive(false);

        isGameOver = false;


    }

    public void gameExit() {
        Debug.Log("back to title screen");
    }

    private void handleMouseInput() {
        if (Input.GetMouseButtonDown(0)) {
            spawnBee();
        }
    }

    private void spawnBee() {
        float fRadius;

        //fRadius = Input.mousePosition.
        Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("WorldPoint: " + pos);
        fRadius = Vector2.Distance(Vector3.zero, pos);
        //float fRadians = Mathf.PI;
        float fDegrees = Vector2.Angle(Vector2.right, pos);

        float fRadians = 0f;
        if (pos.y >= 0) {
            fRadians = fDegrees * Mathf.Deg2Rad;
        } else {
            fRadians = (180f + (180f - fDegrees)) * Mathf.Deg2Rad;

        }

        Debug.Log("Angle: " + fRadians);

//        Debug.Log("fRadius: " + fRadius);

        //        Vector2 pos = new Vector2(4f, 0f);
        Vector2 positionSpawn = new Vector2(fRadius, 0f);
        Bee bee = Instantiate(BeePrefab, pos, Quaternion.identity);;
        bee.fOrbitRadius = fRadius;
        bee.fStartRadians = fRadians;

        bee.transform.SetParent(Room.transform);
    }
}
