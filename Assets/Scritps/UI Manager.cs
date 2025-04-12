using UnityEngine;

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _CanvasTrasn;

    private void Awake()
    {
        _CanvasTrasn = transform;
    }
    public void CreatStartUI()
    {
        GameObject resGo = Resources.Load<GameObject>("UI PreFab/Button");
        GameObject sceneGO = Instantiate(resGo, _CanvasTrasn, false);
    }
    public void CreatModeUI()
    {
        GameObject ModeUI = Resources.Load<GameObject>("UI PreFab/ModeUI");
        GameObject sceneGO = Instantiate(ModeUI, _CanvasTrasn, false);
        ModeUI uiComp = sceneGO.GetComponent<ModeUI>();
    }
}
