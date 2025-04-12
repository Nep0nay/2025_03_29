using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        Button button = GetComponentInChildren<Button>();

        if(button != null)
        {
            _button.onClick.AddListener(OnClickStartButton);
        }
    }
    private void OnClickStartButton()
    {
        UIManager.Instace.CreatModeUI();

        Destroy(gameObject);

        //ModeUI = Resources.Load<GameObject>("UI PreFab/ModeUI");
        //GameObject sceneGO = Instantiate(ModeUI, _CanvasTrasn, false);
        //ModeUI uiComp = sceneGO.GetComponent<ModeUI>();

        //uiComp.AddTimeClickEnvent(OnClickTimeAttackMode);
        //uiComp.AddStageClickEvent(OnClickStageMode);

    }

}
