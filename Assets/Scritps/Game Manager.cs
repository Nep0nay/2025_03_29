using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingletone<GameManager>
{
    [SerializeField]
    private Button _StartButton;
    
    [SerializeField]
    private Transform _CanvasTrasn;
    
    private GameObject ModeUI;

    void Start()
    {
        var temp = Instace;
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
        Player.transform.position = new Vector3(0, -2.8f, 0);

        //배경 불러오기
        GameObject wall = Resources.Load<GameObject>("UI PreFab/Wall");
        wall = Instantiate(wall);

        //공 불러오기
        GameObject ball = Resources.Load<GameObject>("PreFab/Ball");
        ball = Instantiate(ball);
        ball.transform.position = new Vector3(0, 6.5f, 0);

        //게임 UI 로드하는 부분
        GameObject ScoreUI = Resources.Load<GameObject>("UI PreFab/Score UI");
        ScoreUI = Instantiate(ScoreUI);


    }

    public void CreateEffect()
    {
        //공 불러오기
        GameObject effect = Resources.Load<GameObject>("PreFab/Effect");
        effect = Instantiate(effect);
        effect.transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        
    }
}
