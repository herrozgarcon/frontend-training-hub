namespace Hospital_Mannagement_System.Models;

public class doctors
{
    public string? Doctor_id { get; set; }
    public string? Doctor_name { get; set; }
    
    public string? Specilization { get; set; }
    
    public decimal? ConsultationFee{ get; set; }
    
    public doctors (string ? doctor_id, string? doctor_name, string? specilization, decimal? consultation_fee) 
    {
        Doctor_id = doctor_id;
        Doctor_name = doctor_name;
        Specilization = specilization;
        ConsultationFee= consultation_fee;
        
    }
    public doctors()
    {
        
    }
}