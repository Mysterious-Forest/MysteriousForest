using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float bulletTime = 1.0f; //총알이 사라지는 시간 변수 설정

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime); //설정한 시간에 총알이 사라지게 하기
    }

}
