using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    float currentTime; //시간을 저장할 수 있는 변수 정의
    public float createTime = 1.0f; //설정한 시간에 생성되도록 설정
    public GameObject zombie; // 대상은 좀비 게임 오브젝트 생성
    public float minTime = 5.0f; //가장 먼저 나타나는 시간
    public float maxTime = 15.0f; //가장 늦게 나타나는 시간

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f; //처음에는 0부터 시작
        createTime = UnityEngine.Random.Range(minTime, maxTime); //설정한 시간 사이에 랜덤으로 나오도록 설정
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //한번 생성되고, 걸리는 시간

        if (currentTime > createTime) //설정한 시간이 넘었을 때,
        {
            GameObject newzombie = Instantiate(zombie); //게임오브젝트의 새로운 좀비가 생성된다.
            newzombie.transform.position = transform.position; //위치는 zombieManager에서 설정한 위치로 한다.

            currentTime = 0.0f; //업데이트할 때마다 1초를 세는 방법으로 생성된다.
            createTime = UnityEngine.Random.Range(minTime, maxTime); //다시 생성하면 랜덤으로 좀비를 생성하도록 반복
        }
    }
}
