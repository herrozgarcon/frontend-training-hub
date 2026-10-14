using trainingmannagement.models;
namespace trainingmannagement;

class Program
{
    static List<courses> coursesList = new List<courses>();
    static Dictionary<string,learner> learnerDict = new Dictionary<string,learner>();
    static private List<Enrollment> _enrollments = new List<Enrollment>();
    public static void Dispalaycourses()
    {
        
        for (int i = 0; i < coursesList.Count; i++)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"course code: {coursesList[i].Coursecode}");
            Console.WriteLine($"Title: {coursesList[i].Title}");
            Console.WriteLine($"Fees: {coursesList[i].Fees}");
            Console.WriteLine($"Durration days: {coursesList[i].Durrationdays}");
            Console.WriteLine($"Total seats: {coursesList[i].Totalseats}");
            Console.WriteLine($"Enroled count: {coursesList[i].EnrolledCount}");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"available seats: {coursesList[i].Totalseats-coursesList[i].EnrolledCount}");
            Console.WriteLine("---------------------------");
            
        }

    }
    
    public  static void Searchcourse()
    {
        bool courseavailablityFlag=false;
        Console.Write("Search by course code:"); 
        string courseCode = Console.ReadLine();
        for (int i = 0; i < coursesList.Count; i++)
        {
            if ((coursesList[i].Coursecode == courseCode) &&  (coursesList[i].Totalseats > coursesList[i].EnrolledCount))
            {
                courseavailablityFlag = true;
                break;
            }
        }

        if (courseavailablityFlag)
        {
            Console.WriteLine("course available");
        }
        else
        {
            Console.WriteLine("course not available");
        }
        
    }

    public static void addlearner()
    {
        Console.WriteLine("enter learner id");
        string learnerId =  Console.ReadLine();
        while(string.IsNullOrWhiteSpace(learnerId))
        {
            Console.WriteLine("invalid learner id! enter learner id");
            learnerId = Console.ReadLine();
        }

        if (learnerDict.ContainsKey(learnerId))
        {
            Console.WriteLine("learner already exists");
            return;
        }
        Console.WriteLine("enter learner name");
        string name =  Console.ReadLine();
        while(string.IsNullOrWhiteSpace(learnerId))
        {
            Console.WriteLine("invalid learner id! enter learner id");
            learnerId = Console.ReadLine();
        }
        Console.WriteLine("enter learner contactnumber");
        int contactnum = int.Parse(Console.ReadLine());
        Console.WriteLine("enter learner email");
        string  email =  Console.ReadLine();
        
        learner learner=new learner(learnerId,name,contactnum,email);
        learnerDict.Add(learnerId,learner);
    }

    public static void displaylearners()
    {
        foreach (var learner in learnerDict)
        {
            Console.WriteLine($"{learner.Key}:{learner.Value}");
        }
    }

    public static void searchlearners(string id)
    {
        if (learnerDict.ContainsKey(id))
        {
            Console.WriteLine("learner found");
            return;
        }
        Console.WriteLine("learner not found");
    }

    public static void createenrolment()
    {
        Console.WriteLine("enter the course you want to enroll");
        string learnerid = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(learnerid))
        {
            Console.WriteLine("invalid course code");
            learnerid = Console.ReadLine();
        }
        
        Console.WriteLine("enter the course you want to enroll");
        string courseCode = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(courseCode))
        {
            Console.WriteLine("invalid course code");
            courseCode = Console.ReadLine();
        }
        
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        
        //finding base fees of the particular course
        decimal basefees=0;
        for (int i = 0; i < coursesList.Count; i++)
        {
            if (coursesList[i].Coursecode == courseCode)
            {
                
                basefees = coursesList[i].Fees;
                return;
            }
            Console.WriteLine("invalid course code entered");
        }

        decimal discount = 20;
        
        decimal finalfees = basefees-discount;
        
        string enrolementstatus="active";
        
        Enrollment enrollment=new Enrollment(learnerid,courseCode,today,basefees,discount,finalfees,enrolementstatus);
        _enrollments.Add(enrollment);
    }

    public static void cancelenrolement(string learnerid)
    {
        foreach (var enrollment in _enrollments)
        {
            if (enrollment.Learnerid == learnerid)
            {
                enrollment.Enrolementstatus="cancelled";
                return;
            }
        }
    }
    static void Main(string[] args)
    {
        courses course1 = new courses("cs23324","python",100,60,60,10);
        courses course2 = new courses("cs234","java",100,60,60,10);
        courses course3 = new courses("cs454","oops",1000,60,60,50);
        courses course4 = new courses("cs876","networks",2000,80,60,5);
        coursesList.Add(course1);
        coursesList.Add(course2);
        coursesList.Add(course3);
        coursesList.Add(course4);

        //menu driven 
        Console.Write("-----------------------\n" +
                      "1--->addlearner\n" +
                      "2--->dispaly courses\n" +
                      "3--->display learners\n" +
                      "4--->enroll\n" +
                      "5--->exit\n" +
                      "6--->cancel enrolement\n" +
                      "-----------------------\n");
        bool flag=true;
        while (flag)
        {
        int choice=0;
        Console.Write("enter the choice");
        int.TryParse(Console.ReadLine(), out choice);


            switch (choice)
            {
                case 1:
                    addlearner();
                    break;
                case 2:
                    Dispalaycourses();
                    break;
                case 3:
                    displaylearners();
                    break;
                case 4:
                    createenrolment();
                    break;
                case 5:
                    flag=false;
                    break;
            
            }

        }
        
    }
}