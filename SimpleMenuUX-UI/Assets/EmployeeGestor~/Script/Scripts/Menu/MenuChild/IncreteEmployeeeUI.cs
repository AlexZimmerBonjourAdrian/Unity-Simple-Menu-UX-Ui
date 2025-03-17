using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class IncreteEmployeeeUI : FatherUi, IMenuUi, ISend
{
    //TODO: IncreceeSalaryEmployee by Rol, Seniority and JoinDate

    private TMP_Dropdown RolUi;
    private TMP_Dropdown SeniorityUi;
    private TMP_InputField[] JoinDateUi;
    private TMP_InputField IncrementUi;
    private CanvasGroup ConfirmPanel;
    private UnityEngine.UI.Button YesButton;
    private UnityEngine.UI.Button NoButton;
    CanvasGroup NotificationSuccefullUi;
    CanvasGroup NotificationFailedUi;
    void Awake()
    {
        RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>(); ;
        SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>(); 
        IncrementUi = GameObject.Find("Input_Increment").GetComponent<TMP_InputField>();
        ConfirmPanel = GameObject.Find("ConfirmPanel").GetComponent<CanvasGroup>();
      


        NotificationSuccefullUi = GameObject.Find("NotificationSuccefull").GetComponent<CanvasGroup>();
        NotificationFailedUi = GameObject.Find("NotificationFailed").GetComponent<CanvasGroup>();
        YesButton = GameObject.Find("Yes_Buttom").GetComponent<UnityEngine.UI.Button>();
        NoButton = GameObject.Find("No_Buttom").GetComponent<UnityEngine.UI.Button>();
        EventManager.Inst.OnNotificationSuccesfull += NotificationSuccess;
        EventManager.Inst.OnNotificationError += NotificationError;
        ConfirmPanel.alpha = 0;
        NotificationFailedUi.alpha = 0;
        NotificationSuccefullUi.alpha = 0;
    }
    protected override List<DTEmploye> FindEmployees(EEmploye.Roles Roles, EEmploye.Seniority Seniority, bool IsActive = true)
    {
        return base.FindEmployees(Roles, Seniority, true);
    }
    public void AppyIncrement(float Increment)
    {
        if (RolAndSeniorityChecker((EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value))
        {
            if (Increment <= 100 && Increment >= 0)
            {

                var Employees = FindEmployees((EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value, true);
                if (Employees.Count > 0)
                {
                    foreach (var item in Employees)
                    {
                        var IncrementSalary = (item.getSalary() * (Increment / 100));

                        Principal.Inst.IncrementEmployeeSalary(item, IncrementSalary);

                    }
                    EventManager.Inst.NotificationSuccesfull();
                }
            }
        }
        else
        {
            EventManager.Inst.NotificationError();
        }
    }
   
    private void ShowMenuConfirm()
    {
        EventManager.Inst.ActiveMenu();

        YesButton.onClick.AddListener(() => FunctionSummit());
        NoButton.onClick.AddListener(() => FunctionRejected());
    }
    private void FunctionRejected()
    {
        EventManager.Inst.DesactiveMenu();
    }
  
    public void FunctionSummit()
    {
        AppyIncrement(float.Parse(IncrementUi.text));
        EventManager.Inst.DesactiveMenu();
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
    protected override bool RolAndSeniorityChecker(EEmploye.Roles rol, EEmploye.Seniority seniority)
    {
        return base.RolAndSeniorityChecker(rol, seniority);
    }

    public void OnSend()
    {
        ShowMenuConfirm();
    }
    public void OnBackMenu(int Str)
    {
        SceneManager.LoadScene(Str);
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
