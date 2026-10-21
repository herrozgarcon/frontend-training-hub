using System.Text.Json;
using Hospital_Mannagement_System.Models;

namespace Hospital_Mannagement_System.Services;

public class doctorServices
{
    static List<doctors>  doctorsList=new List<doctors>();

    public doctorServices()
    {
        RetriveDoctors();
    }
    
    //file adding doctors
    public static void addDoctorTofile(doctors doctor)
    {
        doctorsList.Add(doctor);
        string json=System.Text.Json.JsonSerializer.Serialize(doctorsList);
        string filepath="/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/doctors.json";
        File.WriteAllText(filepath, json);
    }
    
    //sync doctors list 
    public static void docSync()
    {
        string json=System.Text.Json.JsonSerializer.Serialize(doctorsList);
        string filepath="/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/doctors.json";
        File.WriteAllText(filepath, json);
    }
    
    
    //retriving data (doctors)
    public static void RetriveDoctors()
    {
        string filepath="/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/doctors.json";
        string serialized_data = File.ReadAllText(filepath);
        doctorsList = System.Text.Json.JsonSerializer.Deserialize<List<doctors>>(serialized_data);
    }

    public static void adddoctor()
    {
        Console.WriteLine("---------Adding doctor------------");
        //entering doctor id
        Console.WriteLine("Enter doctor id to create a new doctor");
        string doctor_id = Console.ReadLine();
        while (string.IsNullOrEmpty(doctor_id))
        {
            Console.WriteLine("invalid or empty space! Enter doctor id to create a new doctor");
            doctor_id = Console.ReadLine();
        }
        
        //entering doctor name
        Console.WriteLine("Enter doctor name to create a new doctor");
        string doctor_name = Console.ReadLine();
        while (string.IsNullOrEmpty(doctor_name))
        {
            Console.WriteLine("invalid or empty space! Enter doctor id to create a new doctor");
            doctor_name = Console.ReadLine();
        }
        
        //entering specialty
        Console.WriteLine("Enter doctor specilization to create a new doctor");
        string specilization = Console.ReadLine();
        while (string.IsNullOrEmpty(specilization))
        {
            Console.WriteLine("invalid or empty space! Enter specilization to create a new doctor");
            specilization = Console.ReadLine();
        }
        
        //fees of the doctor
        Console.WriteLine("Enter consultation Fee to create a new doctor");
        int.TryParse(Console.ReadLine(),out int consultation_fee);
        while (consultation_fee < 0)
        {
            Console.WriteLine("invalid or  consultation fee cannot be negative");
            int.TryParse(Console.ReadLine(),out  consultation_fee);
        }
        doctors doc=new doctors(doctor_id, doctor_name, specilization, consultation_fee);
        
        //syncing new doctors
        addDoctorTofile(doc);
        RetriveDoctors();
        
    }
    
    //updating doctor details
    public static void updateDoctor()
    {
        Console.WriteLine("update doctor ");
        Console.WriteLine("Enter doctor id to update a  doctor details");
        string doctor_id = Console.ReadLine();
        while (string.IsNullOrEmpty(doctor_id))
        {
            Console.WriteLine("invalid input ! Enter doctor id to update a  doctor details");
            doctor_id = Console.ReadLine();
        }

        foreach (doctors doc in doctorsList)
        {
            if (doc.Doctor_id == doctor_id)
            {
                Console.WriteLine("enter new doctor name ");
                
                string doctor_name = Console.ReadLine();
                while (string.IsNullOrEmpty(doctor_name))
                {
                    Console.WriteLine("invalid or empty space! Enter doctor id to create a new doctor");
                    doctor_name = Console.ReadLine();
                }
                doc.Doctor_name = doctor_name;
                
                Console.WriteLine("enter new doctor specilization ");
                string doctor_specilization = Console.ReadLine();
                while (string.IsNullOrEmpty(doctor_specilization))
                {
                    Console.WriteLine("invalid or empty space! Enter doctor id to create a new doctor");
                    doctor_specilization = Console.ReadLine();
                }
                doc.Specilization = doctor_specilization;
                Console.WriteLine("Enter updated consultation Fee to create a new doctor");
                int.TryParse(Console.ReadLine(),out int consultation_fee);
                while (consultation_fee < 0)
                {
                    Console.WriteLine("invalid or  consultation fee cannot be negative");
                    int.TryParse(Console.ReadLine(),out  consultation_fee);
                }
                doc.ConsultationFee = consultation_fee;
                docSync();
                RetriveDoctors();
                
            }

        }
    }

    //display doctors
    public static void displayDoctors()
    {
        Console.WriteLine("list of doctors");
        foreach (var doc in doctorsList)
        {
            
            
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"doctor id : {doc.Doctor_id} -------> doctor name: {doc.Doctor_name}");
            Console.WriteLine($"specilization : {doc.Specilization}");
            Console.WriteLine($"consultation fee: {doc.ConsultationFee}");
            Console.WriteLine("--------------------------------------------------------------------");

        }
    }
    
    //searching doctors
    public static void searchDoctors()
    {
        Console.WriteLine("Enter doctor id or doctor name or specilization to search");
        string searchtext = Console.ReadLine();
        while (string.IsNullOrEmpty(searchtext))
        {
            Console.WriteLine("invalid input ! Enter doctor id or doctor name or specilization  to search");
            searchtext = Console.ReadLine();
        }
        bool docfound = false;
        foreach (var doc in doctorsList)
        {
            if (doc.Doctor_id == searchtext || doc.Doctor_name == searchtext || doc.Specilization == searchtext)
            {
                docfound = true;
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"doctor id : {doc.Doctor_id} -------> doctor name: {doc.Doctor_name}");
                Console.WriteLine($"specilization : {doc.Specilization}");
                Console.WriteLine($"consultation fee: {doc.ConsultationFee}");
                Console.WriteLine("--------------------------------------------------------------------");
            }
        }

        if (!docfound)
        {
            Console.WriteLine("Doctor not found");
        }
        
    }

    public static doctors getDoctorByID(string doctor_id)
    {
        foreach (var doc in doctorsList)
        {
            if (doc.Doctor_id == doctor_id)
            {
                return doc;
            }
        }
        return null;
    }
    
    
    
    


}