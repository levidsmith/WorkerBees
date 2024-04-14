//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hive : MonoBehaviour {
    // Start is called before the first frame update
    [HideInInspector]
    public int iHealth;
    public Text textHealth;

    void Start() {
        iHealth = 5;
        
    }

    // Update is called once per frame
    void Update() {
        if (iHealth > 0) {
            textHealth.text = iHealth.ToString();
        } else {
            textHealth.text = "";
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("hive collided");
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null) {
            Destroy(enemy.gameObject);
            iHealth--;

            if (iHealth <= 0) {
                Destroy(this.gameObject);
            }
            FindObjectOfType<SoundEffects>().soundHiveHit.Play();
        }
    }
}
