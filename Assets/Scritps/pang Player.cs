using System.Collections;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pangPlayer : MonoBehaviour
{
    [SerializeField]
    private Sprite[] idleSprites;

    [SerializeField]
    private Sprite[] walkSprites;

    private SpriteRenderer _render;
    private int _CurrentspriteIndex; //현재 가지고 있는 스프라이트중 몇번째 스프라이트가 출력중인가를 알아야한다

    private STATE _currentState;
    private float _Speed = 3f;
    private float _accTime = 0;
    public enum STATE
    {
        IDLE, //가만히 서 있는 상태
        WALK, //움직이는 상태
        HITTED,

    }
    
    void Awake()
    {
        _currentState = STATE.IDLE;
        _render = GetComponentInChildren<SpriteRenderer>();
        
    }
    private void IDLE_Action()
    {
        MoveInput();
        
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f) //시간처리 - 0.2초마다 반복되게 한다
        {
            _CurrentspriteIndex++;

            if (_CurrentspriteIndex >= idleSprites.Length) //스프라이트 번호가 지정된6개의 스프라이트의 길이와 같으면 0으로 초기화
                _CurrentspriteIndex = 0;
            _render.sprite = idleSprites[_CurrentspriteIndex];

            _accTime = 0;
        }
    }
    private void Walk_Action() //update로 계속 실행됌
    {
        MoveInput();
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f)
        {
            _CurrentspriteIndex++;

            if (_CurrentspriteIndex >= walkSprites.Length)
                _CurrentspriteIndex = 0;
            _render.sprite = walkSprites[_CurrentspriteIndex];

            _accTime = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Resources.Load<GameObject>("PreFab/bullet");
            GameObject bulletGO = Instantiate(bullet);

            bulletGO.transform.position = transform.position;
        }
    }
  
    private void Hitted_Action()
    {

    }

    void Update()
    {
    

        switch (_currentState) //현재의 상태에 따라서
        {
            case STATE.IDLE:
                IDLE_Action(); //이 함수가 불리거나
                break;
            case STATE.WALK:
                Walk_Action(); //이 함수가 불린다
                break;
            case STATE.HITTED:
                Hitted_Action();
                break;
        }
    }
    
    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _Speed;
            _currentState = STATE.WALK;
            _render.flipX = true; //왼쪽 바라보기
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _Speed;
            _currentState = STATE.WALK;
            _render.flipX = false; //오른쪽 바라보기
        }
        else
        {
            _currentState = STATE.IDLE;
        }
    }
} 