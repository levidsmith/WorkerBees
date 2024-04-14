//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {
    Vector3 positionStart;
    public float fStartRadians;
    float fLifetime;
    float fSpeed = 1f;
    public float fOrbitRadius;


    // Start is called before the first frame update
    void Start() {
        positionStart = transform.position;
        fLifetime = 0f;
        
    }

    // Update is called once per frame
    void Update() {
        fLifetime += Time.deltaTime;
        Vector3 position = new Vector3(fOrbitRadius * Mathf.Cos(fLifetime + fStartRadians),
                                       fOrbitRadius * Mathf.Sin(fLifetime + fStartRadians),
                                       1f
                                       );
                           
        transform.localPosition = position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null) {
            Destroy(enemy.gameObject);
            Destroy(this.gameObject);
        }
    }
}
