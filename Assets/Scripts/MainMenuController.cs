using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    private float need = 1.0f;
    private void Start()
    {
        if (PlayerPrefs.GetFloat("difficulty") <0)
        {
            PlayerPrefs.SetFloat("difficulty", 1);
        }
        
    }
    public void Scrollbar(float value)
    {
        PlayerPrefs.SetFloat("difficulty",value + need);
    }

    public void ForQuit()
    {
        Application.Quit();
    }
    public void showInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void PlayEndless()
    {
        SceneManager.LoadScene("Endless Mode");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
    public void PlayStory()
    {
        SceneManager.LoadScene("Level Sel");
    }
    public void ClearCache()
    {
        PlayerPrefs.DeleteAll();
    }
}
