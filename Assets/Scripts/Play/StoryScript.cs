﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryScript : MonoBehaviour {

    // Scripts
    List<string[]> textscripts;

    // EventController
    public GameObject EC;
    private EventController ec;

    // BiscuitMode text
    public GameObject BiscuitText;
    public Text text_b;

    // Rec2Square text
    public GameObject Rec2SquareText;
    public Text text_r;

    // Similar text
    public GameObject SimilarText;
    public Text text_s;

    // StoryMode Text
    public GameObject TextBox;
    public Text TextBox_text;

    // Story mode internal variables
    private int currentmode;
    private int storyprogress;

    // 1st stage
    string[] textscript1 = {
        "1어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        };

    // 2nd stage
    string[] textscript2 = {
        "2어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        };


    // 3rd stage
    string[] textscript3 = {
        "3어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        };


    // 4th stage
    string[] textscript4 = {
        "4어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        };



    // Use this for initialization
    private void Awake()
    {

        // adding scripts

        textscripts = new List<string[]>();

        textscripts.Add(textscript1);
        textscripts.Add(textscript2);
        textscripts.Add(textscript3);
        textscripts.Add(textscript4);

        // Sync with Event controller

        ec = EC.GetComponent<EventController>();

        // using "storyprogress" state variable

        currentmode = PlayerPrefs.GetInt("Mode") - 1; // for Script indexing and standardization
        storyprogress = 0;
        StoryManager();        

    }

    // Update is called once per frame
    void Update()
    {
        // stage continues with mouse click
        if(currentmode!=-1 && Input.GetKeyDown(KeyCode.Mouse0) /*&& !ec.isPlay*/)
        {
            storyprogress++;
            StoryManager();
        }
    }


    public void StoryManager()
    {
        if(currentmode == 0)
        { // Biscuit Story

            switch (storyprogress)
            {
                case 0:
                    Start_TextBox_B(0);
                    break;
                case 1:
                    Start_TextBox_B(1);
                    break;
                case 2:
                    Stop_TextBox_B();
                    ec.isPlay = 1;
                    break;                
            }

        }else if(currentmode == 1)
        { // Rec2Square Story

            switch (storyprogress)
            {
                case 0:
                    Start_TextBox_R(0);
                    break;
                case 1:
                    Start_TextBox_R(1);
                    break;
                case 2:
                    Stop_TextBox_R();
                    ec.isPlay = 1;
                    break;
            }

        }
        else if(currentmode == 2)
        { // Similarity Story

            switch (storyprogress)
            {
                case 0:
                    Start_TextBox_S(0);
                    break;
                case 1:
                    Start_TextBox_S(1);
                    break;
                case 2:
                    Stop_TextBox_S();
                    ec.isPlay = 1;
                    break;
            }

        }
    }

    void Start_TextBox_B(int num)
    {
        BiscuitText.SetActive(true);
        text_b.text = textscripts[currentmode][num];
    }

    void Start_TextBox_R(int num)
    {
        Rec2SquareText.SetActive(true);
        text_r.text = textscripts[currentmode][num];
    }

    void Start_TextBox_S(int num)
    {
        SimilarText.SetActive(true);
        text_s.text = textscripts[currentmode][num];
    }

    void Stop_TextBox_B()
    {
        BiscuitText.SetActive(false);
    }

    void Stop_TextBox_R()
    {
        Rec2SquareText.SetActive(false);
    }

    void Stop_TextBox_S()
    {
        SimilarText.SetActive(false);
    }

}
