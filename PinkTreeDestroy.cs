using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTreeDestroy : MonoBehaviour
{
    public ParticleSystem Pinktree; //������ ������ ��, ����Ʈ ������ �����ϴ� ������ �����Ѵ�.
    public GameObject tomato; //������ �������� ������ ���ξ����� �������� �ϴ� ���� ����
    public Transform PinkTreePost; //������ ������ ��ġ�� ���ξ����� ���������ϴ� ���� ����

    int PinkTreeHp = 3; //������ ü�º��� �����Ѵ�.

    void OnCollisionEnter(Collision col) //Collider�� �߻��� �浹�� �����ϴ� �Լ� ����
    {
        if (col.gameObject.name == "w_sword_B") //���� �浹�ϴ� ��ü�� Į�̶��
        {
            PinkTreeHp -= 1; //������ ü���� 1 �پ���.
            Debug.Log("Tree Hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PinkTreeHp == 0) //���� ������ ü���� 0�̶��
        {
            Destroy(gameObject); //������ �������.
            Debug.Log("Tree DIE!");
            Instantiate(tomato, PinkTreePost.position, PinkTreePost.rotation); //������ ������ �ڸ��� ���ξ����� �ߴ� �Լ� �ڵ�
        }
    }
}
