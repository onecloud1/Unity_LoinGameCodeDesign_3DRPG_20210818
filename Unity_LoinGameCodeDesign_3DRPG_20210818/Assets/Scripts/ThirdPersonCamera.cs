using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ĤT�H����v���t��.�l�ܫ��w�ؼШåB�i���k��.�W�U��(����)
public class ThirdPersonCamera : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ���")]
    public Transform target;
    [Header("�l�ܳt��"), Range(0, 500)]
    public float speedTrack = 1.5f;
    [Header("���४�k�t��"), Range(0, 100)]
    public float speedTurnHorizontal = 5;
    [Header("����W�U�t��"), Range(0, 100)]
    public float speedTurnVertical = 5;
    [Header("X �b�W�U���୭��")]
    public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);

    //��v���e��y��
    public Vector3 _posForward;
    private float lenthForward = 3;

    #endregion

    #region �ݩ�

    private float inputMouseX { get => Input.GetAxis("Mouse X"); }
    private float inputMouseY { get => Input.GetAxis("Mouse Y"); }

    public Vector3 posForward
    {
        get
        {
            _posForward = transform.position + transform.forward * lenthForward;
            _posForward.y = target.position.y;
            return _posForward;
        }

    }
    #endregion

    #region �ƥ�
    private void Update()
    {
        TurnCamera();
    }
    //Update�����,�A�X��v���ϥ�
    private void LateUpdate()
    {
        TrackTarget();

        LimitAngleX();
        
        FreezeAngleZ();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
        //�e��y��= ������y��+������e�� *����
        _posForward = transform.position + transform.forward * lenthForward;
        //�e��y��.y = �ؼ�.�y��.y(���e��y�а��׻P�ؼЬۦP)
        _posForward.y = target.position.y;
        Gizmos.DrawSphere(_posForward, 0.15f);
    }


    #endregion

    #region ��k
    //�l�ܥؼ�
    private void TrackTarget()
    {
        Vector3 posTarget = target.position;    //���o �ؼ� �y��
        Vector3 posCamera = transform.position; //���o ��v�� �y��

        posCamera = Vector3.Lerp(posCamera, posTarget, speedTrack * Time.deltaTime); //��v���y�� = ����

        transform.position = posCamera; // �����󪺮y�� = ��v���y��
    }

    #endregion

    //������v��
    private void TurnCamera()
    {
        transform.Rotate(
            inputMouseY * Time.deltaTime * speedTurnVertical,
            inputMouseX * Time.deltaTime * speedTurnHorizontal, 0);
    }
    
    private void LimitAngleX()
    #region ����W�U���ਤ�� X�b
    {
        Quaternion angle = transform.rotation; // ���o�|�줸����
        angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y); //������ X �b
        transform.rotation = angle; //��s���󨤫�
    }

    #endregion

    private void FreezeAngleZ()
    {
        Vector3 angle = transform.eulerAngles;
        angle.z = 0;
        transform.eulerAngles = angle;
    }
}
