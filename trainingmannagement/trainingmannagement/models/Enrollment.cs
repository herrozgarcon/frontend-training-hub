namespace trainingmannagement.models;

public class Enrollment
{
    static int inc = 1;

    public int EnrollmentId { get; set; }

    public string Learnerid{get;set;}
    public string Coursecode{get;set;}
    public DateOnly EnrollmentDate{get;set;}
    public decimal BaseFee{get;set;}
    public decimal Discount{get;set;}
    public decimal Finalfees{get;set;}
    public string Enrolementstatus{get;set;}
    
    public Enrollment(string learnerid,string coursecode,DateOnly enrollmentDate,decimal baseFee,decimal discount,decimal finalfees,string enrolementstatus)
    {
        EnrollmentId = inc;
        Learnerid = learnerid;
        Coursecode = coursecode;
        EnrollmentDate = enrollmentDate;
        BaseFee = baseFee;
        Discount = discount;
        Finalfees = finalfees;
        Enrolementstatus = enrolementstatus;
        inc++;

    }

    public Enrollment()
    {
        
    }
    
    
}