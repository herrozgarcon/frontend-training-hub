namespace tms.Models;

public class learners
{
    public string Learner_id { get; set; }
    public string Learner_name { get; set; }
    public int Contactno { get; set; }
    public string Email { get; set; }

    public learners(string learner_id, string learner_name, int contactno, string email)
    {
        Learner_id = learner_id;
        Learner_name = learner_name;
        Contactno = contactno;
        Email = email;
    }

    public learners()
    {
        
    }
}