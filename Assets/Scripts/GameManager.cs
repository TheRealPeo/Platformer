using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentPickup;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = Mathf.Ceil(100f * (currentPickup / 11f));
        GameObject.Find("RubbishText").GetComponent<Text>().text = "Collected " + percentage + "% of rubbish";
    }

    public void AddPickup(int pickupToAdd)
    {
        currentPickup += pickupToAdd;
    }

    public int GetCurrentPickup()
    {
        return currentPickup;
    }
}
