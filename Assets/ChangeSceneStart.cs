using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneStart : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Clicked");
    }
}