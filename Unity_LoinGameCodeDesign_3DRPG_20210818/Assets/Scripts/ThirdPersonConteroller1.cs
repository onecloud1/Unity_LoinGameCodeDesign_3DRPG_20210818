using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonConteroller1 : MonoBehaviour
{
    #region 欄位 Field
 
    private AudioSource aud;
    private Rigidbody rig;
    private Animator anim;



    [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(0, 500)]
    public float speed = 10.5f;

    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 100;

    [Header("是否在地板上"), Tooltip("角色是否踩在地板上")]
    public bool Isground = false;
    public Vector3 groundDisplacement;
    public float groundRadius = 0.2f;

    [Header("音效檔案")]
    public AudioClip jumpSound;
    public AudioClip downSound;

    [Header("動畫參數")]
    public string animatroParWalk = "Walk";
    public string animatroParRun = "Run";
    public string animatroParHurt = "hurt";
    public string animatroParDead = "death";
    public string animatroParJump = "jump";
    public string animatroParIsGround = "checkground";


    #region Unity 資料類型
   



    #endregion

    #endregion

    #region 屬性 Property

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

    #endregion

    #region 方法 Method

    
    private void Test()
    {
        print("我是自訂方法~");
    }

    private int ReturnJump()
    {
        return 999;
    }

   
    private void Skill(int damage, string effect = "灰塵特效", string sound = "嘎嘎嘎")
    {
        print("參數版本 - 傷害值" + damage);
        print("參數版本 - 技能特效" + effect);
        print("參數版本 - 音效" + sound);
    }

    //移動 speedMove移動速度
    private void Move(float speedMove)
    {   //鋼體.加速度 = 新三維向量 用加速度控制
        //使用前後左右軸向運動且保持原本地心引力
        rig.velocity =
            Vector3.forward * MoveInput("Vertical") * speedMove +
            Vector3.right * MoveInput("Horizontal") * speedMove +
            Vector3.up * rig.velocity.y;

    }
    // 移動按鍵輸入 asisName移動按鍵值
    private float MoveInput(string asisName)
    {
        return Input.GetAxis(asisName);
    }

    
    #endregion

    #region 事件 Event
    
    private float BMI(float weight, float height, string name = "測試")
    {
        print(name + "的 BMI");

        return weight / (height * height);
    }

    public GameObject platerObject;
    void Start() // 開始執行一次
    {
        #region
        print(BMI(70, 1.75f, "WEI"));

        #region 輸出方法



        #endregion
        
        Test();
        //呼叫方式
        //1.區域變數 -僅能在大括號內存取
        int j = ReturnJump();
        print("跳躍值" + j);
        //2.將傳回方法當成值使用
        print("跳躍值.當值使用" + (ReturnJump() + 1));


        //有參數的版本↓
        Skill(300);
        Skill(999, "爆炸特效");
        Skill(500, sound: "咻咻咻");
        #endregion
        // 物件欄位名稱.取得元件(類型(元件類型)) 當作 元件類型
        aud = platerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //    此腳本遊戲物件.取得元件<泛型>()
        rig = gameObject.GetComponent<Rigidbody>();
        // 取得元件
        anim = GetComponent<Animator>();

    }
    // 更新事件：約一秒執行60次
    // 處理持續性運動.移動物件.監聽玩家輸入按鍵
    void Update()
    {
        Jump();
        UpdataAnimation();
    }
    // 0.002秒執行一次
    void FixedUpdate()
    {
        Move(speed);
    }
    //繪製圖示事件
    //1.指定顏色
    //2.繪製圖形
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

        Gizmos.DrawSphere(
            transform.position +
            transform.right * groundDisplacement.x +
            transform.up * groundDisplacement.y +
            transform.forward * groundDisplacement.z,
            groundRadius);
    }

    private bool CheckGround()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position +
            transform.right * groundDisplacement.x +
            transform.up * groundDisplacement.y +
            transform.forward * groundDisplacement.z,
            groundRadius, 1 << 3);

        //Debug.Log("球體第一個碰到的物件" + hits[0].name);
        //傳回碰撞陣列數量 > 0 只要碰到指定圖層就代表在地面上

        Isground = hits.Length > 0;

        return hits.Length > 0;
    }

    private void Jump()
    {
        Debug.Log("是否在地面上" + CheckGround());
        // &&=並且
        //如果在地面上 並且 按下空白鍵就跳躍
        if (CheckGround() && KeyJump)
        {
            rig.AddForce(transform.up * jump);
        }

    }

    private void UpdataAnimation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool(animatroParWalk, true);
        }
        else
            anim.SetBool(animatroParWalk, false);

        anim.SetBool(animatroParIsGround, Isground);

        if (KeyJump) anim.SetTrigger(animatroParJump);
    }
   #endregion
}