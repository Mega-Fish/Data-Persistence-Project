using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField UsernameInput;
    public Text BestScoreText;

    private void Start()
    {
        if(ScoreManager.BestScore == 0)
        {
            ScoreManager.Instance.LoadHighScore();
        }
        ScoreManager.Instance.UpdateBestScoreText(BestScoreText);
        UsernameInput.onEndEdit.AddListener(SubmitName);
    }

    void SubmitName(string name)
    {
        ScoreManager.Username = name;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

}
