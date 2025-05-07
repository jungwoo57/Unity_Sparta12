using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player player;
    public int speed;

    public bool isMainGame = true;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    void Start()
    {
        
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMainGame) return;
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(h, v);
        
        if(h < 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(h > 0)
            player.transform.rotation = Quaternion.Euler(0, 0, 0);

        rigid.velocity = direction * speed ;
    }
}
