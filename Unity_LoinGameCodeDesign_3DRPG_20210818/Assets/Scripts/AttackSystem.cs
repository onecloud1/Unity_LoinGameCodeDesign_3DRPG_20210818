using UnityEngine;
using System.Collections;

namespace WEI
{
    /// <summary>
    /// 攻擊系統
    /// 玩家攻擊按鍵監聽
    /// 攻擊區域.攻擊力.造成傷害
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [Header("攻擊力"), Range(0, 500)]
        public float attack = 20;
        [Header("攻擊冷卻時間"), Range(0, 5)]
        public float timeAttack = 1.5f;
        [Header("延遲傳送傷害時間"), Range(0, 100)]
        public float delaySendDamage = 0.2f;
        [Header("攻擊區域尺寸與位移")]
        public Vector3 v3AttackOffset;
        public Vector3 v3AttackSize = Vector3.one;

        [Header("攻擊動畫參數")]
        public string parameterAttack = "攻擊圖層觸發";
        private bool isAttack;

        private Animator anim;
        private bool keyAttack { get => Input.GetKeyDown(KeyCode.Mouse0); }      

        private void Awake()
        {
            anim = GetComponent<Animator>();            
        }

        private void Update()
        {
            Attack();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0.2f, 0.3f);
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                transform.rotation, transform.localScale);

            Gizmos.DrawCube(Vector3.zero, v3AttackSize);
        }

        private void Attack()
        {
            if(keyAttack && !isAttack)
            {
                isAttack = true;
                anim.SetTrigger(parameterAttack);
                StartCoroutine(DelayHit());
            }
        }

        private IEnumerator DelayHit()
        {
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                v3AttackSize / 2, Quaternion.identity, 1 << 7);

            if (hits.Length > 0) hits[0].GetComponent<HurtSystem>().Hurt(attack);

            float waitToNextAttack = timeAttack - delaySendDamage;
            yield return new WaitForSeconds(waitToNextAttack);
            isAttack = false;
        }
    }
}
