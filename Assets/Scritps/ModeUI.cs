using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    private Button _timeAttackButton;

    [SerializeField]
    private Button _stageModeButton;
    
    private void Start()
    {
        

    }

    public void AddTimeClickEnvent(UnityAction clickcall)
    {
        _timeAttackButton.onClick.AddListener(clickcall);

    }
    public void AddStageClickEvent(UnityAction clickcall1)
    {
        _stageModeButton.onClick.AddListener(clickcall1);

    }
}
