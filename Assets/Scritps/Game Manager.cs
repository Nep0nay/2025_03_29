using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button _StartButton;
    private GameObject ModeUI;
    

    [SerializeField]
    private Transform _CanvasTrasn;
    

    void Start()
    {
        _StartButton.onClick.AddListener(OnClickStartButton);

        DontDestroyOnLoad(gameObject);
    }

    private void OnClickStartButton()
    {
        Destroy(_StartButton.gameObject);

        ModeUI = Resources.Load<GameObject>("UI PreFab/ModeUI");
        GameObject sceneGO = Instantiate(ModeUI, _CanvasTrasn, false);
        ModeUI uiComp = sceneGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEnvent(OnClickTimeAttackMode);
        uiComp.AddTimeClickEnvent(OnClickStageMode);

    }
    
    private void OnClickTimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync("TimeAttackScene"));
    }
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        //���⼭ ���ӽ��� �� �ε� �� ���Ŀ� ���� �ڵ带 �аڴ�.
        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        GameObject Player = Resources.Load<GameObject>("PreFab/Player");
        Instantiate(Player);
        
    }

    private void OnClickStageMode()
    {
        SceneManager.LoadScene(1);

    }

    void Update()
    {
        
    }
}
