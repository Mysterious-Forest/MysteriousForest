using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField] private float isTime; //���� �ð��� ���� �ð��� �޶�� �ϱ� ������ ���� ����

    private bool Night = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * isTime * Time.deltaTime); //���� x�� �������� �����̵��� ����
    }
}
