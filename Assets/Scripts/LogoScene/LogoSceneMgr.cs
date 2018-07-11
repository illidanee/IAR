using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneMgr : MonoBehaviour {

    private void Awake()
    {
        LogoMgr._OnFinish += OnFinish;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnFinish()
    {
        Debug.Log("--------------------------------------- LogoScene Done!");
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
    }
}
