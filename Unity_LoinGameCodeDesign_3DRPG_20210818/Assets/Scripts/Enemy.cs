using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace WEI.Enemy
{
    public class Enemy : MonoBehaviour
    {   //屬性
        [Header("移動速度"), Range(0, 20)]
        public float speed = 2.5f;
        [Header("攻擊力"), Range(0, 200)]
        public float attack = 35;
        [Header("範圍:追蹤與攻擊")]
        [Range(0, 7)]
        public float rangeattack = 5;
        [Range(7, 20)]
        public float rangeTrack = 15;
        [Header("等待隨機秒數")]
        public Vector2 v2RandomWait = new Vector2(1f, 5f);
        [Header("走路隨機秒數")]
        public Vector2 v2RandomWalk = new Vector2(3, 7);
        [Header("攻擊區域位移與尺寸")]
        public Vector3 v3AttackOffset;
        public Vector3 v3AttackSize = Vector3.one;

        //是否等待等等...狀態
        private bool isIdle;
        private bool isWalk;

        private Animator anim;
        private string parameterIdleWalk = "Walk";

        [Header("攻擊時間"), Range(0, 5)]
        public float timeAttack = 2.5f;
        private string parameterAttack = "攻擊觸發";
        private bool isAttack;

        private NavMeshAgent nma;

        private Vector3 v3RandomWalkFinal;
        private Vector3 v3RandomWalk
        {
            get => Random.insideUnitSphere * rangeTrack + transform.position;
        }

        private Transform traPlayer;
        private string namePlayer = "Player";

        [SerializeField]
        private StateEnemy state;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;

            nma.SetDestination(transform.position);              //導覽器
        }

        //繪製圖形
        private void OnDrawGizmos()
        {
            #region 攻擊.追蹤.隨機行走
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeattack);

            Gizmos.color = new Color(0.2f, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeTrack);

            if(state == StateEnemy.Walk)
            {
                Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
                Gizmos.DrawSphere(v3RandomWalkFinal, 0.3f);
            }
            #endregion

            #region 攻擊碰撞判定區域
            Gizmos.color = new Color(0.8f, 0.2f, 0.7f, 0.3f);
            //繪製方形.需要跟著角色旋轉 使用 matrix 指定座標角度與尺寸
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                transform.rotation, transform.localScale);

            Gizmos.DrawCube(Vector3.zero,v3AttackSize);
            #endregion
        }

        private void Update()
        {
            StateManager();
        }

        private void StateManager()
        {
            switch(state)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Walk:
                    Walk();
                    break;
                case StateEnemy.Track:
                    Track();
                    break;
                case StateEnemy.Attack:
                    Attack();
                    break;
                case StateEnemy.Hurt:
                    break;
                case StateEnemy.Dead:
                    break;
                default:
                    break;
            }
        }
        
        private void Idle()
        {
            if (playerInTrackRange) state = StateEnemy.Track; //如果玩家進入 追蹤範圍 切換成追蹤狀態

            //進入條件
            if (isIdle) return;
            isIdle = true;
            print("等待");

            anim.SetBool(parameterIdleWalk, false);
            StartCoroutine(IdleEffect());
        }

        private IEnumerator IdleEffect()
        {
            float randomWait = Random.Range(v2RandomWait.x, v2RandomWait.y);
            yield return new WaitForSeconds(randomWait);

            state = StateEnemy.Walk;
            //出去條件
            isIdle = false;
        }

        private void Walk()
        {
            if (playerInTrackRange) state = StateEnemy.Track; //如果玩家進入 追蹤範圍 切換成追蹤狀態

            //代理器.設定目的地(座標)
            nma.SetDestination(v3RandomWalkFinal);
            anim.SetBool(parameterIdleWalk, nma.remainingDistance > 0.1f); //走路動畫 - 離目的地大於0.1時走路

            if (isWalk) return;
            isWalk = true;
            print("隨機座標" + v3RandomWalk);        

            NavMeshHit hit;  //導覽網格碰撞.儲存碰撞資訊
            NavMesh.SamplePosition(v3RandomWalk, out hit,rangeTrack,NavMesh.AllAreas); //導覽網格.取得座標.網格內可走座標
            v3RandomWalkFinal = hit.position; //最終座標 = 碰撞資訊 的 座標

            
            StartCoroutine(WalkEffect());           
        }

        private IEnumerator WalkEffect()
        {
            float randomWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);
            yield return new WaitForSeconds(randomWalk);

            state = StateEnemy.Idle;

            //離開條件
            isWalk = false;
        }

        private bool playerInTrackRange { get => Physics.OverlapSphere(transform.position, rangeTrack, 1 << 6).Length > 0; }


        /// <summary>
        /// 追蹤玩家
        /// </summary>
        private bool isTrack;
        private void Track()
        {
            if(!isTrack)
            {
                StopAllCoroutines();
            }

            nma.isStopped = false;
            nma.SetDestination(traPlayer.position);
            anim.SetBool(parameterIdleWalk, true);

            if (nma.remainingDistance <= rangeattack) state = StateEnemy.Attack;
        }
        /// <summary>
        /// 攻擊玩家
        /// </summary>
        private void Attack()
        {
            nma.isStopped = true;
            anim.SetBool(parameterIdleWalk, false);
            nma.SetDestination(traPlayer.position);

           if (nma.remainingDistance > rangeattack) state = StateEnemy.Track;

            if (isAttack) return;
            anim.SetTrigger(parameterAttack);

            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                v3AttackSize / 2, Quaternion.identity, 1 << 6);

            if (hits.Length > 0) print("攻擊到的物件：" + hits[0].name);

            isAttack = true;
        }

    }
}
