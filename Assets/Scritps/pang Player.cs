using System.Collections;
using Mono.Cecil;
using Unity.VisualScripting;
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
    
    
    private int _CurrentIndex;    

    private STATE _currentState;
    private float _Speed = 3f;
    private float _accTime = 0;
    public enum STATE
    {
        IDLE, //������ �� �ִ� ����
        WALK, //�����̴� ����
        HITTED,

    }
    
    void Awake()
    {
        _currentState = STATE.IDLE;
        _render = GetComponentInChildren<SpriteRenderer>();
        
    }
    private void IDLE_Action()
    {
        _accTime += Time.deltaTime;
        if(_accTime >= 0.2f)
        {
            _CurrentIndex++;

            if (_CurrentIndex >= idleSprites.Length)
                _CurrentIndex = 0;
            _render.sprite = idleSprites[_CurrentIndex];

            _accTime = 0;
        }
    }
    private void Walk_Action()
    {
        //Debug.Log("������");
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f)
        {
            _CurrentIndex++;

            if (_CurrentIndex >= walkSprites.Length)
                _CurrentIndex = 0;
            _render.sprite = walkSprites[_CurrentIndex];

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
        MoveInput();

        switch (_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
            case STATE.WALK:
                Walk_Action();
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
            transform.rotation = Quaternion.Euler(0, 180, 0); //���� ���� �ٶ󺸱�
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _Speed;
            transform.rotation = Quaternion.Euler(0, 0, 0); // ������ ���� �ٶ󺸱�
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