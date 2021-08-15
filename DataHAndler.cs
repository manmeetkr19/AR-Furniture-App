using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class DataHAndler : MonoBehaviour
{
    private GameObject furniture;
    [SerializeField] ButtonManager buttonPrefab;
    [SerializeField] GameObject buttonContainer;
    [SerializeField] List<Item> items;
    [SerializeField] private string label;

    private int currentid = 0;

    private static DataHAndler instance;
    public static DataHAndler Instance {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<DataHAndler>();
            return instance;
        }
    
    
    }
    private async void Start()
    {
          LoadItem();
       // await Get(label);
        CreateButton();
    }

    void LoadItem()
    {
       
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach(var item in items_obj)
        {
            items.Add(item as Item);
        }
        Debug.Log("Load Item is acccessed");
    }

   void CreateButton()
    {
        foreach(Item i in items)
        {
            ButtonManager btn = Instantiate(buttonPrefab, buttonContainer.transform);
            btn.ItemId = currentid;
            btn.ButtonPic = i.furnitureImage;
            currentid++;
        }
        Debug.Log("Button Added");
    }
   public void setFurniture(int id)
    {
        furniture = items[id].furniturePrefab;
        Debug.Log("furniture added");
    }

    public GameObject getFurniture()
    {
        return furniture;
    }

   /* public async Task Get(string label)
    {
        var locations =await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach(var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            items.Add(obj);
        }
    
    }*/
}
