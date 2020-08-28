using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI currentScoreT;

    private void Start()
    {
        currentScoreT.text = currentScore.ToString();
    }

    private void Update()
    {
        currentScoreT.text = currentScore.ToString(); 
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroy()
    {
        breakableBlocks--;
        currentScore++;

        if (breakableBlocks <= 0)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }
}
