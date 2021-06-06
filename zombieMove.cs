using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieMove : MonoBehaviour
{
    public List<Transform> locations; //���� ������ ��ġ ����
    public Transform patrolRoute; //������ ���� ����
    public Transform player; //Player ������

    private int locationIndex = 0; //ó������ 0���� ����
    private NavMeshAgent zombie; //������ NavMeshAgent ������ ������ش�.
    private AudioSource zombiedie; //���� �Ҹ� ���� ����

    private GameManger gameManager;

     private int lives = 3;

    void OnCollisionEnter(Collision col) //Collider�� �߻��� �浹�� �����ϴ� �Լ� ����
    {
        if (col.gameObject.tag == "bullet") //���� ���ƿ��� ��ü�� �Ѿ��̶��
        {
            lives -= 1; //���� ü���� 1 �پ���.
            zombiedie.Play(); //�״� �Ҹ� ���
            Debug.Log("Hit!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform; //player�� �ҷ��´�.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManger>();
        zombiedie = GetComponent<AudioSource>(); //���� ������ �ִ� �Ҹ��� �ҷ��´�.
        zombie = GetComponent<NavMeshAgent>(); //���� ������ �ִ� NavMeshAgent�� �ҷ��´�.
        patrolRoute = GameObject.Find("Route1").transform; //������ ��ġ�� ���� �������� Route1�� �ҷ��´�.
        InitializePatrolRoute(); //���� ������ ��ġ ����Ʈ�� ����ϱ� ���� �Լ�
        MoveToNextPatrolPoint(); //���� ��ġ�� �̵��ϱ� ���� �Լ�
    }

    // Update is called once per frame
    void Update()
    {
        if (zombie.remainingDistance < 0.1f && !zombie.pathPending) //���� ������ġ���� ������ ����, ���� ���� ���°� �ƴҶ�
        {
            MoveToNextPatrolPoint(); //���� ������ ���������� �̵�
        }

        if (lives <= 0) //���� ü���� 0�̶��
        {
            GameObject.Find("zombie(Clone)").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject); //����� �������.

            if (this.gameObject.name == "zombie(Clone)")
            {
                gameManager.Score += 1;
            }
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
        zombie.destination = locations[locationIndex].position; //���� ����Ʈ�� �̵��ϱ� ���� �Լ� �ڵ�

        locationIndex = (locationIndex + 1) % locations.Count; //�ݺ������� �̵��� �� �ְ� �ϴ� �Լ� �ڵ�
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            zombie.destination = player.position;
        }
    }
}
