using System.Globalization;
using System;
namespace LinqMasteryPractice;
//json practice 
public class Course
{
    public int CourseId{get;set;}
    public string CourseName { get; set; }
    
}
public class Student
{
    public int Id {get; set;}
    public int Age { get; set; }
    public string Name { get; set; }

    public List<Course> Course_list { get; set; }
    
    public Student(int id, int age, string name,List<Course> course_list)
    {
        Id = id;
        Age = age;
        Name = name;
        Course_list=course_list;
    }
}
public class serialization
{

    static List<Student> student_list = new List<Student>();
    static List<Course> course_list = new List<Course>()
    {
        new Course{CourseId=1,CourseName="python"},
        new Course{CourseId=2,CourseName="ML"},
        new Course{CourseId=3,CourseName="AI"},
        new Course{CourseId=4,CourseName="Java"}
    };
    public static void method1()

    {
        Console.WriteLine("enter ur id");
        int.TryParse(Console.ReadLine(),out int id);
        Console.WriteLine("enter ur age");
        int.TryParse(Console.ReadLine(),out int age);
        Console.WriteLine("enter ur name");
        string? name=Console.ReadLine();
        Student s1 = new Student(id, age, name?? "",course_list);
        student_list.Add(s1);
        
        string json =System.Text.Json.JsonSerializer.Serialize(student_list);
        Console.WriteLine(json);


        // //DESERIALIZATION
        // Student? s2 =System.Text.Json.JsonSerializer.Deserialize<Student>(json);
        // Console.WriteLine($"deserialized data:- {s2.Age} {s2.Name} ");


    }

}

