using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float bulletTime = 1.0f; //�Ѿ��� ������� �ð� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime); //������ �ð��� �Ѿ��� ������� �ϱ�
    }

}
