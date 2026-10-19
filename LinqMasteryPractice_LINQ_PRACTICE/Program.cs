using LinqMastery.Data;
using LinqMasteryPractice;
using System.Linq;


namespace LinqMastery;

public class Program
{
    public static void Main()
    {

        serialization.method1();
        //Console.WriteLine("LINQ Mastery Practice Project");
        //Console.WriteLine("Uncomment one exercise method at a time in Main().");

        //Exercise01_Filtering();
        // Exercise02_Projection();
        // Exercise03_SelectMany();
        // Exercise04_Sorting();
        // Exercise05_ElementOperators();
        // Exercise06_Aggregation();
        // Exercise07_AnyAll();
        // Exercise08_Grouping();
        // Exercise09_SetOperations();
        // Exercise10_InnerJoin();
        // Exercise11_LeftJoin();
        // Exercise12_GroupJoin();
        // Exercise13_Partitioning();
        // Exercise14_QuantifiersAndMembership();
        // Exercise15_StringAndNumericQueries();
        // Exercise16_NestedQueries();
        // Exercise17_CombinedQueries();
        // Exercise18_DictionaryAndLookup();
        // Exercise19_JoinOrdersAndCustomers();
        // Exercise20_Reports();
    }

    // RULE: For every task, implement both styles where supported.
    // Use these labels to keep your work organised:
    // METHOD SYNTAX PRACTICE
    // QUERY SYNTAX PRACTICE

    static void Exercise01_Filtering()
    {
        var products = StoreData.Products;

        // Task 1: Find products priced above 5,000.
        var prod_abov_5000=products.Where(p=>p.Price>=5000).Select(p=>p.ProductName);
        // TODO: products.Where(...)

        // QUERY SYNTAX PRACTICE
        var query_prod_abov_5000=from p in products where p.Price>=5000 select p.ProductName;
        // TODO: from p in products where ... select p

        // Task 2: Find Electronics products that are in stock.
        var prod_elec_in_stock=products.Where(p=>p.Category=="Electronics" && p.Stock>0).Select(p=>p.ProductName);
        // METHOD SYNTAX PRACTICE
        // TODO: Where with &&

        // QUERY SYNTAX PRACTICE
        var query_prod_elec_in_stock=from p in products where p.Category=="Electronics" && p.Stock>0 select p.ProductName;
        // TODO: where with &&

        // Task 3: Find products priced between 1,000 and 20,000.
        var prod_price_range=products.Where(p=>p.Price>=1000 && p.Price<=20000).Select(p=>p.ProductName);
        // METHOD SYNTAX PRACTICE
        // TODO

        // QUERY SYNTAX PRACTICE
        var query_prod_in_range=from p in products where p.Price>=1000 && p.Price<=20000 select p.ProductName;
        // TODO

        // Task 4: Find products whose names contain "Office".
        // METHOD SYNTAX PRACTICE
        var prod_contains_office = products.Where(p=>p.ProductName.Contains("Office")).Select(p=>p.ProductName);
        // TODO: Contains()

        // QUERY SYNTAX PRACTICE
        var query_prod_contains_office=from p in products where p.ProductName.Contains("Office") select p.ProductName;
        // TODO
    }

    static void Exercise02_Projection()
    {
        var products = StoreData.Products;

        // Task 1: Select only product names.
        // METHOD SYNTAX PRACTICE
        var prod_names=products.Select(p=>p.ProductName);
        // TODO: Select(...)

        // QUERY SYNTAX PRACTICE
        var query_prod_names=from p in products select p.ProductName;
        // TODO: select p.ProductName

        // Task 2: Return ProductName and Price using an anonymous type.
        // METHOD SYNTAX PRACTICE
        var prod_name_price=products.Select(p=>new{p.ProductName,p.Price});
        // TODO: Select(p => new { ... })

        // QUERY SYNTAX PRACTICE
        var query_prod_name_price=from p in products select new{p.ProductName,p.Price};
        // TODO: select new { ... }

        // Task 3: Return ProductName, Price, and PriceWithTax (18%).
        // METHOD SYNTAX PRACTICE
        var prod_name_tax=products.Select(p=>new{p.ProductName,p.Price,PriceWithTax=p.Price*1.18M});
        // TODO

        // QUERY SYNTAX PRACTICE
        var query_prod_name_tax=from p in products select new{p.ProductName,p.Price,PriceWithTax=p.Price*1.18M};
        // TODO
    }

