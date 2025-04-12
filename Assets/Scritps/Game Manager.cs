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
        //���⼭ ���ӽ�dl �� �ε� �� ���Ŀ� ���� �ڵ� �аڴ�
        yield return SceneManager.LoadSceneAsync(sceneName);


        //�÷��̾� ����
        GameObject Player = Resources.Load<GameObject>("PreFab/Player");
        Instantiate(Player);
        Player.transform.position = new Vector3(0, -2.8f, 0);

        //��� �ҷ�����
        GameObject wall = Resources.Load<GameObject>("UI PreFab/Wall");
        wall = Instantiate(wall);

        //�� �ҷ�����
        GameObject ball = Resources.Load<GameObject>("PreFab/Ball");
        ball = Instantiate(ball);
        ball.transform.position = new Vector3(0, 6.5f, 0);

        //���� UI �ε��ϴ� �κ�
        GameObject ScoreUI = Resources.Load<GameObject>("UI PreFab/Score UI");
        ScoreUI = Instantiate(ScoreUI);


    }

    public void CreateEffect()
    {
        //�� �ҷ�����
        GameObject effect = Resources.Load<GameObject>("PreFab/Effect");
        effect = Instantiate(effect);
        effect.transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        
    }
}
