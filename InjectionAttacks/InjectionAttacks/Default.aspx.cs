using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //XSS: Cross Site Scripting

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        string userName = TextBoxUserName.Text;
        string password = TextBoxPassword.Text;

        SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");

        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = "SELECT * FROM Employees WHERE FirstName=@username AND LastName=@password";
        cmd.Parameters.AddWithValue("@username", userName);
        cmd.Parameters.AddWithValue("@password", password);

        sqlConnection.Open();
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Label1.Text = "Giriş Başarılı";
        }
        else
        {
            Label1.Text = "Giriş Başarısız";

        }

        sqlConnection.Close();


    }

    protected void ButtonComment_Click(object sender, EventArgs e)
    {
        Labelcomment.Text = TextBoxComment.Text;
    }
}