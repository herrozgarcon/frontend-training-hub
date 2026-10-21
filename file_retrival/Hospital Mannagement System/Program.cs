using Hospital_Mannagement_System.Services;

namespace Hospital_Mannagement_System;

class Program
{
    static void Main(string[] args)
    {
        doctorServices.RetriveDoctors();
        patientService.retrievePatients();
        //appointmentService.retriveAppointmentData();
        
        //patientService.AddPatient();
        //patientService.searchPatient();
        //patientService.updatePatient();
        patientService.displayallpatients();
        
        
    }
}