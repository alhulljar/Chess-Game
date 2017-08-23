using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool selection = true;
    public bool newSelect = false;
    public MoveWhite[] whiteProp = new MoveWhite[16];
    public MoveBlack[] blackProp = new MoveBlack[16];
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    private GameObject[] white = new GameObject[16];
    private GameObject[] black = new GameObject[16];

    void Start ()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        white = GameObject.FindGameObjectsWithTag("White");
        black = GameObject.FindGameObjectsWithTag("Black");
        for (int i = 0; i < white.Length; i++)
        {
            whiteProp[i] = white[i].GetComponent<MoveWhite>();
            blackProp[i] = black[i].GetComponent<MoveBlack>();
        }
    }
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < whiteProp.Length; i++)
        {
            whiteProp[i].Deselect();
            blackProp[i].Deselect();
        }
    }
}
