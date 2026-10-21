using Hospital_Mannagement_System.Models;

namespace Hospital_Mannagement_System.Services;

public class appointmentService
{
    static List<appoinments>  appointmentsList=new List<appoinments>();


    public static void addAppointmentToFile(appoinments appointment)
    {
        appointmentsList.Add(appointment);
        string path =
            "/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/appointments.json";
        string json =System.Text.Json.JsonSerializer.Serialize(appointmentsList);
        File.WriteAllText(path, json);
    }
    
    
    public static void retriveAppointmentData()
    {

        string path =
            "/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/appointments.json";
        string serializedData = File.ReadAllText(path);
        appointmentsList=System.Text.Json.JsonSerializer.Deserialize<List<appoinments>>(serializedData);
    }
    public static void createAppoinment()
    {
        bool valid = false;
        Console.WriteLine("----------------creating appoinment-----------");
        Console.WriteLine("enter patient id to create a new appoinment");
        string patientId = Console.ReadLine();
        while (string.IsNullOrEmpty(patientId))
        {
            Console.WriteLine("invalid input !enter patient id to create a new appoinment");
            patientId = Console.ReadLine();
        }

        patients selected_patient = patientService.getPatientByid(patientId);
        if ( selected_patient!= null)
        {
            
               valid = true; 
        }
        else
        {
            valid = false;
            Console.WriteLine("patient not found");
            return;
        }
        Console.WriteLine("enter doctor id to book a appoinment");
        string doctorId = Console.ReadLine();
        while (string.IsNullOrEmpty(doctorId))
        {
            Console.WriteLine("invalid input !enter doctor id to book a appoinment");
            doctorId = Console.ReadLine();
        }

        doctors doc = doctorServices.getDoctorByID(doctorId);
        if (doc == null)
        {
            valid = false;
            Console.WriteLine("doctor not found");
            return;
        }
        Console.WriteLine("enter reason to book a appoinment");
        string reason = Console.ReadLine();
        while (string.IsNullOrEmpty(reason))
        {
            Console.WriteLine("invalid input !enter reason to book a appoinment");
            reason = Console.ReadLine();
        }
        
        appoinments appointment=new appoinments(patientId, doctorId, reason);
        addAppointmentToFile(appointment);
        retriveAppointmentData();
    }
    
}