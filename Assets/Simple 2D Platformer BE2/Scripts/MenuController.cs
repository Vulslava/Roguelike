using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool start = false;
    public bool settings = false;
    public bool back = false;
    public bool quit = false;
    int quality;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("settings.txt"))
        {
            StreamReader f = new StreamReader("settings.txt");
            quality = int.Parse(f.ReadLine());
            QualitySettings.SetQualityLevel(quality, true);
            f.Close();
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (start == true)
            SceneManager.LoadScene("Demo");
        if (settings == true)
            SceneManager.LoadScene("Settings");
        if (back == true)
            SceneManager.LoadScene("Main menu");
        if (quit == true)
            Application.Quit();
    }
}
