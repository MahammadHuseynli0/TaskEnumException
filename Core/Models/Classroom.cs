using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Exceptions;

namespace Core.Models
{
    public class Classroom
    {
        private static int _id;
        public int Id { get; set; }
        public string Name { get; set; }

        public int Limit { get; set; }

        public Student[] students = new Student[] {};
        public Classroom[] Classrooms = new Classroom[] {};

        public Core.Enums.Type ClassType { get; set; }

        public Classroom()
        {
            
        }



        public Classroom(string classroomname, byte classType)
        {
            _id++;
            Id = _id;
            Name = classroomname;

            if (classType == 1)
            {
                ClassType = Enums.Type.Frontend;
                Limit = 15;

            }

            else if (classType == 2)
            {
                ClassType = Enums.Type.Frontend;
                Limit = 20;
            }


        }

        public void AddStudent(int no ,Student student)
        {
            bool ClassFound = false;
            for (int i = 0; i < Classrooms.Length; i++)
            {

                if (Classrooms[i].Id == no)
                {
                    ClassFound = true;
                    Array.Resize(ref Classrooms[i].students, Classrooms[i].students.Length + 1);
                    Classrooms[i].students[Classrooms[i].students.Length - 1] = student;
                }
            }
            
            if (ClassFound == false)
            {
                throw new ClassroomNotFoundException("Classroom tapilmadi!");
            }

            
        }

        public void AddClassroom(Classroom classroom)
        {
            Array.Resize(ref Classrooms, Classrooms.Length + 1);
            Classrooms[Classrooms.Length - 1] = classroom;
        }



        public void ShowClassrooms()
        {
            for (int i = 0; i < Classrooms.Length; i++)
            {
                Console.WriteLine($"{Classrooms[i].Id} {Classrooms[i].Name}");
            }
        }

        public void ShowAllStudents()
        {
            for (int i = 0; i < Classrooms.Length; i++)
            {
                Console.WriteLine($"{Classrooms[i].Id} {Classrooms[i].Name} - : \n");


                for (int j = 0; j < Classrooms[i].students.Length; j++)
                {
                    Console.WriteLine($"{Classrooms[i].students[j].Id}    {Classrooms[i].students[j].Name}     {Classrooms[i].students[j].Surname}");
                }
            }
        }



        public void ShowStudentsForClass(int no)
        {
            for (int i = 0; i < Classrooms.Length; i++)
            {
                if (Classrooms[i].Id == no)
                {
                    Console.WriteLine($"Classroomdaki telebeler:");
                   
                    for (int j = 0; j < Classrooms[i].students.Length; j++)
                    {
                        Console.WriteLine($"{Classrooms[i].students[j].Id}    {Classrooms[i].students[j].Name}     {Classrooms[i].students[j].Surname}");
                    }
                }
            }        
        }




        public Student FindId(int id)
        {
            
            for(int i = 0; i < students.Length; i++)
            {
                if (students[i].Id == id)
                {
                    return students[i];
                }
            }
            return null;
        }
         
        public void Delete(int no)
        {
            bool check = false;

            Student[] deletestudents = new Student[] { };

            for(int i = 0;i < students.Length;i++)
            {

                if (students[i].Id == no)
                {
                    check = true;
                }

                else if (students[i].Id! == no)
                {
                    Array.Resize(ref deletestudents, deletestudents.Length+1);
                    deletestudents[deletestudents.Length-1] = students[i];
                }
            }
            students = deletestudents;

            if (check == false)
            {
                throw new StudentNotException("Bele telebe yoxdur!");
            }



        }




























    }
}
