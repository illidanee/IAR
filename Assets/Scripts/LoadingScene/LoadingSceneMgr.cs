using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneMgr : MonoBehaviour {

    private void Awake()
    {
        SliderMgr._OnFinish += OnFinish;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnFinish()
    {
        Debug.Log("--------------------------------------- LoadingScene Done!");
    }
}