    static void Exercise03_SelectMany()
    {
        var batches = StoreData.TrainingBatches;

        // Task 1: Flatten all training batches into one sequence.
        // METHOD SYNTAX PRACTICE
        // TODO: SelectMany()

        // QUERY SYNTAX PRACTICE
        // TODO: use two from clauses

        // Task 2: Get every product tag as one flat sequence.
        // METHOD SYNTAX PRACTICE
        // TODO

        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise04_Sorting()
    {
        var products = StoreData.Products;

        // Task 1: Sort by price ascending.
        // METHOD SYNTAX PRACTICE
        var prod_sorted_asc=products.OrderBy(p=>p.Price).Select(p=>p.ProductName);
        // TODO: OrderBy()

        // QUERY SYNTAX PRACTICE
        var query_prod_sorted_asc=from p in products orderby p.Price select p.ProductName;
        // TODO: orderby

        // Task 2: Sort by price descending.
        // METHOD SYNTAX PRACTICE
        var prod_sorted_desc=products.OrderByDescending(p=>p.Price).Select(p=>p.ProductName);
        // TODO: OrderByDescending()

        // QUERY SYNTAX PRACTICE
        var query_prod_sorted_desc=from p in products orderby p.Price descending select p.ProductName;
        // TODO: orderby ... descending

        // Task 3: Sort by Category ascending, then Price descending.
        // METHOD SYNTAX PRACTICE
        var sortbycategory =products.OrderBy(c=>c.Category).ThenByDescending(p=>p.Price).Select(p=>p.ProductName);
        // TODO: OrderBy().ThenByDescending()

        // QUERY SYNTAX PRACTICE
        var query_sortbycategory=from p in products orderby p.Category ascending ,p.Price descending  select p.ProductName;
        // TODO
    }

    static void Exercise05_ElementOperators()
    {
        var products = StoreData.Products;

        // Task 1: Find the first product priced above 10,000.
        // METHOD SYNTAX PRACTICE
        var prod_first=products.First(p=>p.Price>10000);
        // TODO: First()

        // QUERY SYNTAX PRACTICE
        var query_prod=from p in products where p.Price>10000 select p.ProductName;
        
        // TODO: query + First()

        // Task 2: Search for ProductId 999 safely.
        // METHOD SYNTAX PRACTICE
        var prod_firstdefault=products.FirstOrDefault(p=>p.Price>10000);
        // TODO: FirstOrDefault()

        // QUERY SYNTAX PRACTICE
        // TODO: query + FirstOrDefault()

        // Task 3: Find ProductId 3 using Single().
        // METHOD SYNTAX PRACTICE
        var prod_single=products.Single(p=>p.Price>10000);
        // TODO: Single()

        // QUERY SYNTAX PRACTICE
        var query_prod_single=from p in products where p.Price>10000 select p.ProductName;
        // TODO: query + Single()
    }

    static void Exercise06_Aggregation()
    {
        var products = StoreData.Products;

        // Task 1: Count all products.
        // METHOD SYNTAX PRACTICE
        var prod_count=products.Count();
        // TODO: Count()

        // QUERY SYNTAX PRACTICE
        var query_prod_count=from p in products select p.ProductName;
        // TODO: query + Count()

        // Task 2: Calculate total stock.
        // METHOD SYNTAX PRACTICE
        var prod_stock=products.Sum(p=>p.Stock);
        // TODO: Sum()

        // QUERY SYNTAX PRACTICE
        var query_prod_stock=from p in products select p.Stock;
        // TODO: query + Sum()

        // Task 3: Find average, minimum and maximum price.
        // METHOD SYNTAX PRACTICE
        var avg_price=products.Average(p=>p.Price);
        var min_price=products.Min(p=>p.Price);
        var max_price=products.Max(p=>p.Price);
        // TODO

        // QUERY SYNTAX PRACTICE
  
        // TODO

        // Task 4: Calculate total inventory value (Price * Stock).
        // METHOD SYNTAX PRACTICE
        var total_val = products.Sum(p=>p.Price*p.Stock);
        // TODO

        // QUERY SYNTAX PRACTICE
        var query_total_val=from p in products select p.Price*p.Stock;
        // TODO
    }

    static void Exercise07_AnyAll()
    {
        var products = StoreData.Products;

        // Task 1: Check whether any product costs more than 50,000.
        // METHOD SYNTAX PRACTICE
        var prod_more_5000=products.Any(p=>p.Price>50000);
        // TODO: Any()

        // QUERY SYNTAX PRACTICE
        // TODO: query + Any()

        // Task 2: Check whether all products have non-negative stock.
        // METHOD SYNTAX PRACTICE\
        var prod_stock_non_neg=products.All(p=>p.Stock>=0);
        // TODO: All()

        // QUERY SYNTAX PRACTICE
        // TODO: query + All()
    }

    static void Exercise08_Grouping()
    {
        var products = StoreData.Products;

        // Task 1: Group products by Category.
        // METHOD SYNTAX PRACTICE
        var prod_grp_by_cat=products.GroupBy(p=>p.Category);
        // TODO: GroupBy()

        // QUERY SYNTAX PRACTICE
        var query_prod_grp_by_cat=from p in products group p by p.Category;
        // TODO: group ... by ...

        // Task 2: For each category, calculate product count,
        // total stock, and average price.
        // METHOD SYNTAX PRACTICE
        var prod_grp_by_cat_summary=products.GroupBy(p=>p.Category).Select(g=>new{g.Key,Count=g.Count(),TotalStock=g.Sum(p=>p.Stock),AveragePrice=g.Average(p=>p.Price)});
        // TODO: GroupBy + Select

        // QUERY SYNTAX PRACTICE
        var query_prod_grp_by_cat_summary=from p in products group p by p.Category into g select new{g.Key,Count=g.Count(),TotalStock=g.Sum(p=>p.Stock),AveragePrice=g.Average(p=>p.Price)};
        // TODO: group ... by ... into ...
    }

    static void Exercise09_SetOperations()
    {
        var a = StoreData.ListA;
        var b = StoreData.ListB;

        // Task 1: Remove duplicates.
        // METHOD SYNTAX PRACTICE
        // TODO: Distinct()

        // QUERY SYNTAX PRACTICE
        // TODO: query + Distinct()

        // Task 2: Find union, intersection and A-only values.
        // METHOD SYNTAX PRACTICE
        // TODO: Union(), Intersect(), Except()

        // QUERY SYNTAX PRACTICE
        // TODO: query results + set operators
    }

    static void Exercise10_InnerJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Display EmployeeName and DepartmentName for matching records.
        // METHOD SYNTAX PRACTICE
        var join=employees.Join(departments,e=>e.DepartmentId,d=>d.DepartmentId,(e,d)=>new{EmployeeName=e.EmployeeName,DepartmentName=d.DepartmentName});
        // TODO: Join()

        // QUERY SYNTAX PRACTICE
        var query_join=from e in employees join d in departments on e.DepartmentId equals d.DepartmentId select new{EmployeeName=e.EmployeeName,DepartmentName=d.DepartmentName};
        // TODO: join ... on ... equals ...
    }

