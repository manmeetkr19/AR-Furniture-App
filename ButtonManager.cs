using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    Button btn;
   // public GameObject furniture;
   [SerializeField]  private RawImage buttonImage;
    private int _itemId;
    private Sprite buttonPic;
    public int ItemId
    {
        set => _itemId = value;
    }
    public Sprite ButtonPic {
        set
        {
            buttonPic = value;
            buttonImage.texture = buttonPic.texture;
            Debug.Log(value.name);
        }

    }

    

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(furnitureSelector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void furnitureSelector()
    {
        DataHAndler.Instance.setFurniture(_itemId);
    }
}
