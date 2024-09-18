using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public float timer;
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
            if(timer%100==0 && timer!=0) {
                if(timer!=currentTimePrevention){
                    IncreaseDifficulty(0.025f);
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
        timer=0;
        playerMovementScript.difficultyTimer=1;
        currentTimePrevention=0;
        if(rbPlayer.gravityScale>0) {
          rbPlayer.gravityScale=12;
         } else {
         rbPlayer.gravityScale=-12;
               }
    }
}
