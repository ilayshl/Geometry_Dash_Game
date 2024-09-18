using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;
    Vector3 respawnPos;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle")) {
            gameObject.GetComponent<PlayerMovement>().StopPlayerMovement();
            audioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
        }
    }
}
