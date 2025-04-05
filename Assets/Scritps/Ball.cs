using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rigid;

    void Start()
    {
        //_rigid = GetComponent<Rigidbody2D>();
        
    }
    //충돌 했을때
    public float gravity = -9.8f;
    private float velocity = 0f;
    private bool _isLeftMove = true;
    private float _Speed = 3f;

    void Update()
    {
        //충돌이 된 부분
        if (transform.position.y < -3.46f)
        {
            velocity = 10f;
            transform.position = new Vector3(transform.position.x, -3.45f);
            return;
        }
        
        
        // 중력에 의한 속도 변화(자유낙하)
        velocity += gravity * Time.deltaTime;
        transform.position += new Vector3(0, velocity * Time.deltaTime, 0);

        if (_isLeftMove)
            BallLeftMove();

        else 
            BallRightMove();

        if (transform.position.x < -7.37 || transform.position.x > 7.37)
        {
            _isLeftMove = !_isLeftMove;
            
        }
    }
    private void BallLeftMove()
    {
        transform.position += Vector3.left * Time.deltaTime * _Speed;
    }
    private void BallRightMove()
    {
        transform.position += Vector3.right * Time.deltaTime * _Speed;
    }
}
