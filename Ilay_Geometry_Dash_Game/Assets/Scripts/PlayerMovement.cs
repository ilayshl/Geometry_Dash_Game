using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] float jumpForce = 25f;
    [SerializeField] float jumpTimeFullCharge = 0.5f;
    [SerializeField] ParticleSystem halfChargeParticle;
    [SerializeField] ParticleSystem fullChargeParticle;
    bool isJumping=false;
    Rigidbody2D rbPlayer;
    float jumpTimer;
    int gravityScale = 1;

    void Start()
    {
        rbPlayer=gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        gameObject.transform.position+=Vector3.right*moveSpeed*Time.deltaTime;
        if(isJumping==true) {
            rbPlayer.transform.Rotate(Vector3.back*2*gravityScale);
        }

        if (Input.GetKey(KeyCode.UpArrow) ||Input.GetKey(KeyCode.W)) {
            if(isJumping==false) {
            if(jumpTimer<jumpTimeFullCharge) {
            jumpTimer+=Time.deltaTime;
            Debug.Log("Jump timer is "+jumpTimer);
            }
            if(jumpTimer>(jumpTimeFullCharge/2) && halfChargeParticle.isPlaying==false && jumpTimer<jumpTimeFullCharge) {
                    halfChargeParticle.Play();
                }
            if(jumpTimer>jumpTimeFullCharge){
                    jumpTimer=jumpTimeFullCharge;
                    Debug.Log("Jump timer reset to "+jumpTimer);
                    fullChargeParticle.Play();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && isJumping==false) {
            rbPlayer.velocity=Vector2.zero;
            gravityScale*=-1;
            rbPlayer.gravityScale*=-1;
            isJumping=true;
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.W)) {
            if(isJumping==false) {
                isJumping=true;
                rbPlayer.velocity=Vector2.zero;
                    if(jumpTimer==jumpTimeFullCharge) {
                        rbPlayer.AddForce(Vector2.up*jumpForce*1.5f*gravityScale, ForceMode2D.Impulse);
                    Debug.Log($"Jumped for {jumpForce*1.5f} units");
                } else if(jumpTimer>=(jumpTimeFullCharge/2)) {
                        rbPlayer.AddForce(Vector2.up*jumpForce*1.2f*gravityScale, ForceMode2D.Impulse);
                    Debug.Log($"Jumped for {jumpForce*1.2f} units");
                } else if(jumpTimer<(jumpTimeFullCharge/2)) {
                        rbPlayer.AddForce(Vector2.up*jumpForce*gravityScale, ForceMode2D.Impulse);
                    Debug.Log($"Jumped for {jumpForce} units");
                }
                
                jumpTimer=0;
            }
        }
        }


        void OnCollisionEnter2D(Collision2D collision) {
            if(isJumping==true) {
                isJumping=false;
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.z=Mathf.Round(rotation.z/90)*90;
            transform.rotation=Quaternion.Euler(rotation);
                Debug.Log("Landed");
            }
        }

}
