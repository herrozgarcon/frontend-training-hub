using Hospital_Mannagement_System.Models;

namespace Hospital_Mannagement_System.Services;

public class patientService
{
    public static List<patients>  patientlist=new List<patients>();

    public static void addpatientsToFile(patients patient)
    {
        patientlist.Add(patient);
        string path = "/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/patients.json";
        string json = System.Text.Json.JsonSerializer.Serialize(patientlist);
        File.WriteAllText(path, json);
    }

    public static void  syncPatient()
    {
        string path = "/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/patients.json";
        string json = System.Text.Json.JsonSerializer.Serialize(patientlist);
        File.WriteAllText(path, json);
    }
    public static void retrievePatients()
    {
        string path = "/Users/hrithik/hcl training/file_retrival/Hospital Mannagement System/Utilities/patients.json";

        string serializeddata = File.ReadAllText(path);
        patientlist=System.Text.Json.JsonSerializer.Deserialize<List<patients>>(serializeddata);
        

    }
    public static void AddPatient()
    {
        Console.WriteLine("Adding patient...");
        Console.WriteLine("enter patientID");
        string patientID = Console.ReadLine();
        while (string.IsNullOrEmpty(patientID))
        {
            Console.WriteLine("invalid input ! enter patientID");
            patientID = Console.ReadLine();
        }

        if (getPatientByid(patientID) != null)
        {
            Console.WriteLine("patient already exists with this patientID try another  ID to create a new patient");
            return;
        }
        
        Console.WriteLine("enter patient Name");
        string patientName = Console.ReadLine();
        while (string.IsNullOrEmpty(patientName))
        {
            Console.WriteLine("invalid input ! enter patientID");
            patientName = Console.ReadLine();
        }
        
        Console.WriteLine("enter patient Age");
        int.TryParse(Console.ReadLine(), out int patientAge);
        while (patientAge < 0)
        {
            Console.WriteLine("invalid input ! enter patientID");
            int.TryParse(Console.ReadLine(),out patientAge);
        }
       
        Console.WriteLine("enter patient phone number");
        int.TryParse(Console.ReadLine(), out int patientphno);
        while (patientphno < 0)
        {
            Console.WriteLine("invalid input ! enter patientID");
            int.TryParse(Console.ReadLine(),out patientphno);
        }
        
        patients patient = new patients(patientID, patientName, patientAge, patientphno);
        addpatientsToFile(patient);
        retrievePatients();
    }

    public static void displayallpatients()
    {
        Console.WriteLine(" ----------------- patient list --------------------");
        foreach (patients patient in patientlist)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"patient id : {patient.PatientId}\n" +
                              $"patient name : {patient.PatientName}\n" +
                              $"patient age: {patient.PatientAge}\n" +
                              $"patient phn no : {patient.PatientPhno}");
            Console.WriteLine("-------------------------------------------------");

        }
    }


    public static void searchPatient()
    {
        Console.WriteLine("enter patientID or patient Name");
        string searchtext = Console.ReadLine();
        while (string.IsNullOrEmpty(searchtext))
        {
            Console.WriteLine("invalid input ! enter patientID or patient name");
            searchtext = Console.ReadLine();
        }

        foreach (patients patient in patientlist)
        {
            if (patient.PatientId == searchtext || patient.PatientName == searchtext)
            {
                Console.WriteLine("patient found ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"patient id : {patient.PatientId}\n" +
                                  $"patient name : {patient.PatientName}\n" +
                                  $"patient age: {patient.PatientAge}\n" +
                                  $"patient phn no : {patient.PatientPhno}");
                Console.WriteLine("-------------------------------------------------");
                return;
            }
            
        }
        Console.WriteLine("patient  not found ");
    }
    
    public static void updatePatient()
    {
        
        Console.WriteLine("enter patientID or patient Name to update ");
        string searchtext = Console.ReadLine();
        while (string.IsNullOrEmpty(searchtext))
        {
            Console.WriteLine("invalid input ! enter patientID or patient name");
            searchtext = Console.ReadLine();
        }

        foreach (patients patient in patientlist)
        {
            if (patient.PatientId == searchtext || patient.PatientName == searchtext)
            {
                Console.WriteLine("enter the new patient name ");
                patient.PatientName = Console.ReadLine();
                while (string.IsNullOrEmpty(patient.PatientName))
                {
                    Console.WriteLine("invalid input !  patient name");
                    patient.PatientName = Console.ReadLine();
                }
                
                Console.WriteLine("enter the new patient age ");
                int.TryParse(Console.ReadLine(),out int patientAge);
                while (patientAge < 0)
                {
                    Console.WriteLine("invalid input !  patient age");
                    int.TryParse(Console.ReadLine(),out patientAge);
                }
                patient.PatientAge = patientAge;
                
                Console.WriteLine("enter the new patient phone number ");
                int.TryParse(Console.ReadLine(),out int patientPhno);
                patient.PatientPhno = patientPhno;
                
                Console.WriteLine("patient details updated");
                syncPatient();
                return;
            }
            Console.WriteLine("patient  not found ");
        }
        
    }
    
    public static void deletePatient()
    {
        Console.WriteLine("enter patientID or patient Name");
        string searchtext = Console.ReadLine();
        while (string.IsNullOrEmpty(searchtext))
        {
            Console.WriteLine("invalid input ! enter patientID or patient name");
            searchtext = Console.ReadLine();
        }
        foreach (patients patient in patientlist)
            {
                if (patient.PatientId == searchtext || patient.PatientName == searchtext)
                {
                    Console.WriteLine("ensure to delete the patient say (Y/N)  ");
                    string cnf= Console.ReadLine();
                    if (cnf.ToUpper() == "Y")
                    {
                        patientlist.Remove(patient);
                        retrievePatients();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("deletion revoked");
                        return;
                    }
                }
                Console.WriteLine("patient  not found ");
                
            }
    }

    public static patients? getPatientByid(string patientId)
    {
        foreach (var patient in patientlist)
        {
            if (patient.PatientId == patientId)
            {
                return patient;
            }
        }
        return null;
    }
    
    
    
   
}