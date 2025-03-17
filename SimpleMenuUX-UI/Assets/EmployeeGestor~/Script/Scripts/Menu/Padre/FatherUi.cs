using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class FatherUi : MonoBehaviour
{
    protected virtual List<DTEmploye> FindEmployees(EEmploye.Roles Roles, EEmploye.Seniority Seniority, bool IsActive = true)
    {
        List<DTEmploye> employees = new List<DTEmploye>();

        string[] guids = AssetDatabase.FindAssets("t:DTEmploye", new[] { "Assets/Script/Data/Data/Employe" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            DTEmploye employee = AssetDatabase.LoadAssetAtPath<DTEmploye>(path);

            if (IsActive == true)
            {
                if ((employee.getRol() == Roles && employee.getSenior() == Seniority))
                {
                    employees.Add(employee);
                }
            }
        }
        return employees;
    }

    protected virtual bool RolAndSeniorityChecker(EEmploye.Roles rol, EEmploye.Seniority seniority)
    {
        if (rol == EEmploye.Roles.None)
        {
            return false;
        }

        else if (seniority == EEmploye.Seniority.None && rol != EEmploye.Roles.CEO)
        {
            return false;
        }

        else if (seniority == EEmploye.Seniority.Junior && (rol == EEmploye.Roles.Art || rol == EEmploye.Roles.PM))
        {
            return false;
        }
        else if (rol == EEmploye.Roles.Design && seniority == EEmploye.Seniority.Semi_Senior)
        {
            return false;
        }
        return true;
    }

    protected virtual void NotificationError()
    {
        
    }

    protected virtual void NotificationSuccess()
    { 

    }

    public virtual void DesactiveMenuData()
    {

    }
    public virtual void ActiveMenuData()
    {

    }


    public virtual void DesactiveMenuConfirme()
    {

    }

   
    public virtual void ActiveMenuConfirme()
    {

    }
}
     


