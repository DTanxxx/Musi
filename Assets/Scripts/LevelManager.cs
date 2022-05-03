using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image blackImage = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private int battleSceneIndex = 1;
    [SerializeField] private int summarySceneIndex = 2;

    public void LoadBattleScene()
    {
        StartCoroutine(FadeOut(true));
    }

    public void LoadSummaryScene()
    {
        StartCoroutine(FadeOut(false));
    }

    private IEnumerator FadeOut(bool goesToBattleScene)
    {
        if (goesToBattleScene)
        {
            // heading to battle scene, FadeOutDirect = true
            animator.SetBool("FadeOutDirect", true);
        }
        blackImage.gameObject.SetActive(true);
        animator.SetBool("Fade", true);
        
        yield return new WaitUntil(() => blackImage.color.a == 1);
        if (goesToBattleScene)
        {
            yield return SceneManager.LoadSceneAsync(battleSceneIndex);
        }
        else
        {
            yield return SceneManager.LoadSceneAsync(summarySceneIndex);
        }
    }
}
