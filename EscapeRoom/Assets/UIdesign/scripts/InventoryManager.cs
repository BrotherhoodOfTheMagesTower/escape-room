using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<Item> Items;
    [SerializeField] Transform ItemContent;
    [SerializeField] GameObject InventoryItem;
    private void Awake()
    {
        Items = new List<Item>();
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Delete(Item item)
    {
        Items.Remove(item);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ListItems()
    {
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Items.Add(new Item() { id = 2, itemName = "test", value = 13 });
        }
    }
}
