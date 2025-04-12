using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _scoretext;

    void Start()
    {
        _scoretext = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void ChangeScore(int score)
    {
        _scoretext.text = score.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScore(4885);
        }
    }
}
