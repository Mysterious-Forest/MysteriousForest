using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //스피드 조정 변수
    [SerializeField] //walkSpeed를 Inspector창에서 수정 가능하도록 하는 기능
    private float walkSpeed; //걷는 속도 변수 설정

    [SerializeField] //runSpeed를 Inspector창에서 수정 가능하도록 하는 기능
    private float runSpeed; //달리는 속도 변수 설정

    private float applySpeed; //걷는 속도와 달리는 속도를 대입할 수 있도록 하는 변수 설정

    [SerializeField] //jumpForce를 Inspector창에서 수정 가능하도록 하는 기능
    private float jumpForce; //점프 변수 설정

    //상태 변수
    private bool isRun = false; //뛰는지 안뛰는지 상태를 확인해주는 변수 코드
    private bool isGround = true; //땅에 있는지 없는지 상태를 확인해주는 변수 코드


    private CapsuleCollider capsuleCollider; //땅 착지 여부

    //민감도
    [SerializeField] //lookSensitivity를 Inspector창에서 수정 가능하도록 하는 기능
    private float lookSensitivity; //카메라의 민감도 변수를 설정한다.

    //카메라 한계
    [SerializeField]
    private float cameraRotationLimit; //마우스로 카메라를 조절할 때 일정 각도까지만 움직이도록 제한을 준다.
    private float currentCameraRotationX = 0; //카메라가 정면을 바라볼 수 있도록 설정

    public GameObject bullet;
    public float bulletspeed = 10.0f;
    private AudioSource audioBullet;

    private bool pon1;
    private bool pon2;
    private bool pon3;


    public GameObject[] weapon;

    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera; //Camera의 GetComponent를 불러온다.

    private Rigidbody myRigid; //Player의 Collider에 물리적인 기능을 하도록 하는 기능 //Inspector창에 Rigidbody추가 후 작성

    private Animator playerAnim; //Player의 애니메이션을 사용하기 위해 애니메이션 변수를 설정한다.


    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>(); //Inspector창에서 CapsuleCollider를 불러온다.
        myRigid = GetComponent<Rigidbody>(); //Inspector창에서 Rigidbody를 불러온다.
        audioBullet = GetComponent<AudioSource>();
        applySpeed = walkSpeed; //달리기 전까지 걷는 상태                            
        playerAnim = GameObject.Find("Player").GetComponent<Animator>(); //Inspector창에서 Animator를 불러온다.
    }




    // Update is called once per frame
    void Update()
    {
        IsGround(); //땅에 착지하고 있는지 하지 않는지 제어하기 위한 코드 작성 전 함수 정의
        TryJump(); //점프를 실행 및 제어하기 위한 코드 작성 전 함수 정의
        TryRun(); //뛰는지 걷는지 제어하기 위한 코드 작성 전 함수 정의(움직임 제어)
        Move(); //클릭을 하면 실시간으로 움직이도록 하는 코드를 작성하기 위한 함수 정의
        CameraRotation(); //카메라 움직임 함수 정의
        CharacterRotation(); //캐릭터 움직임 함수 정의
        Swap();

        if (Input.GetMouseButtonDown(1))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation) as GameObject; //총알이 Player에서 나오도록하기
            Rigidbody rbBullet = newBullet.GetComponent<Rigidbody>(); //총알의 Rigidbody불러오기
            rbBullet.velocity = transform.forward * bulletspeed; //총알이 Player 앞에 나오도록 하기
        }


    }
    void GetInput()
    {
        pon1 = Input.GetButtonDown("1");
        pon2 = Input.GetButtonDown("2");

        Debug.Log("dd");
    }

    void Swap()
    {
        int weaponIndex = -1;
        if (pon1) weaponIndex = 0;
        if (pon2) weaponIndex = 1;

        if (pon1 || pon2)
        {
            weapon[weaponIndex].SetActive(true);
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

        if (_moveDirZ > 0.05f || _moveDirZ < -0.05f) //만약 A,D를 누르고 있으면
        {
            playerAnim.SetBool("Run", true); //뛰어라
        }
        else
        {
            playerAnim.SetBool("Run", false); //멈춰라
        }


        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼을 누르면
        {
            playerAnim.SetBool("Hit", true); //때리는 애니메이션을 실행
        }

        if (Input.GetMouseButtonUp(0)) //왼쪽 마우스 버튼이 올라오면
        {
            playerAnim.SetBool("Hit", false); //때리는 애니메이션을 멈춰라
        }

        if (Input.GetMouseButtonDown(1)) //오른쪽 마우스 버튼을 누르면
        {
            playerAnim.SetBool("Dig", true); //총쏘는 애니메이션을 실행
            audioBullet.Play();
        }

        if (Input.GetMouseButtonUp(1)) //오른쪽 마우스 버튼이 올라오면
        {
            playerAnim.SetBool("Dig", false); //총쏘는 애니메이션을 멈춰라
        }

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
