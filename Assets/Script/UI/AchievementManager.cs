using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Sprite lockIcon;
    public Sprite unlockedIcon;
    public Image currentImage;

    public int color;
    private List<Color> colors;

    public int row;
    enum rows
    {
        ENEMY_KILLED,
        TOWERS_PLACED
    }

    public int constraint;

    // Use this for initialization
    void Start()
    {
        colors = new List<Color>() { Color.green, Color.yellow, Color.magenta, Color.blue, Color.red };
        currentImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIcon();
    }

    public void ChangeIcon()
    {
        Debug.Log(PlayerDataLoad.main);
        if (currentImage.sprite != unlockedIcon)
        {
            switch (row)
            {
                case (int)rows.ENEMY_KILLED:
                    UnlockIcon(PlayerDataLoad.main.enemiesKilled);
                    break;
                case (int)rows.TOWERS_PLACED:
                    UnlockIcon(PlayerDataLoad.main.towersPlaced);
                    break;
            }
        }
    }

    private void UnlockIcon(int val)
    {
        if (val >= constraint)
        {
            currentImage.sprite = unlockedIcon;
            currentImage.color = colors[color];
        }
    }
}

