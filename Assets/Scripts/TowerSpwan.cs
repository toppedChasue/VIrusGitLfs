using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpwan : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    //드래그 해서 놓는 법 찾아보자

    public List<Tower> towerList;
    List<Transform> towerPosList;
    public Transform[] towerPos;
    public Tower[] towerPrefabs;

    private void Awake()
    {
        towerList = new List<Tower>();
        towerPosList = new List<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //내가 하고싶은것
    //타워를 드래그하여 정해진 위치에 갖다 놓으면 설치



}
