using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DTSalary", menuName = "Employe/Salary")]
public class DTSalary : ScriptableObject
{

    public EEmploye.Roles Role;
    public EEmploye.Seniority Seniorit;
    public float SalaryBase;

    public EEmploye.Roles GetRole()
    {
        return Role;
    }

    public EEmploye.Seniority GetSeniority()
    {
        return Seniorit;
    }

    public void SetRoles(EEmploye.Roles role)
    {
        Role = role;
    }

    public void SetSeniority(EEmploye.Seniority seniority)
    {
        Seniorit = seniority;
    }

    public float GetSalary()
    {
        return SalaryBase;
    }


}
