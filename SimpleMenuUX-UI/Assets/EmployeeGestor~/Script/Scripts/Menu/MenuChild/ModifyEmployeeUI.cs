using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyEmployeeUI : FatherUi, IMenuUi
{
    private TMP_InputField SearchFigure;


    private CanvasGroup ModifyDataPanel;


    private UnityEngine.UI.Button EmployeerButtonPrefab;
    private Transform buttonContainer;

    //Confirm Panel
    private CanvasGroup ConfirmPanel;
    private UnityEngine.UI.Button YesButton;
    private UnityEngine.UI.Button NoButton;


    //FichaPanel


    private TMP_InputField CIUi;
    private TMP_InputField NameUi;
    private TMP_InputField LastNameUi;
    private TMP_InputField EmailUi;
    private TMP_InputField PhoneUi;
    private TMP_InputField[] BirthDateUi;
    private TMP_InputField AdressUi;

    //CargoPanel 
    private UnityEngine.UI.Button ModifierButtom;
    private UnityEngine.UI.Button CancelButtom;
    private TMP_Dropdown RolUi;
    private TMP_Dropdown SeniorityUi;
    private TMP_InputField[] JoinDateUi;
    CanvasGroup NotificationSuccefullUi;
    CanvasGroup NotificationFailedUi;

    public void Awake()
    {
        SearchFigure = GameObject.Find("InputField_Search").GetComponent<TMP_InputField>();
        buttonContainer = GameObject.Find("employeersContainer").transform;
        EmployeerButtonPrefab = Resources.Load<UnityEngine.UI.Button>("Prefabs/employeer");

        ModifyDataPanel = GameObject.Find("ModifieDataPanel").GetComponent<CanvasGroup>();
        ConfirmPanel = GameObject.Find("ConfirmPanel").GetComponent<CanvasGroup>();
        
        CIUi = GameObject.Find("Input_CI").GetComponent<TMP_InputField>();
        NameUi = GameObject.Find("Input_Name").GetComponent<TMP_InputField>();
        LastNameUi = GameObject.Find("Input_LastName").GetComponent<TMP_InputField>();
        AdressUi = GameObject.Find("Input_Adress").GetComponent<TMP_InputField>();
        EmailUi = GameObject.Find("Input_Email").GetComponent<TMP_InputField>();
        PhoneUi = GameObject.Find("Input_Phone").GetComponent<TMP_InputField>();
        BirthDateUi = GameObject.Find("BirthDateInput").GetComponentsInChildren<TMP_InputField>();
        RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>();
        SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>();
        JoinDateUi = GameObject.Find("JoinDateInput").GetComponentsInChildren<TMP_InputField>();

        ModifierButtom = GameObject.Find("Modification_Button").GetComponent<UnityEngine.UI.Button>();
        CancelButtom = GameObject.Find("Cancel_Button").GetComponent<UnityEngine.UI.Button>();

        NotificationSuccefullUi = GameObject.Find("NotificationSuccefull").GetComponent<CanvasGroup>();
        NotificationFailedUi = GameObject.Find("NotificationFailed").GetComponent<CanvasGroup>();

       
        NotificationFailedUi.alpha = 0;
        NotificationSuccefullUi.alpha = 0;
        
        YesButton = GameObject.Find("Yes_Buttom").GetComponent<UnityEngine.UI.Button>();
        NoButton = GameObject.Find("No_Buttom").GetComponent<UnityEngine.UI.Button>();

        EventManager.Inst.DesactiveMenu();
        EventManager.Inst.DesactiveDataMenu();
    }
    #region MenusLogic

    //Selet Tipe Data modification

    public void ShowModifyData(DTEmploye dtEmployee)
    {
        EventManager.Inst.ActiveDataMenu();

      

        CIUi.text = dtEmployee.getCi().ToString();
        NameUi.text = dtEmployee.getName();
        LastNameUi.text = dtEmployee.getLastname();
        AdressUi.text = dtEmployee.getAdress();
        EmailUi.text = dtEmployee.getEmail();
        PhoneUi.text = dtEmployee.getPhone().ToString();
        RolUi.value = (int)dtEmployee.getRol();
        SeniorityUi.value = (int)dtEmployee.getSenior();

        var BirthDate = BirthDateUi;
        var joinDate = JoinDateUi;

        joinDate[2].text = dtEmployee.getJoinDate().GetDay();
        joinDate[1].text = dtEmployee.getJoinDate().GetMonth();
        joinDate[0].text = dtEmployee.getJoinDate().GetYear();

        BirthDate[2].text = dtEmployee.getBirthDate().GetDay();
        BirthDate[1].text = dtEmployee.getBirthDate().GetMonth();
        BirthDate[0].text = dtEmployee.getBirthDate().GetYear();


        ModifierButtom.onClick.AddListener(() => ShowMenuConfirm(dtEmployee));
        CancelButtom.onClick.AddListener(() => EventManager.Inst.DesactiveDataMenu());

    }

    private void ShowMenuConfirm(DTEmploye dTEmploye)
    {
            
            var joinDate = JoinDateUi;

            DateTimeCustom joinDateTemp = new DateTimeCustom(joinDate[0].text.ToString(), joinDate[1].text.ToString(), joinDate[2].text.ToString());

            var birthDate = BirthDateUi;
            DateTimeCustom BirthdDateTemp = new DateTimeCustom(birthDate[0].text.ToString(), birthDate[1].text.ToString(), birthDate[2].text.ToString());

            var Salary = AssetDatabase.LoadAssetAtPath<DTSalary>("Assets/Script/Data/Data/Salary" + "/" + (EEmploye.Roles)RolUi.value + "/" + (EEmploye.Roles)RolUi.value + "_" + (EEmploye.Seniority)SeniorityUi.value + "_Salary" + ".asset");
        if (CheckDataEmployee(CIUi.text.ToString(), NameUi.text.ToString(), LastNameUi.text.ToString(), EmailUi.text.ToString(), PhoneUi.text.ToString(), AdressUi.text.ToString(), (EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value, BirthdDateTemp, joinDateTemp) && RolAndSeniorityChecker((EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value))
        {
            EventManager.Inst.ActiveMenu();
           
            Employee newEmployee = new Employee(Principal.Inst.GetId(), Int32.Parse(CIUi.text.ToString()), NameUi.text.ToString(), LastNameUi.text.ToString(), EmailUi.text.ToString(), Int32.Parse(PhoneUi.text.ToString()), adress: AdressUi.text.ToString(), (EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value, joinDateTemp, BirthdDateTemp, Salary.GetSalary(), true);

            YesButton.onClick.AddListener(() => ModifyEmployee(dTEmploye, newEmployee));
            NoButton.onClick.AddListener(() => EventManager.Inst.DesactiveMenu());
        }
        else
        {
            EventManager.Inst.NotificationError();
        }
    }

    public DTEmploye SearchEmployee()
    {
        DTEmploye employee = FindEmployeeByNameOrLastName(Id: Int32.Parse(SearchFigure.text.ToString()), CI: Int32.Parse(SearchFigure.text.ToString()), Name: SearchFigure.text, LastName: SearchFigure.text, IsActive: true);
        return employee;
    }


    public void ShowEmployee(DTEmploye dTEmploye)
    {
        ClearEmployeersUI();
        UnityEngine.UI.Button button = GameObject.Instantiate(EmployeerButtonPrefab, buttonContainer);
        button.GetComponentInChildren<Text>().text = dTEmploye.getAllData();
        button.onClick.AddListener(() => ShowModifyData(dTEmploye));
    }
    #endregion 
    public DTEmploye FindEmployeeByNameOrLastName(int Id,int CI ,string Name = "", string LastName = "", bool IsActive = true)
    {
        string[] guids = AssetDatabase.FindAssets("t:DTEmploye", new[] { "Assets/Script/Data/Data/Employe" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            DTEmploye employee = AssetDatabase.LoadAssetAtPath<DTEmploye>(path);

            if ((IsActive == true))
            {
                if ((employee.getISActive() == IsActive) && ((employee.getName() == Name) || (employee.getLastname() == LastName) || (employee.getID() == Id ||employee.getCi() == CI)))
                {
                    ShowEmployee(employee);
                    return employee;
                }
            }
        }
        return null;
    }

    public void ModifyEmployee(DTEmploye dTEmploye, Employee newDataEmploye)
    {
        Principal.Inst.ModifyEmployee(dTEmploye, newDataEmploye);
        EventManager.Inst.DesactiveDataMenu();
        EventManager.Inst.NotificationSuccesfull();
        ClearEmployeersUI();
        
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

    public void OnBackMenu(int Str)
    {
        SceneManager.LoadScene(Str);
    }
    public void OnSend()
    {
        if (SearchEmployee() != null)
        {
            ShowEmployee(SearchEmployee());
        }

    }
    public bool CheckDataEmployee(string ci, string name, string lastName, string email, string phone, string adress, EEmploye.Roles rol, EEmploye.Seniority seniority, DateTimeCustom birthDate, DateTimeCustom joinDate)
    {
        if (ci == "" || name == "" || lastName == "" || email == "" || phone == "" || adress == "" || rol < 0 || seniority < 0 || birthDate == null || joinDate == null)
        {
            return false;
        }
        else if (ci.Length > 7)
        {
            foreach (char ch in ci)
            {
                if (char.IsLetter(ch))
                {

                    return false;
                }

            }

        }
        else if (phone.Length > 9)
        {
            foreach (char ch in phone)
            {
                if (char.IsLetter(ch))
                {
                    Debug.Log(ch);
                    return false;
                }

            }
        }
        foreach (char ch in name)
        {
            if (char.IsDigit(ch))
            {
                Debug.Log(ch);
                return false;
            }

        }
        foreach (char ch in lastName)
        {
            if (char.IsDigit(ch))
            {
                Debug.Log(ch);
                return false;
            }
        }

        return true;
    }
    protected override bool RolAndSeniorityChecker(EEmploye.Roles rol, EEmploye.Seniority seniority)
    {
        return base.RolAndSeniorityChecker(rol, seniority);
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

    public void OnEnable()
    {
        EventManager.Inst.OnNotificationSuccesfull += NotificationSuccess;
        EventManager.Inst.OnNotificationError += NotificationError;

        EventManager.Inst.OnActiveMenu += ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu += DesactiveMenuConfirme;

        EventManager.Inst.OnActiveDataMenu += ActiveMenuData;
        EventManager.Inst.OnDesactiveDataMenu += DesactiveMenuData;
        
    }

    public void OnDisable()
    {
        EventManager.Inst.OnNotificationSuccesfull -= NotificationSuccess;
        EventManager.Inst.OnNotificationError -= NotificationError;

        EventManager.Inst.OnActiveMenu -= ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu -= DesactiveMenuConfirme;

        EventManager.Inst.OnActiveDataMenu -= ActiveMenuData;
        EventManager.Inst.OnDesactiveDataMenu -= DesactiveMenuData;

    }

    public void OnDestroy()
    {

        ClearEmployeersUI();
        EventManager.Inst.OnNotificationSuccesfull -= NotificationSuccess;
        EventManager.Inst.OnNotificationError -= NotificationError;

        EventManager.Inst.OnActiveMenu -= ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu -= DesactiveMenuConfirme;

        EventManager.Inst.OnActiveDataMenu -= ActiveMenuData;
        EventManager.Inst.OnDesactiveDataMenu -= DesactiveMenuData;
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

    public override void ActiveMenuData()
    {
        ModifyDataPanel.alpha = 1;
        ModifyDataPanel.blocksRaycasts = true;
    }

    public override void DesactiveMenuData()
    {
        ModifyDataPanel.alpha = 0;
        ModifyDataPanel.blocksRaycasts = false;
    }

   

}
