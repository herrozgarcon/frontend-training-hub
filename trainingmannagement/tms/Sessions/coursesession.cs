using tms.Services;

namespace tms.Models;

public abstract class CourseSession
{
    public string CourseId { get; set; }
    public DateTime CoursestartDate { get; set; }
    public int Durration { get; set; }
    public decimal? TotalFees { get; set; }

    protected CourseSession(string courseId, DateTime coursestartDate)
    {
        CourseId = courseId;
        CoursestartDate = coursestartDate;

        // Retrieve the selected course using CourseId
        courses sel_course = courseservices.GetCourseByCode(courseId);

        if (sel_course == null)
        {
            throw new ArgumentException("Course not found.");
        }

        // Automatically retrieve the course duration
        Durration = sel_course.Duration;

        // Calculate the session charge
        TotalFees = feecalculator.calculatefees(sel_course.Fees);
    }

    public abstract decimal CalculateSessionCharge();
}