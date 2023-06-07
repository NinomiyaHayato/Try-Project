using System.Collections.Generic;
using UnityEngine;

public class PocketManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> _ItemList;
    [SerializeField] public List<int> _itemIdList;
    public ItemDataBase _itemDataBase;

    ItemSlots _itemSlots;
    // Start is called before the first frame update
    void Start()
    {
        _itemSlots = GameObject.FindObjectOfType<ItemSlots>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            ItemManager itemManager = collision.gameObject.GetComponent<ItemManager>();

            if (itemManager.PickUp() != _itemDataBase._itemList.Count)
            {
                AddPocket(itemManager.PickUp());
            }
        }
    }
    public void AddPocket(int itemId)
    {
        var itemPrefab = Instantiate(_itemDataBase._itemList[itemId]._item, this.gameObject.transform);
        _ItemList.Add(itemPrefab);
        itemPrefab.transform.localPosition = new Vector3(0, 0, 0);
        if (_itemIdList.Contains(itemId))
        {
            //_itemDataBase._itemList[itemId]._itemCount += 1;
            _itemSlots.Set(itemId);
        }
        else
        {
            _itemDataBase._itemList[itemId]._itemCount += 1;
            _itemIdList.Add(itemId);
            _itemSlots.FirstSet(itemId);
        }
        itemPrefab.SetActive(false);
    }
}
