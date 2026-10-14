using tms.Models;
using tms.Services;
namespace tms;

class Program
{
    static void Main(string[] args)
    {
        courseservices.AddCourses();
        enrolementservices.AddEnrollment();
        enrolementservices.displayEnrollments();
        
        
    }
}