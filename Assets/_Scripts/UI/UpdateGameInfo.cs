using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHpStatus;
    [SerializeField] private Image lineHpStatus;
    [SerializeField] private TextMeshProUGUI textEnemySpawned;
    [SerializeField] private TextMeshProUGUI textEnemyRemaining;

    private void OnEnable()
    {
        LevelManager.OnLoadLevel += SetInfoHp;
        LevelManager.OnHpChange += UpdateHpStatus;
        LevelManager.OnEnemyStartSpawned += SetInfoEnemy;
        LevelManager.OnEnemyDead += UpdateEnemyRemaining;
    }

    private void OnDisable()
    {
        LevelManager.OnLoadLevel -= SetInfoHp;
        LevelManager.OnHpChange -= UpdateHpStatus;
        LevelManager.OnEnemyStartSpawned -= SetInfoEnemy;
        LevelManager.OnEnemyDead -= UpdateEnemyRemaining;
    }

    private void SetInfoHp()
    {
        textHpStatus.text =
            $"HP: {LevelManager.HpLevel} / {LevelManager.HpLevel}";
        lineHpStatus.fillAmount = 1f;
    }

    private void SetInfoEnemy(int value)
    {
        textEnemySpawned.text =
            $"Spawned Enemy: {value}";
        textEnemyRemaining.text =
            $"Remaining Enemy: {value}";
    }
    
    private void UpdateEnemyRemaining(int value)
    {
        textEnemyRemaining.text =
            $"Remaining Enemy: {value}";
    }

    private void UpdateHpStatus(int hp)
    {
        textHpStatus.text =
            $"HP: {hp} / {LevelManager.HpLevel}";
        lineHpStatus.fillAmount = (float)hp / LevelManager.HpLevel;
    }
}
