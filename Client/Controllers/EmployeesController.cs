using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    class EmployeesController
    {
        private static EmployeesController instance;
        private static object syncRoot = new Object();
        private List<EmployeePosition> employeePositions = new List<EmployeePosition>();

        protected EmployeesController()
        {
        }
        public static EmployeesController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new EmployeesController();
                }
            }
            return instance;
        }

        public List<Employee> GetEmployees()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("Employees").Result;
            if(sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<Employee> result = new List<Employee>();
            for(int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetEmployeeFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private Employee GetEmployeeFromRow(List<object> row)
        {
            return new Employee
            {
                Id = (int)(long)row[0],
                Name = (string)row[1],
                Position = new EmployeePosition
                {
                    Id = (int)(long)row[2],
                    Name = (string)row[3]
                },
                TradePoint = new TradePoint
                {
                    Id = (int)(long)row[4],
                    Name = (string)row[5],
                    Type = new TradePointType
                    {
                        Id = (int)(long)row[6],
                        Name = (string)row[7]
                    }
                }
            };

        }

        internal void AddEmployee(Employee employee)
        {
            if (employee == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Employees/Insert", employee);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void EditEmployee(Employee employee)
        {
            if (employee == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Employees/Update", employee);
            }
            catch(Exception ex)
            {
                return;
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Employees/Delete", employee);
            }
            catch(Exception ex)
            {
                return;
            }
        }

        public List<EmployeePosition> GetEmployeePositions()
        {
            if (employeePositions.Count == 0)
            {
                UpdateEmployeePositions();
            }
            return employeePositions;
        }

        public void UpdateEmployeePositions()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("EmployeePositions").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }

            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                employeePositions.Add(GetEmployeePosiionFromRow(sqlResult.Rows[i]));
            }
        }

        private EmployeePosition GetEmployeePosiionFromRow(List<object> row)
        {
            return new EmployeePosition
            {
                Id = (int)(long)row[0],
                Name = (string)row[1]
            };
        }
    }
}
