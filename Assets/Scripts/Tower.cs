using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum  TowerType { ATK, BUFF, GOLD }

public class Tower : MonoBehaviour
{
    //타워의 종류 - 공격타워, 버프 & 디버프 타워, 골드타워,
    public TowerType type;

    public string towerName; //타워의 이름
    public float currentTime;
    public float maxTime; //도달하면 액션
    public Vector2 towersize; //범위 - 공격범위, 버프범위
    public int atk; //공격력, 버프수치, 디버프수치, 골드 획득량

    public LayerMask layer;

    public SpwanVirus spwanVirus;

    //필요한것들
    //타겟
    //공격 - 공격력, 공격범위, 공격속도, 
    //버프 - 버프 증가량, 버프 지속시간, 버프 쿨타임, 버프 범위 - (아군타워, 플레이어), 디버프 범위 - 필드
    //골드 - 골드 획득량, 골드 획득 쿨타임

    //타워가 해야할것
    //공통 - 타겟, 쿨타임, 액션, 증가량

    protected virtual void Init()
    {
        maxTime = 0f;
        towersize = Vector2.zero;
        atk = 0;
    }

    //void OnDrawGizmos()
    //{//감지 범위 그려줌
    //    Gizmos.color = Color.red;
    //    switch (type)
    //    {
    //        case TowerType.ATK:
    //           Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), towersize);
    //            break;
    //        case TowerType.BUFF:
    //            Gizmos.DrawWireCube(transform.position, towersize);
    //            break;
    //    }
    //}
}
