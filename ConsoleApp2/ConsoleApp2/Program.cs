using System;

public class HelloWorld {
    public  static void Main()
    {
        
        int orderid=0;
        bool isvalidorderid = false;
        int counterfororderid = 1;
        while (!isvalidorderid || orderid <= 0)
        {
            if (counterfororderid == 1)
            {
                Console.Write("enter orderid");
            }
            else
            {
                Console.Write("invalid ! enter orderid");
            }
            isvalidorderid = int.TryParse(Console.ReadLine(), out orderid);
            counterfororderid++;
        }


        //customername 
        string name;
        while (true)
        {
            Console.Write("enter name");
            name = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                break;
            }
        }

        Console.WriteLine("enter product name ");
        string prodname = Console.ReadLine() ?? string.Empty;
        while (string.IsNullOrWhiteSpace(prodname))
        {
            Console.Write("invalid enter product name");
            prodname = Console.ReadLine() ?? string.Empty;
        }
        
        
        
        //quantity
        int quantity=0;
        bool isvalidquantity = false;
        int counterforquantity = 1;
        while (!isvalidquantity || quantity <= 0)
        {
            if (counterforquantity == 1)
            {
                Console.Write("enter quantity");
            }
            else
            {
                Console.Write("invalid! enter quantity");
            }
            isvalidquantity = int.TryParse(Console.ReadLine(), out quantity);
            counterforquantity++;
        }
        
        
        //unitprice
        double unitprice=0;
        bool isvalidunitprice = false;
        int counterforunitprice = 1;
        while (!isvalidunitprice || unitprice <= 0)
        {
            if (counterforunitprice == 1)
            {
                Console.Write("enter unitprice");
            }
            else
            {
                Console.Write("invalid !enter unitprice");
            }
            isvalidunitprice = double.TryParse(Console.ReadLine(), out unitprice);
            counterforunitprice++;
        }
        
        //calculating subtotal
        
        double price=0;
        double qty = (double)quantity;
        price = qty * unitprice;
        
        // Order Classification
        string orderclassification;
        if (price < 1000 )
        {
            orderclassification = "small order";
        }
        else if (price <= 5000 && price >= 1000)
        {
            orderclassification = "medium order";
        }
        else if (price <= 10000 && price >= 5000)
        {
            orderclassification = "large order";
        }
        else
        {   
            orderclassification = "big order";
        }
        
        //displaying 
        
        Console.Write("-----order summary-----\n"+
                      $"orderID:{orderid}\n" +
                      $"customername:{name}\n" +
                      $"Product Name:{prodname}\n" +
                      $"quantiy;{quantity}\n" +
                      $"unit price:{unitprice}\n" +
                      $"subtotal:{price}\n" +
                      $"order classification:{orderclassification}\n");
        
        
        
        

    }
}
