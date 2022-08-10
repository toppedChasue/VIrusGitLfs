using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //추상클래스로 구현해보기
    //타워의 종류 - 공격타워, 버프 & 디버프 타워, 골드타워,

    public GameObject[] TowerPrefabs; //프리팹들
    public Vector2 size; //범위 - 공격범위, 버프범위

    public float currentTime;
    public float coolTime;

    
    
    //필요한것들
    //공격 - 공격력, 공격범위, 공격속도, 
    //버프 - 버프 증가량, 버프 지속시간, 버프 쿨타임, 버프 범위 - 아군타워, 플레이어, 디버프 범위 - 필드
    //골드 - 골드 획득량, 골드 획득 쿨타임


    //타워가 해야할것
    //공통 - 타겟설정, 쿨타임 돌리기, 액션, 





}
