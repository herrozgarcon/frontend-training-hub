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
    public  DateTime AppoinmentDate { get; set; }
    public  status Status { get; set; }
    
    public appoinments (string patientId, string doctorId, string reason)
    {
        AppoinmentId = id++;
        AppoinmentDate = DateTime.Now;
        PatientId = patientId;
        DoctorId = doctorId;
        Reason = reason;
        Status = status.scheduled;
    }
}