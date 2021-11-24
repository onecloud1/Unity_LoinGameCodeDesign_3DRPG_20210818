using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace WEI
{

    public class HurtSystemWithUI : HurtSystem
    {
        [Header("要更新的血條")]
        public Image imgHp;

        private float hpeffectOriginal;
        // 複寫父類別成員 override
        public override void Hurt(float damage)
        {
            hpeffectOriginal = hp;

            //base 該成員的父類別基底 父類別內的內容
            base.Hurt(damage);

            StartCoroutine(HpBarEffect());
        }

        private IEnumerator HpBarEffect()
        {
            while (hpeffectOriginal != hp)
            {
                hpeffectOriginal--;
                imgHp.fillAmount = hpeffectOriginal / hpMax;
                yield return new WaitForSeconds(0.01f);

            }
        }

    }
}
