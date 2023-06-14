using UnityEngine;

public class ItemShop : MonoBehaviour
{
    [SerializeField] public GameObject _selectBottun; //アイテム購入のBottun
    [SerializeField] public ItemDataBase _itemBase; //databaseをアタッチ
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ItemsShop()　//palyerで呼ぶ
    {
        if (gameObject.transform.childCount < _itemBase._itemList.Count)
        {
            for (int i = 0; i < _itemBase._itemList.Count; i++)
            {
                GameObject itemButton = Instantiate(_selectBottun);
                itemButton.GetComponent<ItemShopButton>().ID = _itemBase._itemList[i]._itemID;
                itemButton.GetComponent<ItemShopButton>().Cost = _itemBase._itemList[i]._cost;
                itemButton.transform.SetParent(transform);
            }
        }
    }
}
