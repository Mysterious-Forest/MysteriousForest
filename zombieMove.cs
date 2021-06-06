using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieMove : MonoBehaviour
{
    public List<Transform> locations; //좀비가 나오는 위치 설정
    public Transform patrolRoute; //움직임 변수 설정
    public Transform player; //Player 움직임

    private int locationIndex = 0; //처음에는 0으로 설정
    private NavMeshAgent zombie; //좀비의 NavMeshAgent 변수를 만들어준다.
    private AudioSource zombiedie; //좀비 소리 변수 설정

    private GameManger gameManager;

     private int lives = 3;

    void OnCollisionEnter(Collision col) //Collider간 발생한 충돌을 감지하는 함수 설정
    {
        if (col.gameObject.tag == "bullet") //만약 날아오는 물체가 총알이라면
        {
            lives -= 1; //좀비 체력이 1 줄어든다.
            zombiedie.Play(); //죽는 소리 재생
            Debug.Log("Hit!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform; //player를 불러온다.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManger>();
        zombiedie = GetComponent<AudioSource>(); //좀비가 가지고 있는 소리를 불러온다.
        zombie = GetComponent<NavMeshAgent>(); //좀비가 가지고 있는 NavMeshAgent를 불러온다.
        patrolRoute = GameObject.Find("Route1").transform; //설정한 위치에 좀비가 나오도록 Route1를 불러온다.
        InitializePatrolRoute(); //좀비가 나오는 위치 리스트를 사용하기 위한 함수
        MoveToNextPatrolPoint(); //다음 위치로 이동하기 위한 함수
    }

    // Update is called once per frame
    void Update()
    {
        if (zombie.remainingDistance < 0.1f && !zombie.pathPending) //좀비가 일정위치까지 가까이 가고, 좀비가 멈춘 상태가 아닐때
        {
            MoveToNextPatrolPoint(); //다음 지정한 포지션으로 이동
        }

        if (lives <= 0) //만약 체력이 0이라면
        {
            GameObject.Find("zombie(Clone)").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject); //좀비는 사라진다.

            if (this.gameObject.name == "zombie(Clone)")
            {
                gameManager.Score += 1;
            }
        }

    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute) //위치를 설정한 patrolRoute 안에 있는 child 움직임
        {
            locations.Add(child); //child를 저장한다.
        }
    }
    void MoveToNextPatrolPoint()
    {
        zombie.destination = locations[locationIndex].position; //다음 리스트로 이동하기 위한 함수 코드

        locationIndex = (locationIndex + 1) % locations.Count; //반복적으로 이동할 수 있게 하는 함수 코드
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            zombie.destination = player.position;
        }
    }
}
