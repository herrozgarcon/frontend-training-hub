namespace trainingmannagement.models;

public class learner
{
    public string Learnerid { get; set; }
    public string Name { get; set; }
    public int Contactnumber { get; set; }
    public string Email { get; set; }

    public learner(string learnerid, string name, int contactnumber, string email)
    {
        Learnerid=learnerid;
        Name=name;
        Contactnumber=contactnumber;
        Email=email;
    }

    public learner()
    {
        
    }
    
}