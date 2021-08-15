using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour
{
    
   // [SerializeField] GameObject furniture;
    [SerializeField] Camera arCam;
    [SerializeField] ARRaycastManager _rayManager;
    List<ARRaycastHit> hit = new List<ARRaycastHit>();
    Touch touch;
    [SerializeField] GameObject crosshair;
    Pose pose;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        
        if(Input.touchCount<0 || touch.phase!=TouchPhase.Began)
        {
            return;
        }
        if (IsPointerOverUI(touch))
            return;

       Instantiate(DataHAndler.Instance.getFurniture(), pose.position, pose.rotation);


    }

    bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;  
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(.5f, .5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);
        if (_rayManager.Raycast(ray, hit))
        {
            pose = hit[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
