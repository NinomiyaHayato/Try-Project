using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PocketItem
{
    public int _itemID; //アイテムのID
    public GameObject _item; // アイテムのPrefab
    public string _itemName;
    public string _itemEffect; // どんな効果があるか
    public int _itemCount; // 現在の所持数
    public Sprite _itemImage; // アイテムSlotに表示するためのimage
    public Action _effect; // そのアイテムがどんな効果があるか
    public int _cost;
}
