using Core.Models;
using Core.Enums;
using Core.Exceptions;

namespace TaskEnumException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int no;
            int limit = 0;
            string choice;
            string classroomName;
            string studentName;
            string studentSurname;



            Classroom classroom = new Classroom();

            do
            {
                Console.WriteLine("Menu:1.Classroom yarat\n2.Student yarat\n3.Butun telebeleri ekranda goster" +
                "\n4.Secilmis sinifdeki telebeleri ekrana cixart\n5.Telebe sil");
                choice = Console.ReadLine();

                if (choice == "1")
                {

                    do
                    {
                        Console.WriteLine("Classroom adini daxil edin ");
                        classroomName = Console.ReadLine();
                    } while (!classroomName.CheckClassroomName());





                    Console.WriteLine("Classroom tipini secin:1.Frontend\n2.Backend");
                    byte classType = Convert.ToByte(Console.ReadLine());


                    Classroom classroom1 = new Classroom(classroomName, classType);

                    classroom.AddClassroom(classroom1);

                }



                else if (choice == "2")
                {
                    do
                    {
                        Console.WriteLine("Student adini daxil edin: ");
                        studentName = Console.ReadLine();
                    } while (!studentName.CheckName());

                    do
                    {
                        Console.WriteLine("Student soyadini daxil edin: ");
                        studentSurname = Console.ReadLine();
                    } while (!studentSurname.CheckSurname());

                    try
                    {
                        if (classroom.Classrooms.Length == 0)
                        {
                            throw new ClassroomNotFoundException("Classroom movcud deyil!");
                        }
                    }
                    catch (ClassroomNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                    classroom.ShowClassrooms();

                    Console.WriteLine("Student yuxaridaki qruplardan hansina elave olunacaq : (no daxil et)");
                    no = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(studentName, studentSurname);

                    classroom.AddStudent(no, student);


                }

                else if (choice == "3")
                {
                    classroom.ShowAllStudents();
                }
                 

                else if (choice == "4")
                {
                    classroom.ShowClassrooms();
                    Console.WriteLine(" Bu qruplar var");
                    Console.WriteLine(" Qrup secin :");
                    no = Convert.ToInt32(Console.ReadLine());

                    classroom.ShowStudentsForClass(no);
                }




                else if (choice == "5")
                {
                    
                    Console.WriteLine("Silinen telebenin id daxil et:");                 
                    no = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        classroom.Delete(no);
                    }
                          
                    catch(StudentNotException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            } while (true);


        }
    }
}


