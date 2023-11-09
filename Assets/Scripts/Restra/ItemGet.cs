using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{
    public int _arrayNum { get; private set; }
    private void Awake()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < ItemInventory.instance._itemBool.Length; i++)
            {
                if (ItemInventory.instance._itemBool[i] == false)
                {
                    MoveItem(i);
                    break;
                }
            }
        }
    }
    private void MoveItem(int i)
    {
        _arrayNum = i;
        ItemInventory.instance._itemBool[i] = true;
        transform.position = ItemInventory.instance._itemSlot[i].transform.position;
    }
}
