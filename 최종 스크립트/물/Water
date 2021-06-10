using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public static bool isWater = false; //물속여부 판단

    [SerializeField] private float waterDrag; //물속 중력
    private float orignDrag; //물밖으로 나오면 원래 저항값으로 돌아가기

    [SerializeField] private Color WaterColor; //물속 색깔
    [SerializeField] private float waterFogDensity; //물 탁함 정도

    private Color originColor; //물밖에 나왔을 때 원래대로 돌아오게 하는 변수 지정
    private float originFogDensity; //물밖에 나왔을 때 원래대로 돌아오게 하는 변수 지정

    private GameManger2 gameManager; //Player체력을 사용하기 위한 변수 설정

    // Start is called before the first frame update
    void Start()
    {
        originColor = RenderSettings.fogColor; //처음 색 값
        originFogDensity = RenderSettings.fogDensity; //처음 색 값
        gameManager = GameObject.Find("GameManager2").GetComponent<GameManger2>(); //GameManager2를 불러온다.

        orignDrag = 0; //물의 저항을 0으로 시작한다.
    }

    // Update is called once per frame
    void Update()
    {
 
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player") //만약 강에 Player가 들어오면
        {
            GetWater(other); //GetWater를 불러온다.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player") //만약 강에서 Player가 나가면
        {
            GetOutWater(other); //GetOutWater를 불러온다.
        }
    }

    private void GetWater(Collider _player) //물에 들어갔을 때
    {
        isWater = true; //물에 들어갔을 때 실행
        _player.transform.GetComponent<Rigidbody>().drag = waterDrag; //player의 저항을 물의 저항으로 바꿔준다.(천천히 갈아앉음)

        gameManager.HP -= 1;

        RenderSettings.fogColor = WaterColor; //물에 들어갔을 때 주변 색을 바꿔준다.
        RenderSettings.fogDensity = waterFogDensity; //물에 들어갔을 때 주변 색을 바꿔준다.
    }

    private void GetOutWater(Collider _player) //물을 빠져나왔을 때
    {
 

        isWater = false; //물에 나왔을 때
        _player.transform.GetComponent<Rigidbody>().drag = orignDrag; //player의 저항으로 바꿔준다.

        RenderSettings.fogColor = originColor; //물에서 나왔을 때 주변 색을 다시 원래대로 바꿔준다.
        RenderSettings.fogDensity = originFogDensity; //물에서 나왔을 때 주변 색을 다시 원래대로 바꿔준다.
    }
}
