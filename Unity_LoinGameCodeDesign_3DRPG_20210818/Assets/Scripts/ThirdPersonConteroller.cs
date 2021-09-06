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
    [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(0,500)]
    public float speed = 10.5f;

    [Header("跳躍高度"), Range(0, 1000)]
    public float jump = 100f;

    [Header("是否在地板上"), Tooltip("角色是否踩在地板上")]
    public bool groundCheck = false;
    public Vector3 groundDisplacement;
    public float groundRadius = 0.2f;
    
    [Header("音效檔案")]
    public AudioClip jumpSound;
    public AudioClip downSound;

    [Header("動畫參數")]
    public string animatroParWalk ="Play_walk";
    public string animatroParRun = "Player_run";
    public string animatroParHurt = "Player_hurt";
    public string animatroParDead = "Player_death";

    public AudioSource soundSource;
    public Rigidbody rig;
    public Animator anim;

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

    #endregion

    #region 方法 Method

    #endregion

    #region 事件 Event
    //特定時間點會執行的方法
    #endregion
}
