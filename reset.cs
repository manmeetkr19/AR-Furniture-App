using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Clear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Clear()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
