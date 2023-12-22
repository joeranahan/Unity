using UnityEngine;
using TMPro;  // Add this namespace to use TextMeshPro

public class GameStatsDisplay : MonoBehaviour
{
    public TextMeshProUGUI statsText; // Change to TextMeshProUGUI
    private float updateInterval = 0.5f;
    private float accumTime = 0;
    private int frames = 0;
    private float timeleft;

    void Start()
    {
        if (!statsText)
        {
            Debug.LogError("Please assign a TextMeshPro component!");
            this.enabled = false;
            return;
        }
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accumTime += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            float fps = accumTime / frames;
            string format = string.Format("{0:F2} FPS\n{1} MB Used", fps,
                                (System.GC.GetTotalMemory(false) / 1048576f));
            statsText.text = format;

            timeleft = updateInterval;
            accumTime = 0.0f;
            frames = 0;
        }
    }
}