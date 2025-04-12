using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instace;

    public static T Instace
    {
        get
        {
            if(_instace == null) // 0개면 게임 오브젝트 하나 생성 그 뒤로 생성 X
            {
                 _instace = FindAnyObjectByType<T>(); //현재 존재하는 신에 T가 있는지 확인
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
