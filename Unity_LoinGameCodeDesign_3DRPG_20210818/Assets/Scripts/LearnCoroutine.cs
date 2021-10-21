using System.Collections; // 引用 系統.集合 引用就可用 協同程序 API
using UnityEngine;

namespace WEI.Practice
{

    public class LearnCoroutine : MonoBehaviour
    {
        //定義協同程序方法
        //IEnumerator 為協同程序 傳回值,可傳回時間

        private IEnumerator TestCoroutine()
        {
            print("協同");
            yield return new WaitForSeconds(2);
            print("協同等待兩秒後執行");
        }

        public Transform sphere;
        private IEnumerator SpherScale()
        {
            for (int i = 0; i < 10; i++)
            {
                sphere.localScale += Vector3.one;
                yield return new WaitForSeconds(1);            
            }
        }

        private void Start()
        {   //必須使用這樣啟動協同程序 才會有效果
            StartCoroutine(TestCoroutine());
            StartCoroutine(SpherScale());
        }

    }
}