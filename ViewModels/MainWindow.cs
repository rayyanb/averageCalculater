using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using averageCalculater.Model;

namespace averageCalculater
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Student> students;
        private string selectedStudent;
        private string average;
        private List<Courses> includedCourses;

        public List<Courses> IncludedCourses
        {
            get { return includedCourses; }
            set
            {
                includedCourses = value;
                OnPropertyChanged(nameof(IncludedCourses));
            }
        }
        public string SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                CalculateAverage();
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public string Average
        {
            get { return average; }
            set
            {
                average = value;
                OnPropertyChanged(nameof(Average));
            }
        }

        public List<string> StudentNames { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            DataContext = this;
        }
        private void InitializeData()
        {
            // Create a list of courses for each student
            students = new List<Student>
            {
                new Student
                {
                    Id = "1",
                    First_name = "John",
                    Last_name = "Doe",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "1", Course_name = "Calculus", Course_points = 4, Score = 90 },
                        new Courses { Id = "2", Course_name = "Physics", Course_points = 4, Score = 70 },
                        new Courses { Id = "3", Course_name = "Operating Systems", Course_points = 2, Score = 100 },
                        new Courses { Id = "4", Course_name = "Programming", Course_points = 2, Score = 80 },
                        new Courses { Id = "5", Course_name = "OOP", Course_points = 2, Score = 70 },
                    }
                },
                new Student
                {
                    Id = "2",
                    First_name = "Jane",
                    Last_name = "Smith",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "6", Course_name = "Chemistry", Course_points = 4, Score = 85 },
                        new Courses { Id = "7", Course_name = "Biology", Course_points = 6, Score = 75 },
                        new Courses { Id = "8", Course_name = "English Literature", Course_points = 3, Score = 90 },
                        new Courses { Id = "9", Course_name = "History", Course_points = 3, Score = 80 },
                        new Courses { Id = "10", Course_name = "Geography", Course_points = 2, Score = 70 },
                    }
                },
                new Student
                {
                    Id = "3",
                    First_name = "Michael",
                    Last_name = "Johnson",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "11", Course_name = "Mathematics", Course_points = 4, Score = 95 },
                        new Courses { Id = "12", Course_name = "Computer Science", Course_points = 4, Score = 85 },
                        new Courses { Id = "14", Course_name = "Physics", Course_points = 2, Score = 70 },
                        new Courses { Id = "13", Course_name = "English", Course_points = 2, Score = 80 },
                        new Courses { Id = "15", Course_name = "Chemistry", Course_points = 2, Score = 75 },
                    }
                },
                new Student
                {
                    Id = "4",
                    First_name = "Emily",
                    Last_name = "Wilson",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "16", Course_name = "History", Course_points = 3, Score = 88 },
                        new Courses { Id = "17", Course_name = "Geography", Course_points = 3, Score = 75 },
                        new Courses { Id = "18", Course_name = "Economics", Course_points = 3, Score = 82 },
                        new Courses { Id = "19", Course_name = "Biology", Course_points = 2, Score = 93 },
                        new Courses { Id = "20", Course_name = "English", Course_points = 2, Score = 85 },
                    }
                },
                new Student
                {
                    Id = "5",
                    First_name = "Daniel",
                    Last_name = "Williams",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "21", Course_name = "Computer Science", Course_points = 4, Score = 90 },
                        new Courses { Id = "22", Course_name = "Mathematics", Course_points = 4, Score = 85 },
                        new Courses { Id = "23", Course_name = "Physics", Course_points =3, Score = 78 },
                        new Courses { Id = "24", Course_name = "Chemistry", Course_points = 2, Score = 80 },
                        new Courses { Id = "25", Course_name = "Biology", Course_points = 2, Score = 72 },
                    }
                },
                new Student
                {
                    Id = "6",
                    First_name = "Olivia",
                    Last_name = "Anderson",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "26", Course_name = "English Literature", Course_points = 4, Score = 92 },
                        new Courses { Id = "27", Course_name = "History", Course_points = 3, Score = 78 },
                        new Courses { Id = "28", Course_name = "Geography", Course_points = 3, Score = 82 },
                        new Courses { Id = "29", Course_name = "Mathematics", Course_points = 2, Score = 85 },
                        new Courses { Id = "30", Course_name = "Chemistry", Course_points = 2, Score = 76 },
                    }
                },
                new Student
                {
                    Id = "7",
                    First_name = "David",
                    Last_name = "Thomas",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "31", Course_name = "Physics", Course_points = 4, Score = 88 },
                        new Courses { Id = "32", Course_name = "Computer Science", Course_points = 4, Score = 72 },
                        new Courses { Id = "33", Course_name = "English", Course_points = 3, Score = 76 },
                        new Courses { Id = "34", Course_name = "Biology", Course_points = 4, Score = 84 },
                        new Courses { Id = "35", Course_name = "History", Course_points = 2, Score = 82 },
                    }
                },
                new Student
                {
                    Id = "8",
                    First_name = "Sophia",
                    Last_name = "Brown",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "36", Course_name = "Chemistry", Course_points = 4, Score = 90 },
                        new Courses { Id = "37", Course_name = "Mathematics", Course_points = 3, Score = 86 },
                        new Courses { Id = "38", Course_name = "Physics", Course_points = 3, Score = 80 },
                        new Courses { Id = "39", Course_name = "Biology", Course_points = 2, Score = 78 },
                        new Courses { Id = "40", Course_name = "English", Course_points = 2, Score = 84 },
                        new Courses { Id = "41", Course_name = "Geography", Course_points = 2, Score = 88 },

                    }
                },
                new Student
                {
                    Id = "9",
                    First_name = "Jacob",
                    Last_name = "Martinez",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "41", Course_name = "Geography", Course_points = 4, Score = 88 },
                        new Courses { Id = "42", Course_name = "Computer Science", Course_points = 3, Score = 76 },
                        new Courses { Id = "43", Course_name = "English Literature", Course_points = 3, Score = 80 },
                        new Courses { Id = "44", Course_name = "History", Course_points = 2, Score = 74 },
                        new Courses { Id = "45", Course_name = "Mathematics", Course_points = 2, Score = 82 },
                    }
                },
                new Student
                {
                    Id = "10",
                    First_name = "Ava",
                    Last_name = "Garcia",
                    courses = new List<Courses>
                    {
                        new Courses { Id = "46", Course_name = "Biology", Course_points = 4, Score = 92 },
                        new Courses { Id = "47", Course_name = "Chemistry", Course_points = 4, Score = 86 },
                        new Courses { Id = "48", Course_name = "Physics", Course_points =4, Score = 80 },
                        new Courses { Id = "49", Course_name = "Mathematics", Course_points = 4, Score = 75 },
                        new Courses { Id = "50", Course_name = "English", Course_points = 2, Score = 82 },
                    }
                }
            };
            StudentNames = students.Select(s => s.First_name).ToList();
            

            // Set the students as the DataContext for the window
            DataContext = students;
        }


        private void CalculateAverage()
        {
            if (SelectedStudent == null)
            {
                Average = string.Empty;
                IncludedCourses = new List<Courses>();
                return;
            }

            Student selectedStudent = students.FirstOrDefault(s => s.First_name == SelectedStudent);
            if (selectedStudent == null)
            {
                Average = string.Empty;
                IncludedCourses = new List<Courses>();
                return;
            }

            List<Courses> studentCourses = selectedStudent.courses;
            if (studentCourses == null || studentCourses.Count == 0)
            {
                Average = string.Empty;
                IncludedCourses = new List<Courses>();
                return;
            }

            List<Courses> bestCourseCombination = new List<Courses>();
            double bestAverage = 0;

            // Generate all possible combinations of courses with replacements
            List<List<Courses>> courseCombinations = GetCombinations(studentCourses);

            // Calculate average for each combination and find the best average
            foreach (List<Courses> combination in courseCombinations)
            {
                double sumScores = combination.Sum(c => c.Score*c.Course_points);
                double average = sumScores / combination.Sum(c=>c.Course_points);

                if (average > bestAverage)
                {
                    bestAverage = average;
                    bestCourseCombination = new List<Courses>(combination);
                }
            }

            IncludedCourses = bestCourseCombination;
            Average = bestAverage.ToString("F2");
        }

       
     
        public  List<List<Courses>> GetCombinations(IEnumerable<Courses> objects)
        {
            List<List<Courses>> result = new List<List<Courses>>();

            var array = objects.ToArray();
            var n = array.Length;

            for (var i = 0; i < (1 << n); i++)
            {
                List<Courses> combination = new List<Courses>();

                for (var j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        combination.Add(array[j]);
                    }
                }

                if (combination.Sum(obj => obj.Course_points) == 10)
                {
                    result.Add(combination);
                }
            }

            return result;
        }
        


        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}


