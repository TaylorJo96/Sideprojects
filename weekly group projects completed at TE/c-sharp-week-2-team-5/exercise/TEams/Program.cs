﻿using System;
using System.Collections.Generic;
using TEams.Classes;

namespace TEams
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        
    private void Run()
        {
          
           
            // create some departments
            CreateDepartments();

            // print each department by name
            PrintDepartments();

            // create employees
            CreateEmployees();

            // give Angie a 10% raise, she is doing a great job!


            // print all employees
            PrintEmployees();

            // create the TEams project
            CreateTeamsProject();

            // create the Marketing Landing Page Project
            CreateLandingPageProject();

            // print each project name and the total number of employees on the project
            PrintProjectsReport();
        }
        List<Department> departments = new List<Department>();
        List<Employee> employees = new List<Employee>();

        Dictionary<string, Project> projects = new Dictionary<string, Project>();

        /**
         * Create departments and add them to the collection of departments
         */
       
        private void CreateDepartments()
        {
            Department marketing = new Department(1, "Marketing");
            Department sales = new Department(2, "Sales");
            Department engineering = new Department(3, "Engineering");

            departments.Add(marketing);
            departments.Add(sales);
            departments.Add(engineering);
        }
        
        
        /**
         * Print out each department in the collection.
         */
        private void PrintDepartments()
        {
            Console.WriteLine("-------------DEPARTMENTS------------------------------");
            
            for (int i = 0; i < departments.Count; i++)
            {
                //Console.WriteLine($"{departments[i].DepartmentId.ToString()} | {departments[i].Name}"); 
                Console.WriteLine($"{departments[i].Name}");
            }
        }

        /**
         * Create employees and add them to the collection of employees
         */
        private void CreateEmployees()
        {
            Employee deanJohnson = new Employee();
            Employee angieSmith = new Employee(2, "Angie", "Smith", "asmith@teams.com",departments[2] , "08/21/2020");
            Employee margaretThompson = new Employee(3, "Margaret", "Thompson", "mthompson@teams.com", departments[0], "08/21/2020");
            deanJohnson.EmployeeId = 1;
            deanJohnson.FirstName = "Dean";
            deanJohnson.LastName = "Johnson";
            deanJohnson.Email = "djohnson@teams.com";
            deanJohnson.Department = departments[2];
            deanJohnson.HireDate = "08/21/2020";
            angieSmith.Salary = angieSmith.Salary + angieSmith.Salary * 10 / 100;
            employees.Add(deanJohnson);
            employees.Add(angieSmith);
            employees.Add(margaretThompson);
            
            
        }

        /**
         * Print out each employee in the collection.
         * 
         */
        private void PrintEmployees()
        {
            Console.WriteLine("\n------------- EMPLOYEES ------------------------------");
            for (int i = 0; i < employees.Count; i++)
            {
     
                Console.WriteLine($"{employees[i].LastName}, {employees[i].FirstName} ({employees[i].Salary}) {employees[i].Department.Name}");

            }
        }

        /**
         * Create the 'TEams' project.
         */
        private void CreateTeamsProject()
        {


            Project teams = new Project("TEams", "Project Management Software", "10/10/2020", "11/10/2020");
            for (int i = 0; i < employees.Count; i++)
            {
               
                if(employees[i].Department.Name == "Engineering")
                {
                   teams.TeamMembers.Add(employees[i]); 
                }
            }
            projects.Add("teams",teams);


        }
        /**
         * Create the 'Marketing Landing Page' project.
         */
        private void CreateLandingPageProject()
        {
            Project marketingLandingPage = new Project("Marketing Landing Page", "Lead Capture Landing Page for Marketing", "10/10/2020", "10/17/2020");
            for (int i = 0; i < employees.Count; i++)
            {

                if (employees[i].Department.Name == "Marketing")
                {
                    marketingLandingPage.TeamMembers.Add(employees[i]);
                }
            }
            projects.Add("marketingLandingPage", marketingLandingPage);




        }

        /**
         * Print out each project in the collection.
         */
        private void PrintProjectsReport()
        {
            Console.WriteLine("\n------------- PROJECTS ------------------------------");
            // 
            //       for (int i = 0; i < projects.Count; i++)
            //     {
            //       Console.WriteLine($"{projects[i].Name}: {projects.TeamMembers.Count}");
            //
            // }
            Console.WriteLine(projects.Count);


        }
    }
}
