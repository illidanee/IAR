using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderMgr : MonoBehaviour {

    public delegate void OnFinish();
    public static SliderMgr.OnFinish _OnFinish;

    private Slider _Slider;
    
    private AsyncOperation _OP;

    // Use this for initialization
    void Start () {
        _Slider = GetComponent<Slider>();

        StartCoroutine(LoadNextScene());
    }
	
	// Update is called once per frame
	void Update () {
  
    }

    IEnumerator LoadNextScene() {
        _OP = SceneManager.LoadSceneAsync("Main");
        _OP.allowSceneActivation = false;

        int toProgress = 0;
        int displayProgress = 0;
        while (_OP.progress < 0.9f)
        {
            toProgress = (int)(_OP.progress * 100.0f);
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                _Slider.value = displayProgress / 100.0f;
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            _Slider.value = displayProgress / 100.0f;
            yield return new WaitForEndOfFrame();
        }

        _OP.allowSceneActivation = true;
        _OnFinish();
        yield return new WaitForEndOfFrame();
    }
}
