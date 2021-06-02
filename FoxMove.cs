using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxMove : MonoBehaviour
{
    public List<Transform> locations; //���찡 ������ ��ġ ����
    public Transform patrolRoute; //������ ���� ����

    private int locationIndex = 0; //ó������ 0���� ����
    private NavMeshAgent Fox; //������ NavMeshAgent�� agent ������ ������ش�.

    // Start is called before the first frame update
    void Start()
    {
        Fox = GetComponent<NavMeshAgent>(); //���찡 ������ �ִ� NavMeshAgent�� �ҷ��´�
        InitializePatrolRoute(); //���찡 ������ ��ġ ����Ʈ�� ����ϱ� ���� �Լ�
        MoveToNextPatrolPoint(); //���� ��ġ�� �̵��ϱ� ���� �Լ�
    }

    // Update is called once per frame
    void Update()
    {
        if (Fox.remainingDistance < 0.2f && !Fox.pathPending) //���찡 ������ġ���� ������ ����, ���찡 ���� ���°� �ƴҶ�
        {
            MoveToNextPatrolPoint(); //���� ������ ���������� �̵�
        }
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute) //��ġ�� ������ patrolRoute �ȿ� �ִ� child ������
        {
            locations.Add(child); //child�� �����Ѵ�.
        }
    }
    void MoveToNextPatrolPoint()
    {
        Fox.destination = locations[locationIndex].position; //���� ����Ʈ�� �̵��ϱ� ���� �Լ� �ڵ�

        locationIndex = (locationIndex + 1) % locations.Count; //�ݺ������� �̵��� �� �ְ� �ϴ� �Լ� �ڵ�
    }
}
