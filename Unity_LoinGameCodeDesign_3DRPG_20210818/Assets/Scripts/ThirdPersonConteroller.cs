using UnityEngine;  //引用 Unity API
using UnityEngine.Video;

/// <summary>
/// 2021.0906
/// 第三人稱控制器
/// 移動.跳躍
/// </summary>

public class ThirdPersonConteroller : MonoBehaviour
{

    /** 課堂練習 控制器方法

   // 摺疊 Cart + M O  展開 Cart + M L
   /// <summary>
   /// 移動
   /// </summary>
   /// <param name="moveSpeed">移動速度</param>
   private void move(float moveSpeed)
   {
       
   }
   /// <summary>
   /// 移動按鍵輸入
   /// </summary>
   /// <returns>移動按鍵值</returns>
   private float moveKey()
   {
       return 0f;
   }
   /// <summary>
   /// 檢查地板
   /// </summary>
   /// <returns>是否碰到地板</returns>
   private bool groundCheck()
   {
       return false;
   }
   /// <summary>
   /// 跳躍
   /// </summary>
   private void jump()
   {

   }
   /// <summary>
   /// 更新動畫
   /// </summary>
   private void animationUpdate()
   {

   }

   **/






    #region 欄位 Field
    //儲存遊戲資料，例如：移動速度.跳躍高度等等...
    //常用四大類型：整數int.浮點數float.字串string.布林值bool
    //欄位語法：修飾詞 資料類型 欄位名稱(指定 預設值) 結尾
    //修飾詞：
    //1. 公開 public  - 允許所有類別存取 - 顯示在屬性面板 - 需要調整
    //2. 私人 private - 禁止其他類別存取 - 隱藏在屬性面板
    // Unity 以屬性面板資料為主
    // 欄位屬性 Attribute：輔助欄位資料
    // 欄位屬性與法：[屬性名稱(屬性值)]
    //Header標題 Tooltip滑鼠停留提示 Range範圍
    private AudioSource aud;
    private Rigidbody rig;
    private Animator anim;

    

    [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(0,500)]
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
    /** 練習 Unity 資料類型
    // 顏色 Color
    public Color color;
    public Color white = Color.white; //內建顏色
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0); //自訂顏色RGB或RGBA
    public Color color2 = new Color(0, 0.5f, 0.5f,0.5f);

    // 座標 Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v20ne = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1,2,3);
    public Vector4 v4 = new Vector4(1,2,3,4);

    // 按鍵 列舉資料 enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    // 遊戲資料類型：不能指定預設值
    //存放 Project 專案內資料
    public AudioClip sound; //音效 mp3 ogg wav
    public VideoClip video; //影片 mp4
    public Sprite sprite; // 圖片 png jpeg - 不支援gif
    public Material material; //材質球

    // 元件 Component：屬性面板上可折疊
    [Header("元件")]
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera cam;

    //綠色蚯蚓 1.建議不要用的名稱 2.使用過時API
    **/



    #endregion

    #endregion

    #region 屬性 Property
    /** 屬性練習
    //儲存資料與欄位相同
    //差異在於：可以設定存取權限 Get Set
    //屬性語法：修飾詞 資料類型 屬性名稱 { 取; 存; }
    public int readAndWritr { get; set; }

    public int read { get; } //唯讀屬性：只能取得 get

    public int readValue //唯讀屬性：透過get設定預設值,return為傳回值
    {
        get
        {
            return 77;
        }
    }
    //唯寫屬性禁止單獨set
    private int _hp;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    */

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

    #endregion

    #region 方法 Method

    //定義與實作較複雜程式的區塊.功能
    //方法語法：修飾詞 傳回資料類型 方法名稱 (參數1,參數N){程式區塊}
    //常用傳回類型：無傳回 void - 此方法沒有傳回資料

    //格式自動排版快捷鍵 Ctrl+ K D

    //名稱淡黃-沒被呼叫  名稱亮黃-有被呼叫
    private void Test()
    {
        print("我是自訂方法~");
    }

    private int ReturnJump()
    {
        return 999;
    }

    //降低維護與擴充性的方法↓ 資料類型 參數名稱
    //有預設值的參數可以不輸入引數，選填式參數
    //＊選填式參數只能放在()右邊
    private void Skill(int damage, string effect = "灰塵特效",string sound = "嘎嘎嘎")
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

    //對照組 不使用參數↓
    /**對照組
    private void Skill100()
    {
        print("傷害值" + 100);
        print("技能特效");
    }
    private void Skill200()
    {
        print("傷害值" + 200);
        print("技能特效");
    }
    **/
    #endregion

    #region 事件 Event
    // 特定時間點會執行的方法

    // BMI = 體重 / 身高 * 身高 (公尺)
    /// <summary>
    /// 計算BMI的方法
    /// </summary>
    /// <param name="weight">體重，單位為公斤</param>
    /// <param name="height">身高，單位為公分</param>
    /// <param name="name">名子</param>
    /// <returns></returns>
    private float BMI(float weight,float height,string name = "測試")
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
        /**屬性輸出練習
        // 欄位與屬性 取得 Get 設定Set
        print("欄位資料 - 移動速度：" + speed);
        print("屬性資料 - 讀寫速度：" + readAndWritr);
        speed = 20.5f;
        readAndWritr = 90;
        print("修改後的資料");
        print("欄位資料 - 移動速度：" + speed);
        print("欄位資料 - 移動速度：" + readAndWritr);

        print("唯讀屬性：" + read);
        print("唯讀屬性.有預設值：" + readValue);

        //屬性存取練習
        print("HP：" + hp);
        hp = 100;
        print("HP：" + hp);
        */
        //呼叫自訂方法語法：方法名稱();
        Test();
        //呼叫方式
        //1.區域變數 -僅能在大括號內存取
        int j = ReturnJump();
        print("跳躍值" + j);
        //2.將傳回方法當成值使用
        print("跳躍值.當值使用" + (ReturnJump() + 1));

        
        //有參數的版本↓
        Skill(300);
        Skill(999,"爆炸特效");
        Skill(500, sound:"咻咻咻");
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
        if(CheckGround() && KeyJump)
        {
            rig.AddForce(transform.up * jump);
        }

    }

    private void UpdataAnimation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool(animatroParWalk, true);
        } else
        anim.SetBool(animatroParWalk, false);

        anim.SetBool(animatroParIsGround, Isground);

        if (KeyJump) anim.SetTrigger(animatroParJump);
    }

    #endregion
}
