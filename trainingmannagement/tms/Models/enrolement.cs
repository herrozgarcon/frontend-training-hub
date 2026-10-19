namespace tms.Models;

public class Enrollment
{
    private static int nextId = 1;

    public int EnrollmentId { get; private set; }
    public string LearnerId { get; set; }
    public string CourseCode { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public decimal BaseFee { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalFee { get; set; }
    public string Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public Enrollment(string learnerId, string courseCode,
        decimal baseFee, decimal discountAmount, decimal finalFee)
    {
        EnrollmentId = nextId++;
        LearnerId = learnerId;
        CourseCode = courseCode;
        BaseFee = baseFee;
        DiscountAmount = discountAmount;
        FinalFee = finalFee;
        EnrollmentDate = DateTime.Now;
        Status = "Active";
        PaymentStatus = PaymentStatus.Pending;
    }

    public Enrollment()
    {
        EnrollmentId = nextId++;
        EnrollmentDate = DateTime.Now;
        Status = "Active";
        PaymentStatus = PaymentStatus.Pending;
    }

    public void cancel()
    {
        Status = "Cancelled";
    }
}