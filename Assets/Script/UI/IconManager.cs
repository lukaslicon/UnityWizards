using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class IconManager : MonoBehaviour
{
	public Image buildTowerIcon;
	public Image killedEnemyIcon;
	public Image balloonPopIcon;
	public TMP_Text label;

	public Dictionary<int, Color> iconColors;

	private DataManager dataManager;
	private PopUpAchievements popUpManager;


	// Use this for initialization
	void Start()
	{
		dataManager = FindObjectOfType<DataManager>();
		popUpManager = FindAnyObjectByType<PopUpAchievements>();

		iconColors = new Dictionary<int, Color>();

		// colors for icons
		iconColors[10] = Color.green;
		iconColors[50] = Color.yellow;
		iconColors[100] = Color.magenta;
		iconColors[500] = Color.blue;
		iconColors[1000] = Color.red;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CreateTowerIcon()
	{
		if (iconColors.ContainsKey(dataManager.towersPlaced)) {
			Image newTowerIcon = Instantiate(buildTowerIcon);
			newTowerIcon.color = iconColors[dataManager.towersPlaced];
			popUpManager.PopUpIcon(newTowerIcon);

			TMP_Text newLabel = Instantiate(label, newTowerIcon.transform);
			newLabel.transform.localPosition = new Vector3(0, -110, 0);
			newLabel.text = "Placed " + dataManager.towersPlaced + (dataManager.towersPlaced > 1 ? " Towers" : " Tower");

			StartCoroutine(popUpManager.DestroyIcon(newTowerIcon, newLabel));
		}
	}

	public void CreateEnemyKilledIcon()
	{
        if (iconColors.ContainsKey(dataManager.enemiesKilled))
        {
            Image newSkullIcon = Instantiate(killedEnemyIcon);
            newSkullIcon.color = iconColors[dataManager.enemiesKilled];
            popUpManager.PopUpIcon(newSkullIcon);

            TMP_Text newLabel = Instantiate(label, newSkullIcon.transform);
            newLabel.transform.localPosition = new Vector3(0, -110, 0);
            newLabel.text = "Killed " + dataManager.enemiesKilled + (dataManager.enemiesKilled > 1 ? " Enemies" : " Enemy");

            StartCoroutine(popUpManager.DestroyIcon(newSkullIcon, newLabel));
        }
    }
}

