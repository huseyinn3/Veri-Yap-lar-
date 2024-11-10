using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private StudentList studentList;

        public Form1()
        {
            InitializeComponent();
            studentList = new StudentList();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            int number = int.Parse(txtStudentNumber.Text);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            studentList.Add(new Student { Number = number, FirstName = firstName, LastName = lastName });
            DisplayStudents();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            int number = int.Parse(txtStudentNumber.Text);
            studentList.Delete(number);
            DisplayStudents();
        }

        private void btnSortStudents_Click(object sender, EventArgs e)
        {
            DisplayStudents();
        }

        private void btnPrintStudents_Click(object sender, EventArgs e)
        {
            List<Student> students = studentList.GetStudents();
            foreach (Student student in students)
            {
                MessageBox.Show($"Numara: {student.Number}, Adı: {student.FirstName}, Soyadı: {student.LastName}");
            }
        }

        private void DisplayStudents()
        {
            listViewStudents.Items.Clear();
            List<Student> students = studentList.GetStudents();
            foreach (Student student in students)
            {
                var item = new ListViewItem(new[] { student.Number.ToString(), student.FirstName, student.LastName });
                listViewStudents.Items.Add(item);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

public class Student
{
    public int Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Student Next { get; set; }
}

public class StudentList
{
    public Student Head { get; private set; }

    public void Add(Student newStudent)
    {
        if (Head == null || Head.Number > newStudent.Number)
        {
            newStudent.Next = Head;
            Head = newStudent;
        }
        else
        {
            Student current = Head;
            while (current.Next != null && current.Next.Number < newStudent.Number)
            {
                current = current.Next;
            }
            newStudent.Next = current.Next;
            current.Next = newStudent;
        }
    }

    public void Delete(int number)
    {
        if (Head == null) return;

        if (Head.Number == number)
        {
            Head = Head.Next;
            return;
        }

        Student current = Head;
        while (current.Next != null && current.Next.Number != number)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();
        Student current = Head;
        while (current != null)
        {
            students.Add(current);
            current = current.Next;
        }
        return students;
    }
}
