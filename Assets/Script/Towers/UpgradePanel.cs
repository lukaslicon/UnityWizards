using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    
    public Button upgradeButton1;
    public Button upgradeButton2;
    

    void Start()
    {
        upgradeButton1.onClick.AddListener(UpgradeOption1);
        upgradeButton2.onClick.AddListener(Sell);
        
    }
    void Update()
    {
        // Make the health bar face the camera
        if (Camera.main != null)
        {
           upgradeButton1.transform.LookAt(Camera.main.transform);
           upgradeButton2.transform.LookAt(Camera.main.transform);
        }
    }
    
    void UpgradeOption1()
    {
        Debug.Log("YES");
    }

    
    void Sell()
    {
       Debug.Log("YES");
    }
}
