using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    //This is the bar that will fill itself as the scene is loading
    [SerializeField]
    private Image progressBar;

    public string nextScene;
    
    // Start is called before the first frame update
    protected void Start()
    {
        progressBar = Resources.Load("MovingLoadingBar") as Image;
    }


    //Load the next scene when this is called
    public IEnumerator loadingNextScene(string scene)
    {
        print("Got Here");
        //Go to the loading screen first
        SceneManager.LoadScene("Loading Screen");
        //While on the loading screen, load the next scene
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
        //This means wait for 1 seconds
        yield return new WaitForSeconds(1.0f);
        //Fill up the progress bar as the scene is loading
        while (loadScene.progress < 1)
        {
            progressBar.fillAmount = loadScene.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
