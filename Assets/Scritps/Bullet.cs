using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _bulletsprite; //�׷��پ����� �Ѱ��� �׸���
    
    [SerializeField]
    private SpriteRenderer _bulletrender; //�׷��ִ¾�

    private float _Speed = 2f;

    private float _accbullettime = 0;
    private int _currentIndex = 0; //�׸����� ���°�ΰ�


    void Start()
    {
        

    }
    
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _Speed;
        if (transform.position.y > 4)
            Destroy(gameObject);

        OnFIRE(); //�Ѿ� ��������Ʈ ���� �Լ�
        
    }
    private void OnFIRE()
    {
        _accbullettime += Time.deltaTime;
        if (_accbullettime >= 0.2f) //�ð�ó�� - 0.2�ʸ��� �ݺ��ǰ� �Ѵ�
        {
            _currentIndex++;

            if (_currentIndex >= _bulletsprite.Length)
                _currentIndex = 0;
            _bulletrender.sprite = _bulletsprite[_currentIndex];

            _accbullettime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�����");
    }
}
