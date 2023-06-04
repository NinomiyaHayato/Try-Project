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
        _image.sprite = _itemSprite[_nowItem % _itemSprite.Count];
        _text.text = $"{_itemDataBase._itemList[_nowItem % _itemSprite.Count]._itemCount}個";
    }
    public void LeftChange()
    {
        if(_nowItem > 0)
        {
            _nowItem--;
            _image.sprite = _itemSprite[_nowItem % _itemSprite.Count];
            _text.text = $"{_itemDataBase._itemList[_nowItem % _itemSprite.Count]._itemCount}個";
        }
    }
    public void FirstSet(int itemid)
    {
        _itemSprite.Add(_itemDataBase._itemList[itemid]._itemImage);
        _image.sprite = _itemSprite[0];
        _nowItem = 0;
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}個";
    }
    public void Set(int itemid)
    {
        _itemSprite.Add(_itemDataBase._itemList[itemid]._itemImage);
    }
}
