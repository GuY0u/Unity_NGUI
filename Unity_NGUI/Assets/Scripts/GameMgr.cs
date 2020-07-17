using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    //배경 오브젝트
    public GameObject _BgObj;

    //추가배경(전등) 오브젝트
    public GameObject _BgLightObj;

    //배경의 이동속도
    public float _moveSpeed;

    //이동거리 체크
    float _xPosMoveChk = 0f;
    float _xLightPosMoveChk = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //매 시간 이동량 누적하여 저장
        _xPosMoveChk += _moveSpeed * Time.deltaTime;
        _xLightPosMoveChk += _moveSpeed * Time.deltaTime*0.5f;

        //배경 이미지 왼쪽(x좌표)으로 매 프레임마다 이동
        _BgObj.transform.localPosition += new Vector3(_moveSpeed * -1f * Time.deltaTime*0.5f, 0, 0);
        _BgLightObj.transform.localPosition += new Vector3(_moveSpeed * -1f * Time.deltaTime, 0, 0);

        //누적 이동량이 960보다 크면 체크(화면에서 배경이 나갈때)
        if (_xPosMoveChk > 960.0f)
        {
            //누적량 초기화 -> 나중에 다시 나가게될시 체크해야되기 때문에
            _xPosMoveChk = 0;

            _BgLightObj.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);
        }
        //누적 이동량이 960보다 크면 체크(화면에서 배경이 나갈때)
        if (_xLightPosMoveChk > 960.0f)
        {
            //누적량 초기화 -> 나중에 다시 나가게될시 체크해야되기 때문에
            _xLightPosMoveChk = 0;

            _BgObj.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);
        }
    }
}
