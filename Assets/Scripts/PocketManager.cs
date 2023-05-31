using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _ItemList;
    [SerializeField] List<int> _itemIdList;
    public ItemDataBase _itemDataBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            ItemManager _itemManager = collision.gameObject.GetComponent<ItemManager>();

            if(_itemManager.PickUp() != _itemDataBase._itemList.Count)
            {
                AddPocket(_itemManager.PickUp());
            }
        }
    }
    public void AddPocket(int itemId)
    {
        if(_itemIdList.Contains(itemId))
        {
            var itemprehub = Instantiate(_itemDataBase._itemList[itemId]._item, this.gameObject.transform);
            _ItemList.Add(itemprehub);
            itemprehub.transform.localPosition = new Vector3(0, 0, 0);
            _itemDataBase._itemList[itemId]._itemCount += 1;
            itemprehub.SetActive(false);
        }
        else
        {
            var itemPrehub = Instantiate(_itemDataBase._itemList[itemId]._item, this.gameObject.transform);
            _ItemList.Add(itemPrehub);
            _itemIdList.Add(itemId);
            itemPrehub.transform.localPosition = new Vector3(0, 0, 0);
            _itemDataBase._itemList[itemId]._itemCount += 1;
            itemPrehub.SetActive(false);
        }
    }
}
