//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float fSpeed = 4f;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("enemy created");
        
    }

    // Update is called once per frame
    void Update() {
        
        transform.localPosition = Vector2.MoveTowards(transform.position, Vector3.zero, fSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("enemy collided");
    }
}
