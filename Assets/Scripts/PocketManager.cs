using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _ItemList;
    ItemDataBase _itemDataBase;
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

            if(_itemManager.PickUp() != 0)
            {
                AddPocket(_itemManager.PickUp());
            }
        }
    }
    public void AddPocket(int itemId)
    {
        var itemPrehub = Instantiate(_itemDataBase._itemList[itemId]._item, this.gameObject.transform);
        _ItemList.Add(itemPrehub);
    }
}
