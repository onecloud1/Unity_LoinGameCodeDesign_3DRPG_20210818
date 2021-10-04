using UnityEngine;  //引用 Unity API
using UnityEngine.Video;

/// <summary>
/// 2021.0906
/// 第三人稱控制器
/// 移動.跳躍
/// </summary>

public class ThirdPersonConteroller : MonoBehaviour
{

    #region 欄位 Field
   
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
    //隨機音量
    private float volumeRamdom { get => Random.Range(0.7f, 1.2f); }

    [Header("動畫參數")]
    public string animatroParWalk = "Walk";
    public string animatroParRun = "Run";
    public string animatroParHurt = "hurt";
    public string animatroParDead = "death";
    public string animatroParJump = "jump";
    public string animatroParIsGround = "checkground";

    public GameObject platerObject;
    private ThirdPersonCamera thirdPersonCamera;


    #endregion

    #region 屬性 Property 

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

    #endregion

    #region 方法 Method

    private int ReturnJump()
    {
        return 999;
    }

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
            transform.forward * MoveInput("Vertical") * speedMove +
            transform.right * MoveInput("Horizontal") * speedMove +
            Vector3.up * rig.velocity.y;
        
    }
    // 移動按鍵輸入 asisName移動按鍵值
    private float MoveInput(string asisName)
    {
        return Input.GetAxis(asisName);
    }
    [Header("面相速度")]
    public float speedLookAt = 2;
    //垂直軸向大於0.1 就處理 面向
    private void LookAtForward()
    {
        if (MoveInput("Vertical") > 0.1f)
        {
            Quaternion angle = Quaternion.LookRotation(thirdPersonCamera.posForward - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
        }
    }

   
    #endregion

    #region 事件 Event
   
    

    void Start() // 開始執行一次
    {      
        // 物件欄位名稱.取得元件(類型(元件類型)) 當作 元件類型
        aud = platerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //    此腳本遊戲物件.取得元件<泛型>()
        rig = gameObject.GetComponent<Rigidbody>();
        // 取得元件
        anim = GetComponent<Animator>();

        //攝影機類別 = 透過類型尋找物件<泛型>(); 需要實體物件
        //FindObjectOfType不要再updata用,會過大負擔 
        thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>();
    }
    void Update() 
    {
        Jump();
        UpdataAnimation();
        LookAtForward();
    }
    // 0.002秒執行一次
    void FixedUpdate()
    {
        Move(speed);
    }

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
        //落第音效與加判斷
        if (!Isground && hits.Length > 0) aud.PlayOneShot(downSound, volumeRamdom);
       

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
            //起跳音效
            aud.PlayOneShot(jumpSound, volumeRamdom);
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
