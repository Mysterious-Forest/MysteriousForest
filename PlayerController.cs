using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] //walkSpeed�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float walkSpeed; //�ȴ� �ӵ� ���� ����

    [SerializeField] //lookSensitivity�� Inspectorâ���� ���� �����ϵ��� �ϴ� ���
    private float lookSensitivity; //ī�޶��� �ΰ��� ������ �����Ѵ�.


    [SerializeField]
    private float cameraRotationLimit; //���콺�� ī�޶� ������ �� ���� ���������� �����̵��� ������ �ش�.
    private float currentCameraRotationX = 0; //ī�޶� ������ �ٶ� �� �ֵ��� ����


    [SerializeField]
    private Camera theCamera; //Camera�� GetComponent�� �ҷ��´�.

    private Rigidbody myRigid; //Player�� Collider�� �������� ����� �ϵ��� �ϴ� ��� //Inspectorâ�� Rigidbody�߰� �� �ۼ�


    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody>(); //Inspectorâ���� Rigidbody�� �ҷ��´�.
    }




    // Update is called once per frame
    void Update()
    {

        Move(); //Ŭ���� �ϸ� �ǽð����� �����̵��� �ϴ� �ڵ带 �ۼ��ϱ� ���� �Լ� ����
        CameraRotation(); //ī�޶� �Լ� ����
        CharacterRotation();

    }

    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal"); //A,D�� ������ ��
        float _moveDirZ = Input.GetAxisRaw("Vertical"); //W,S�� ������ ��

        Vector3 _moveHorizontal = transform.right * _moveDirX; //Player�� transform X���� �̿��Ͽ� ��, �� �̵��ϵ��� ����
        Vector3 _moveVertical = transform.forward * _moveDirZ; //Player�� transform Z���� �̿��Ͽ� ��, �� �̵��ϵ��� ����

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed; //�ӵ��� ������ �����̸� �ӵ����� ���Ͽ� �󸶳� ���� �̵��� ������ �����Ѵ�.

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime); //Rigidbody�� ������ �Լ��� �����Ͽ� Player�� ��ġ�� �ӵ��� �����ְ�, 1�ʵ��� �ӵ���ŭ �����̰� �ϰڴ�.
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
