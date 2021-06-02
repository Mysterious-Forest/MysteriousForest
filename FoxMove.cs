using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxMove : MonoBehaviour
{
    public List<Transform> locations; //여우가 나오는 위치 설정
    public Transform patrolRoute; //움직임 변수 설정

    private int locationIndex = 0; //처음에는 0으로 설정
    private NavMeshAgent Fox; //여우의 NavMeshAgent의 agent 변수를 만들어준다.

    // Start is called before the first frame update
    void Start()
    {
        Fox = GetComponent<NavMeshAgent>(); //여우가 가지고 있는 NavMeshAgent를 불러온다
        InitializePatrolRoute(); //여우가 나오는 위치 리스트를 사용하기 위한 함수
        MoveToNextPatrolPoint(); //다음 위치로 이동하기 위한 함수
    }

    // Update is called once per frame
    void Update()
    {
        if (Fox.remainingDistance < 0.2f && !Fox.pathPending) //여우가 일정위치까지 가까이 가고, 여우가 멈춘 상태가 아닐때
        {
            MoveToNextPatrolPoint(); //다음 지정한 포지션으로 이동
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
        Fox.destination = locations[locationIndex].position; //다음 리스트로 이동하기 위한 함수 코드

        locationIndex = (locationIndex + 1) % locations.Count; //반복적으로 이동할 수 있게 하는 함수 코드
    }
}
