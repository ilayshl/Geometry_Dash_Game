using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject[] obstacleList;
    GameObject activeObstacle;
    Transform player;

    void Start()
    {
        activeObstacle = obstacleList[Random.Range(0, obstacleList.Length)];
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(activeObstacle.transform.position.x < player.position.x-15) {
            RenewObstacle();
        }
    }

    public void RenewObstacle() {
        activeObstacle=obstacleList[Random.Range(0, obstacleList.Length)];
        activeObstacle.transform.position=new Vector3(player.position.x+20, 0, 0);
    }
}
