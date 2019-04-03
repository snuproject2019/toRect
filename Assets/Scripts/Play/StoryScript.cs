﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour {

    // 텍스트박스는 텍스트만, 스피치버블은 이름 + 텍스트로 이중 작업.
    // 스테이트 활용해서 중간중간 텍스트/스피치가 나올 수 있도록 설계.

    // Scripts
    List<string[]> textscripts;
    List<string[]> bubblescripts;
    List<string[]> bubblenames; 

    // EventController
    public GameObject EC;
    private EventController ec;

    // StoryMode Text
    public GameObject TextBox;
    public Text TextBox_text;

    // StoryMode Bubble
    public GameObject SpeechBubble;
    public Text SpeechBubble_text;
    public Text SpeechBubble_name;

    // Story mode internal variables
    private int currentmode;
    private int storyprogress;

    // Scripts (Horrible code, may need to refactor it sometime)

    // 1st stage
    string[] textscript1 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        };
    string[] bubblescript1 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        ,"이번에는 sec다. 멋진 창을 날릴 수 있지"
        };
    string[] bubblename1 =  {
        "깨다",
        "교관",
        "따미",
        "깨다",
        "깨다",
        "따미"
        };

    // 2nd stage
    string[] textscript2 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        };
    string[] bubblescript2 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        ,"이번에는 sec다. 멋진 창을 날릴 수 있지"
        };
    string[] bubblename2 =  {
        "깨다",
        "교관",
        "따미",
        "깨다",
        "깨다",
        "따미"
        };

    // 3rd stage
    string[] textscript3 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        };
    string[] bubblescript3 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        ,"이번에는 sec다. 멋진 창을 날릴 수 있지"
        };
    string[] bubblename3 =  {
        "깨다",
        "교관",
        "따미",
        "깨다",
        "깨다",
        "따미"
        };

    // 4th stage
    string[] textscript4 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        };
    string[] bubblescript4 = {
        "어느 날 깨다는 깨봉으로 열심히 삼각함수를 공부를 하였습니다. \n공부를 마친 깨다는 잠시 쉬기 위해 TV를 켰는데 \n마침 중세시대의 기사들이 나오는 영화가 나오고 있었습니다. \n지난 방학 때 로마로 여행을 갔다 온 깨다는 콜로세움의 검투사들의 전투가 멋있어 보였습니다. \n한창 영화를 보던 깨다는 눈꺼풀이 점차 무거워 지며 참을 수 없는 졸음에 빠집니다."
        ,"정신을 차린 깨다는 콜로세움 경기장 안에 서있었습니다. \n그리고 바로 눈 앞에는 험상궂게 생기고 온몸에 흉터가 있는 검투사가 한 명 서있었습니다. \n깨다를 노려보며 그 검투사는 입을 열었습니다."
        ,"신참! 정신 똑바로 차려라! \n싸울 검투사가 부족해 지원을 받았더니\n이렇게 흐리멍텅한 사람을 보내주다니…. 나 원 참…"
        ,"이 삼각형을 이용해서 공격과 방어를 할 수 있다.\n 삼각함수는 알고 있겠지? \n잘 모르겠으면 깨봉tv에서 공부하고 와라. "
        ,"멋진 화살이군.\n이번에는 활로 슬라임을 조준해서 쏘아보거라.\n처음이니까 2마리부터다."
        ,"이번에는 sec다. 멋진 창을 날릴 수 있지"
        };
    string[] bubblename4 =  {
        "깨다",
        "교관",
        "따미",
        "깨다",
        "깨다",
        "따미"
        };


    // Use this for initialization
    private void Awake()
    {

        // Sync with Event controller

        ec = EC.GetComponent<EventController>();

        // using "storyprogress" state variable

        currentmode = PlayerPrefs.GetInt("mode") - 1; // for Script indexing and standardization
        storyprogress = 0;

        // adding scripts

        textscripts.Add(textscript1);
        bubblescripts.Add(bubblescript1);
        bubblenames.Add(bubblename1);
 
        textscripts.Add(textscript2);
        bubblescripts.Add(bubblescript2);
        bubblenames.Add(bubblename2);

        textscripts.Add(textscript3);
        bubblescripts.Add(bubblescript3);
        bubblenames.Add(bubblename3);

        textscripts.Add(textscript4);
        bubblescripts.Add(bubblescript4);
        bubblenames.Add(bubblename4);

    }

    // Update is called once per frame
    void Update()
    {
        // stage continues with mouse click
        if(Input.GetKeyDown(KeyCode.Mouse0) /*&& !ec.isPlay*/)
        {
            storyprogress++;
            StoryManager();
        }
    }

    // 
    public void StoryManager()
    {
        if(currentmode == 1)
        { // mom story

            switch (storyprogress)
            {
                case 0:
                    Start_TextBox(0);
                    break;
                case 1:
                    Start_TextBox(1);
                    break;
            }

        }else if(currentmode == 2)
        { // dad story

        }else if(currentmode == 3)
        { // friend story

        }else if(currentmode == 4)
        { // teacher story

        }
    }

    // 해당 currentmode의 TextBox + num번째 Text 띄우기
    void Start_TextBox(int num)
    {
        TextBox.SetActive(true);
        TextBox_text.text = textscripts[currentmode][storyprogress];
    }

    // TextBox 지우기
    void Stop_TextBox()
    {
        TextBox.SetActive(false);
    }

    // Bublle + num번째 Text 띄우기
    void Start_SpeechBubble(int num)
    {
        SpeechBubble.SetActive(true);
        SpeechBubble_text.text = bubblescripts[currentmode][storyprogress];
        SpeechBubble_name.text = bubblenames[currentmode][storyprogress];
    }

    // Bubble 지우기
    void Stop_SpeechBubble()
    {
        SpeechBubble.SetActive(false);
    }
}
