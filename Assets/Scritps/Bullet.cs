using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _bulletsprite; //그려줄애한테 넘겨줄 그림들
    
    [SerializeField]
    private SpriteRenderer _bulletrender; //그려주는애

    private float _Speed = 2f;

    private float _accbullettime = 0;
    private int _currentIndex = 0; //그림들중 몇번째인가


    void Start()
    {
        

    }
    
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _Speed;
        if (transform.position.y > 4)
            Destroy(gameObject);

        OnFIRE(); //총알 스프라이트 변경 함수
        
    }
    private void OnFIRE()
    {
        _accbullettime += Time.deltaTime;
        if (_accbullettime >= 0.2f) //시간처리 - 0.2초마다 반복되게 한다
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
        Debug.Log("닿아음");
    }
}
