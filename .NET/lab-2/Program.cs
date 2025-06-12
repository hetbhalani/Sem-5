// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//---------------------------- 1 ------------------------------

// class Cnadidate
// {
//     int id;
//     string name;
//     int age;
//     int weight;
//     int height;

//     public void getUserData()
//     {
//         Console.Write("ID: ");
//         id = Convert.ToInt32(Console.ReadLine());
//         Console.Write("Name: ");
//         name = Console.ReadLine();
//         Console.Write("Age: ");
//         age = Convert.ToInt32(Console.ReadLine());
//         Console.Write("Weight: ");
//         weight = Convert.ToInt32(Console.ReadLine());
//         Console.Write("Height: ");
//         height = Convert.ToInt32(Console.ReadLine());
//     }

//     public void setUserData()
//     {
//         Console.WriteLine(id);
//         Console.WriteLine(name);
//         Console.WriteLine(age);
//         Console.WriteLine(weight);
//         Console.WriteLine(height);
//     }
// }


//-------------------------- 2 ------------------------


class Staff {
    string name;
    string department;
    string designation;
    int experience;
    int salary;

    public void display() { 
        name = Console.ReadLine();
        department = Console.ReadLine();
        designation = Console.ReadLine();
        experience = Convert.ToInt32(Console.ReadLine());
        salary = Convert.ToInt32(Console.ReadLine());

        if(designation == "HOD")
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("HOD Salary: " + salary);
        }
    }
}

//-------------------------- 3 ------------------------

class BankAccount
{
    string name;
    string account_no;
    string email;
    string type;
    int balance;

    public void getAccountDetails()
    {
        Console.Write("Name: ");
        name = Console.ReadLine();
        Console.Write("Account No: ");
        account_no = Console.ReadLine();
        Console.WriteLine("Email: ");
        email = Console.ReadLine();
        Console.Write("Type: ");
        type = Console.ReadLine();
        Console.Write("Balance: ");
        balance = Convert.ToInt32(Console.ReadLine());
    }

    public void setAccountDetails()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Account No: " + account_no);
        Console.WriteLine("Email: " + email);
        Console.WriteLine("Type: " + type);
        Console.WriteLine("Balance: " + balance);
    }
}

//-------------------------- 4 ------------------------

public class Student
{
    string EnrollmentNo;
    string Name;
    int semester;
    int cpi;
    int spi;

    public Student(string enrl, string name, int sem, int cpi, int spi) 
    {
        Console.WriteLine(enrl);
        Console.WriteLine(name);
        Console.WriteLine(sem);
        Console.WriteLine(cpi);
        Console.WriteLine(spi);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Cnadidate cd = new Cnadidate();
        //cd.getUserData();
        //cd.setUserData();

        //for (int i = 0; i < 5; i++) { 
        //    Staff st = new Staff();
        //    Console.WriteLine("Enter Staff Details: ");
        //    st.display();
        //}

        //BankAccount b1 = new BankAccount();
        //b1.getAccountDetails();
        //b1.setAccountDetails();

        Student s1 = new Student("1234", "Het", 1, 9, 9);
    }
}
