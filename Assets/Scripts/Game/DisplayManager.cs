//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {
    public Text TextTimeValue;
    public GameManager gamemanager;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        TextTimeValue.text = Mathf.FloorToInt(gamemanager.fTotalTime).ToString();

        
    }
}
