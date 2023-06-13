using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PocketItem
{
    public int _itemID; //�A�C�e����ID
    public GameObject _item; // �A�C�e����Prefab
    public string _itemName;
    public string _itemEffect; // �ǂ�Ȍ��ʂ����邩
    public int _itemCount; // ���݂̏�����
    public Sprite _itemImage; // �A�C�e��Slot�ɕ\�����邽�߂�image
    public Action _effect; // ���̃A�C�e�����ǂ�Ȍ��ʂ����邩
    public int _cost;
}
