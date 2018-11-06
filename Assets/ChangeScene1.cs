using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Clicked");
    }
}