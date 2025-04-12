using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instace;

    public static T Instace
    {
        get
        {
            if(_instace == null) // 0���� ���� ������Ʈ �ϳ� ���� �� �ڷ� ���� X
            {
                 _instace = FindAnyObjectByType<T>(); //���� �����ϴ� �ſ� T�� �ִ��� Ȯ��
                if(_instace == null)
                {
                    GameObject go = new GameObject("Singletone " + typeof(T).ToString());
                    _instace = go.AddComponent<T>();
                    DontDestroyOnLoad(go);

                }
                DontDestroyOnLoad(_instace.gameObject);
            }

            return _instace;
        }
    }

}
