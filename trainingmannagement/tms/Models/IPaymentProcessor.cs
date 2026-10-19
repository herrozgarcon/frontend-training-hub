namespace tms.Models;

public interface IPaymentProcessor
{
    bool ProcessPayment(int enrollmentId);
    bool ProcessPayment(int enrollmentId, decimal amount);
    bool ProcessPayment(int enrollmentId, decimal amount, bool? simulateSuccess);
}