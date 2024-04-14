//2024 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeMeter : MonoBehaviour {
    // Start is called before the first frame update
    public GameManager gamemanager;
    public Image imgMeterFill;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float fReadyPercent = 1f - (gamemanager.fWaitDelay / gamemanager.fMaxWaitDelay);
        imgMeterFill.transform.localPosition = new Vector2(0f, -64 + (64f * fReadyPercent));

        
    }
}
