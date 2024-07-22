using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject finishGameMenu;
    [SerializeField] private Button reloadSceneButton;

    [SerializeField] private TextMeshProUGUI textFinishGame;
    private void OnEnable()
    {
        LevelManager.OnEnemyDead += CheckFinishGame;
        LevelManager.OnCompleteGame += ActivateFinishGameMenu;
    }

    private void OnDisable()
    {
        LevelManager.OnEnemyDead -= CheckFinishGame;
        LevelManager.OnCompleteGame -= ActivateFinishGameMenu;
    }

    private void CheckFinishGame(int countEnemyRemaining)
    {
        if(countEnemyRemaining <= 0) ActivateFinishGameMenu();
    }

    private void ActivateFinishGameMenu()
    {
        reloadSceneButton.onClick.AddListener(ReloadScene);
        finishGameMenu.SetActive(true);
        if (LevelManager.HpLevel <= 0)
        {
            textFinishGame.text = $"You LOSS! Remaining count enemy: {LevelManager.CountEnemyRemaining}";
            textFinishGame.color = Color.red;
        }
        else
        {
            textFinishGame.text = $"You WIN! Remaining heath: {LevelManager.HpLevel}";
            textFinishGame.color = Color.green;
        }

        Time.timeScale = 0;
    }
    
    private void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
