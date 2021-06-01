using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //스피드 조정 변수
    [SerializeField] //walkSpeed를 Inspector창에서 수정 가능하도록 하는 기능
    private float walkSpeed; //걷는 속도 변수 설정

    [SerializeField] //runSpeed를 Inspector창에서 수정 가능하도록 하는 기능
    private float runSpeed; //달리는 속도 변수 설정

    [SerializeField]
    private float crouchSpeed;//앉는 속도 변수 설정

    private float applySpeed; //걷는 속도와 달리는 속도를 대입할 수 있도록 하는 변수 설정

    [SerializeField] //jumpForce를 Inspector창에서 수정 가능하도록 하는 기능
    private float jumpForce; //점프 변수 설정

    //상태 변수
    private bool isRun = false; //뛰는지 안뛰는지 상태를 확인해주는 변수 코드
    private bool isCrouch = false; //앉았는지 앉지 않았는지 상태를 확인해주는 변수 코드
    private bool isGround = true; //땅에 있는지 없는지 상태를 확인해주는 변수 코드

    // 앉았을 때 얼마나 앉을지 결정하는 변수.
    [SerializeField]
    private float crouchPosY; //숙였을 때의 변수
    private float originPosY; //숙였다가 다시 원래 상태로 돌아오게 하는 변수(처음 높이)
    private float applyCrouchPosY; //숙였을 때와 다시 원래 상태로 돌아오게 하는 변수를 대입할 수 있도록 하는 변수 설정

    private CapsuleCollider capsuleCollider; //땅 착지 여부

    //민감도
    [SerializeField] //lookSensitivity를 Inspector창에서 수정 가능하도록 하는 기능
    private float lookSensitivity; //카메라의 민감도 변수를 설정한다.

    //카메라 한계
    [SerializeField]
    private float cameraRotationLimit; //마우스로 카메라를 조절할 때 일정 각도까지만 움직이도록 제한을 준다.
    private float currentCameraRotationX = 0; //카메라가 정면을 바라볼 수 있도록 설정

    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera; //Camera의 GetComponent를 불러온다.

    private Rigidbody myRigid; //Player의 Collider에 물리적인 기능을 하도록 하는 기능 //Inspector창에 Rigidbody추가 후 작성


    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>(); //Inspector창에서 CapsuleCollider를 불러온다.
        myRigid = GetComponent<Rigidbody>(); //Inspector창에서 Rigidbody를 불러온다.
        applySpeed = walkSpeed; //달리기 전까지 걷는 상태                            
        originPosY = theCamera.transform.localPosition.y; //카메라의 Y축 위치를 앉는 여부에 따라 움직이도록 설정
        applyCrouchPosY = originPosY; //Player가 기본적으로 서있는 상태
    }




    // Update is called once per frame
    void Update()
    {
        IsGround(); //땅에 착지하고 있는지 하지 않는지 제어하기 위한 코드 작성 전 함수 정의
        TryJump(); //점프를 실행 및 제어하기 위한 코드 작성 전 함수 정의
        TryRun(); //뛰는지 걷는지 제어하기 위한 코드 작성 전 함수 정의(움직임 제어)
        TryCrouch(); //앉는 여부를 제어하기 위한 코드 작성 전 함수 정의
        Move(); //클릭을 하면 실시간으로 움직이도록 하는 코드를 작성하기 위한 함수 정의
        CameraRotation(); //카메라 움직임 함수 정의
        CharacterRotation(); //캐릭터 움직임 함수 정의

    }

    // 앉기 시도
    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) //왼쪽 Control를 눌렀을 때
        {
            Crouch(); //앉도록 실행
        }
    }

    // 앉기 동작
    private void Crouch()
    {
        isCrouch = !isCrouch; //isCrouch가 true이거나, false이거나

        if (isCrouch) //앉을 경우
        {
            applySpeed = crouchSpeed; //applySpeed를 앉는 속도로 바꾼다.
            applyCrouchPosY = crouchPosY; //앉았을 때 crouchPosY 실행
        }
        else //일어섰을 경우
        {
            applySpeed = walkSpeed; //applySpeed를 걷는 속도로 바꾼다.
            applyCrouchPosY = originPosY; //섰을 때 originPosY 실행
        }

        StartCoroutine(CrouchCoroutine()); //CrouchCoroutine을 실행시켜준다.

        IEnumerator CrouchCoroutine() //부드럽게 카메라 동작 실행
        {
            float _posY = theCamera.transform.localPosition.y; //_posY는 카메라의 Y축 움직임(상대적인 움직임 조정)
            int count = 0; //저장하기 위한 임시 변수 설정

            while (_posY != applyCrouchPosY) //_posY가 원하는 값이면 벗어나온다.
            {
                count++;//목표까지 도달하기 전까지 count가 하나씩 증가 한다.
                _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f); //_posY(시작)부터 applyCrouchPosY(목적지)까지 설정한 속도만큼 증가한다.
                theCamera.transform.localPosition = new Vector3(0, _posY, 0); //
                if (count > 15) //15번 도달하면
                    break; //while문을 빠져나간다.
                yield return null; // applyCrouchPosY(목적지)까지 반복한다.
            }
            theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f); //카메라 움직임 위치를 서있는 위치와 일치시켜라
        }

    }

    // 지면 체크.
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f); //Player의 Y축 방향으로 0.1 거리 만큼 레이저를 쏘아 Player가 땅에 닿는지 닿지 않는지 여부 인식(땅에 착지한 순간)
    }

    // 점프 시도
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //Space키가 눌러지고 Player가 땅에 착지하고 있으면
        {
            Jump();
        }
    }

    // 점프
    private void Jump()
    {
        // 앉은 상태에서 점프시 앉은 상태 해제.
        if (isCrouch)
            Crouch();

        myRigid.velocity = transform.up * jumpForce; //Player의 움직임에서 Y축으로 설정한 점프 힘만큼 증가하도록 한다.
    }

    //달리기 시도
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //왼쪽 Shift 키를 누르면
        {
            Running(); //달리기가 실행됨
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //왼쪽 Shift키가 올라올라왔을 때
        {
            RunningCancel(); //달리지 않는다.
        }
    }

    // 달리기 실행
    private void Running()
    {
        if (isCrouch)
            Crouch();

        isRun = true; //달리기 실행
        applySpeed = runSpeed; //걷는 속도가 달리는 속도로 바뀐다.
    }
    // 달리기 취소
    private void RunningCancel()
    {
        isRun = false; //달리기가 실행되지 않도록 한다.
        applySpeed = walkSpeed; //달리는 속도가 걷는 속도로 바뀐다.
    }

    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal"); //A,D를 눌렀을 때
        float _moveDirZ = Input.GetAxisRaw("Vertical"); //W,S를 눌렀을 때

        Vector3 _moveHorizontal = transform.right * _moveDirX; //Player의 transform X축을 이용하여 좌, 우 이동하도록 정의
        Vector3 _moveVertical = transform.forward * _moveDirZ; //Player의 transform Z축을 이용하여 앞, 뒤 이동하도록 정의

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed; //속도는 방향이 움직이면 속도값을 곱하여 얼마나 빨리 이동할 것인지 설정한다.

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
