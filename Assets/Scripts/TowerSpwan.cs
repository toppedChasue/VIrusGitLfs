using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpwan : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    //�巡�� �ؼ� ���� �� ã�ƺ���

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

    //���� �ϰ������
    //Ÿ���� �巡���Ͽ� ������ ��ġ�� ���� ������ ��ġ



}
