using UnityEngine;
using UnityEngine.Events;

namespace WEI
{

    public class HurtSystem : MonoBehaviour
    {
        [Header("血量"), Range(0, 5000)]
        public float hp = 100;
        [Header("受傷事件")]
        public UnityEvent onHurt;
        [Header("死亡事件")]
        public UnityEvent onDead;
        [Header("動畫參數:受傷與死亡")]
        public string parameterHurt = "hurt";
        public string parameterDead = "death";

        //私人不允許再子類別存取
        private Animator anim;

        protected float hpMax;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            hpMax = hp;
        }
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">接收到的傷害</param>
        /// 成員要被子類別複寫必須加上 virtual 虛擬
        public virtual bool Hurt(float damage)
        {
            if (anim.GetBool(parameterDead)) return true; //如果 死亡參數勾選 就跳出
            hp -= damage;
            anim.SetTrigger(parameterHurt);
            onHurt.Invoke();
            if (hp <= 0)
            {
                Dead();
                return true;
            }
            else return false;
        }

        private void Dead()
        {
            anim.SetBool(parameterDead,true);
            onDead.Invoke();
        }
    }
}
