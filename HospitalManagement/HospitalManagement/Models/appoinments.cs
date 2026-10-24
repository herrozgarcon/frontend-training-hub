namespace Hospital_Mannagement_System.Models;

public class appoinments
{
    public enum status
    {
        scheduled,
        completed,
        cancelled,
    }

    private static int id = 1;
    public int AppoinmentId { get; set; }
    public string PatientId { get; set; } 
    public string DoctorId { get; set; }
    public string Reason { get; set; }
    public  DateOnly AppoinmentDate { get; set; }
    public  status Status { get; set; }
    
    public appoinments (string patientId, string doctorId, string reason, DateOnly appoinmentDate)
    {
        AppoinmentId = id++;
        AppoinmentDate = appoinmentDate;
        PatientId = patientId;
        DoctorId = doctorId;
        Reason = reason;
        Status = status.scheduled;
    }
}