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

    public int sceneNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(sceneNumber==0)
        {
            StartCoroutine(loadingNextScene(2));
        }
        
    }

    IEnumerator loadingNextScene(int scene)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
        while(loadScene.progress < 1)
        {
            progressBar.fillAmount = loadScene.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
