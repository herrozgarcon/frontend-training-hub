namespace tms.Models;

public enum PaymentStatus
{
    Pending,
    Successful,
    Failed
}

public class Payment
{
    private static int _nextPaymentId = 1;

    public int PaymentId { get; set; }
    public int EnrollmentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }

    // Central in-memory history recording all payment attempts (both successful and failed)
    public static List<Payment> PaymentHistory { get; } = new List<Payment>();

    public Payment()
    {
        PaymentId = _nextPaymentId++;
        PaymentDate = DateTime.Now;
        Status = PaymentStatus.Pending;
    }

    public Payment(int enrollmentId, decimal amount, PaymentStatus status)
    {
        PaymentId = _nextPaymentId++;
        EnrollmentId = enrollmentId;
        Amount = amount;
        PaymentDate = DateTime.Now;
        Status = status;
    }

    public Payment(int paymentId, int enrollmentId, decimal amount, DateTime paymentDate, PaymentStatus status)
    {
        PaymentId = paymentId;
        EnrollmentId = enrollmentId;
        Amount = amount;
        PaymentDate = paymentDate;
        Status = status;
    }

    public static Payment RecordPayment(int enrollmentId, decimal amount, PaymentStatus status)
    {
        var payment = new Payment(enrollmentId, amount, status);
        PaymentHistory.Add(payment);
        return payment;
    }

    public static void DisplayPaymentHistory()
    {
        Console.WriteLine("\n============================ PAYMENT HISTORY ============================");
        if (PaymentHistory.Count == 0)
        {
            Console.WriteLine("No payment records found.");
        }
        else
        {
            Console.WriteLine(string.Format("{0,-12} | {1,-14} | {2,-12} | {3,-20} | {4,-12}", 
                "Payment ID", "Enrollment ID", "Amount (₹)", "Payment Date", "Status"));
            Console.WriteLine(new string('-', 73));
            foreach (var p in PaymentHistory)
            {
                Console.WriteLine(string.Format("{0,-12} | {1,-14} | {2,-12:F2} | {3,-20:yyyy-MM-dd HH:mm:ss} | {4,-12}",
                    p.PaymentId, p.EnrollmentId, p.Amount, p.PaymentDate, p.Status));
            }
        }
        Console.WriteLine("=========================================================================\n");
    }
}
