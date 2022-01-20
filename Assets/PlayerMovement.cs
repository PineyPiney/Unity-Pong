
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D paddle;
    public KeyCode up;
    public KeyCode down;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            IncrementPosition(1);
        }
        if (Input.GetKey(down))
        {
            IncrementPosition(-1);
        }
    }

    public void Restart()
    {
        paddle.position = new Vector2(paddle.position.x, 0);
    }

    void IncrementPosition(float direction)
    {
        Vector2 newPosition = paddle.position + new Vector2(0, 0.05f * direction);
        if(newPosition.y > 3) newPosition.y = 3;
        if (newPosition.y < -3) newPosition.y = -3;
        paddle.position = newPosition;
    }
}
