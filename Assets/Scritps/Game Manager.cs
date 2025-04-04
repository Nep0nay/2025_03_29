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
        uiComp.AddStageClickEvent(OnClickStageMode);

    }
    private void OnClickTimeAttackMode()
    {
        Debug.Log("TimeAttackScene");
        StartCoroutine(LoadSceneAsync("TimeAttackScene"));
    }
    private void OnClickStageMode()
    {
        Debug.Log("StageScene");
        StartCoroutine(LoadSceneAsync("StageScene"));

    }
    
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        //여기서 게임신dl 다 로드 된 이후에 다음 코드 읽겠다
        yield return SceneManager.LoadSceneAsync(sceneName);


        //플레이어 생성
        GameObject Player = Resources.Load<GameObject>("PreFab/Player");
        Instantiate(Player);
        
    }

    void Update()
    {
        
    }
}
