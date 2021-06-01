using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] //walkSpeed를 Inspector창에서 수정 가능하도록 하는 기능
    private float walkSpeed; //걷는 속도 변수 설정

    [SerializeField] //lookSensitivity를 Inspector창에서 수정 가능하도록 하는 기능
    private float lookSensitivity; //카메라의 민감도 변수를 설정한다.


    [SerializeField]
    private float cameraRotationLimit; //마우스로 카메라를 조절할 때 일정 각도까지만 움직이도록 제한을 준다.
    private float currentCameraRotationX = 0; //카메라가 정면을 바라볼 수 있도록 설정


    [SerializeField]
    private Camera theCamera; //Camera의 GetComponent를 불러온다.

    private Rigidbody myRigid; //Player의 Collider에 물리적인 기능을 하도록 하는 기능 //Inspector창에 Rigidbody추가 후 작성


    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody>(); //Inspector창에서 Rigidbody를 불러온다.
    }




    // Update is called once per frame
    void Update()
    {

        Move(); //클릭을 하면 실시간으로 움직이도록 하는 코드를 작성하기 위한 함수 정의
        CameraRotation(); //카메라 움직임 함수 정의
        CharacterRotation(); //Player 움직임 함수 정의

    }

    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal"); //A,D를 눌렀을 때
        float _moveDirZ = Input.GetAxisRaw("Vertical"); //W,S를 눌렀을 때

        Vector3 _moveHorizontal = transform.right * _moveDirX; //Player의 transform X축을 이용하여 좌, 우 이동하도록 정의
        Vector3 _moveVertical = transform.forward * _moveDirZ; //Player의 transform Z축을 이용하여 앞, 뒤 이동하도록 정의

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed; //속도는 방향이 움직이면 속도값을 곱하여 얼마나 빨리 이동할 것인지 설정한다.

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime); //Rigidbody에 움직임 함수를 정의하여 Player의 위치에 속도를 더해주고, 1초동안 속도만큼 움직이게 하겠다.
    }


    private void CharacterRotation()
    {
        // 좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");  //마우스를 좌 우로 움직였을 때, 카메라가 좌 우(Y축)으로 움직인다.
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity; //카메라가 천천히 움직이도록 설정한다.
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY)); //Player의 회전값에 천천히 움직이도록 설정한 카메라 값을 곱하여 회전하도록 한다.
    }

    private void CameraRotation()
    {
        //상 하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y"); //마우스를 앞 뒤로 움직였을 때, 카메라가 상 하(X축)으로 움직인다.
        float _cameraRotationX = _xRotation * lookSensitivity; //카메라가 천천히 움직이도록 설정한다.
        currentCameraRotationX -= _cameraRotationX; //현재 카메라 움직임은 마우스를 앞 뒤로 움직이는 값에 따라 움직인다.
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //cameraRotationLimit의 최대, 최소값을 결정한다.(설정한 각도만큼 이상 움직이지 못하도록 제한을 둔다.)

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //실제 카메라에 적용시키기 위한 설정을 한다. 마우스를 앞 뒤로 움직였을 때 카메라가 상 하(X축)로만 움직이도록 설정한다.
    }

}
