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

            cachedCommand = File.ReadAllText("D:\\Repositories\\Visual Studio Projects\\BDProject\\Server\\Server\\" + (commandPath));
            return cachedCommand;
        }

        internal static string InsertSupply(Supply supply)
        {
            return GetCommand(ref insertSupply, insertSupplyPath, new string[] { supply.Product.Product.Id.ToString(), supply.Product.TradePoint.Id.ToString(), supply.Product.Supplier.Id.ToString(), supply.Product.Count.ToString(), supply.Product.Price.ToString(), supply.Order.Id.ToString(), /*supply.Date.ToString("yyyy/mm/dd")*/ "2020/10/10" });
        }

        //------------------------------------------------------------------------
        internal static string SelectTradePointSales(int id)
        {
            return GetCommand(ref selectTradePointSales, selectTradePointSalesPath, new string[] { id.ToString() });
        }
        internal static string SelectTradePointRequests(int id)
        {
            return GetCommand(ref selectTradePointRequests, selectTradePointRequestsPath, new string[] { id.ToString() });
        }
        internal static string SelectTradePointProducts(int id)
        {
            return GetCommand(ref selectTradePointProducts, selectTradePointProductsPath, new string[] { id.ToString() });
        }
        internal static string SelectAllTradePointsCustomers()
        {
            return GetCommand(ref selectAllTradePointsCustomers, selectAllTradePointsCustomersPath);
        }
        internal static string SelectAllOrders()
        {
            return GetCommand(ref selectAllOrders, selectAllOrdersPath);
        }

        internal static string DeleteTradePointSale(int id)
        {
            return GetCommand(ref deleteTradePointSale, deleteTradePointSalePath, new string[] { id.ToString() });
        }
        internal static string DeleteTradePointRequest(int id)
        {
            return GetCommand(ref deleteTradePointRequest, deleteTradePointRequestPath, new string[] { id.ToString() });
        }
        internal static string DeleteTradePointProduct(int id)
        {
            return GetCommand(ref deleteTradePointProduct, deleteTradePointProductPath, new string[] { id.ToString() });
        }
        internal static string DeleteTradePointsCustomer(int id)
        {
            return GetCommand(ref deleteTradePointsCustomer, deleteTradePointsCustomerPath, new string[] { id.ToString() });
        }
        internal static string DeleteOrder(int id)
        {
            return GetCommand(ref deleteOrder, deleteOrderPath, new string[] { id.ToString() });
        }
        internal static string DeleteProduct(int id)
        {
            return GetCommand(ref deleteProduct, deleteProductPath, new string[] { id.ToString() });
        }

        internal static string InsertTradePointSale(TradePointSale sale)
        {
            return GetCommand(ref insertTradePointSale, insertTradePointSalePath, new string[] { sale.Count.ToString(), sale.Date.ToString("'yyyy/mm/dd"), sale.TradePointProduct.Id.ToString() });
        }
        internal static string InsertTradePointRequest(TradePointRequest request)
        {
            return GetCommand(ref insertTradePointRequest, insertTradePointRequestPath, new string[] { request.TradePoint.Id.ToString(), request.Product.Product.Id.ToString(), request.Product.Count.ToString(), request.Product.Supplier.Id.ToString() });
        }
        internal static string InsertTradePointProduct(TradePointProduct product)
        {
            return GetCommand(ref insertTradePointProduct, insertTradePointProductPath, new string[] { product.TradePoint.Id.ToString(), product.Product.Id.ToString(), product.Supplier.Id.ToString(), product.Count.ToString(), product.Price.ToString() });
        }
        internal static string InsertTradePointsCustomer(TradePointCustomer customer)
        {
            return GetCommand(ref insertTradePointsCustomer, insertTradePointsCustomerPath, new string[] { customer.Name, customer.Description });
        }
        internal static string InsertOrder(Order order)
        {
            return GetCommand(ref insertOrder, insertOrderPath, new string[] { order.Date.ToString("yyyy/mm/dd"), order.Product.Product.Id.ToString(), order.Product.Supplier.Id.ToString(), order.Product.Count.ToString(), order.Request.Id.ToString() });
        }
        internal static string InsertProduct(Product product)
        {
            return GetCommand(ref insertProduct, insertProductPath, new string[] { product.Name });
        }

        internal static string UpdateTradePointSale(TradePointSale sale)
        {
            return GetCommand(ref updateTradePointSale, updateTradePointSalePath, new string[] { sale.Count.ToString(), sale.Date.ToString("yyyy/mm/dd"), sale.TradePointProduct.Id.ToString(), sale.Id.ToString() });
        }
        internal static string UpdateTradePointRequest(TradePointRequest request)
        {
            return GetCommand(ref updateTradePointRequest, updateTradePointRequestPath, new string[] { request.TradePoint.Id.ToString(), request.Product.Product.Id.ToString(), request.Product.Count.ToString(), request.Product.Supplier.Id.ToString(), request.Id.ToString() });
        }
        internal static string UpdateTradePointProduct(TradePointProduct product)
        {
            return GetCommand(ref updateTradePointProduct, updateTradePointProductPath, new string[] { product.TradePoint.Id.ToString(), product.Product.Id.ToString(), product.Supplier.Id.ToString(), product.Count.ToString(), product.Price.ToString(), product.Id.ToString() });
        }
        internal static string UpdateTradePointsCustomer(TradePointCustomer customer)
        {
            return GetCommand(ref updateTradePointsCustomer, updateTradePointsCustomerPath, new string[] { customer.Name, customer.Description, customer.Id.ToString() });
        }
        internal static string UpdateOrder(Order order)
        {
            return GetCommand(ref updateOrder, updateOrderPath, new string[] { order.Id.ToString(), order.Date.ToString("yyyy/mm/dd"), order.Product.Product.Id.ToString(), order.Product.Supplier.Id.ToString(), order.Product.Count.ToString(), order.Request.Id.ToString() });
        }
        internal static string UpdateProduct(Product product)
        {
            return GetCommand(ref updateProduct, updateProductPath, new string[] { product.Name, product.Id.ToString() });
        }
        //------------------------------------------------------------------------
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
        public static string SelectAllParents()
        {
            return GetCommand(ref selectAllParents, selectAllParentsPath);
        }
        public static string SelectParent(int id)
        {
            return GetCommand(ref selectParent, selectParentPath, new string[] { id.ToString() });
        }
        public static string SelectTradePointPayments(int id)
        {
            return GetCommand(ref selectTradePointPayments, selectTradePointPaymentsPath, new string[] { id.ToString() });
        }
        public static string SelectAllSuppliers()
        {
            return GetCommand(ref selectAllSuppliers, selectAllSuppliersPath, new string[] { });
        }
        internal static string SelectAllProducts()
        {
            return GetCommand(ref selectAllProducts, selectAllProductsPath, new string[] { });
        }

        /* inserts */

        public static String InsertTradePointType(TradePointType type)
        {
            return GetCommand(ref insertTradePointType, insertTradePointTypePath, new string[]{ type.Name });
        }
        public static String InsertTradePoint(TradePoint point)
        {
            return GetCommand(ref insertTradePoint, insertTradePointPath, new string[] { point.Name, point.Type.Id.ToString(), point.Size.ToString(), point.NumberOfCounters.ToString() });
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
        public static String InsertTradePointPayment(TradePointPayment payment)
        {
            return GetCommand(ref insertTradePointPayment, insertTradePointPaymentPath, new string[] { payment.Id.ToString(), payment.Name, payment.Sum.ToString(), payment.Date.ToString("YYYY/MM/DD") });
        }
        public static String InsertSupplier(Supplier supplier)
        {
            return GetCommand(ref insertSupplier, insertSupplierPath, new string[] { supplier.Name });
        }

        /* updated */

        public static String UpdateTradePointType(TradePointType type)
        {
            return GetCommand(ref updateTradePointType, updateTradePointTypePath, new string[] { type.Name, String.Format("{0}", type.Id) });
        }
        public static String UpdateTradePoint(TradePoint point)
        {
            return GetCommand(ref updateTradePoint, updateTradePointPath, new string[] { point.Name, point.Type.Id.ToString(), point.Size.ToString(), point.NumberOfCounters.ToString(), point.Id.ToString() });
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
        public static String UpdateTradePointPayment(TradePointPayment payment)
        {
            return GetCommand(ref updateTradePointPayment, updateTradePointPaymentPath, new string[] { payment.Name, payment.Sum.ToString(), payment.Date.ToString("YYYY/MM/DD"), payment.Id.ToString() });
        }
        public static String UpdateSupplier(Supplier supplier)
        {
            return GetCommand(ref updateSupplier, updateSupplierPath, new string[] { supplier.Name, supplier.Id.ToString() });
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
        public static String DeleteTradePointPayment(int id)
        {
            return GetCommand(ref deleteTradePointPayment, deleteTradePointPaymentPath, new string[] { id.ToString() });
        }
        public static String DeleteSupplier(int id)
        {
            return GetCommand(ref deleteSupplier, deleteSupplierPath, new string[] { id.ToString() });
        }

        private static string cmdFolder = "Controllers\\SQLUtils\\Resources\\";
        private static string createFolder = cmdFolder + "CreatingDB\\";
        private static string selectFolder = cmdFolder + "Select\\";
        private static string insertFolder = cmdFolder + "Insert\\";
        private static string updateFolder = cmdFolder + "Update\\";
        private static string deleteFolder = cmdFolder + "Delete\\";

        private static string selectTest = null;
        private static string selectTestPath = selectFolder + "SelectFromTest.sql";
        private static string selectAllEmployees = null;
        private static string selectAllEmployeesPath = selectFolder + "SelectAllEmployees.sql";
        private static string selectAllTradePointsTypes = null;
        private static string selectAllTradePointsTypesPath = selectFolder + "SelectAllTradePointsTypes.sql";
        private static string selectAllTradePoints = null;
        private static string selectAllTradePointsPath = selectFolder + "SelectAllTradePoints.sql";
        private static string selectAllObjectsRelations = null;
        private static string selectAllObjectsRelationsPath = selectFolder + "SelectAllObjectsRelations.sql";
        private static string selectAllEmployeesPositions = null;
        private static string selectAllEmployeesPositionsPath = selectFolder + "SelectAllEmployeesPositions.sql";
        private static string selectAllParents = null;
        private static string selectAllParentsPath = selectFolder + "SelectAllParents.sql";
        private static string selectParent = null;
        private static string selectParentPath = selectFolder + "SelectParent.sql";
        private static string selectTradePointPayments = null;
        private static string selectTradePointPaymentsPath = selectFolder + "SelectTradePointPayments.sql";
        private static string selectAllSuppliers = null;
        private static string selectAllSuppliersPath = selectFolder + "SelectAllSuppliers.sql";

        private static string insertTradePointType = null;
        private static string insertTradePointTypePath = insertFolder + "InsertTradePointType.sql";
        private static string insertTradePoint = null;
        private static string insertTradePointPath = insertFolder + "InsertTradePoint.sql";
        private static string insertObjectsRelations = null;
        private static string insertObjectsRelationsPath = insertFolder + "InsertObjectsRelations.sql";
        private static string insertEmployeesPositions = null;
        private static string insertEmployeesPositionsPath = insertFolder + "InsertEmployeesPositions.sql";
        private static string insertEmployees = null;
        private static string insertEmployeesPath = insertFolder + "InsertEmployees.sql";
        private static string insertEmployeesList = null;
        private static string insertEmployeesListPath = insertFolder + "InsertEmployeesList.sql";
        private static string insertTradePointPayment = null;
        private static string insertTradePointPaymentPath = insertFolder + "InsertTradePointPayment.sql";
        private static string insertSupplier = null;
        private static string insertSupplierPath = insertFolder + "InsertSupplier.sql";

        private static string updateTradePointType = null;
        private static string updateTradePointTypePath = updateFolder + "UpdateTradePointType.sql";
        private static string updateTradePoint = null;
        private static string updateTradePointPath = updateFolder + "UpdateTradePoint.sql";
        private static string updateObjectsRelations = null;
        private static string updateObjectsRelationsPath = updateFolder + "UpdateObjectsRelations.sql";
        private static string updateEmployeesPositions = null;
        private static string updateEmployeesPositionsPath = updateFolder + "UpdateEmployeesPositions.sql";
        private static string updateEmployees = null;
        private static string updateEmployeesPath = updateFolder + "UpdateEmployees.sql";
        private static string updateEmployeesList = null;
        private static string updateEmployeesListPath = updateFolder + "UpdateEmployeesList.sql";
        private static string updateTradePointPayment = null;
        private static string updateTradePointPaymentPath = updateFolder + "UpdateTradePointPayment.sql";
        private static string updateSupplier = null;
        private static string updateSupplierPath = updateFolder + "UpdateSupplier.sql";

        private static string deleteTradePointType = null;
        private static string deleteTradePointTypePath = deleteFolder + "DeleteTradePointType.sql";
        private static string deleteTradePoint = null;
        private static string deleteTradePointPath = deleteFolder + "DeleteTradePoint.sql";
        private static string deleteObjectsRelations = null;
        private static string deleteObjectsRelationsPath = deleteFolder + "DeleteObjectsRelations.sql";
        private static string deleteEmployeesPositions = null;
        private static string deleteEmployeesPositionsPath = deleteFolder + "DeleteEmployeesPositions.sql";
        private static string deleteEmployees = null;
        private static string deleteEmployeesPath = deleteFolder + "DeleteEmployees.sql";
        private static string deleteEmployeesList = null;
        private static string deleteEmployeesListPath = deleteFolder + "DeleteEmployeesList.sql";
        private static string deleteTradePointPayment = null;
        private static string deleteTradePointPaymentPath = deleteFolder + "DeleteTradePointPayment.sql";
        private static string deleteSupplier = null;
        private static string deleteSupplierPath = deleteFolder + "DeleteSupplier.sql";

        private static string createTTypes = null;
        private static string createTTypesPath = createFolder + "CreateTSuppliers.sql";
        private static string createTTradePoints = null;
        private static string createTTradePointsPath = createFolder + "CreateTTradePoints.sql";
        private static string createTObjectsRelations = null;
        private static string createTObjectsRelationsPath = createFolder + "CreateTObjectRelations.sql";
        private static string createTEmployeesPositions = null;
        private static string createTEmployeesPositionsPath = createFolder + "CreateTEmployeesPositions.sql";
        private static string createTEmployees = null;
        private static string createTEmployeesPath = createFolder + "CreateTEmployees.sql";
        private static string createTEmployeesList = null;
        private static string createTEmployeesListPath = createFolder + "CreateEmployeesList.sql";
        private static string createTTradePointsPayments = null;
        private static string createTTradePointsPaymentsPath = createFolder + "CreateTTradePointsPayments.sql";
        private static string createTTradePointsProps = null;
        private static string createTTradePointsPropsPath = createFolder + "CreateTTradePointsProps.sql";
        private static string createTSuppliers = null;
        private static string createTSuppliersPath = createFolder + "CreateTSuppliers.sql";
        private static string createTProducts = null;
        private static string createTProductsPath = createFolder + "CreateTProducts.sql";
        private static string createTTradePointsProducts = null;
        private static string createTTradePointsProductsPath = createFolder + "CreateTTradePointsProducts.sql";
        private static string createTTradePointsSales = null;
        private static string createTTradePointsSalesPath = createFolder + "CreateTTradePointsSales.sql";
        private static string createTTradePointsCustomers = null;
        private static string createTTradePointsCustomersPath = createFolder + "CreateTTradePointsCustomers.sql";
        private static string createTTradePointsCustomersPurchases = null;
        private static string createTTradePointsCustomersPurchasesPath = createFolder + "CreateTTradePointsCustomersPurchases.sql";
        private static string createTTradePointsRequests = null;
        private static string createTTradePointsRequestsPath = createFolder + "CreateTTradePointsRequests.sql";
        private static string createTOrders = null;
        private static string createTOrdersPath = createFolder + "CreateTOrders.sql";
        private static string createTOrdersLists = null;
        private static string createTOrdersListsPath = createFolder + "CreateTOredersLists.sql";
        private static string createTRequestsOrders = null;
        private static string createTRequestsOrdersPath = createFolder + "CreateTRequestsOrders.sql";
        private static string createTSupplies = null;
        private static string createTSuppliesPath = createFolder + "CreateTSupplies.sql";
        private static string createTSuppliesOrders = null;
        private static string createTSuppliesOrdersPath = createFolder + "CreateTSuppliesOrders.sql";
        private static string createTSuppliesDistribution = null;
        private static string createTSuppliesDistributionPath = createFolder + "CreateTSuppliesDistribution.sql";

        private static string selectTradePointSales = null;
        private static string selectTradePointSalesPath = selectFolder + "SelectTradePointSales.sql";
        private static string selectTradePointRequests = null;
        private static string selectTradePointRequestsPath = selectFolder + "SelectTradePointRequests.sql";
        private static string selectTradePointProducts = null;
        private static string selectTradePointProductsPath = selectFolder + "SelectTradePointProducts.sql";
        private static string selectAllTradePointsCustomers = null;
        private static string selectAllTradePointsCustomersPath = selectFolder + "SelectAllTradePointsCustomers.sql";
        private static string selectAllOrders = null;
        private static string selectAllOrdersPath = selectFolder + "SelectAllOrders.sql";
        private static string selectAllProducts = null;
        private static string selectAllProductsPath = selectFolder + "SelectAllProducts.sql";

        private static string deleteTradePointSale = null;
        private static string deleteTradePointSalePath = deleteFolder + "DeleteTradePointSale.sql";
        private static string deleteTradePointRequest = null;
        private static string deleteTradePointRequestPath = deleteFolder + "DeleteTradePointRequest.sql";
        private static string deleteTradePointProduct = null;
        private static string deleteTradePointProductPath = deleteFolder + "DeleteTradePointProduct.sql";
        private static string deleteTradePointsCustomer = null;
        private static string deleteTradePointsCustomerPath = deleteFolder + "DeleteTradePointsCustomer.sql";
        private static string deleteOrder = null;
        private static string deleteOrderPath = deleteFolder + "DeleteOrder.sql";
        private static string deleteProduct = null;
        private static string deleteProductPath = deleteFolder + "DeleteProduct.sql";

        private static string insertTradePointSale = null;
        private static string insertTradePointSalePath = insertFolder + "InsertTradePointSale.sql";
        private static string insertTradePointRequest = null;
        private static string insertTradePointRequestPath = insertFolder + "InsertTradePointRequest.sql";
        private static string insertTradePointProduct = null;
        private static string insertTradePointProductPath = insertFolder + "InsertTradePointProduct.sql";
        private static string insertTradePointsCustomer = null;
        private static string insertTradePointsCustomerPath = insertFolder + "InsertTradePointsCustomer.sql";
        private static string insertOrder = null;
        private static string insertOrderPath = insertFolder + "InsertOrder.sql";
        private static string insertProduct = null;
        private static string insertProductPath = insertFolder + "InsertProduct.sql";

        private static string updateTradePointSale = null;
        private static string updateTradePointSalePath = updateFolder + "UpdateTradePointSale.sql";
        private static string updateTradePointRequest = null;
        private static string updateTradePointRequestPath = updateFolder + "UpdateTradePointRequest.sql";
        private static string updateTradePointProduct = null;
        private static string updateTradePointProductPath = updateFolder + "UpdateTradePointProduct.sql";
        private static string updateTradePointsCustomer = null;
        private static string updateTradePointsCustomerPath = updateFolder + "UpdateTradePointsCustomer.sql";
        private static string updateOrder = null;
        private static string updateOrderPath = updateFolder + "UpdateOrder.sql";
        private static string updateProduct = null;
        private static string updateProductPath = updateFolder + "UpdateProduct.sql";
        private static string insertSupply = null;
        private static string insertSupplyPath = insertFolder + "InsertSupply.sql";
    }
}
