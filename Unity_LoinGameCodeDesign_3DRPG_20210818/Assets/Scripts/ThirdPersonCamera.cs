using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//第三人稱攝影機系統.追蹤指定目標並且可左右轉.上下轉(限制)
public class ThirdPersonCamera : MonoBehaviour
{
    #region 欄位
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 500)]
    public float speedTrack = 1.5f;
    [Header("旋轉左右速度"), Range(0, 100)]
    public float speedTurnHorizontal = 5;
    [Header("旋轉上下速度"), Range(0, 100)]
    public float speedTurnVertical = 5;
    [Header("X 軸上下旋轉限制")]
    public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);

    //攝影機前方座標
    public Vector3 _posForward;
    private float lenthForward = 3;

    #endregion

    #region 屬性

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

    #region 事件
    private void Update()
    {
        TurnCamera();
    }
    //Update後執行,適合攝影機使用
    private void LateUpdate()
    {
        TrackTarget();

        LimitAngleX();
        
        FreezeAngleZ();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
        //前方座標= 此物件座標+此物件前方 *長度
        _posForward = transform.position + transform.forward * lenthForward;
        //前方座標.y = 目標.座標.y(讓前方座標高度與目標相同)
        _posForward.y = target.position.y;
        Gizmos.DrawSphere(_posForward, 0.15f);
    }


    #endregion

    #region 方法
    //追蹤目標
    private void TrackTarget()
    {
        Vector3 posTarget = target.position;    //取得 目標 座標
        Vector3 posCamera = transform.position; //取得 攝影機 座標

        posCamera = Vector3.Lerp(posCamera, posTarget, speedTrack * Time.deltaTime); //攝影機座標 = 插值

        transform.position = posCamera; // 此物件的座標 = 攝影機座標
    }

    #endregion

    //旋轉攝影機
    private void TurnCamera()
    {
        transform.Rotate(
            inputMouseY * Time.deltaTime * speedTurnVertical,
            inputMouseX * Time.deltaTime * speedTurnHorizontal, 0);
    }
    
    private void LimitAngleX()
    #region 限制上下旋轉角度 X軸
    {
        Quaternion angle = transform.rotation; // 取得四位元角度
        angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y); //夾住角度 X 軸
        transform.rotation = angle; //更新物件角度
    }

    #endregion

    private void FreezeAngleZ()
    {
        Vector3 angle = transform.eulerAngles;
        angle.z = 0;
        transform.eulerAngles = angle;
    }
}
