using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousPlatforms : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    void Update()
    {
        if(transform.position.x <playerPosition.position.x-40) {
            transform.position=new Vector3(transform.position.x+160, transform.position.y, transform.position.z);
        } 
    }
}
