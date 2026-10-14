using tms.Models;

namespace tms.Services;

public class learnerservices
{
    static Dictionary<string,learners> learners=new Dictionary<string,learners>();

    public void createlearner()
    {
        
        
        Console.WriteLine("enter learner id");
        string learnerId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(learnerId))
        {
            Console.WriteLine("invalid!enter correct learner id");
            learnerId = Console.ReadLine();
        }

        if (learners.ContainsKey(learnerId))
        {
            Console.WriteLine("learner already exists");
            return;
        }
        
        Console.WriteLine("enter learner name");
        string learnername = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(learnername))
        {
            Console.WriteLine("invalid!enter correct learner name");
            learnername = Console.ReadLine();
        }
        
        int.TryParse(Console.ReadLine(), out int contactnumber);
        
        Console.WriteLine("enter email address");
        string email = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("invalid!enter correct learner name");
            email = Console.ReadLine();
        }
        learners learner1 = new learners(learnerId,learnername,contactnumber,email);
        learners.Add(learnerId,learner1);
    }

    public void displaylearners()
    {
        foreach (var learner in learners)
        {
            Console.WriteLine($"{learner.Key}: {learner.Value}");
        }
    }

    public void searchlearners()
    {
        Console.WriteLine("enter learner id");
        string learnerId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(learnerId))
        {
            Console.WriteLine("invalid!enter correct learner id");
            learnerId = Console.ReadLine();
        }

        if (learners.ContainsKey(learnerId))
        {
            Console.WriteLine("learner  exists");
            Console.WriteLine(learners[learnerId]);
            return;
        }
        Console.WriteLine("learner does not exist");
    }
    
    
}