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
    private int _CurrentspriteIndex; //���� ������ �ִ� ��������Ʈ�� ���° ��������Ʈ�� ������ΰ��� �˾ƾ��Ѵ�

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
        MoveInput();
        
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f) //�ð�ó�� - 0.2�ʸ��� �ݺ��ǰ� �Ѵ�
        {
            _CurrentspriteIndex++;

            if (_CurrentspriteIndex >= idleSprites.Length) //��������Ʈ ��ȣ�� ������6���� ��������Ʈ�� ���̿� ������ 0���� �ʱ�ȭ
                _CurrentspriteIndex = 0;
            _render.sprite = idleSprites[_CurrentspriteIndex];

            _accTime = 0;
        }
    }
    private void Walk_Action() //update�� ��� ������
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
    

        switch (_currentState) //������ ���¿� ����
        {
            case STATE.IDLE:
                IDLE_Action(); //�� �Լ��� �Ҹ��ų�
                break;
            case STATE.WALK:
                Walk_Action(); //�� �Լ��� �Ҹ���
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
            _render.flipX = true; //���� �ٶ󺸱�
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _Speed;
            _currentState = STATE.WALK;
            _render.flipX = false; //������ �ٶ󺸱�
        }
        else
        {
            _currentState = STATE.IDLE;
        }
    }
} 