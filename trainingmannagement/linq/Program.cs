namespace linq;

class Program
{
    List<StoreOrder> orders = new()
    {
        new() { OrderId=101, ProductName="Laptop", Category="Electronics", Amount=50000m },
        new() { OrderId=102, ProductName="Mouse", Category="Electronics", Amount=1000m },
        new() { OrderId=103, ProductName="Chair", Category="Furniture", Amount=5000m },
        new() { OrderId=104, ProductName="Desk", Category="Furniture", Amount=10000m },
        new() { OrderId=105, ProductName="Keyboard", Category="Electronics", Amount=2500m }
    };
    public void filterbyamount()
    {
        //filtering product name that has amount greateer than 5000

        var filtered=orders.Where(n=>n.Amount>=50000m);
        foreach (var storeOrder in filtered)
        {
            Console.WriteLine(storeOrder.ProductName);
            
        }
        
        //select the filtered object and store their prod name 
        var result=filtered.Select(n => n.Amount);
        foreach (var amt in result)
        {
            Console.WriteLine(amt);
        }
        
        //combining filtering and selecting the that particular amount to store 
        var res=orders.Where(n=>n.Amount>=50000m).Select(n => n.Amount);
        foreach (var ress in res)
        {
            Console.WriteLine(ress);
            
        }

    }

    public void sorting()
    {
        //sorting in ascending 
        orders.OrderBy(order => order.Amount);
        //sorting in descending 
        orders.OrderByDescending(order => order.Amount);
        
        
        //then by 
        //if that attribute has same values then go for next attribute that is inside then byv 
        orders.OrderBy(order => order.ProductName).ThenBy(o=>o.Category).ThenBy(o=>o.Amount);
        
    }

    public void first()
    {
        //selects the first element that satisfy the condition 
        var element =orders.First(order => order.Amount>=50000m);
        //selects the first element that satisfies if no such exists return the default elemet
        var fdef=orders.FirstOrDefault(order => order.Amount>=50000m);
        
        
    }

    public void count()
    {
        var count=orders.Count(o=>o.Amount>=50000m);
        Console.WriteLine(count);
    }

    public void grouping()
    {
        var productgrp=orders.GroupBy(order => order.ProductName);
    }

    public void anyorone()
    {
        var allres=orders.All(n=>n.Amount>=50000m);
        var anyres=orders.Any(n=>n.Amount>=50000m);
    }
    static void Main(string[] args)
    {
        //copying  numbers greater than or equal to 2 and storing in another list  
        List<int> numbers = new() { 1, 2 , 3, 4 };
        var numbers_copy = numbers.Where(n => n >= 2);
         
        
        
        

        
    }
}