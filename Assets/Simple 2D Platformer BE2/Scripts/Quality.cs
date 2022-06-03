using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    public Dropdown dropdown;
    private void Start()
    {
        dropdown.value = QualitySettings.GetQualityLevel();
        checkdropdown();
    }

    public void checkdropdown()
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
        PlayerPrefs.SetInt("Qualities", dropdown.value);
        StreamWriter f = new StreamWriter("settings.txt");
        f.WriteLine(dropdown.value);
        f.Close();
    }
}
