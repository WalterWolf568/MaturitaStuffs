using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    public object[][] LvlUpOptions;

    public UnityEvent EnablePanel;

    [SerializeField]
    public RectTransform Option1;
    [SerializeField]
    public RectTransform Option3;
    [SerializeField]
    public RectTransform Option2;

    [SerializeField]
    public TMP_Text OptionDesc1;
    [SerializeField]
    public TMP_Text OptionDesc2;
    [SerializeField]
    public TMP_Text OptionDesc3;

    public UnityEvent SuccessfulSelect;
    [SerializeField]
    private GameObject Player;
    private PlayerMovement PlayerMovement;
    private PlayerShoot PlayerShoot;
    private HealthController HealthController;

    public void Awake()
    {
        PlayerMovement = Player.GetComponentInChildren<PlayerMovement>();
        PlayerShoot = Player.GetComponentInChildren<PlayerShoot>();
        HealthController = Player.GetComponentInChildren<HealthController>();


        LvlUpOptions = new object[4][];
        

        LvlUpOptions[0] = new object[] { "speed", 0 , 7 };
        LvlUpOptions[1] = new object[] { "health", 0 , 10};
        LvlUpOptions[2] = new object[] { "fireRate", 0, 7 };
        LvlUpOptions[3] = new object[] { "damage", 0, 10};

    }

    public void LevelUp()
    {
       

        if (LvlUpOptions.Length > 3){
            SelectRandomOptions();
            TMP_Text text1 = Option1.GetComponentInChildren<TMP_Text>();
            text1.text = (string)LvlUpOptions[0][0];
            OptionDesc1.text = (LvlUpOptions[0][1] + "/" + LvlUpOptions[0][2]);
            TMP_Text text2 = Option2.GetComponentInChildren<TMP_Text>();
            text2.text = (string)LvlUpOptions[1][0];
            OptionDesc2.text = (LvlUpOptions[1][1] + "/" + LvlUpOptions[1][2]);
            TMP_Text text3 = Option3.GetComponentInChildren<TMP_Text>();
            text3.text = (string)LvlUpOptions[2][0];
            OptionDesc3.text = (LvlUpOptions[2][1] + "/" + LvlUpOptions[2][2]);
            Time.timeScale = 0;
            PlayerShoot.canShoot = false;
            EnablePanel.Invoke();
        }
        else if (LvlUpOptions.Length == 2)
        {
            TMP_Text text1 = Option1.GetComponentInChildren<TMP_Text>();
            text1.text = (string)LvlUpOptions[0][0];
            OptionDesc1.text = (LvlUpOptions[0][1] + "/" + LvlUpOptions[0][2]);
            TMP_Text text2 = Option2.GetComponentInChildren<TMP_Text>();
            text2.text = (string)LvlUpOptions[1][0];
            OptionDesc2.text = (LvlUpOptions[1][1] + "/" + LvlUpOptions[1][2]);
            Option3.gameObject.SetActive(false);
            Option1.localPosition = new Vector3(300, 0);
            Option2.localPosition = new Vector3(250, 0);
            Time.timeScale = 0;
            PlayerShoot.canShoot = false;
            EnablePanel.Invoke();
        }
        else if (LvlUpOptions.Length == 1)
        {
            TMP_Text text1 = Option1.GetComponentInChildren<TMP_Text>();
            text1.text = (string)LvlUpOptions[0][0];
            OptionDesc1.text = (LvlUpOptions[0][1] + "/" + LvlUpOptions[0][2]);
            Option2.gameObject.SetActive(false);
            Option3.gameObject.SetActive(false);
            Option1.localPosition = new Vector3(750, 0);
            Time.timeScale = 0;
            PlayerShoot.canShoot = false;
            EnablePanel.Invoke();
        }
        else if (LvlUpOptions.Length == 3)
        {
            TMP_Text text1 = Option1.GetComponentInChildren<TMP_Text>();
            text1.text = (string)LvlUpOptions[0][0];
            OptionDesc1.text = (LvlUpOptions[0][1] + "/" + LvlUpOptions[0][2]);
            TMP_Text text2 = Option2.GetComponentInChildren<TMP_Text>();
            text2.text = (string)LvlUpOptions[1][0];
            OptionDesc2.text = (LvlUpOptions[1][1] + "/" + LvlUpOptions[1][2]);
            TMP_Text text3 = Option3.GetComponentInChildren<TMP_Text>();
            text3.text = (string)LvlUpOptions[2][0];
            OptionDesc3.text = (LvlUpOptions[2][1] + "/" + LvlUpOptions[2][2]);
            Time.timeScale = 0;
            PlayerShoot.canShoot = false;
            EnablePanel.Invoke();
        }
        else if (LvlUpOptions.Length == 0)
        {
            HealthController.AddHealth(10);
        }
        
        
    }
    public void SelectRandomOptions()
    {

        for (int i = 0; i < LvlUpOptions.Length; i++)
        {
            object[] temp = LvlUpOptions[i];
            int randomIndex = Random.Range(0, LvlUpOptions.Length);
            LvlUpOptions[i] = LvlUpOptions[randomIndex];
            LvlUpOptions[randomIndex] = temp;
        }

    }
    public void SelectOption(int option)
    {
        object[] selectedOption = LvlUpOptions[option];

        switch ((string)selectedOption[0])
        {
            case "speed":
                Debug.Log("speed selected");
                Debug.Log("speed = " + PlayerMovement.speed);
                PlayerMovement.speed += 1f;
                Debug.Log("speed after = " + PlayerMovement.speed);
                selectedOption[1] = (int)selectedOption[1] + 1;
                break;
            case "health":
                Debug.Log("health selected");
                HealthController.AddMaxHealth(10);
                Debug.Log("fireRate = " + PlayerShoot.timeBetweenShots);
                selectedOption[1] = (int)selectedOption[1] + 1;
                break;
            case "damage":
                Debug.Log("damage selected");
                Debug.Log("damage = " + PlayerShoot.bulletDamage);
                PlayerShoot.bulletDamage += 4;
                Debug.Log("damage after = " + PlayerShoot.bulletDamage);
                selectedOption[1] = (int)selectedOption[1] + 1;
                break;
            case "fireRate":
                Debug.Log("fikreRate selected");
                Debug.Log("fireRate = " + PlayerShoot.timeBetweenShots);
                PlayerShoot.timeBetweenShots -= 0.1f;
                Debug.Log("fireRate after = " + PlayerShoot.timeBetweenShots);
                selectedOption[1] = (int)selectedOption[1] + 1;
                break;
            
        }
        if ((int)selectedOption[1] >= (int)selectedOption[2])
        {
            Debug.Log("triggered for 0 fucking reason im killing myself");
            List<object[]> tempOptionsList = new List<object[]>(LvlUpOptions);
            tempOptionsList.RemoveAt(option); 
            LvlUpOptions = tempOptionsList.ToArray(); 
        }

        Time.timeScale = 1;
        PlayerShoot.canShoot = true;
        SuccessfulSelect.Invoke();
    }
}
