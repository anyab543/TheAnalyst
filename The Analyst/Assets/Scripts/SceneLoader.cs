using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Water_Level");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("RunningLevel");
    }
}