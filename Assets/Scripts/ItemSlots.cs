using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlots : MonoBehaviour
{
    [SerializeField, Header("���ݏ��L���Ă���A�C�e�����i�[")] public List<Sprite> _itemSprite;
    [SerializeField, Header("�]��v�Z�̂��߂̐���")] public int _nowItem;

    [SerializeField] Image _image;�@// �A�C�e����image
    public ItemDataBase _itemDataBase;
    [SerializeField] Text _text; //�A�C�e���̌���\��

    public List<PocketItem> _pocketItem;
    public void RightChange()�@//�A�C�e�����E�ɐ؂�ւ���(Bottun�ɂ���
    {
        if (_pocketItem.Count != 0)
        {
            _nowItem++;
            _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
            _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}��";
        }
    }
    public void LeftChange()�@//�A�C�e�������ɐ؂�ւ���(Button�ɂ���
    {
        if (_nowItem > 0)
        {
            if (_pocketItem.Count != 0)
            {
                _nowItem--;
                _image.sprite = _pocketItem[_nowItem % _pocketItem.Count]._itemImage;
                _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}��";
            }
        }
    }
    public void FirstSet(int itemid)�@//�������A�C�e����Slot����Set����
    {
        _pocketItem.Add(_itemDataBase._itemList[itemid]);
        _image.sprite = _pocketItem[0]._itemImage;
        _nowItem = 0;
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}��";
        _pocketItem[_pocketItem.Count - 1]._effect += FindObjectOfType<ItemManager>().Use;
    }
    public void Set(int itemid)�@//���Ɏ����Ă���A�C�e���������ꍇ����1���₷
    {
        foreach (var item in _pocketItem)
        {
            if (item._itemID == itemid)
            {
                item._itemCount++;
            }
        }
        _text.text = $"{_itemDataBase._itemList[itemid]._itemCount}��";
    }
    public void UseItem() //�A�C�e���̎g�p(slot��؂�ւ��铙�̏���
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
                _text.text = $"{_pocketItem[_nowItem % _pocketItem.Count]._itemCount}��";
            }
        }
        if(_pocketItem.Count == 0)
        {
            _image.sprite = null;
            _text.text = "0��";
        }
    }
    IEnumerator HealEffect() //�R���[�`���ł̃p�[�e�B�N��
    {
        GameObject heal = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>()._healMotion;
        heal.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        heal.SetActive(false);
    }
}
