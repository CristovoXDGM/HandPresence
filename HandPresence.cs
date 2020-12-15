using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    public List<GameObject> controllePrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    
    void Start()
    {

        TryInitialize();

    }

    //This function try to initialize the controllers and then display them
    void TryInitialize() {
        List<InputDevice> devices = new List<InputDevice>();
        ;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            GameObject prefab = controllePrefab.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {

                spawnedController = Instantiate(prefab, transform);
            }
            else
            {

                Debug.Log("did not fid the correnspondig controller");
                spawnedController = Instantiate(controllePrefab[0], transform);

            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }


    void UpdateHandAnimator() {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
    }

    void Update()
    {


        if (!targetDevice.isValid)
        {

            TryInitialize();

        }
        else {


            if (showController)
            {

                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);

            }
            else
            {

                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimator();

            }


        }


        //Get input from controller : targetDevice.TryGetFeatureValue(CommonUsages.X, out VariableType VariableName)
        



    }





}
