
using System;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D body;

    public PlayerMovement paddle1;
    public PlayerMovement paddle2;

    public Text score1;
    public Text score2;

    private System.Random rand = new System.Random();
    private int dir = 1;
    private float speed = 5;
    private Vector2Int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(body.position.x) > 7.8)
        {
            if(dir > 0) scoreCount.x++;
            else scoreCount.y++;
            score1.text = scoreCount.x.ToString();
            score2.text = scoreCount.y.ToString();

            Restart();
        }
        if( body.velocity.x > 0 && dir < 0 ||
            body.velocity.x < 0 && dir > 0 )
        {
            dir = -dir;
            Bounce();
        }
    }

    void Restart()
    {
        dir = rand.NextDouble() > 0.5 ? -1 : 1;

        body.position = new Vector2(0, 0);
        body.velocity = new Vector2(dir, rand.Next(-10, 10)/10f) * speed;

        paddle1.Restart();
        paddle2.Restart();

        speed *= 1.02f;
    }

    void Bounce()
    {
        PlayerMovement activePaddle = body.position.x > 0 ? paddle2 : paddle1;
        body.velocity = new Vector2(dir, (body.position.y - activePaddle.paddle.position.y) * 1.5f) * speed;
    }
}
