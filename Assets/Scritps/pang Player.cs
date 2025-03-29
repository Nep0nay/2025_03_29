using UnityEngine;

public class pangPlayer : MonoBehaviour
{
    [SerializeField]
    private Sprite[] idleSprites;

    [SerializeField]
    private Sprite[] walkSprites;

    public enum STATE
    {
        IDLE, //가만히 서 있는 상태
        WALK, //움직이는 상태
        HITTED,

    }
    private STATE _currentState;

    private float _Speed = 3;
    void Awake()
    {
       _currentState = STATE.IDLE;
    }

    private void IDLE_Action()
    {

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _Speed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _Speed;

        }

        switch( _currentState )
        {
            case STATE.IDLE:
                IDLE_Action();
                    break;
            case STATE.WALK:
                IDLE_Action();
                break;
            case STATE.HITTED:
                IDLE_Action();
                break;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _currentState = STATE.WALK;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _currentState = STATE.HITTED;
        }
    }
}
