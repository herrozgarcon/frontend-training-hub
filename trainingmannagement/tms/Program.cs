using tms.Models;
using tms.Services;
using tms.exception;
namespace tms;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================================");
        Console.WriteLine("        TRAINING MANAGEMENT SYSTEM (TMS) - PAYMENT MODULE        ");
        Console.WriteLine("=================================================================\n");

        // Run the automated demonstration of IPaymentProcessor and its implementations
        //RunPaymentSimulationDemo();

        // Interactive console menu
        while (true)
        {
           
            Console.WriteLine("\n------------- TMS MAIN MENU -------------");
            Console.WriteLine("1. Display All Courses");
            Console.WriteLine("2. Display All Enrollments");
            Console.WriteLine("3. Add New Enrollment");
            Console.WriteLine("4. add  learner");
            Console.WriteLine("5. Cancel Enrollment");
            Console.WriteLine("6. Pay via OnlinePaymentProcessor ");
            Console.WriteLine("7. Pay via ClassroomPaymentProcessor");
            Console.WriteLine("8. View Payment History");
            Console.WriteLine("9. Re-run Automated Payment Demo");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice (1-10): ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    try
                    {
                        courseservices.displayCourses();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    
                    break;

                case 2:
                    try
                {
                    enrolementservices.displayEnrollments();
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 3:
                    try
                {
                    enrolementservices.AddEnrollment();
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;
                case 4:
                    try
                {
                    learnerservices.createlearner();
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 5:
                    try
                {
                    enrolementservices.cancelEnrollment();
                }
                    catch (doesnotcontain e)
                {
                    Console.WriteLine(e);
                }
                    break;

                case 6:
                    try
                {
                    ProcessPaymentInteractive(useOnline: true);
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 7:
                    try
                {
                    ProcessPaymentInteractive(useOnline: false);
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 8:
                    try
                {
                    Payment.DisplayPaymentHistory();
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 9:
                    try
                {
                    RunPaymentSimulationDemo();
                }
                    catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    break;

                case 10:
                    Console.WriteLine("Exiting TMS. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Choice out of range. Please choose between 1 and 9.");
                    break;
            }
        }
    }

    /// <summary>
    /// Demonstrates all core requirements:
    /// 1. Implicit implementation (OnlinePaymentProcessor)
    /// 2. Explicit implementation (ClassroomPaymentProcessor)
    /// 3. Invoking both via IPaymentProcessor interface references
    /// 4. Simulating success and failure without real money
    /// 5. Updating enrollment payment status ONLY after successful payment
    /// 6. Rejecting payment for cancelled enrollments
    /// 7. Recording all payment attempts (both successful and failed) in Payment history
    /// </summary>
    private static void RunPaymentSimulationDemo()
    {
        Console.WriteLine("\n>>> RUNNING AUTOMATED PAYMENT SIMULATION DEMO <<<\n");

        // Seed courses if empty
        if (courseservices.CoursesList.Count == 0)
        {
            courseservices.CoursesList.Add(new courses("C101", "C# .NET Masterclass", 12000m, 30, 40, 2));
            courseservices.CoursesList.Add(new courses("C102", "Cloud Architecture", 18000m, 45, 30, 1));
        }

        // Seed enrollments for testing different payment scenarios
        if (enrolementservices.enrollments.Count == 0)
        {
            var en1 = new Enrollment("L-001", "C101", 12000m, 0m, 12000m); // For successful payment
            var en2 = new Enrollment("L-002", "C102", 18000m, 0m, 18000m); // For failed payment simulation
            var en3 = new Enrollment("L-003", "C101", 12000m, 0m, 12000m); // For cancelled enrollment rejection
            en3.cancel(); // Mark en3 as cancelled

            enrolementservices.enrollments.Add(en1);
            enrolementservices.enrollments.Add(en2);
            enrolementservices.enrollments.Add(en3);
        }

        Console.WriteLine("--- Initial Enrollments State ---");
        enrolementservices.displayEnrollments();

        // ----------------------------------------------------------------------------------------
        // REQUIREMENT: Invoke both implementations through interface references
        // ----------------------------------------------------------------------------------------
        // 1. OnlinePaymentProcessor uses IMPLICIT interface implementation.
        IPaymentProcessor onlineProcessor = new OnlinePaymentProcessor();

        // 2. ClassroomPaymentProcessor uses EXPLICIT interface implementation.
        // NOTE: ClassroomPaymentProcessor methods cannot be invoked directly on class instance:
        //   ClassroomPaymentProcessor cp = new ClassroomPaymentProcessor();
        //   cp.ProcessPayment(2); // COMPILE ERROR! Method not visible on class reference.
        // It MUST be invoked through an IPaymentProcessor interface reference:
        IPaymentProcessor classroomProcessor = new ClassroomPaymentProcessor();

        // ----------------------------------------------------------------------------------------
        // SCENARIO 1: Simulate SUCCESSFUL payment using OnlinePaymentProcessor (Implicit implementation)
        // ----------------------------------------------------------------------------------------
        Console.WriteLine("\n[DEMO SCENARIO 1] Successful payment simulation via OnlinePaymentProcessor (via IPaymentProcessor interface):");
        bool result1 = onlineProcessor.ProcessPayment(1, 12200m, simulateSuccess: true);
        Console.WriteLine($"Result returned: {result1}");

        // ----------------------------------------------------------------------------------------
        // SCENARIO 2: Simulate FAILED payment using ClassroomPaymentProcessor (Explicit implementation)
        // ----------------------------------------------------------------------------------------
        Console.WriteLine("\n[DEMO SCENARIO 2] Failed payment simulation via ClassroomPaymentProcessor (via IPaymentProcessor interface):");
        bool result2 = classroomProcessor.ProcessPayment(2, 18800m, simulateSuccess: false);
        Console.WriteLine($"Result returned: {result2}");

        // ----------------------------------------------------------------------------------------
        // SCENARIO 3: Reject payment for CANCELLED enrollment
        // ----------------------------------------------------------------------------------------
        Console.WriteLine("\n[DEMO SCENARIO 3] Reject payment attempt for CANCELLED enrollment #3:");
        bool result3 = onlineProcessor.ProcessPayment(3, 12200m, simulateSuccess: true);
        Console.WriteLine($"Result returned: {result3}");

        // ----------------------------------------------------------------------------------------
        // VERIFY: Enrollment payment status updated ONLY after successful payment
        // ----------------------------------------------------------------------------------------
        Console.WriteLine("\n--- Enrollments State After Payments ---");
        enrolementservices.displayEnrollments();

        // ----------------------------------------------------------------------------------------
        // VERIFY: Both successful and failed payment attempts recorded in Payment history
        // ----------------------------------------------------------------------------------------
        Payment.DisplayPaymentHistory();

        Console.WriteLine(">>> END OF AUTOMATED DEMO <<<\n");
    }

    private static void ProcessPaymentInteractive(bool useOnline)
    {
        Console.Write("\nEnter Enrollment ID to process payment: ");
        if (!int.TryParse(Console.ReadLine(), out int enrollmentId))
        {
            Console.WriteLine("Invalid Enrollment ID.");
            return;
        }

        // Invoke through IPaymentProcessor interface reference
        IPaymentProcessor processor = useOnline 
            ? new OnlinePaymentProcessor() 
            : new ClassroomPaymentProcessor();

        Console.WriteLine($"Invoking processor through {nameof(IPaymentProcessor)} reference...");
        processor.ProcessPayment(enrollmentId);
    }
}