using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // 地面の位置
    private float groundLevel = -3.0f;

    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    Rigidbody2D rigid2D;

    private AudioSource sound01;

    public GameObject UnityChan2D { get; private set; }

    int sound = 0;
    private string unitychan2D;

    // Use this for initialization
    void Start()
    {
        // Rigidbody2Dのコンポーネントを取得する（追加）
        this.rigid2D = GetComponent<Rigidbody2D>();

       sound01= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
       
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            sound01.PlayOneShot(sound01.clip);
            sound++;
        }
        
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == unitychan2D)
        {
            {
                sound01.PlayOneShot(sound01.clip);
                sound = 0;
            }
        }
    }
}