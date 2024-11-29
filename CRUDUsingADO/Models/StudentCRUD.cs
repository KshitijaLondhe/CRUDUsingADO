using System.Data.SqlClient;
namespace CRUDUsingADO.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            cmd = new SqlCommand("select * from student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.id = Convert.ToInt32(dr["id"]);
                    student.name = dr["name"].ToString();
                    student.percentage = Convert.ToInt32(dr["percentage"]);
                    student.branch = dr["branch"].ToString();
                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }


        public Student GetStudentById(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("select * from student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.id = Convert.ToInt32(dr["id"]);
                    student.name = dr["name"].ToString();
                    student.percentage = Convert.ToInt32(dr["percentage"]);
                    student.branch = dr["branch"].ToString();

                }
            }
            con.Close();
            return student;
        }

        public int AddStudent(Student std)
        {
            int result = 0;
            string qry = "insert into student values(@name,@percentage,@branch)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name",std.name);
            cmd.Parameters.AddWithValue("@percentage", std.percentage);
            cmd.Parameters.AddWithValue("@branch", std.branch);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateStudent(Student std)
        {
            int result = 0;
            string qry = "update student set name=@name,percentage=@percentage,branch=@branch where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.name);
            cmd.Parameters.AddWithValue("@percentage", std.percentage);
            cmd.Parameters.AddWithValue("@branch", std.branch);
            cmd.Parameters.AddWithValue("@id", std.id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
