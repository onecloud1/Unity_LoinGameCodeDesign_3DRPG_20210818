using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//認識API:非靜態 Non Static
public class APInoStatic : MonoBehaviour
{
    public Transform tra1;
    public Camera cam;
    public Light lig;

    private void Start()
    {
        #region 非靜態屬性
        //與靜態差異
        //1.需要實體物鍵
        //2.取得實體物件 - 定義欄位並將要存取的物件存入欄位
        //3. 遊戲物件.元件必須存在場景內
        //取得 Get
        //語法:欄位名稱.非靜態屬性
        Debug.Log("攝影機的座標" + tra1.position);
        Debug.Log("攝影機的深度" + cam.depth);

        tra1.position = new Vector3(99, 99, 99);
        cam.depth = 7;
        #endregion

        #region 非靜態方法
        //呼叫
        //語法:
        //欄位名稱.非靜態方法名稱(對應引數)
        lig.Reset();
        #endregion
    }

}
