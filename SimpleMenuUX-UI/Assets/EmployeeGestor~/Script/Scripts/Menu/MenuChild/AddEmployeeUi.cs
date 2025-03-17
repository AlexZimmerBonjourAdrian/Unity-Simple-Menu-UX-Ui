using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddEmployeeUi : FatherUi, ISend, IMenuUi
{
    TMP_InputField CIUi;
    TMP_InputField NameUi;
    TMP_InputField LastNameUi;
    TMP_InputField AdressUi;
    TMP_InputField EmailUi;
    TMP_InputField PhoneUi;
    TMP_InputField[] BirthDateUi;
    TMP_Dropdown RolUi;
    TMP_Dropdown SeniorityUi;
    TMP_InputField[] JoinDateUi;
    CanvasGroup NotificationSuccefullUi;
    CanvasGroup NotificationFailedUi;
    private void Awake()
    {
        CIUi = GameObject.Find("Input_CI").GetComponent<TMP_InputField>();
        NameUi = GameObject.Find("Input_Name").GetComponent<TMP_InputField>();
        LastNameUi = GameObject.Find("Input_LastName").GetComponent<TMP_InputField>();
        AdressUi = GameObject.Find("Input_Adress").GetComponent<TMP_InputField>();
        EmailUi = GameObject.Find("Input_Email").GetComponent<TMP_InputField>();
        PhoneUi = GameObject.Find("Input_Phone").GetComponent<TMP_InputField>();
        BirthDateUi = GameObject.Find("BirthdayInput").GetComponentsInChildren<TMP_InputField>();
        RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>();
        SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>(); 
        JoinDateUi = GameObject.Find("JoinDateInput").GetComponentsInChildren<TMP_InputField>();
        NotificationSuccefullUi = GameObject.Find("NotificationSuccefull").GetComponent<CanvasGroup>();
        NotificationFailedUi = GameObject.Find("NotificationFailed").GetComponent<CanvasGroup>();
        var joinDate = JoinDateUi;
        joinDate[2].text = DateTime.Now.Day.ToString();
        joinDate[1].text = DateTime.Now.Month.ToString();
        joinDate[0].text = DateTime.Now.Year.ToString(); 
        NotificationFailedUi.alpha = 0;
        NotificationSuccefullUi.alpha = 0;
    }
    public void AddEmployee()
    {
        var birthDate = BirthDateUi;
        DateTimeCustom BirthdDateTemp = new DateTimeCustom(birthDate[0].text.ToString(), birthDate[1].text.ToString(), birthDate[2].text.ToString());

        var joinDate = JoinDateUi;

        DateTimeCustom joinDateTemp = new DateTimeCustom(joinDate[0].text.ToString(), joinDate[1].text.ToString(), joinDate[2].text.ToString());

        var Salary = AssetDatabase.LoadAssetAtPath<DTSalary>("Assets/Script/Data/Data/Salary" + "/" + (EEmploye.Roles)RolUi.value + "/" + (EEmploye.Roles)RolUi.value + "_" + (EEmploye.Seniority)SeniorityUi.value + "_Salary" + ".asset");

        if (CheckDataEmployee(CIUi.text.ToString(), NameUi.text.ToString(), LastNameUi.text.ToString(), EmailUi.text.ToString(), PhoneUi.text.ToString(), AdressUi.text.ToString(), (EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value, BirthdDateTemp, joinDateTemp) && RolAndSeniorityChecker((EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value))
        {
            Employee newEmployee = new Employee(Principal.Inst.GetId(), Int32.Parse(CIUi.text.ToString()), NameUi.text.ToString(), LastNameUi.text.ToString(), EmailUi.text.ToString(), Int32.Parse(PhoneUi.text.ToString()), AdressUi.text.ToString(), (EEmploye.Roles)RolUi.value, (EEmploye.Seniority)SeniorityUi.value, joinDateTemp, BirthdDateTemp, Salary.GetSalary(), true);
            Principal.Inst.CreateEmployee(newEmployee);

            EventManager.Inst.NotificationSuccesfull();
        }
        else
        {
            EventManager.Inst.NotificationError();
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
        AddEmployee();
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
        EventManager.Inst.OnNotificationSuccesfull -= NotificationSuccess;
        EventManager.Inst.OnNotificationError -= NotificationError;

        EventManager.Inst.OnActiveMenu -= ActiveMenuConfirme;
        EventManager.Inst.OnDesactiveMenu -= DesactiveMenuConfirme;

        EventManager.Inst.OnActiveDataMenu -= ActiveMenuData;
        EventManager.Inst.OnDesactiveDataMenu -= DesactiveMenuData;   
    }

}
