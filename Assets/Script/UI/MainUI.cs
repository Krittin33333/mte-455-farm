using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    
    public static MainUI instance;
    
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text staffText;
    [SerializeField] private TMP_Text wheatText;
    [SerializeField] private TMP_Text melonText;
    [SerializeField] private TMP_Text cornText;
    [SerializeField] private TMP_Text StoneText;
    [SerializeField] private TMP_Text WoodText;

    [SerializeField] private TMP_Text dayText;

    public GameObject laborMarketPanel;

    public GameObject farmPanel;


    [SerializeField] private TMP_Text farmNameText;
    public TMP_Text FarmNameText
    { get { return farmNameText; } set { farmNameText = value; } }

    public GameObject warehousePanel;

    [SerializeField] private TMP_Text warehouseNameText;
    public TMP_Text WarehouseNameText { get { return warehouseNameText; } set { warehouseNameText = value; } }

    public GameObject techPanel;
    [SerializeField]
    private Button[] techBtns;
    [SerializeField] private TMP_Text[] techTexts;

    [SerializeField] public GameObject savePanel;

    [SerializeField] public GameObject settingPanel;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateResourceUI();
        UpdateDayText();
        SetTechBtnIcons();
        UpdateTechBtns();
    }

    public void UpdateResourceUI()
    {
        moneyText.text = Office.instance.Money.ToString();
        staffText.text = (Office.instance.Workers.Count.ToString() + " / " + Office.instance.UnitLimit.ToString());
        wheatText.text = Office.instance.Wheat.ToString();
        melonText.text = Office.instance.Melon.ToString();
        cornText.text = Office.instance.Corn.ToString();
        StoneText.text = Office.instance.Stone.ToString();
        WoodText.text = Office.instance.Wood.ToString();
        Debug.Log(0);
    }

    public void ToggleLaborPanel()
    {
        if (!laborMarketPanel.activeInHierarchy)
            laborMarketPanel.SetActive(true);
        else
            laborMarketPanel.SetActive(false);
    }

    public void ToggleFarmPanel()
    {
        if (!farmPanel.activeInHierarchy)
            farmPanel.SetActive(true);
        else
            farmPanel.SetActive(false);
    }

    public void ToggleWarehousePanel()
    {
        if (!warehousePanel.activeInHierarchy)
            warehousePanel.SetActive(true);
        else
            warehousePanel.SetActive(false);
    }
    public void UpdateDayText()
    {
        dayText.text = ("Day ")+GameManager.instance.Day.ToString();
    }

    public void ToggleTechPanel()
    {
        if (!techPanel.activeInHierarchy)
            techPanel.SetActive(true);
        else
            techPanel.SetActive(false);
    }

    public void ToggleSettingPanel()
    {
        if (!settingPanel.activeInHierarchy)
            settingPanel.SetActive(true);
        else
            settingPanel.SetActive(false);
    }

    public void ClickResearchTech(int i)
    {
        if (TechManager.instance.ResearchTech(i))
        {
            UpdateResourceUI();
            techBtns[i].interactable = false;
            techTexts[i].text = "In Progress";
        }
    }


    private void SetTechBtnIcons()
    {
        for (int i = 0; i < techBtns.Length; i++)
        {
            techBtns[i].image.sprite = TechManager.instance.TechSet[i].Icon;
        }
    }

    public void UpdateTechBtns()
    {
        for (int i = 0; i < techBtns.Length; i++)
        {
            if (TechManager.instance.CheckTechState(i, TechState.Locked))
            {
                techBtns[i].interactable = false;
                techTexts[i].text = "Locked";
            }
            if (TechManager.instance.CheckTechState(i, TechState.Unlocked))
            {
                techBtns[i].interactable = true;
                techTexts[i].text = "";
            }
            if (TechManager.instance.CheckTechState(i, TechState.InProgress))
            {
                techBtns[i].interactable = false;
                techTexts[i].text = "In Progress";
            }
            if (TechManager.instance.CheckTechState(i, TechState.Completed))
            {
                techBtns[i].interactable = false;
                techTexts[i].text = "Completed";
            }
        }
    }

    public void ToggleSavePanel()
    {
        if (!savePanel.activeInHierarchy)
            savePanel.SetActive(true);
        else
            savePanel.SetActive(false);
    }


}
