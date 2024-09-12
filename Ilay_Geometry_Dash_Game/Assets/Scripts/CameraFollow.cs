using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] GameObject playerToFollow;
   
    void Update()
    {
        gameObject.transform.position=playerToFollow.transform.position;
    }
}
