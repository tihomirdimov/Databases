using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using IntroToEntityFramework.Models;

namespace IntroToEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftuniContext context = new SoftuniContext();
            //GetEmployeesFullInfo(context);
            //EmployeesWithSalaryOver(context);
            //EmployeesFromSeattle(context);
            //AddingNewAddressAndUpdatingEmployee(context);
            //DeleteProjectById(context);
            //FindEmployeesInPeriod(context);
            //AddressesByTownName(context);
            //EmployeeWithIdSortedByProjectNames(context);
            //DepartmentsWithMoreThanNemployees(context);
            //FindLatestNProjects(context);
            //IncreaseSalaries(context);
            FindEmployeesByFirstNameStartingWith(context);
        }
        public static void GetEmployeesFullInfo(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            IEnumerable<Employee> employees = context.Employees;
            foreach (Employee employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary.ToString().Replace(",", ".")}");
            }
            Console.WriteLine(result);
        }
        public static void EmployeesWithSalaryOver(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(em => em.FirstName);
            foreach (var employee in employees)
            {
                result.AppendLine(employee);
            }
            Console.WriteLine(result);
        }
        public static void EmployeesFromSeattle(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var employees = context.Employees
                    .Where(employee => employee.Department.Name == "Research and Development")
                    .OrderBy(employee => employee.Salary)
                    .ThenByDescending(employee => employee.FirstName);
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} " +
                                     $"from {employee.Department.Name} - ${employee.Salary:F2}");
            }
            result.Replace(",", ".");
            Console.WriteLine(result);
        }
        public static void AddingNewAddressAndUpdatingEmployee(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var address = new Address() { AddressText = "Vitoshka 15", TownID = 4 };
            var nakovEmployee = context.Employees.First(employee => employee.LastName == "Nakov");
            nakovEmployee.Address = address;
            context.SaveChanges();
            var employeeAddresses = context.Employees
                .OrderByDescending(employee => employee.Address.AddressID)
                .Take(10)
                .Select(employee => employee.Address.AddressText);

            foreach (string employeeAddress in employeeAddresses)
            {
                result.AppendLine(employeeAddress);
            }
            Console.WriteLine(result);
        }
        public static void DeleteProjectById(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var project = context.Projects.Find(2);
            var employees = project.Employees;
            foreach (Employee employee in employees)
            {
                employee.Projects.Remove(project);
            }
            context.SaveChanges();
            context.Projects.Remove(project);
            context.SaveChanges();
            var projects = context.Projects.Take(10).Select(project1 => project1.Name);
            foreach (string proj in projects)
            {
                result.AppendLine(proj);
            }
            Console.WriteLine(result);
        }
        public static void FindEmployeesInPeriod(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var employees = context.Employees
                .Where(employee => employee.Projects
                    .Count(project => project.StartDate.Year >= 2001 && project.StartDate.Year <= 2003) > 0).Take(30);
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Employee1.FirstName}");
                foreach (Project project in employee.Projects)
                {
                    result.AppendLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                }
            }
            Console.WriteLine(result);
        }
        public static void AddressesByTownName(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var addresses =
                context.Addresses
                    .OrderByDescending(address => address.Employees.Count)
                    .ThenBy(address => address.Town.Name)
                    .Take(10);

            foreach (Address address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }
            Console.WriteLine(result);
        }
        public static void EmployeeWithIdSortedByProjectNames(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            Employee employee = context.Employees.Find(147);
            IEnumerable<Project> projects = employee.Projects.OrderBy(project => project.Name);
            result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            foreach (var project in projects)
            {
                result.AppendLine(project.Name);
            }
            Console.WriteLine(result);
        }
        public static void DepartmentsWithMoreThanNemployees(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            IEnumerable<Department> departments = context
                .Departments.Where(department => department.Employees.Count > 5)
                .OrderBy(department => department.Employees.Count);
            foreach (Department department in departments)
            {
                result.AppendLine($"{department.Name} {department.Employee.FirstName}");
                foreach (Employee employee in department.Employees)
                {
                    result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
            Console.WriteLine(result);
        }
        public static void FindLatestNProjects(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var latestStartedProjects =
                context.Projects.OrderByDescending(project => project.StartDate)
                    .Take(10)
                    .OrderBy(project => project.Name);

            foreach (var latestStartedProject in latestStartedProjects)
            {
               result.AppendLine($"{latestStartedProject.Name} {latestStartedProject.Description} {latestStartedProject.StartDate} {latestStartedProject.EndDate}");
            }
            Console.WriteLine(result);
        }
        public static void IncreaseSalaries(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            var employees = context.Employees.Where(employee =>
                employee.Department.Name == "Engineering"
                || employee.Department.Name == "Tool Design"
                || employee.Department.Name == "Marketing"
                || employee.Department.Name == "Information Services");

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }
            context.SaveChanges();
            Console.WriteLine(result);
        }
        public static void FindEmployeesByFirstNameStartingWith(SoftuniContext context)
        {
            StringBuilder result = new StringBuilder();
            string pattern = "SA";
            var employeesByNamePattern = context.Employees
                .Where(employee => employee.FirstName.StartsWith(pattern));

            foreach (var employeeByPattern in employeesByNamePattern)
            {
                result.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
                                  $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
            }
            Console.WriteLine(result);
        }
    }
}
