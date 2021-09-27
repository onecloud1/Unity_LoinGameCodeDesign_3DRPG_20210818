using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//認識API靜態
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        #region 靜態屬性
        //取得 get
        //語法:
        //類別名稱.靜態屬性
        float r = Random.value;
        print("取得靜態屬性.隨機值:" + r);

        //設定 Set
        //語法:
        //類別名稱.靜態屬性 指定 值;
        //只要看到 Read Onliy 就不能設定
        //Cursor.visible = false;
        #endregion


        #region 靜態方法
        //呼叫.參數.傳回
        //簽章:參數.傳回
        //語法:
        //類別名稱.靜態方法(動應引數)
        float range = Random.Range(10.5f, 20.9f);
        print("隨機範圍 10.5 ~ 20.9" + range);

        //使用整數時不包含最大值
        float rangeInt = Random.Range(1, 3);
        print("隨機範圍 1 ~ 3" + rangeInt);
        #endregion

    }

    private void Update()
    {
        #region 靜態屬性
        //print("經過多久" + Time.timeSinceLevelLoad);
        #endregion

        #region 靜態方法
        float h = Input.GetAxis("Horizontal");
        print("水平值" + h);
    #endregion

    }

}
