using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位

    [Header("移動速度")]
    public float speed = 10;

    public float turn = 5;

    /// <summary>
    /// 遊戲總時間: 兩分鐘
    /// </summary>
    private float time = 120;

    #endregion

    /// <summary>
    /// 定義玩家事件委派
    /// </summary>
    public delegate void delegatPlayerEvent();


    /// <summary>
    /// 玩家時間到就死亡
    /// </summary>
    public event delegatPlayerEvent onDead;

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public event delegatPlayerEvent onItem;

    /// <summary>
    /// 玩家完成: 走到終點
    /// </summary>
    public event delegatPlayerEvent onFinal;


    private Rigidbody rig;
    private Transform cam;

    #region 事件

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rig.AddForce(cam.forward * v * speed + cam.right * h * speed);

        // 鏡頭左右移動
        float x = Input.GetAxis("Mouse X");
        cam.Rotate(0, x * turn, 0);
            
    }

    #endregion
}
