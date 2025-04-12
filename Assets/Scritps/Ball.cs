using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rigid;

    public enum BallState
    {
        None = 0,
        Drop,
        Left,
        Right,
    }



    public float gravity = -9.8f;
    private float velocity = 0f;
    private bool _isLeftMove = true;
    private float _Speed = 3f;
    private BallState _state;
    private float _acctime = 0;
    private int _dropcount = 0;

    void Start()
    {
        _state = BallState.Drop;
        
    }

    //충돌 했을때

    void Update()
    {
        switch(_state)
        {
            case BallState.Drop:
                _acctime += Time.deltaTime;
                if(_acctime > 1)
                {
                    transform.position += new Vector3(0, -1, 0);
                    _dropcount++;
                    _acctime = 0;

                    if (_dropcount > 3)
                    {
                        int result = Random.Range(0, 2);
                        if (result > 0)
                            _state = BallState.Left;
                        else
                            _state = BallState.Right;
                    }
                }
                break;
            case BallState.Left:
                BallLeftMove();
                break;
            case BallState.Right:
                BallRightMove();
                break;
        }

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

        //벽 제한
        if (transform.position.x < -7.37 || transform.position.x > 7.37)
        {
            _isLeftMove = !_isLeftMove;
        }

        if (_isLeftMove)
            BallLeftMove();
        else 
            BallRightMove();

        if(_state == BallState.Drop)
        {
            return;
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D : " + other.gameObject.name);

        GameManager manager = GameManager.Instace;

        var center = (transform.position + other.transform.position) * 0.5f;
        
        manager.CreateEffect();

        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
