using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadingNextScene());
    }

    IEnumerator loadingNextScene()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(2);
        while(loadScene.progress < 1)
        {
            progressBar.fillAmount = loadScene.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
