using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos=transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle")) {
            transform.position = startingPos;
        }
    }
}
