string studentName = "Sophia Johnson";
string course1Name = "English 101";
string course2Name = "Algebra 101";
string course3Name = "Biology 101";
string course4Name = "Computer Science I";
string course5Name = "Psychology 101";

int course1Grade = 4;
int course2Grade = 3;
int course3Grade = 3;
int course4Grade = 3;
int course5Grade = 4;

int course1Credit = 3;
int course2Credit = 3;
int course3Credit = 4;
int course4Credit = 4;
int course5Credit = 3;

int hours = 0;
hours += course1Credit;
hours += course2Credit;
hours += course3Credit;
hours += course4Credit;
hours += course5Credit;
// Console.WriteLine(hours);

int courseAverageGrade = 0;
courseAverageGrade += course1Grade * course1Credit ;
courseAverageGrade += course2Grade * course2Credit ;
courseAverageGrade += course3Grade * course3Credit ;
courseAverageGrade += course4Grade * course4Credit ;
courseAverageGrade += course5Grade * course5Credit ;

decimal gradePointAverage = (decimal) courseAverageGrade/hours;


int leadingDigit = (int) gradePointAverage;
int firstDigit = (int) (gradePointAverage * 10) % 10;
int secondDigit = (int) (gradePointAverage * 100 ) % 10;


Console.WriteLine($"Student :  {studentName}");
Console.WriteLine("\n Course \t\t\tGrade \t\tCredit Hours");
Console.WriteLine($" {course1Name}\t\t\t{course1Grade}\t\t{course1Credit}");
Console.WriteLine($" {course2Name}\t\t\t{course2Grade}\t\t{course2Credit}");
Console.WriteLine($" {course3Name}\t\t\t{course3Grade}\t\t{course3Credit}");
Console.WriteLine($" {course4Name}\t\t{course4Grade}\t\t{course4Credit}");
Console.WriteLine($" {course5Name}\t\t\t{course5Grade}\t\t{course5Credit}");


Console.WriteLine($"\n Final GPA :\t\t\t{leadingDigit}.{firstDigit}{secondDigit}");