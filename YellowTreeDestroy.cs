using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTreeDestroy : MonoBehaviour
{
    public ParticleSystem yellowtree; //������ ������ ��, ����Ʈ ������ �����ϴ� ������ �����Ѵ�.
    public GameObject PineApple; //������ �������� ������ ���ξ����� �������� �ϴ� ���� ����
    public Transform TreePost; //������ ������ ��ġ�� ���ξ����� ���������ϴ� ���� ����

    int YellowTreeHp = 3; //������ ü�º��� �����Ѵ�.

    void OnCollisionEnter(Collision col) //Collider�� �߻��� �浹�� �����ϴ� �Լ� ����
    {
        if (col.gameObject.name == "w_sword_B") //���� �浹�ϴ� ��ü�� Į�̶��
        {
            YellowTreeHp -= 1; //������ ü���� 1 �پ���.
            Debug.Log("Tree Hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (YellowTreeHp == 0) //���� ������ ü���� 0�̶��
        {
            Destroy(gameObject); //������ �������.
            Debug.Log("Tree DIE!");
            Instantiate(PineApple, TreePost.position, TreePost.rotation); //������ ������ �ڸ��� ���ξ����� �ߴ� �Լ� �ڵ�
        }
    }
}
