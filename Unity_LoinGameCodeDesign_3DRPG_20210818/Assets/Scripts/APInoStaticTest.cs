using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APInoStaticTest : MonoBehaviour
{
    public Camera cam;
    public Camera cam2;
    public SpriteRenderer srSquare;
    public SpriteRenderer srBird;

    public Transform srBird2;
    public Rigidbody2D srBird3;


    void Start()
    {
        Debug.Log("攝影機的深度" + cam.depth);
        Debug.Log("方形圖片的顏色" + srSquare.color);

        cam2.backgroundColor = Random.ColorHSV();
        srBird.flipY = true;
    }

    
    void Update()
    {
        srBird2.Rotate(0, 0, 3);
        srBird3.AddForce(new Vector2(0,5));
    }


}
