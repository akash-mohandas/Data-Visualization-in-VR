using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Raycast : MonoBehaviour
{
    GameObject heldObject;
    Controller controller;

    Rigidbody simulator;
    public double distance;
    private LineRenderer laserline;
    public Transform laserend;
    

    //public Valve.VR.EVRButtonId pickUpButton;
    //public Valve.VR.EVRButtonId dropButton;
    void Start()
    {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        controller = GetComponent<Controller>();
        laserline = GetComponent<LineRenderer>();
        
    }


    void Update()
    {
        
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
                heldObject.GetComponent<HeldObject>().parent = null;
                //heldObject.GetComponent < HeldObject>().hideLines();
                heldObject = null;
            }
        }
        else
        {
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //laserline.enabled = true;
                laserline.SetPosition(0, controller.transform.position);
                RaycastHit[] cols = Physics.RaycastAll(controller.transform.position,controller.transform.forward, 20.0f);
                Debug.Log(cols.Length);

                if (cols.Length > 0)
                {
                    Debug.Log("collider hit");
                    laserline.SetPosition(1, cols[0].point);
                    Collider col = cols[0].collider;
                    
                    distance = cols[0].distance;
                    


                    for (int i = 0; i < cols.Length; i++)
                    {
                        Debug.Log(cols[i].distance);

                        if (cols[i].distance < distance)
                        {
                            col = cols[i].collider;
                            distance = cols[i].distance;
                            
                        }
                    }



                    if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = col.gameObject;
                        heldObject.transform.parent = transform;
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.transform.localRotation = Quaternion.identity;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        heldObject.GetComponent<HeldObject>().parent = controller;
                        //heldObject.GetComponent<HeldObject>().showLines();
                    }

                }
                else
                {
                    laserline.SetPosition(1, controller.transform.forward * 20.0f);
                }
            }
        }
    }
}
