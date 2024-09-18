using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private float timer;
    private PlayerMovement playerMovementScript;
    private Rigidbody2D rbPlayer;
    private int currentTimePrevention;

    void Start()
    {
        playerMovementScript=gameObject.GetComponent<PlayerMovement>();
        rbPlayer=gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(playerMovementScript.isRunning==true) {
            timer+=Time.deltaTime*100;
            timer=Mathf.Round(timer);
            if(timer%100==0) {
                if(timer!=currentTimePrevention){
                    Debug.Log(timer/100);
                    IncreaseDifficulty(0.0125f);
                    currentTimePrevention=(int) timer;
                }
            }
        }
    }
    void IncreaseDifficulty(float additiveAmount) {
        playerMovementScript.difficultyTimer+=additiveAmount;
        if(rbPlayer.gravityScale>0) {
            rbPlayer.gravityScale=rbPlayer.gravityScale+additiveAmount;
        } else {
            rbPlayer.gravityScale=rbPlayer.gravityScale-additiveAmount;
        }
    }

    public void ResetTimer() {
        playerMovementScript.isRunning=false;
        timer=0;
    }
}
