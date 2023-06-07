using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    [SerializeField, Header("現在所有しているアイテムを格納")] public List<Sprite> _itemSprite;
    [SerializeField, Header("余剰計算のための数字")] public int _nowItem;

    [SerializeField]Image _image;
    public ItemDataBase _itemDataBase;
    [SerializeField] Text _text;

    public List<PocketItem> _pocketItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Sort()
    {
        var poketItemList = FindObjectOfType<PocketManager>()._ItemList;
    }
    public void RightChange()
    {
        _nowItem++;
        //_image.sprite = _itemSprite[_nowItem % _itemSprite.Count];
        //_text.text = $"{_itemDataBase._itemList[_nowItem % _itemSprite.Count]._itemCount}個";
        _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
        _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}個";
    }
    public void LeftChange()
    {
        if(_nowItem > 0)
        {
            _nowItem--;
            _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
            _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}個";
        }
    }

    //public void SetItem(int itemID)
    //{
    //    foreach(var item in _pocketItem)
    //    {
    //        if(item._itemID == itemID)
    //        {
    //            item._itemCount++;
    //        }
    //    }
    //}
    public void FirstSet(int itemid)
    {
        //_itemSprite.Add(_itemDataBase._itemList[itemid]._itemImage);
        _pocketItem.Add(_itemDataBase._itemList[itemid]);
        //_image.sprite = _itemSprite[0];
        _image.sprite = _pocketItem[0]._itemImage;
        _nowItem = 0;
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}個";
        _pocketItem[_pocketItem.Count - 1]._effect += FindObjectOfType<ItemManager>().Use;
    }
    public void Set(int itemid)
    {
        //_itemSprite.Add(_itemDataBase._itemList[itemid]._itemImage);
        //_pocketItem.Add(_itemDataBase._itemList[itemid]);
        foreach (var item in _pocketItem)
        {
            if (item._itemID == itemid)
            {
                item._itemCount++;
            }
        }
    }
    public void UseItem()
    {
        _pocketItem[_nowItem % _pocketItem.Count]._effect();
    }
}
