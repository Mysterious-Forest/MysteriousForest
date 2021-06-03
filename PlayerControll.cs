using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //���ǵ� ���� ����
    [SerializeField] //walkSpeed�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float walkSpeed; //�ȴ� �ӵ� ���� ����

    [SerializeField] //runSpeed�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float runSpeed; //�޸��� �ӵ� ���� ����

    private float applySpeed; //�ȴ� �ӵ��� �޸��� �ӵ��� ������ �� �ֵ��� �ϴ� ���� ����

    [SerializeField] //jumpForce�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float jumpForce; //���� ���� ����

    //���� ����
    private bool isRun = false; //�ٴ��� �ȶٴ��� ���¸� Ȯ�����ִ� ���� �ڵ�
    private bool isGround = true; //���� �ִ��� ������ ���¸� Ȯ�����ִ� ���� �ڵ�


    private CapsuleCollider capsuleCollider; //�� ���� ����

    //�ΰ���
    [SerializeField] //lookSensitivity�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float lookSensitivity; //ī�޶��� �ΰ��� ������ �����Ѵ�.

    //ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRotationLimit; //���콺�� ī�޶� ������ �� ���� ���������� �����̵��� ������ �ش�.
    private float currentCameraRotationX = 0; //ī�޶� ������ �ٶ� �� �ֵ��� ����

    //�ʿ��� ������Ʈ
    [SerializeField]
    private Camera theCamera; //Camera�� GetComponent�� �ҷ��´�.

    private Rigidbody myRigid; //Player�� Collider�� �������� ����� �ϵ��� �ϴ� ��� //Inspectorâ�� Rigidbody�߰� �� �ۼ�

    private Animator playerAnim; //Player�� �ִϸ��̼��� ����ϱ� ���� �ִϸ��̼� ������ �����Ѵ�.


    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>(); //Inspectorâ���� CapsuleCollider�� �ҷ��´�.
        myRigid = GetComponent<Rigidbody>(); //Inspectorâ���� Rigidbody�� �ҷ��´�.
        applySpeed = walkSpeed; //�޸��� ������ �ȴ� ����                            
        playerAnim = GameObject.Find("TT_demo_male_B").GetComponent<Animator>(); //Inspectorâ���� Animator�� �ҷ��´�.
    }




    // Update is called once per frame
    void Update()
    {
        IsGround(); //���� �����ϰ� �ִ��� ���� �ʴ��� �����ϱ� ���� �ڵ� �ۼ� �� �Լ� ����
        TryJump(); //������ ���� �� �����ϱ� ���� �ڵ� �ۼ� �� �Լ� ����
        TryRun(); //�ٴ��� �ȴ��� �����ϱ� ���� �ڵ� �ۼ� �� �Լ� ����(������ ����)
        Move(); //Ŭ���� �ϸ� �ǽð����� �����̵��� �ϴ� �ڵ带 �ۼ��ϱ� ���� �Լ� ����
        CameraRotation(); //ī�޶� ������ �Լ� ����
        CharacterRotation(); //ĳ���� ������ �Լ� ����

    }

    // ���� üũ.
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f); //Player�� Y�� �������� 0.1 �Ÿ� ��ŭ �������� ��� Player�� ���� ����� ���� �ʴ��� ���� �ν�(���� ������ ����)
    }

    // ���� �õ�
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //SpaceŰ�� �������� Player�� ���� �����ϰ� ������
        {
            Jump();
        }
    }

    // ����
    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce; //Player�� �����ӿ��� Y������ ������ ���� ����ŭ �����ϵ��� �Ѵ�.
    }

    //�޸��� �õ�
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //���� Shift Ű�� ������
        {
            Running(); //�޸��Ⱑ �����
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //���� ShiftŰ�� �ö�ö���� ��
        {
            RunningCancel(); //�޸��� �ʴ´�.
        }
    }

    // �޸��� ����
    private void Running()
    {
        isRun = true; //�޸��� ����
        applySpeed = runSpeed; //�ȴ� �ӵ��� �޸��� �ӵ��� �ٲ��.
    }
    // �޸��� ���
    private void RunningCancel()
    {
        isRun = false; //�޸��Ⱑ ������� �ʵ��� �Ѵ�.
        applySpeed = walkSpeed; //�޸��� �ӵ��� �ȴ� �ӵ��� �ٲ��.
    }

    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal"); //A,D�� ������ ��
        float _moveDirZ = Input.GetAxisRaw("Vertical"); //W,S�� ������ ��

        Vector3 _moveHorizontal = transform.right * _moveDirX; //Player�� transform X���� �̿��Ͽ� ��, �� �̵��ϵ��� ����
        Vector3 _moveVertical = transform.forward * _moveDirZ; //Player�� transform Z���� �̿��Ͽ� ��, �� �̵��ϵ��� ����

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed; //�ӵ��� ������ �����̸� �ӵ����� ���Ͽ� �󸶳� ���� �̵��� ������ �����Ѵ�.

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime); //Rigidbody�� ������ �Լ��� �����Ͽ� Player�� ��ġ�� �ӵ��� �����ְ�, 1�ʵ��� �ӵ���ŭ �����̰� �ϰڴ�.

        if (_moveDirZ > 0.05f || _moveDirZ < -0.05f) //���� A,D�� ������ ������
        {
            playerAnim.SetBool("Run", true); //�پ��
        }
        else
        {
            playerAnim.SetBool("Run", false); //�����
        }

        if (Input.GetMouseButtonDown(0)) //���� ���콺 ��ư�� ������
        {
            playerAnim.SetBool("Hit", true); //������ �ִϸ��̼��� ����
        }

        if (Input.GetMouseButtonUp(0)) //���� ���콺 ��ư�� �ö����
        {
            playerAnim.SetBool("Hit", false); //������ �ִϸ��̼��� �����
        }

    }


    private void CharacterRotation()
    {
        // �¿� ĳ���� ȸ��
        float _yRotation = Input.GetAxisRaw("Mouse X");  //���콺�� �� ��� �������� ��, ī�޶� �� ��(Y��)���� �����δ�.
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity; //ī�޶� õõ�� �����̵��� �����Ѵ�.
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY)); //Player�� ȸ������ õõ�� �����̵��� ������ ī�޶� ���� ���Ͽ� ȸ���ϵ��� �Ѵ�.
    }

    private void CameraRotation()
    {
        //�� �� ī�޶� ȸ��
        float _xRotation = Input.GetAxisRaw("Mouse Y"); //���콺�� �� �ڷ� �������� ��, ī�޶� �� ��(X��)���� �����δ�.
        float _cameraRotationX = _xRotation * lookSensitivity; //ī�޶� õõ�� �����̵��� �����Ѵ�.
        currentCameraRotationX -= _cameraRotationX; //���� ī�޶� �������� ���콺�� �� �ڷ� �����̴� ���� ���� �����δ�.
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //cameraRotationLimit�� �ִ�, �ּҰ��� �����Ѵ�.(������ ������ŭ �̻� �������� ���ϵ��� ������ �д�.)

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //���� ī�޶� �����Ű�� ���� ������ �Ѵ�. ���콺�� �� �ڷ� �������� �� ī�޶� �� ��(X��)�θ� �����̵��� �����Ѵ�.
    }
}