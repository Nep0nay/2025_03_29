using UnityEngine;

public class explosion : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _explosionsprite;

    [SerializeField]
    private SpriteRenderer _explosionrender;

    private float _accexplosiontime = 0;
    private int _explosionIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Onexplosion();
    }

    private void Onexplosion()
    {
        _accexplosiontime += Time.deltaTime;

        if (_accexplosiontime > 0.2f) 
        {
            _explosionIndex++;
            if (_explosionIndex >= _explosionsprite.Length)
            {
                Destroy(gameObject);
                return;
            }
            _accexplosiontime = 0;
            Debug.Log("_explosionIndex");

            _explosionrender.sprite = _explosionsprite[_explosionIndex];

           
        }

    }
}
