using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    public GameObject GameObjectToHide;
    public GameObject GameObjectToHide1;
    public GameObject GameObjectToHide2;
    public GameObject GameObjectToHide3;
    public GameObject GameObjectToHide4;
    public GameObject GameObjectToHide5;
    public float MinTime = 2.0f;
    public float MaxTime = 5.0f;
    

    
    

    void Start()
    {
        
        

        StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide1));
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide2));
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide3));
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide4));
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide5));
    }

    void Update()
    {
        
    }

    IEnumerator ToggleVisibilityCo(GameObject platform)
    {
        if (platform == null) yield break;

        while (true)
        {
            platform.SetActive(!platform.activeSelf);
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }
    }

    
}