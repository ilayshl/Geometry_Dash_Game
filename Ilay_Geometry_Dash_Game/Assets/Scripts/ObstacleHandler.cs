using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject[] obstacleList;
    GameObject activeObstacle;
    Transform player;

    void Start()
    {
        activeObstacle = obstacleList[0];
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(activeObstacle.transform.position.x < player.position.x-15) {
            RenewObstacle();
        }
    }

    public void RenewActiveObstacle() {
        activeObstacle.transform.position=new Vector3(player.position.x+40, 5, 0);
    }

    void RenewObstacle() {
        activeObstacle=obstacleList[Random.Range(0, obstacleList.Length)];
        int verticalDirection = Random.Range(0, 1);
        if(verticalDirection == 0) {
            Transform activeTransform = activeObstacle.transform;
            activeTransform.localScale=new Vector3(activeTransform.localScale.x, activeTransform.localScale.y*-1, activeTransform.localScale.z);
        }
        activeObstacle.transform.position=new Vector3(player.position.x+30, 5,  0);
    }
}
