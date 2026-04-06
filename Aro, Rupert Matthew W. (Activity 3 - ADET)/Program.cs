using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Welcome to PUP Grade Calculator! ===\n");

        // MIDTERM RAW SCORE INPUTS
        Console.WriteLine("MIDTERM");
        double totalCSMid = GetValidInput("Enter total possible score for Class Standing: ", 1, double.MaxValue);
        double obtainedCSMid = GetValidInput($"Enter obtained score for Class Standing (0 - {totalCSMid}): ", 0, totalCSMid);

        double totalExamMid = GetValidInput("Enter total possible score for Exam/Project: ", 1, double.MaxValue);
        double obtainedExamMid = GetValidInput($"Enter obtained score for Exam/Project (0 - {totalExamMid}): ", 0, totalExamMid);

        // MIDTERM CONVERSION TO 70/30
        double midtermCS = (obtainedCSMid / totalCSMid) * 70;
        double midtermExam = (obtainedExamMid / totalExamMid) * 30;

        // FINAL TERM RAW SCORE INPUTS
        Console.WriteLine("\nFINAL TERM");
        double totalCSFin = GetValidInput("Enter total possible score for Class Standing: ", 1, double.MaxValue);
        double obtainedCSFin = GetValidInput($"Enter obtained score for Class Standing (0 - {totalCSFin}): ", 0, totalCSFin);

        double totalExamFin = GetValidInput("Enter total possible score for Exam/Project: ", 1, double.MaxValue);
        double obtainedExamFin = GetValidInput($"Enter obtained score for Exam/Project (0 - {totalExamFin}): ", 0, totalExamFin);

        // FINAL TERM CONVERSION TO 70/30
        double finalCS = (obtainedCSFin / totalCSFin) * 70;
        double finalExam = (obtainedExamFin / totalExamFin) * 30;

        // COMPUTATION
        double midtermGrade = midtermCS + midtermExam;
        double finalGrade = finalCS + finalExam;

        // CONVERT TO EQUIVALENTS
        string midtermEq = GetGradeEquivalent(midtermGrade);
        string finalEq = GetGradeEquivalent(finalGrade);

        double midtermEqNum = Convert.ToDouble(midtermEq);
        double finalEqNum = Convert.ToDouble(finalEq);

        // OVERALL FINAL GRADE
        double overallEqNum = ComputeFinalEquivalentPUP(midtermEqNum, finalEqNum);
        string overallEq = overallEqNum.ToString("0.00");

        // DESCRIPTIONS
        string midtermDesc = GetDescription(midtermGrade);
        string finalDesc = GetDescription(finalGrade);
        string overallDesc = GetDescriptionFromEquivalent(overallEqNum);

        // OUTPUT
        Console.WriteLine("\n=== RESULTS ===");

        Console.WriteLine("\nMIDTERM GRADE");
        Console.WriteLine($"Grade: {midtermGrade:F2}");
        Console.WriteLine($"Equivalent: {midtermEq}");
        Console.WriteLine($"Description: {midtermDesc}");

        Console.WriteLine("\nFINAL TERM GRADE");
        Console.WriteLine($"Grade: {finalGrade:F2}");
        Console.WriteLine($"Equivalent: {finalEq}");
        Console.WriteLine($"Description: {finalDesc}");

        Console.WriteLine("\nOVERALL FINAL GRADE");
        Console.WriteLine($"Equivalent: {overallEq}");
        Console.WriteLine($"Description: {overallDesc}");
    }

    // INPUT VALIDATION
    static double GetValidInput(string message, double min, double max)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (!double.TryParse(input, out value))
            {
                Console.WriteLine("❌ Invalid input. Please enter a number.\n");
                continue;
            }

            if (value < min || value > max)
            {
                Console.WriteLine($"❌ Input must be between {min} and {max}.\n");
                continue;
            }

            return value;
        }
    }

    // PERCENTAGE TO GRADE EQUIVALENT
    static string GetGradeEquivalent(double grade)
    {
        if (grade >= 97) return "1.0";
        else if (grade >= 94) return "1.25";
        else if (grade >= 91) return "1.5";
        else if (grade >= 88) return "1.75";
        else if (grade >= 85) return "2.0";
        else if (grade >= 82) return "2.25";
        else if (grade >= 79) return "2.5";
        else if (grade >= 76) return "2.75";
        else if (grade >= 75) return "3.0";
        else return "5.0";
    }

    // DESCRIPTION (FROM PERCENTAGE)
    static string GetDescription(double grade)
    {
        if (grade >= 94) return "Excellent";
        else if (grade >= 88) return "Very Good";
        else if (grade >= 82) return "Good";
        else if (grade >= 76) return "Satisfactory";
        else if (grade >= 75) return "Passing";
        else return "Failure";
    }

    // OVERALL FINAL GRADE EQUIVALENT RULE
    static double ComputeFinalEquivalentPUP(double mid, double fin)
    {
        double[] grades = { 1.0, 1.25, 1.5, 1.75, 2.0, 2.25, 2.5, 2.75, 3.0, 5.0 };

        double avg = (mid + fin) / 2;

        // FIND THE CLOSEST VALID GRADE TO THE AVERAGE
        double closest = grades[0];
        double minDiff = Math.Abs(avg - grades[0]);

        foreach (double g in grades)
        {
            double diff = Math.Abs(avg - g);
            if (diff < minDiff)
            {
                minDiff = diff;
                closest = g;
            }
            else if (diff == minDiff)
            {
                // CHOOSE THE BETTER/HIGHER GRADE
                closest = Math.Min(closest, g);
            }
        }

        return closest;
    }

    // DESCRIPTION (FROM EQUIVALENT)
    static string GetDescriptionFromEquivalent(double grade)
    {
        if (grade <= 1.25) return "Excellent";
        else if (grade <= 1.75) return "Very Good";
        else if (grade <= 2.25) return "Good";
        else if (grade <= 2.75) return "Satisfactory";
        else if (grade == 3.0) return "Passing";
        else return "Failure";
    }
}

// THIS COMMENT IS FOR PULL DEMONSTRATION
