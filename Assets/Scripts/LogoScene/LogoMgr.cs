using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoMgr : MonoBehaviour {

    public delegate void OnFinish();
    public static LogoMgr.OnFinish _OnFinish;

    public float _Speed;
    public Sprite[] _Sprites;

    private Image _Image;

    // Use this for initialization
    void Start () {
        _Image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        int index = (int)(Time.time * _Speed) % _Sprites.Length;
        _Image.sprite = _Sprites[index];
            
        if (index == _Sprites.Length - 1)
        {
            _OnFinish();
            this.enabled = false;
        }
    }
}
