using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_CRUD
{
    class Program
    {
        static string connectionstring = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        static void Main(string[] args)
        {

        }
        /**
        * Function creates new Member
        * @param MembershipNumber | The member's membership number
        * @param Name | The member's full name
        * @param FirstName | The member's first name
        * @param MiddleName | The member's middle name
        * @param LastName | The member's last name
        * @param PhoneNumber | The member's phone number
        * @param AlternativeNumber | The member's alternative phone number
        * @param Email | The member's email address
        * @param DateOfBirth | The member's date of birth
        * @param Gender | The member's gender
        * @param Nationality | The member's nationality
        * @param NationalIdNumber | The member's national id number
        * @param TaxPIN | The member's tax pin (KRA/URA)
        * @param Address | The member's address
        * @param Photo | The member's photo name
        * @param Password | The member's portal password
        * @param SourceOfIncome | The member's primary source of income
        * @param Employer | The member's current employer
        * @param JobPosition | The member's job postion
        * @param PayrollNumber | The member's payroll number
        * @param EmployerAddress | The member's employer's address
        * @param EmployerTelephoneNumber | The member's employer's phone number
        * @param GrossMonthlyIncome | The member's gross monthly income
        * @param DateJoined | The date member joined the sacco
        * @param MembershipStatus | The member's membership status
        * @param LastModifiedBy | The user that last modified the record
        * @param LastModifiedAt | The time the record was last modified

        * @return bool | return true if member information is created / return false if not created
        */
        public static bool Create(string MembershipNumber, string Name, string FirstName, string MiddleName, string LastName, string PhoneNumber, string AlternativeNumber, string Email, string DateOfBirth, string Gender, string Nationality, string NationalIdNumber, string TaxPIN, string Address, string Photo, string Password,
        string SourceOfIncome, string Employer, string JobPosition, string PayrollNumber, string EmployerAddress, string EmployerTelephoneNumber, string GrossMonthlyIncome,
        string DateJoined, string MembershipStatus, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;
            MySqlConnection conn = new MySqlConnection(connectionstring);

            try
            {
                conn.Open();

                string sql = @"INSERT INTO members(MembershipNumber, Name, FirstName, MiddleName, LastName, PhoneNumber, AlternativeNumber, Email, DateOfBirth, Gender, Nationality, NationalIdNumber, TaxPIN, Address, Photo, Password, SourceOfIncome, Employer, JobPosition, PayrollNumber, EmployerAddress, EmployerTelephoneNumber, GrossMonthlyIncome, DateJoined, MembershipStatus, LastModifiedBy, LastModifiedAt) VALUES (@MembershipNumber, @Name, @FirstName, @MiddleName, @LastName, @PhoneNumber, @AlternativeNumber, @Email, @DateOfBirth, @Gender, @Nationality, @NationalIdNumber, @TaxPIN, @Address, @Photo, @Password, @SourceOfIncome, @Employer, @JobPosition, @PayrollNumber, @EmployerAddress, @EmployerTelephoneNumber, @GrossMonthlyIncome, @DateJoined, @MembershipStatus, @LastModifiedBy, @LastModifiedAt)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@AlternativeNumber", AlternativeNumber);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Nationality", Nationality);
                    cmd.Parameters.AddWithValue("@NationalIdNumber", NationalIdNumber);
                    cmd.Parameters.AddWithValue("@TaxPIN", TaxPIN);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Photo", Photo);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@SourceOfIncome", SourceOfIncome);
                    cmd.Parameters.AddWithValue("@Employer", Employer);
                    cmd.Parameters.AddWithValue("@JobPosition", JobPosition);
                    cmd.Parameters.AddWithValue("@PayrollNumber", PayrollNumber);
                    cmd.Parameters.AddWithValue("@EmployerAddress", EmployerAddress);
                    cmd.Parameters.AddWithValue("@EmployerTelephoneNumber", EmployerTelephoneNumber);
                    cmd.Parameters.AddWithValue("@GrossMonthlyIncome", GrossMonthlyIncome);
                    cmd.Parameters.AddWithValue("@DateJoined", DateJoined);
                    cmd.Parameters.AddWithValue("@MembershipStatus", MembershipStatus);
                    cmd.Parameters.AddWithValue("@LastModifiedBy", LastModifiedBy);
                    cmd.Parameters.AddWithValue("@LastModifiedAt", LastModifiedAt);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status = true;
                }
                }

            catch (MySqlException es)
            {
                Console.WriteLine(es.ToString());
            }
            return status;
        }
        /**
        * Function returns members information
        * @param MembershipNumber | The member's membership number 

        * @return string | returns json string of member's information
        */
        public static string Read(string MembershipNumber)
        {
            string Name = ""; string FirstName = ""; string MiddleName = ""; string LastName = ""; string PhoneNumber = ""; string AlternativeNumber = ""; string Email = ""; string DateOfBirth = ""; string Gender = ""; string Nationality = "";
            string NationalIdNumber = ""; string TaxPIN = ""; string Address = ""; string Photo = ""; string Password = ""; string SourceOfIncome = ""; string Employer = ""; string JobPosition = ""; string PayrollNumber = ""; string EmployerAddress = ""; string EmployerTelephoneNumber = ""; string GrossMonthlyIncome = ""; string DateJoined = ""; string MembershipStatus = ""; string LastModifiedBy = ""; string LastModifiedAt = "", MemberInfo = "";


            string sql = "SELECT * FROM members WHERE MembershipNumber ='" + MembershipNumber + "'";

            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MembershipNumber = dr.GetString(0);
                    Name = dr.GetString(1);
                    FirstName = dr.GetString(2);
                    MiddleName = dr.GetString(3);
                    LastName = dr.GetString(4);
                    PhoneNumber = dr.GetString(5);
                    AlternativeNumber = dr.GetString(6);
                    Email = dr.GetString(7);
                    DateOfBirth = dr.GetString(8);
                    Gender = dr.GetString(9);
                    Nationality = dr.GetString(10);
                    NationalIdNumber = dr.GetString(11);
                    TaxPIN = dr.GetString(12);
                    Address = dr.GetString(13);
                    Photo = dr.GetString(14);
                    Password = dr.GetString(15);
                    SourceOfIncome = dr.GetString(16);
                    Employer = dr.GetString(17);
                    JobPosition = dr.GetString(18);
                    PayrollNumber = dr.GetString(19);
                    EmployerAddress = dr.GetString(20);
                    EmployerTelephoneNumber = dr.GetString(21);
                    GrossMonthlyIncome = dr.GetString(22);
                    DateJoined = dr.GetString(23);
                    MembershipStatus = dr.GetString(24);
                    LastModifiedBy = dr.GetString(25);
                    LastModifiedAt = dr.GetString(26);
                }
                conn.Close();

                var _Member = new Member
                {
                    MembershipNumber = MembershipNumber,
                    Name = Name,
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    AlternativeNumber = AlternativeNumber,
                    Email = Email,
                    DateOfBirth = DateOfBirth,
                    Gender = Gender,
                    Nationality = Nationality,
                    NationalIdNumber = NationalIdNumber,
                    TaxPIN = TaxPIN,
                    Address = Address,
                    Photo = Photo,
                    Password = Password,
                    SourceOfIncome = SourceOfIncome,
                    Employer = Employer,
                    JobPosition = JobPosition,
                    PayrollNumber = PayrollNumber,
                    EmployerAddress = EmployerAddress,
                    EmployerTelephoneNumber = EmployerTelephoneNumber,
                    GrossMonthlyIncome = GrossMonthlyIncome,
                    DateJoined = DateJoined,
                    MembershipStatus = MembershipStatus,
                    LastModifiedBy = LastModifiedBy,
                    LastModifiedAt = LastModifiedAt
                    // MemberKinsList = GetKinsList(MembershipNumber)
                };
                MemberInfo = JsonConvert.SerializeObject(_Member);
            }
            catch (MySqlException es)
            {
                Console.WriteLine(es.ToString());
            }
            return MemberInfo;
        }
        /**
        * Function updates Member
        * @param MembershipNumber | The member's membership number
        * @param Name | The member's full name
        * @param FirstName | The member's first name
        * @param MiddleName | The member's middle name
        * @param LastName | The member's last name
        * @param PhoneNumber | The member's phone number
        * @param AlternativeNumber | The member's alternative phone number
        * @param Email | The member's email address
        * @param DateOfBirth | The member's date of birth
        * @param Gender | The member's gender
        * @param Nationality | The member's nationality
        * @param NationalIdNumber | The member's national id number
        * @param TaxPIN | The member's tax pin (KRA/URA)
        * @param Address | The member's address
        * @param Photo | The member's photo name
        * @param Password | The member's portal password
        * @param SourceOfIncome | The member's primary source of income
        * @param Employer | The member's current employer
        * @param JobPosition | The member's job postion
        * @param PayrollNumber | The member's payroll number
        * @param EmployerAddress | The member's employer's address
        * @param EmployerTelephoneNumber | The member's employer's phone number
        * @param GrossMonthlyIncome | The member's gross monthly income
        * @param DateJoined | The date member joined the sacco
        * @param MembershipStatus | The member's membership status
        * @param LastModifiedBy | The user that last modified the record
        * @param LastModifiedAt | The time the record was last modified

        * @return bool | return true if member information is updated / return false if not updated
        */
        public static bool Update(string MembershipNumber, string Name, string FirstName, string MiddleName, string LastName, string PhoneNumber, string AlternativeNumber, string Email, string DateOfBirth, string Gender, string Nationality, string NationalIdNumber, string TaxPIN, string Address, string Photo, string Password,
        string SourceOfIncome, string Employer, string JobPosition, string PayrollNumber, string EmployerAddress, string EmployerTelephoneNumber, string GrossMonthlyIncome,
        string DateJoined, string MembershipStatus, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;
            MySqlConnection conn = new MySqlConnection(connectionstring);

            try
            {
                conn.Open();

                string sql = @"UPDATE members SET Name=@Name,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,PhoneNumber=@PhoneNumber,AlternativeNumber=@AlternativeNumber,Email=@Email,DateOfBirth=@DateOfBirth,Gender=@Gender,Nationality=@Nationality,NationalIdNumber=@NationalIdNumber,TaxPIN=@TaxPIN,Address=@Address,Photo=@Photo,Password=@Password,SourceOfIncome=@SourceOfIncome,Employer=@Employer,JobPosition=@JobPosition,PayrollNumber=@PayrollNumber,EmployerAddress=@EmployerAddress,EmployerTelephoneNumber=@EmployerTelephoneNumber,GrossMonthlyIncome=@GrossMonthlyIncome,DateJoined=@DateJoined,MembershipStatus=@MembershipStatus,LastModifiedBy=@LastModifiedBy,LastModifiedAt=@LastModifiedAt WHERE MembershipNumber=@MembershipNumber";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@AlternativeNumber", AlternativeNumber);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Nationality", Nationality);
                    cmd.Parameters.AddWithValue("@NationalIdNumber", NationalIdNumber);
                    cmd.Parameters.AddWithValue("@TaxPIN", TaxPIN);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Photo", Photo);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@SourceOfIncome", SourceOfIncome);
                    cmd.Parameters.AddWithValue("@Employer", Employer);
                    cmd.Parameters.AddWithValue("@JobPosition", JobPosition);
                    cmd.Parameters.AddWithValue("@PayrollNumber", PayrollNumber);
                    cmd.Parameters.AddWithValue("@EmployerAddress", EmployerAddress);
                    cmd.Parameters.AddWithValue("@EmployerTelephoneNumber", EmployerTelephoneNumber);
                    cmd.Parameters.AddWithValue("@GrossMonthlyIncome", GrossMonthlyIncome);
                    cmd.Parameters.AddWithValue("@DateJoined", DateJoined);
                    cmd.Parameters.AddWithValue("@MembershipStatus", MembershipStatus);
                    cmd.Parameters.AddWithValue("@LastModifiedBy", LastModifiedBy);
                    cmd.Parameters.AddWithValue("@LastModifiedAt", LastModifiedAt);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status = true;
                }
            }

            catch (MySqlException es)
            {
                Console.WriteLine(es.ToString());
            }
            return status;
        }

        /**
        * Function deletes Members 
        * @param MembershipNumber | The member's membership number
        * @return bool | return true if member is deleted / return false if not deleted
        */
        public static bool Delete(string MembershipNumber)
        {
            bool status = false;

            string sql = "DELETE FROM `members` WHERE `MembershipNumber` = @MembershipNumber";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionstring;
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();

                status = true;

            }
            catch (MySqlException es)
            {
                Console.WriteLine(es.ToString());
            }
            return status;
        }
    }
    class Member
    {
        public string MembershipNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string NationalIdNumber { get; set; }
        public string TaxPIN { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
        public string SourceOfIncome { get; set; }
        public string Employer { get; set; }
        public string JobPosition { get; set; }
        public string PayrollNumber { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerTelephoneNumber { get; set; }
        public string GrossMonthlyIncome { get; set; }
        public string DateJoined { get; set; }
        public string MembershipStatus { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedAt { get; set; }
        public List<Kin> MemberKinsList { get; set; }
    }
    class Kin
    {
        public string IdentificationDocumentNumber { get; set; }
        public string MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Relationship { get; set; }
        public string Occupation { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedAt { get; set; }
    }
}
