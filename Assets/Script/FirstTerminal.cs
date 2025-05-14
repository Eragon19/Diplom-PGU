using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;


public class FirstTerminal : MonoBehaviour
{
    public Transform firstTerminalInteraction;
    private Transform personalAccountInformation;
    private Transform certificateRequestInformation;
    private Transform scienceInternshipInformation;

    public Transform loginField;
    public Transform passwordField;

    public Transform informationPanels;

    public Transform loginPanel;

    public GameObject mainPageAfterLogin;
    public GameObject personalAccountPanel;
    public GameObject COSPanel;
    public GameObject CosPaperItem;
    public GameObject CosPaperRequestPage;

    public GameObject CosStudyPaperPage;
    public GameObject CosArmyItem;
    public GameObject CosArmyPaperPage;

    public int selectedPaperType;


    public GameObject StudyPaperInputField1;
    public GameObject StudyPaperInputField2;
    public GameObject StudyPaperInputField3;

    public bool isStudyPaperInputField1;
    public bool isStudyPaperInputField2;
    public bool isStudyPaperInputField3;


    public GameObject StudyPaperSubmitButton;
    public GameObject COSDropbox;
    public GameObject COSPaperTypeDropbox;

    void Awake()
    {
        GameEvents.OnPause += CloseEverything;

        personalAccountInformation = informationPanels.Find("PersonalAccountInformation");
        certificateRequestInformation = informationPanels.Find("CertificateRequestInformation");
        scienceInternshipInformation = informationPanels.Find("ScienceInternshipInformation");

        CosStudyPaperPage.SetActive(false);
        CosArmyPaperPage.SetActive(false);
        CosPaperRequestPage.SetActive(false);
        COSPanel.SetActive(false);
        personalAccountPanel.SetActive(false);
        mainPageAfterLogin.SetActive(false);

        informationPanels.gameObject.SetActive(false);
        personalAccountInformation.gameObject.SetActive(false);
        certificateRequestInformation.gameObject.SetActive(false);
        scienceInternshipInformation.gameObject.SetActive(false);

        StudyPaperSubmitButton.GetComponent<Button>().interactable = false;
    }

    public void CloseEverything()
    {
        COSPanel.SetActive(false);
        CosPaperItem.SetActive(false);
        personalAccountPanel.SetActive(false);
        COSDropbox.GetComponent<TMP_Dropdown>().value = 0;
        COSPaperTypeDropbox.GetComponent<TMP_Dropdown>().value = 0;

        CosStudyPaperPage.SetActive(false);
        CosArmyPaperPage.SetActive(false);
    }
    public void PersonalAccountButton()
    {
        UnityEngine.Debug.Log($"Button 1 pressed.\nLogin panel: {loginPanel}\nPAI: {personalAccountInformation}");

        informationPanels.gameObject.SetActive(true);
        loginPanel.gameObject.SetActive(true);
        //personalAccountInformation.gameObject.SetActive(true);
    }
    public void FillEditBox(int index)
    {
        switch (index)
        {
            case 1 :
                if(StudyPaperInputField1.GetComponent<TMP_InputField>().text !="")
                    isStudyPaperInputField1 = true;
                else
                    isStudyPaperInputField1 = false;
                break;
            case 2:
                if (StudyPaperInputField2.GetComponent<TMP_InputField>().text != "")
                    isStudyPaperInputField2 = true;
                else
                    isStudyPaperInputField2 = false;
                break;
            case 3:
                if (StudyPaperInputField3.GetComponent<TMP_InputField>().text != "")
                    isStudyPaperInputField3 = true;
                else
                    isStudyPaperInputField3 = false;
                break;
            default:
                break;
        }

        if(isStudyPaperInputField1 &&
            isStudyPaperInputField2 &&
            isStudyPaperInputField3)
        {
            StudyPaperSubmitButton.GetComponent<Button>().interactable = true;
        }
        else
        {

            StudyPaperSubmitButton.GetComponent<Button>().interactable = false;
        } 
    }
    public void SelectPaperType(int index)
    {
        selectedPaperType = index;

        if (selectedPaperType == 1)
        {
            SelectPaperStudy();
        }
        else if (selectedPaperType == 2)
        {
            SelectPaperArmy();
        }
        else
        {
            CosStudyPaperPage.SetActive(false);
            CosArmyPaperPage.SetActive(false);
        }
    }

    public void OpenCos(int index)
    {
        if (index == 5)
        {
            COSPanel.SetActive(true);
            loginPanel.gameObject.SetActive(false);

            mainPageAfterLogin.SetActive(false);

        }
    }

    public void RequestPaper()
    {
        COSPanel.SetActive(false);
        CosPaperRequestPage.SetActive(true);
    }
    public void SelectPaperStudy()
    {

        CosStudyPaperPage.SetActive(true);
        CosArmyPaperPage.SetActive(false);
    }
    public void SelectPaperArmy()
    {

        CosStudyPaperPage.SetActive(false);
        CosArmyPaperPage.SetActive(true);
    }

    public void ClickApply()
    {

        if (selectedPaperType == 1)
        {
            if (QuestTracker.Instance.currentIndex == 2)
            {
                QuestTracker.Instance.AdvanceQuest();
            }

            ApplyPaperStudy();
        }
        else if (selectedPaperType == 2)
        {
            if (QuestTracker.Instance.currentIndex == 9)
            {
                QuestTracker.Instance.AdvanceQuest();
            }
            ApplyPaperArmy();
        }
    }
    public void ApplyPaperStudy()
    {
        COSPanel.SetActive(true);
        CosPaperItem.SetActive(true);
        CosPaperRequestPage.SetActive(false);
    }
    public void ApplyPaperArmy()
    {
        COSPanel.SetActive(true);
        CosArmyItem.SetActive(true);
        CosPaperRequestPage.SetActive(false);
    }

    public void LoginButton()
    {
        if (loginField.TryGetComponent<TMP_InputField>(out var loginFieldComponent) && passwordField.TryGetComponent<TMP_InputField>(out var passwordFieldComponent))
        {
            if (loginFieldComponent.text == "1" && passwordFieldComponent.text == "2")
            {
                if (QuestTracker.Instance.currentIndex == 1)
                {
                    QuestTracker.Instance.AdvanceQuest();
                }
                if (QuestTracker.Instance.currentIndex == 8)
                {
                    QuestTracker.Instance.AdvanceQuest();
                }
                if (firstTerminalInteraction.TryGetComponent<FirstTerminalInteraction>(out var interactionScript))
                {
                    //interactionScript.HandleTriggerExit();

                    mainPageAfterLogin.SetActive(true);
                    personalAccountPanel.SetActive(true);
                    return;
                }
            }

        }
    }

    private void ToggleChildrenByRecursion(Transform aParent, string aName, bool toggle)
    {
        foreach (Transform child in aParent)
        {
            child.gameObject.SetActive(toggle);
            ToggleChildrenByRecursion(child, aName, toggle);
        }
    }
   

    public void OpenPdfExternal(string relativePath)
    {

        if (relativePath.StartsWith("http://") || relativePath.StartsWith("https://"))
        {
            Application.OpenURL(relativePath);
            return;
        }

        // Otherwise treat it as a local PDF in StreamingAssets
        string fullPath = Path.Combine(Application.streamingAssetsPath, relativePath);
        if (File.Exists(fullPath))
        {
            Application.OpenURL(fullPath);
        }
      


    }

}