    static void Exercise11_LeftJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return every employee, displaying "Unassigned" if
        // no matching department exists.
        // METHOD SYNTAX PRACTICE
        // TODO: LeftJoin() on .NET 10, or GroupJoin + SelectMany

        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ... then DefaultIfEmpty()
    }

    static void Exercise12_GroupJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return each department with its employee count.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupJoin()

        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ...
    }

    static void Exercise13_Partitioning()
    {
        var products = StoreData.Products.OrderBy(p => p.ProductId);

        // Task 1: Get first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Take(3)

        // QUERY SYNTAX PRACTICE
        // TODO: query + Take(3)

        // Task 2: Skip first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Skip(3)

        // QUERY SYNTAX PRACTICE
        // TODO: query + Skip(3)
    }

    static void Exercise14_QuantifiersAndMembership()
    {
        List<int> requestedIds = new() { 1, 3, 5 };

        // Task: Find products whose IDs occur in requestedIds.
        // METHOD SYNTAX PRACTICEq
        // TODO: Where + Contains

        // QUERY SYNTAX PRACTICE
        // TODO: where + Contains
    }

    static void Exercise15_StringAndNumericQueries()
    {
        var products = StoreData.Products;

        // Task 1: Find names starting with "O".
        // METHOD SYNTAX PRACTICE
        var res=products.Where(p=>p.ProductName.StartsWith("O")).Select(p=>p.ProductName);
        // TODO: StartsWith()


        // QUERY SYNTAX PRACTICE
        var res1=from prod in products where prod.ProductName.StartsWith("O") select prod;

        // Task 2: Find products with even ProductIds.
        // METHOD SYNTAX PRACTICE
        var res3=products.Where(p=>p.ProductId%2==0).Select(p=>p.ProductName);
        // TODO: modulo operator %

        // QUERY SYNTAX PRACTICE
        var res4=from prod in products where prod.ProductId%2==0 select prod;
    }

    static void Exercise16_NestedQueries()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;

        // Task 1: Find products priced above average.
        // METHOD SYNTAX PRACTICE
        // TODO: Average + Where

        // QUERY SYNTAX PRACTICE
        // TODO

        // Task 2: Find customers with at least one order.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + Any

        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise17_CombinedQueries()
    {
        var products = StoreData.Products;

        // Task: Find in-stock Electronics products, sort by descending
        // price, and return only product names.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + OrderByDescending + Select

        // QUERY SYNTAX PRACTICE
        // TODO: from + where + orderby + select
    }

    static void Exercise18_DictionaryAndLookup()
    {
        var products = StoreData.Products;

        // Task 1: Create a dictionary keyed by ProductId.
        // METHOD SYNTAX PRACTICE
        // TODO: ToDictionary()

        // QUERY SYNTAX PRACTICE
        // TODO: query + ToDictionary()

        // Task 2: Create a lookup by Category.
        // METHOD SYNTAX PRACTICE
        // TODO: ToLookup()

        // QUERY SYNTAX PRACTICE
        // TODO: query + ToLookup()
    }

    static void Exercise19_JoinOrdersAndCustomers()
    {
        var orders = StoreData.Orders;
        var customers = StoreData.Customers;

        // Task: Show OrderId, CustomerName, OrderDate and Status.
        // METHOD SYNTAX PRACTICE
        // TODO: Join + Select

        // QUERY SYNTAX PRACTICE
        // TODO: join + select
    }

    static void Exercise20_Reports()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;

        // Task 1: Count orders by Status.
        // METHOD SYNTAX PRACTICE
        var order_count_by_status=orders.GroupBy(o=>o.Status).Select(o=>new{o.Key,Count=o.Count()});
        // TODO: GroupBy + Count

        // QUERY SYNTAX PRACTICE
        var query_order_count_by_status=from o in orders group o by o.Status into g select new{g.Key,Count=g.Count()};
        // TODO: group by + Count

        // Task 2: Create a category report with product count,
        // average price, total stock and inventory value.
        // METHOD SYNTAX PRACTICE
        // TODO

        // QUERY SYNTAX PRACTICE
        // TODO
    }
}
