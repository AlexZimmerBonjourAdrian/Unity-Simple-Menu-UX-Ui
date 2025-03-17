using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class RemoveEmployeeUI : FatherUi, ISend, IMenuUi
{

    private TMP_InputField SearchFigure;
    private Transform buttonContainer;
    private UnityEngine.UI.Button Employeer;
    private CanvasGroup ConfirmPanel;
    private UnityEngine.UI.Button YesButton;
    private UnityEngine.UI.Button NoButton;
    CanvasGroup NotificationSuccefullUi;
    CanvasGroup NotificationFailedUi;

    public void Awake()
    {

        SearchFigure = GameObject.Find("InputField_Search").GetComponent<TMP_InputField>();
        buttonContainer = GameObject.Find("employeersContainer").transform;
        Employeer = Resources.Load<UnityEngine.UI.Button>("Prefabs/employeer");
        ConfirmPanel = GameObject.Find("ConfirmPanel").GetComponent<CanvasGroup>();

        NotificationSuccefullUi = GameObject.Find("NotificationSuccefull").GetComponent<CanvasGroup>();
        NotificationFailedUi = GameObject.Find("NotificationFailed").GetComponent<CanvasGroup>();
        YesButton = GameObject.Find("Yes_Buttom").GetComponent<UnityEngine.UI.Button>();
        NoButton = GameObject.Find("No_Buttom").GetComponent<UnityEngine.UI.Button>();

        NotificationFailedUi.alpha = 0;
        NotificationSuccefullUi.alpha = 0;
        EventManager.Inst.DesactiveMenu();    
    }
    public void OnSend()
    {
        if (SearchEmployee() != null)
        {
            ShowEmployee(SearchEmployee());
        }
    }
    public void RemoveEmployee(DTEmploye Employee)
    {
        if (Employee != null)
        {
            Principal.Inst.RemoveEmployee(Employee);
            ClearEmployeersUI();
            EventManager.Inst.NotificationSuccesfull();
        }
        else
        {
            EventManager.Inst.NotificationError();
        }
    }

    public void ShowEmployee(DTEmploye dTEmploye)
    {
        ClearEmployeersUI();
        UnityEngine.UI.Button button = GameObject.Instantiate(Employeer, buttonContainer);
        button.GetComponentInChildren<Text>().text = dTEmploye.getAllData();
        button.onClick.AddListener(() => ShowMenuConfirm(dTEmploye));
    }

    private void ShowMenuConfirm(DTEmploye dTEmploye)
    {
        EventManager.Inst.ActiveMenu();
        YesButton.onClick.AddListener(() => RemoveEmployee(dTEmploye));
        NoButton.onClick.AddListener(() => FunctionRejected());
    }
    protected override void NotificationError()
    {
        NotificationFailedUi.alpha = 1; 
        StartCoroutine(NotificationDesactivateCorutine());
    }

    protected override void NotificationSuccess()
    {
        NotificationSuccefullUi.alpha = 1; 
        StartCoroutine(NotificationDesactivateCorutine());
    }

    private IEnumerator NotificationDesactivateCorutine()
    {
        yield return new WaitForSeconds(3f);
        NotificationSuccefullUi.alpha = 0;
        NotificationFailedUi.alpha = 0;
    }
    private void FunctionRejected()
    {
        EventManager.Inst.DesactiveMenu();
    }

    public DTEmploye FindEmployeeByNameOrLastName(int Id, int CI, string Name = "", string LastName = "", bool IsActive = true)
    {
        string[] guids = AssetDatabase.FindAssets("t:DTEmploye", new[] { "Assets/Script/Data/Data/Employe" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            DTEmploye employee = AssetDatabase.LoadAssetAtPath<DTEmploye>(path);

            if ((IsActive == true))
            {
                if ((employee.getISActive() == IsActive) && ((employee.getName() == Name) || (employee.getLastname() == LastName) || (employee.getID() == Id || employee.getCi() == CI)))
                {
                    return employee;
                }
            }
        }
        return null;
    }
    public DTEmploye SearchEmployee()
    {
        DTEmploye employee = FindEmployeeByNameOrLastName(Id: Int32.Parse(SearchFigure.text.ToString()), CI: Int32.Parse(SearchFigure.text.ToString()), Name: SearchFigure.text, LastName: SearchFigure.text, IsActive: true);
        return employee;
    }
    public void OnBackMenu(int Str)
    {
        SceneManager.LoadScene(Str);
    }

    public void ClearEmployeersUI()
    {
        var buttons = buttonContainer.GetComponentsInChildren<UnityEngine.UI.Button>();
        foreach (var bt in buttons)
        {
            Destroy(bt.gameObject);
        }
        EventManager.Inst.DesactiveMenu();
    }

    public void OnEnable()
    {
        EventManager.Inst.OnNotificationSuccesfull += NotificationSuccess;
        EventManager.Inst.OnNotificationError += NotificationError;  

        EventManager.Inst.OnActiveMenu += ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu += DesactiveMenuConfirme;
    }
   
    public void OnDisable()
    {
        EventManager.Inst.OnNotificationSuccesfull -= NotificationSuccess;
        EventManager.Inst.OnNotificationError -= NotificationError;
        EventManager.Inst.OnActiveMenu -= ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu -= DesactiveMenuConfirme;
    }

    public void OnDestroy()
    {
        ClearEmployeersUI();
        EventManager.Inst.OnNotificationSuccesfull -= NotificationSuccess;
        EventManager.Inst.OnNotificationError -= NotificationError;
        EventManager.Inst.OnActiveMenu -= ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu -= DesactiveMenuConfirme;
    }


    public override void DesactiveMenuConfirme()
    {
        ConfirmPanel.alpha = 0;
        ConfirmPanel.blocksRaycasts = false;
    }

    public override void ActiveMenuConfirme()
    {
        ConfirmPanel.alpha = 1;
        ConfirmPanel.blocksRaycasts = true;
    }
}
