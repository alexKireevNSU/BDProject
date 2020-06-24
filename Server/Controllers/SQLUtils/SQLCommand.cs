using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Server.Controllers.SQLUtils
{
    class SQLCommand
    {
        /* general */
        private static String GetCommand(ref String cachedCommand, String commandPath)
        {
            if (cachedCommand != null && cachedCommand.Length != 0)
                return cachedCommand;

            cachedCommand = File.ReadAllText(HttpContext.Current.Server.MapPath(commandPath));

            return cachedCommand;
        }
        private static String GetCommand(ref String cachedCommand, String commandPath, string[] valArr)
        {
            return String.Format(GetCommand(ref cachedCommand, commandPath), valArr);
        }

        /* creating db */

        public static String CreateTTypes()
        {
            return GetCommand(ref createTTypes, createTTypesPath);
        }
        public static String CreateTTradePoints()
        {
            return GetCommand(ref createTTradePoints, createTTradePointsPath);
        }
        public static String CreateTObjectsRelations()
        {
            return GetCommand(ref createTObjectsRelations, createTObjectsRelationsPath);
        }
        public static String CreateTEmployeesPositions()
        {
            return GetCommand(ref createTEmployeesPositions, createTEmployeesPositionsPath);
        }
        public static String CreateTEmployees()
        {
            return GetCommand(ref createTEmployees, createTEmployeesPath);
        }
        public static String CreateTEmployeesList()
        {
            return GetCommand(ref createTEmployeesList, createTEmployeesListPath);
        }
        public static String CreateTTradePointsPayments()
        {
            return GetCommand(ref createTTradePointsPayments, createTTradePointsPaymentsPath);
        }
        public static String CreateTTradePointsProps()
        {
            return GetCommand(ref createTTradePointsProps, createTTradePointsPropsPath);
        }
        public static String CreateTSuppliers()
        {
            return GetCommand(ref createTSuppliers, createTSuppliersPath);
        }
        public static String CreateTProducts()
        {
            return GetCommand(ref createTProducts, createTProductsPath);
        }
        public static String CreateTTradePointsProducts()
        {
            return GetCommand(ref createTTradePointsProducts, createTTradePointsProductsPath);
        }
        public static String CreateTTradePointsSales()
        {
            return GetCommand(ref createTTradePointsSales, createTTradePointsSalesPath);
        }
        public static String CreateTTradePointsCustomers()
        {
            return GetCommand(ref createTTradePointsCustomers, createTTradePointsCustomersPath);
        }
        public static String CreateTTradePointsCustomersPurchases()
        {
            return GetCommand(ref createTTradePointsCustomersPurchases, createTTradePointsCustomersPurchasesPath);
        }
        public static String CreateTTradePointsRequests()
        {
            return GetCommand(ref createTTradePointsRequests, createTTradePointsRequestsPath);
        }
        public static String CreateTOrders()
        {
            return GetCommand(ref createTOrders, createTOrdersPath);
        }
        public static String CreateTOrdersLists()
        {
            return GetCommand(ref createTOrdersLists, createTOrdersListsPath);
        }
        public static String CreateTRequestsOrders()
        {
            return GetCommand(ref createTRequestsOrders, createTRequestsOrdersPath);
        }
        public static String CreateTSupplies()
        {
            return GetCommand(ref createTSupplies, createTSuppliesPath);
        }
        public static String CreateTSuppliesOrders()
        {
            return GetCommand(ref createTSuppliesOrders, createTSuppliesOrdersPath);
        }
        public static String CreateTSuppliesDistribution()
        {
            return GetCommand(ref createTSuppliesDistribution, createTSuppliesDistributionPath);
        }

        /* selecting all from db */

        public static String SelectTest()
        {
            return GetCommand(ref selectTest, selectTestPath);
        }
        public static String SelectAllEmployees()
        {
            return GetCommand(ref selectAllEmployees, selectAllEmployeesPath);
        }
        public static String SelectAllTradePointsTypes()
        {
            return GetCommand(ref selectAllTradePointsTypes, selectAllTradePointsTypesPath);
        }
        public static String SelectAllTradePoints()
        {
            return GetCommand(ref selectAllTradePoints, selectAllTradePointsPath);
        }
        public static String SelectAllObjectsRelations()
        {
            return GetCommand(ref selectAllObjectsRelations, selectAllObjectsRelationsPath);
        }
        public static String SelectAllEmployeesPositions()
        {
            return GetCommand(ref selectAllEmployeesPositions, selectAllEmployeesPositionsPath);
        }

        /* inserts */

        public static String InsertTradePointType(TradePointType type)
        {
            return GetCommand(ref insertTradePointType, insertTradePointTypePath, new string[]{ type.Name });
        }
        public static String InsertTradePoint(TradePoint point)
        {
            return GetCommand(ref insertTradePoint, insertTradePointPath, new string[] { point.Name, point.Type.Id.ToString() });
        }
        public static String InsertObjectsRelations(ObjectRelation relation)
        {
            return GetCommand(ref insertObjectsRelations, insertObjectsRelationsPath, new string[] { relation.Parent.ToString(), relation.Id.ToString() });
        }
        public static String InsertEmployeesPositions(EmployeePosition position)
        {
            return GetCommand(ref insertEmployeesPositions, insertEmployeesPositionsPath, new string[] { position.Name });
        }
        public static String InsertEmployee(Employee employee)
        {
            return GetCommand(ref insertEmployees, insertEmployeesPath, new string[] { employee.Name });
        }
        public static String InsertEmployeesList(Employee employee)
        {
            return GetCommand(ref insertEmployeesList, insertEmployeesListPath, new string[] { employee.TradePoint.Id.ToString(), employee.Id.ToString(), employee.Position.Id.ToString() });
        }

        /* updated */

        public static String UpdateTradePointType(TradePointType type)
        {
            return GetCommand(ref updateTradePointType, updateTradePointTypePath, new string[] { type.Name, String.Format("{0}", type.Id) });
        }
        public static String UpdateTradePoint(TradePoint point)
        {
            return GetCommand(ref updateTradePoint, updateTradePointPath, new string[] { point.Name, point.Type.Id.ToString(), point.Id.ToString() });
        }
        public static String UpdateObjectsRelations(ObjectRelation relation)
        {
            return GetCommand(ref updateObjectsRelations, updateObjectsRelationsPath, new string[] { relation.Parent.ToString(), relation.Id.ToString(), relation.ObjRelId.ToString() });
        }
        public static String UpdateEmployeesPositions(EmployeePosition position)
        {
            return GetCommand(ref updateEmployeesPositions, updateEmployeesPositionsPath, new string[] { position.Name, position.Id.ToString() });
        }
        public static String UpdateEmployee(Employee employee)
        {
            return GetCommand(ref updateEmployees, updateEmployeesPath, new string[] { employee.Name, employee.Id.ToString() });
        }
        public static String UpdateEmployeesList(Employee employee)
        {
            return GetCommand(ref updateEmployeesList, updateEmployeesListPath, new string[] { employee.TradePoint.Id.ToString(), employee.Position.Id.ToString(), employee.Id.ToString() });
        }

        /* deletes */

        public static String DeleteTradePointType(TradePointType type)
        {
            return GetCommand(ref deleteTradePointType, deleteTradePointTypePath, new string[] { type.Id.ToString() });
        }
        public static String DeleteTradePoint(TradePoint point)
        {
            return GetCommand(ref deleteTradePoint, deleteTradePointPath, new string[] { point.Id.ToString() });
        }
        public static String DeleteObjectsRelations(ObjectRelation relation)
        {
            return GetCommand(ref deleteObjectsRelations, deleteObjectsRelationsPath, new string[] { relation.Id.ToString() });
        }
        public static String DeleteEmployeesPositions(EmployeePosition position)
        {
            return GetCommand(ref deleteEmployeesPositions, deleteEmployeesPositionsPath, new string[] { position.Id.ToString() });
        }
        public static String DeleteEmployee(Employee employee)
        {
            return GetCommand(ref deleteEmployees, deleteEmployeesPath, new string[] { employee.Id.ToString() });
        }
        public static String DeleteEmployeesList(Employee employee)
        {
            return GetCommand(ref deleteEmployeesList, deleteEmployeesListPath, new string[] { employee.Id.ToString() });
        }

        private static String cmdFolder = "Controllers\\SQLUtils\\Resources\\";
        private static String createFolder = cmdFolder + "CreatingDB\\";
        private static String selectFolder = cmdFolder + "Select\\";
        private static String insertFolder = cmdFolder + "Insert\\";
        private static String updateFolder = cmdFolder + "Update\\";
        private static String deleteFolder = cmdFolder + "Delete\\";

        private static String selectTest = null;
        private static String selectTestPath = selectFolder + "SelectFromTest.sql";
        private static String selectAllEmployees = null;
        private static String selectAllEmployeesPath = selectFolder + "SelectAllEmployees.sql";
        private static String selectAllTradePointsTypes = null;
        private static String selectAllTradePointsTypesPath = selectFolder + "SelectAllTradePointsTypes.sql";
        private static String selectAllTradePoints = null;
        private static String selectAllTradePointsPath = selectFolder + "SelectAllTradePoints.sql";
        private static String selectAllObjectsRelations = null;
        private static String selectAllObjectsRelationsPath = selectFolder + "SelectAllObjectsRelations.sql";
        private static String selectAllEmployeesPositions = null;
        private static String selectAllEmployeesPositionsPath = selectFolder + "SelectAllEmployeesPositions.sql";

        private static String insertTradePointType = null;
        private static String insertTradePointTypePath = insertFolder + "InsertTradePointType.sql";
        private static String insertTradePoint = null;
        private static String insertTradePointPath = insertFolder + "InsertTradePoint.sql";
        private static String insertObjectsRelations = null;
        private static String insertObjectsRelationsPath = insertFolder + "InsertObjectsRelations.sql";
        private static String insertEmployeesPositions = null;
        private static String insertEmployeesPositionsPath = insertFolder + "InsertEmployeesPositions.sql";
        private static String insertEmployees = null;
        private static String insertEmployeesPath = insertFolder + "InsertEmployees.sql";
        private static String insertEmployeesList = null;
        private static String insertEmployeesListPath = insertFolder + "InsertEmployeesList.sql";

        private static String updateTradePointType = null;
        private static String updateTradePointTypePath = updateFolder + "UpdateTradePointType.sql";
        private static String updateTradePoint = null;
        private static String updateTradePointPath = updateFolder + "UpdateTradePoint.sql";
        private static String updateObjectsRelations = null;
        private static String updateObjectsRelationsPath = updateFolder + "UpdateObjectsRelations.sql";
        private static String updateEmployeesPositions = null;
        private static String updateEmployeesPositionsPath = updateFolder + "UpdateEmployeesPositions.sql";
        private static String updateEmployees = null;
        private static String updateEmployeesPath = updateFolder + "UpdateEmployees.sql";
        private static String updateEmployeesList = null;
        private static String updateEmployeesListPath = updateFolder + "UpdateEmployeesList.sql";

        private static String deleteTradePointType = null;
        private static String deleteTradePointTypePath = deleteFolder + "DeleteTradePointType.sql";
        private static String deleteTradePoint = null;
        private static String deleteTradePointPath = deleteFolder + "DeleteTradePoint.sql";
        private static String deleteObjectsRelations = null;
        private static String deleteObjectsRelationsPath = deleteFolder + "DeleteObjectsRelations.sql";
        private static String deleteEmployeesPositions = null;
        private static String deleteEmployeesPositionsPath = deleteFolder + "DeleteEmployeesPositions.sql";
        private static String deleteEmployees = null;
        private static String deleteEmployeesPath = deleteFolder + "DeleteEmployees.sql";
        private static String deleteEmployeesList = null;
        private static String deleteEmployeesListPath = deleteFolder + "DeleteEmployeesList.sql";

        private static String createTTypes = null;
        private static String createTTypesPath = createFolder + "CreateTSuppliers.sql";
        private static String createTTradePoints = null;
        private static String createTTradePointsPath = createFolder + "CreateTTradePoints.sql";
        private static String createTObjectsRelations = null;
        private static String createTObjectsRelationsPath = createFolder + "CreateTObjectRelations.sql";
        private static String createTEmployeesPositions = null;
        private static String createTEmployeesPositionsPath = createFolder + "CreateTEmployeesPositions.sql";
        private static String createTEmployees = null;
        private static String createTEmployeesPath = createFolder + "CreateTEmployees.sql";
        private static String createTEmployeesList = null;
        private static String createTEmployeesListPath = createFolder + "CreateEmployeesList.sql";
        private static String createTTradePointsPayments = null;
        private static String createTTradePointsPaymentsPath = createFolder + "CreateTTradePointsPayments.sql";
        private static String createTTradePointsProps = null;
        private static String createTTradePointsPropsPath = createFolder + "CreateTTradePointsProps.sql";
        private static String createTSuppliers = null;
        private static String createTSuppliersPath = createFolder + "CreateTSuppliers.sql";
        private static String createTProducts = null;
        private static String createTProductsPath = createFolder + "CreateTProducts.sql";
        private static String createTTradePointsProducts = null;
        private static String createTTradePointsProductsPath = createFolder + "CreateTTradePointsProducts.sql";
        private static String createTTradePointsSales = null;
        private static String createTTradePointsSalesPath = createFolder + "CreateTTradePointsSales.sql";
        private static String createTTradePointsCustomers = null;
        private static String createTTradePointsCustomersPath = createFolder + "CreateTTradePointsCustomers.sql";
        private static String createTTradePointsCustomersPurchases = null;
        private static String createTTradePointsCustomersPurchasesPath = createFolder + "CreateTTradePointsCustomersPurchases.sql";
        private static String createTTradePointsRequests = null;
        private static String createTTradePointsRequestsPath = createFolder + "CreateTTradePointsRequests.sql";
        private static String createTOrders = null;
        private static String createTOrdersPath = createFolder + "CreateTOrders.sql";
        private static String createTOrdersLists = null;
        private static String createTOrdersListsPath = createFolder + "CreateTOredersLists.sql";
        private static String createTRequestsOrders = null;
        private static String createTRequestsOrdersPath = createFolder + "CreateTRequestsOrders.sql";
        private static String createTSupplies = null;
        private static String createTSuppliesPath = createFolder + "CreateTSupplies.sql";
        private static String createTSuppliesOrders = null;
        private static String createTSuppliesOrdersPath = createFolder + "CreateTSuppliesOrders.sql";
        private static String createTSuppliesDistribution = null;
        private static String createTSuppliesDistributionPath = createFolder + "CreateTSuppliesDistribution.sql";
    }
}
