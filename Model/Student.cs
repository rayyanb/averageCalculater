using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace averageCalculater.Model
{
    public class Student
    {
        public string Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public List<Courses> courses { get; set; }
        public List<Courses> GetBestCourses( int targetPoints)
        {
            int numCourses = courses.Count;

            // Create a 2D array to store the maximum average grade
            double[,] dp = new double[numCourses + 1, targetPoints + 1];

            // Initialize the array with 0 values
            for (int i = 0; i <= numCourses; i++)
            {
                for (int j = 0; j <= targetPoints; j++)
                {
                    dp[i, j] = 0;
                }
            }

            // Calculate the maximum average grade for each subproblem
            for (int i = 1; i <= numCourses; i++)
            {
                for (int j = courses[i - 1].Course_points; j <= targetPoints; j++)
                {
                    dp[i, j] = Math.Max(
                        dp[i - 1, j],
                        dp[i - 1, j - courses[i - 1].Course_points] + courses[i - 1].Score * courses[i - 1].Course_points
                    );
                }
            }

            // Find the courses that contribute to the maximum average grade
            List<Courses> bestCourses = new List<Courses>();
            int pointsRemaining = targetPoints;

            for (int i = numCourses; i > 0; i--)
            {
                if (dp[i, pointsRemaining] != dp[i - 1, pointsRemaining])
                {
                    bestCourses.Add(courses[i - 1]);
                    pointsRemaining -= courses[i - 1].Course_points;
                }
            }

            return bestCourses;
        }

        public double CalculateAverage(List<Courses> courses)
        {
            double sum = 0;
            int totalPoints = 0;

            foreach (Courses course in courses)
            {
                sum += course.Course_points * course.Score;
                totalPoints += course.Course_points;
            }

            return sum / totalPoints;
        }
    }
}

