using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField] private float isTime; //게임 시간과 현실 시간이 달라야 하기 때문에 변수 지정

    private bool Night = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * isTime * Time.deltaTime); //빛을 x축 방향으로 움직이도록 설정
    }
}
