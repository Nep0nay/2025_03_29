using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _Speed = 2f;
    void Start()
    {
        

    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _Speed;
        if (transform.position.y > 4)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("´ê¾ÆÀ½");
    }
}
