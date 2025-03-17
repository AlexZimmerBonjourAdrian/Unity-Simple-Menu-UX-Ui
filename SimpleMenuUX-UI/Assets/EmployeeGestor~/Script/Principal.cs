using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Dynamic;
using UnityEditor;
public class Principal : MonoBehaviour
{

    public static Principal Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Principal");
                return obj.AddComponent<Principal>();
            }

            return _inst;
        }
    }

    private static Principal _inst;

    public int ID;


    void Awake()
    {
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _inst = this;

        if(PlayerPrefs.HasKey("ID"))
        {
            ID = PlayerPrefs.GetInt("ID");
        }

    }

    // Start

    //Update
    //AddEmployee()

    public void Save()
    {
        PlayerPrefs.SetInt("ID", ID);
    }

    public int GetId()
    {
        return ID;
    }

    public void SetId(int id)
    {
        ID = id;
    }

    public void CreateEmployee(Employee employee)
    {
        
     
        DTEmploye Scriptable = ScriptableObject.CreateInstance<DTEmploye>();
        Scriptable.setID(GetId());
        Scriptable.setCi(employee.getCi());
        Scriptable.setName(employee.getName());
        Scriptable.setLastname(employee.getLastName());
        Scriptable.setEmail(employee.getEmail());
        Scriptable.setBirthDate(employee.getBirthDate());
        Scriptable.setAdress(employee.getAdress());
        Scriptable.setPhone(employee.getPhone());
        Scriptable.setSenior(employee.getSeniority());
        Scriptable.setRol(employee.getRoles());
        Scriptable.setJoinDate(employee.getJoinDate());
        Scriptable.setSalary(employee.getSalary());
        Scriptable.setIsActive(employee.getIsActive());
        AssetDatabase.CreateAsset(Scriptable, "Assets/Script/Data/Data/Employe/" + Scriptable.Name + Scriptable.Lastname + ".asset");
        SetId(GetId() + 1);
        Save();
    }

    public void ModifyEmployee(DTEmploye Employee, Employee newDataEmployee)
    {
        Employee.setCi(newDataEmployee.getCi());
        Employee.setEmail(newDataEmployee.getEmail());
        Employee.setName(newDataEmployee.getName());
        Employee.setLastname(newDataEmployee.getLastName());
        Employee.setPhone(newDataEmployee.getPhone());
        Employee.setAdress(newDataEmployee.getAdress());
        Employee.setRol(newDataEmployee.getRoles());
        Employee.setSenior(newDataEmployee.getSeniority());
        Employee.setJoinDate(newDataEmployee.getJoinDate());
        Employee.setBirthDate(newDataEmployee.getBirthDate());
        Employee.setSalary(newDataEmployee.getSalary());
        Employee.setIsActive(newDataEmployee.getIsActive());
    
        EditorUtility.SetDirty(Employee);
    }

    public void IncrementEmployeeSalary(DTEmploye Employee, float increment)
    {
        Employee.setSalary(Employee.getSalary() + increment);
        EditorUtility.SetDirty(Employee);
    }

    public void RemoveEmployee(DTEmploye Employee)
    {
        Employee.setIsActive(false);
        EditorUtility.SetDirty(Employee);
    }
}
