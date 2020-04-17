using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class Student_UI_Page : System.Web.UI.Page
{
    //public String dbConnection = "Data Source=LOCALHOST;Initial Catalog=Lab3;Integrated Security=True";
    String LastUpdatedBy = "Kris Case";
    DateTime LastUpdated = DateTime.Now;
    int showHideGrid = 0;
    Boolean showGrid = false;
    System.Data.SqlClient.SqlConnection dbConnect = new System.Data.SqlClient.SqlConnection();
    //SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //Manually connects to DB (or tries to)
        try
        {
            //Connection string for both JMU computers and my personal computer
            dbConnect.ConnectionString = @"server = DESKTOP-QLQP0S6\LOCALHOST; Database=lab3; Trusted_Connection = Yes;"; //For personal computer
            //------------------------------------------------------------------------------------------------------------------------------------------------------------
            //JMU Lab Computers
            //dbConnect.ConnectionString = @"server = LOCALHOST; Database=lab3; Trusted_Connection = Yes;";
            //------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Connection String for web.config file
            //SqlConnection dbConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["lab2ConnectionString"].ConnectionString);
            dbConnect.Open();
            MessageTextBox.Text = "Connected!";
        }
        catch (Exception)
        {
            MessageTextBox.Text = "No Connection Established!";
        }
        //Sets all textboxes to 
        MessageTextBox.Enabled = false;
        lastUpdated.Enabled = false;
        lastUpdatedBy.Enabled = false;
        outputBox.Enabled = false;
        studentAddress.Enabled = false;

        SqlDataAdapter da = new SqlDataAdapter("Select LastName, P.PropertyID from Student S LEFT OUTER JOIN Property P ON S.PropertyID = P.PropertyID", dbConnect);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();

        if (showGrid == false)
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
        }


    }

    //Calculates Student's Age from birthdate given 
    private static int CalculateAge(DateTime dateOfBirth)
    {
        int age = 0;
        age = DateTime.Now.Year - dateOfBirth.Year;
        if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            age = age - 1;

        return age;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        firstName.Text = String.Empty;
        lastName.Text = String.Empty;
        middleName.Text = String.Empty;
        houseNumber.Text = String.Empty;
        streetAddress.Text = String.Empty;
        cityCounty.Text = String.Empty;
        zipcode.Text = String.Empty;
        dateOfBirth.Text = String.Empty;
        stateList.ClearSelection();
        countryList.ClearSelection();
    }

    protected void BtnCommit_Click(object sender, EventArgs e)
    {


        //Update textboxes to display information / not be editible by user
        outputBox.Text = "";
        outputBox.Enabled = false;
        lastUpdated.Enabled = false;
        lastUpdatedBy.Enabled = false;
        DateTime currentDate = DateTime.Now;
        lastUpdated.Text = currentDate.ToString();
        lastUpdatedBy.Text = LastUpdatedBy;
        lastUpdatedBy.Visible = true;
        lastUpdated.Visible = true;

        //Declares variables used in validations:
        Boolean validData = true;
        int age;
        DateTime parsedDOB;

        //Validation1: Checks if field blank
        if (firstName.Text == "" || dateOfBirth.Text == "" || lastName.Text == "" || houseNumber.Text == "" || streetAddress.Text == "")
        {
            outputBox.Visible = true;
            outputBox.Text = "Commit Failed: Please fill out missing fields!";
            validData = false;
        }
        //Validation2: Checks if age is between 18-30 (assuming data successfully went through validation1)
        if (validData == true)
        {
            parsedDOB = DateTime.Parse(dateOfBirth.Text);
            age = CalculateAge(parsedDOB);

            if (validData == true && age < 18 || age > 30)
            {
                outputBox.Visible = true;
                outputBox.Text = "Commit Failed: Invalid Age (must be between 18-30)";

                validData = false;
            }
        }

        //If all validations met - commits student to the database
        if (validData == true)
        {
            try
            {
                parsedDOB = DateTime.Parse(dateOfBirth.Text);

                Student stu = new Student(firstName.Text, lastName.Text, middleName.Text,
                houseNumber.Text, streetAddress.Text, cityCounty.Text, stateList.SelectedValue, countryList.SelectedValue,
                zipcode.Text, DateTime.Parse(dateOfBirth.Text), DateTime.Today, lastUpdatedBy.Text,
                Convert.ToInt32(propertyIDDropDownList.SelectedValue.ToString()));

                //Creates insert command in order to insert students into database
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.Connection = dbConnect;

                insert.Parameters.Add("@fName", System.Data.SqlDbType.VarChar);
                insert.Parameters["@fName"].Value = stu.getFirstName();
                insert.Parameters.Add("@lName", System.Data.SqlDbType.VarChar);
                insert.Parameters["@lName"].Value = stu.getLastName();
                insert.Parameters.Add("@mName", System.Data.SqlDbType.VarChar);
                insert.Parameters["@mName"].Value = stu.getMiddleName();
                insert.Parameters.Add("@hNum", System.Data.SqlDbType.VarChar);
                insert.Parameters["@hNum"].Value = stu.getHouseNumber();
                insert.Parameters.Add("@street", System.Data.SqlDbType.VarChar);
                insert.Parameters["@street"].Value = stu.getStreetAddress();
                insert.Parameters.Add("@cityC", System.Data.SqlDbType.VarChar);
                insert.Parameters["@cityC"].Value = stu.getCityCounty();
                insert.Parameters.Add("@state", System.Data.SqlDbType.Char);
                insert.Parameters["@state"].Value = stu.getState();
                insert.Parameters.Add("@country", System.Data.SqlDbType.Char);
                insert.Parameters["@country"].Value = stu.getCountry();
                insert.Parameters.Add("@zip", System.Data.SqlDbType.Char);
                insert.Parameters["@zip"].Value = stu.getZipCode();
                insert.Parameters.Add("@DOB", System.Data.SqlDbType.DateTime);
                insert.Parameters["@DOB"].Value = stu.getDOB();
                insert.Parameters.Add("@lastUpdatedBy", System.Data.SqlDbType.VarChar);
                insert.Parameters["@lastUpdatedBy"].Value = stu.getLastUpdatedBy();
                insert.Parameters.Add("@lastUpdated", System.Data.SqlDbType.DateTime);
                insert.Parameters["@lastUpdated"].Value = stu.getLastUpdated();
                insert.Parameters.Add("@propID", System.Data.SqlDbType.Int);
                insert.Parameters["@propID"].Value = stu.getPropertyID();

                //Checks if propertyID or state drop down are NULL - if so, modifies insert statement
                if (Convert.ToInt32(propertyIDDropDownList.SelectedValue) == 0)
                {
                    if (stateList.SelectedIndex == 0 || stateList.SelectedIndex == 1)
                    {
                        insert.CommandText = "INSERT INTO [dbo].[Student] VALUES(" +
                       "@fName, @lName, @mName, @hNum, @street," +
                       " @cityC, null, @country, @zip, @DOB, " +
                       "@LastUpdatedBy, @LastUpdated, null);";
                    }
                    insert.CommandText = "INSERT INTO [dbo].[Student] VALUES(" +
                       "@fName, @lName, @mName, @hNum, @street," +
                       " @cityC, @state, @country, @zip, @DOB, " +
                       "@LastUpdatedBy, @LastUpdated, null);";
                }
                else
                {
                    insert.CommandText = "INSERT INTO [dbo].[Student] VALUES(" +
                       "@fName, @lName, @mName, @hNum, @street," +
                       " @cityC, @state, @country, @zip, @DOB, " +
                       "@LastUpdatedBy, @LastUpdated, @propID);";
                }

                insert.ExecuteNonQuery();
                outputBox.Text = "Student Inserted!";
            }
            catch
            {
                outputBox.Text = "Student could not be inserted!";
            }
        }
    }

    protected void btnPopulate_Click(object sender, EventArgs e)
    {

        //Clear
        firstName.Text = String.Empty;
        lastName.Text = String.Empty;
        middleName.Text = String.Empty;
        houseNumber.Text = String.Empty;
        streetAddress.Text = String.Empty;
        cityCounty.Text = String.Empty;
        zipcode.Text = String.Empty;
        dateOfBirth.Text = String.Empty;
        stateList.ClearSelection();
        countryList.ClearSelection();

        //Populate
        firstName.Text = "Kris";
        lastName.Text = "Case";
        middleName.Text = "Burke";
        houseNumber.Text = "940";
        streetAddress.Text = "River Rd";
        cityCounty.Text = "Sykesville";
        zipcode.Text = "21784";
        dateOfBirth.Text = "05/06/1997";
        stateList.Items.FindByValue("MD").Selected = true;
        countryList.Items.FindByValue("US").Selected = true;
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }


    protected void showGridView_Click(object sender, EventArgs e)
    {
        showGrid = true;
        GridView1.Visible = true;
    }

    protected void SearchHouseNum_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlCommand search = new System.Data.SqlClient.SqlCommand();
        search.Connection = dbConnect;

        Boolean validData = true;
        if (firstName.Text == "" || lastName.Text =="")
        {
            validData = false;
            outputBox.Text = "Please enter first and Last name!";
        }
        if (validData == true)
        {
            String searchSelectQuery = "SELECT * FROM STUDENT WHERE FirstName = '" + firstName.Text + "'";
            SqlCommand searchCmd = new SqlCommand(searchSelectQuery, dbConnect);
            SqlDataReader reader = searchCmd.ExecuteReader();
            if (reader.Read())
            {
                studentAddress.Text = (reader["FirstName"].ToString() + " " + reader["LastName"].ToString() + "--" + reader["houseNumber"].ToString() + " " + reader["street"].ToString());
                lastName.Text = (reader["LastName"].ToString());
                middleName.Text = (reader["MiddleName"].ToString());
                houseNumber.Text = (reader["HouseNumber"].ToString());
                streetAddress.Text = (reader["Street"].ToString());
                cityCounty.Text = (reader["CityCounty"].ToString());
                stateList.SelectedValue = (reader["HomeState"].ToString());
                countryList.SelectedValue = (reader["Country"].ToString());
                zipcode.Text = (reader["Zip"].ToString());
                
            }

        }
    }


 
}

