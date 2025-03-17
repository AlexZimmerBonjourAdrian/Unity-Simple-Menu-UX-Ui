using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Employee
{
    private int id;
    private int ci;
    private string email;
    private string Name;
    private string LastName;
    private string adress;
    private int Phone;
    private EEmploye.Roles Roles;
    private EEmploye.Seniority Seniority;
    private DateTimeCustom JoinDate;
    private DateTimeCustom BirthDate;
    private float Salary;
    private bool ISActive;
    public Employee( int id,int ci,string name, string lastName,string email ,int phone, string adress,EEmploye.Roles roles, EEmploye.Seniority seniority, DateTimeCustom joinDate, DateTimeCustom birthDate,float salary,bool isActive)
    {
        this.id = id;
        this.ci = ci;
        this.email = email;
        this.Name = name;
        this.LastName = lastName;
        this.Phone = phone;
        this.adress = adress;
        this.Roles = roles;
        this.Seniority = seniority;
        this.JoinDate = joinDate;
        this.BirthDate = birthDate;
        this.Salary = salary;
        this.ISActive = isActive;
    }



    //Setters and Getters
    //Getters
    public string getName()
    {
        return this.Name;
    }
    public string getLastName()
    {
        return this.LastName;
    }

    public EEmploye.Roles getRoles()
    {
        return this.Roles;
    }

    public EEmploye.Seniority getSeniority()
    {
        return this.Seniority;
    }

    public DateTimeCustom getJoinDate()
    {
        return this.JoinDate;
    }

    public DateTimeCustom getBirthDate()
    {
        return this.BirthDate;
    }

    public int getId()
    {
        return this.id;
    }

    public int getCi()
    {
        return this.ci;
    }

    public int getPhone()
    {
        return this.Phone;
    }

    public string getAdress()
    {
        return this.adress;
    }

    public string getEmail()
    {
        return this.email;
    }

    public float getSalary()
    {
        return this.Salary;
    }

    public bool getIsActive()
    {
        return this.ISActive;
    }

    //Setters and Getters

    //Getters
    //Setters


    ////Setters
    public void setName(string name)
    {
        this.Name = name;
    }

    public void setLastName(string lastName)
    {
        this.LastName = lastName;
    }
    public void setEmail(string email)
    {
        this.email = email;
    }
    public void setRoles(EEmploye.Roles roles)
    {
        this.Roles = roles;
    }

    public void setSeniority(EEmploye.Seniority seniority)
    {
        this.Seniority = seniority;
    }

    public void setJoinDate(DateTimeCustom joinDate)
    {
        this.JoinDate = joinDate;
    }

    public void setBirthDate(DateTimeCustom birthDate)
    {
        this.BirthDate = birthDate;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setCi(int ci)
    {
        this.ci = ci;
    }

    public void setPhone(int phone)
    {
        this.Phone = phone;
    }

    public void setAdress(string address)
    {
        this.adress = address;
    }

   public void setSalary(float salary)
    {
        this.Salary = salary;
    }

   public void setIsActive(bool isActive)
    {
        this.ISActive = isActive;
    }

    //Setters
    //Methods
    //Setters

    //Methods

    public string getAllElements()
    {
        return this.id + " " + this.ci + " " + this.Name + " " + this.LastName + " " + this.email + " " + this.Phone + " " + this.adress + " " + this.Roles + " " + this.Seniority + " " + this.JoinDate + " " + this.BirthDate + " " + this.Salary + " " + this.ISActive;
    
    }
    public void OnDestroy()
    {
        
    }

    
  
}
