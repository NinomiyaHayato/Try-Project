using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlots : MonoBehaviour
{
    [SerializeField, Header("現在所有しているアイテムを格納")] public List<Sprite> _itemSprite;
    [SerializeField, Header("余剰計算のための数字")] public int _nowItem;

    [SerializeField] Image _image;　// アイテムのimage
    public ItemDataBase _itemDataBase;
    [SerializeField] Text _text; //アイテムの個数を表示

    public List<PocketItem> _pocketItem;
    public void RightChange()　//アイテムを右に切り替える(Bottunにつける
    {
        if (_pocketItem.Count != 0)
        {
            _nowItem++;
            _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
            _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}個";
        }
    }
    public void LeftChange()　//アイテムを左に切り替える(Buttonにつける
    {
        if (_nowItem > 0)
        {
            if (_pocketItem.Count != 0)
            {
                _nowItem--;
                _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
                _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}個";
            }
        }
    }
    public void FirstSet(int itemid)　//未所持アイテムをSlot内にSetする
    {
        _pocketItem.Add(_itemDataBase._itemList[itemid]);
        _image.sprite = _pocketItem[0]._itemImage;
        _nowItem = 0;
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}個";
        _pocketItem[_pocketItem.Count - 1]._effect += FindObjectOfType<ItemManager>().Use;
    }
    public void Set(int itemid)　//既に持っているアイテムだった場合個数を1増やす
    {
        foreach (var item in _pocketItem)
        {
            if (item._itemID == itemid)
            {
                item._itemCount++;
            }
        }
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}個";
    }
    public void UseItem() //アイテムの使用(slotを切り替える等の処理
    {
        if (_pocketItem.Count != 0)
        {
            StartCoroutine("HealEffect");
            _pocketItem[_nowItem % _pocketItem.Count]._effect();
            _pocketItem[_nowItem % _pocketItem.Count]._itemCount -= 1;
            if (_pocketItem[_nowItem % _pocketItem.Count]._itemCount == 0)
            {
                FindObjectOfType<PocketManager>()._itemIdList.RemoveAt(_nowItem % _pocketItem.Count);
                _pocketItem.RemoveAt(_nowItem % _pocketItem.Count);
                _nowItem = 0;
                if(_pocketItem.Count != 0)
                {
                    _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
                }
            }
            if(_pocketItem.Count != 0)
            {
                _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}個";
            }
        }
        if(_pocketItem.Count == 0)
        {
            _image.sprite = null;
            _text.text = "0個";
        }
    }
    IEnumerator HealEffect() //コルーチンでのパーティクル
    {
        GameObject heal = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>()._healMotion;
        heal.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        heal.SetActive(false);
    }
}
