namespace Hospital_Mannagement_System.Models;

public class patients
{
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public int PatientAge { get; set; }
    public int PatientPhno{get; set;}

    public patients()
    {
        
    }

    public patients(string patientId, string patientName, int patientAge, int patientPhno)
    {
        PatientId = patientId;
        PatientName = patientName;
        PatientAge = patientAge;
        PatientPhno = patientPhno;
    }
    
}