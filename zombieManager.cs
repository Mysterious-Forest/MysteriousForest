using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    float currentTime; //�ð��� ������ �� �ִ� ���� ����
    public float createTime = 1.0f; //������ �ð��� �����ǵ��� ����
    public GameObject zombie; // ����� ���� ���� ������Ʈ ����
    public float minTime = 5.0f; //���� ���� ��Ÿ���� �ð�
    public float maxTime = 15.0f; //���� �ʰ� ��Ÿ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f; //ó������ 0���� ����
        createTime = UnityEngine.Random.Range(minTime, maxTime); //������ �ð� ���̿� �������� �������� ����
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //�ѹ� �����ǰ�, �ɸ��� �ð�

        if (currentTime > createTime) //������ �ð��� �Ѿ��� ��,
        {
            GameObject newzombie = Instantiate(zombie); //���ӿ�����Ʈ�� ���ο� ���� �����ȴ�.
            newzombie.transform.position = transform.position; //��ġ�� zombieManager���� ������ ��ġ�� �Ѵ�.

            currentTime = 0.0f; //������Ʈ�� ������ 1�ʸ� ���� ������� �����ȴ�.
            createTime = UnityEngine.Random.Range(minTime, maxTime); //�ٽ� �����ϸ� �������� ���� �����ϵ��� �ݺ�
        }
    }
}
