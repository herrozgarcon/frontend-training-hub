namespace tms.Models;

public class ClassroomSession : CourseSession
{
    public ClassroomSession(string courseId, DateTime coursestartDate)
        : base(courseId, coursestartDate)
    {
    }

    public override decimal CalculateSessionCharge()
    {
        return 800m;
    }
}