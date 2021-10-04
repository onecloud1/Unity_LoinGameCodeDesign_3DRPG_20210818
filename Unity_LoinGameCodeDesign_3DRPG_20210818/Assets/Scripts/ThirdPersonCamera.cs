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
    #endregion

    #region 屬性
    #endregion

    #region 事件
    #endregion

    #region 方法
    #endregion
}
