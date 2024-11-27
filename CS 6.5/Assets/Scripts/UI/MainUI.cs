using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    private VisualElement UI;
    private CombatManager combatManager;
    private HealthComponent HealthComponent;
    private Label Wave;
    private Label Points;
    private Label EnemiesLeft;
    private Label Timer;
    private Label Health;
    private int PlayerHealth;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        combatManager = FindObjectOfType<CombatManager>();
        HealthComponent = FindObjectOfType<HealthComponent>();
        if (root != null)
        {
            Wave = root.Q<Label>("Wave");
            Points = root.Q<Label>("Point");
            EnemiesLeft = root.Q<Label>("EnemiesLeft");
            Timer = root.Q<Label>("Timer");
            Health = root.Q<Label>("Health");
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerHealth = HealthComponent.Health();
        if (combatManager != null)
        {
            if (Wave != null)
                Wave.text = "Wave: " + combatManager.waveNumber;
            if (Points != null)
                Points.text = "Points: " + combatManager.points;
            if (EnemiesLeft != null)
                EnemiesLeft.text = "Enemies Left: " + combatManager.totalEnemies;
            if (Timer != null)
            {
                if (combatManager.timer != 0)
                {
                    Timer.text = "Next Wave in: " + (int)(combatManager.GetWaveInterval() - combatManager.timer + 1);
                }
                else
                {
                    Timer.text = null;
                }
            }
            if (Health != null && PlayerHealth != null && PlayerHealth > 0)
            {
                    Health.text = "Health: " + HealthComponent.Health();
            }
            else if (PlayerHealth <= 0)
            {
                Health.text = null;
                Wave.text = null;
                Points.text = null;
                EnemiesLeft.text = null;
                Timer.text = "Game Over!\n Your Points: " + combatManager.points;
            }
        }
    }
}
