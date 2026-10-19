namespace tms.Models;

public class OnlineSession : CourseSession
{
    public OnlineSession(string courseId, DateTime coursestartDate)
        : base(courseId, coursestartDate)
    {
    }

    public override decimal CalculateSessionCharge()
    {
        return 200m;
    }
}