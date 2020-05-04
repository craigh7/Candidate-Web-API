
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirefishAPIProject.Models
{
    public class CandidateDataAccessLayer
    {
        public IEnumerable<Candidate> GetCandidates()
        {
            List<Candidate> candidateList = new List<Candidate>();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Candidate", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var candidate = new Candidate();

                    candidate.candidateID = Convert.ToInt32(rdr["ID"]);
                    candidate.firstName = rdr["FirstName"].ToString();
                    candidate.surname = rdr["Surname"].ToString();
                    candidate.DOB = Convert.ToDateTime(rdr["DateOfBirth"]);
                    candidate.address1 = rdr["Address1"].ToString();
                    candidate.town = rdr["Town"].ToString();
                    candidate.country = rdr["Country"].ToString();
                    candidate.postCode = rdr["PostCode"].ToString();
                    candidate.phoneHome = rdr["PhoneHome"].ToString();
                    candidate.phoneMobile = rdr["PhoneMobile"].ToString();
                    candidate.phoneWork = rdr["PhoneWork"].ToString();
                    candidate.createdDate = Convert.ToDateTime(rdr["CreatedDate"]);
                    candidate.updatedDate = Convert.ToDateTime(rdr["UpdatedDate"]);
                    candidateList.Add(candidate);
                }
            }
            return candidateList;
        }

        public Candidate GetOne(int id)
        {
            List<Candidate> candidateList = new List<Candidate>();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Candidate where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var candidate = new Candidate();

                    candidate.candidateID = Convert.ToInt32(rdr["ID"]);
                    candidate.firstName = rdr["FirstName"].ToString();
                    candidate.surname = rdr["Surname"].ToString();
                    candidate.DOB = Convert.ToDateTime(rdr["DateOfBirth"]);
                    candidate.address1 = rdr["Address1"].ToString();
                    candidate.town = rdr["Town"].ToString();
                    candidate.country = rdr["Country"].ToString();
                    candidate.postCode = rdr["PostCode"].ToString();
                    candidate.phoneHome = rdr["PhoneHome"].ToString();
                    candidate.phoneMobile = rdr["PhoneMobile"].ToString();
                    candidate.phoneWork = rdr["PhoneWork"].ToString();
                    candidate.createdDate = Convert.ToDateTime(rdr["CreatedDate"]);
                    candidate.updatedDate = Convert.ToDateTime(rdr["UpdatedDate"]);
                    return candidate;
                }
            }
            return null ;
        }

        [HttpPost]
        public void AddCandidate(Candidate candidate)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = new SqlConnection(CS);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Candidate (ID, FirstName, Surname, DateOfBirth, Address1, Town, Country, PostCode, PhoneHome,  PhoneMobile, PhoneWork, CreatedDate, UpdatedDate) " +
                    "Values (@ID, @FirstName, @Surname, @DateOfBirth, @Address1, @Town, @Country, @PostCode, @PhoneHome,  @PhoneMobile, @PhoneWork, @CreatedDate, @UpdatedDate)";


            sqlCmd.Parameters.AddWithValue("@ID", candidate.candidateID);
            sqlCmd.Parameters.AddWithValue("@FirstName", candidate.firstName);
            sqlCmd.Parameters.AddWithValue("@Surname", candidate.surname);
            sqlCmd.Parameters.AddWithValue("@DateOfBirth", candidate.DOB);
            sqlCmd.Parameters.AddWithValue("@Address1", candidate.address1);
            sqlCmd.Parameters.AddWithValue("@Town", candidate.town);
            sqlCmd.Parameters.AddWithValue("@Country", candidate.country);
            sqlCmd.Parameters.AddWithValue("@PostCode", candidate.postCode);
            sqlCmd.Parameters.AddWithValue("@PhoneHome", candidate.phoneHome);
            sqlCmd.Parameters.AddWithValue("@PhoneMobile", candidate.phoneMobile);
            sqlCmd.Parameters.AddWithValue("@PhoneWork", candidate.phoneWork);
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            sqlCmd.Connection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();
        }

        public void UpdateCandidate(int id, Candidate candidate)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = new SqlConnection(CS);
            sqlCmd.CommandType = CommandType.Text;
            

            sqlCmd.CommandText = "UPDATE Candidate SET FirstName=@FirstName, Surname=@Surname, DateOfBirth=@DateOfBirth, Address1=@Address1, Town=@Town, Country=@Country, PostCode=@PostCode, PhoneHome=@PhoneHome,  PhoneMobile=@PhoneMobile, PhoneWork=@PhoneWork, CreatedDate=@CreatedDate, UpdatedDate=@UpdatedDate " +
                                "WHERE ID=@ID";

            sqlCmd.Parameters.AddWithValue("@ID", id);
            sqlCmd.Parameters.AddWithValue("@FirstName", candidate.firstName);
            sqlCmd.Parameters.AddWithValue("@Surname", candidate.surname);
            sqlCmd.Parameters.AddWithValue("@DateOfBirth", candidate.DOB);
            sqlCmd.Parameters.AddWithValue("@Address1", candidate.address1);
            sqlCmd.Parameters.AddWithValue("@Town", candidate.town);
            sqlCmd.Parameters.AddWithValue("@Country", candidate.country);
            sqlCmd.Parameters.AddWithValue("@PostCode", candidate.postCode);
            sqlCmd.Parameters.AddWithValue("@PhoneHome", candidate.phoneHome);
            sqlCmd.Parameters.AddWithValue("@PhoneMobile", candidate.phoneMobile);
            sqlCmd.Parameters.AddWithValue("@PhoneWork", candidate.phoneWork);
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            sqlCmd.Connection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();
        }

        


        /*
    
           public IEnumerable<Candidate> GetCandidateById(int id)
        {
            List<Candidate> candidateList = new List<Candidate>();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Candidate where ID=@CandidateID", con);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = id;
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var candidate = new Candidate();

                    candidate.candidateID = Convert.ToInt32(rdr["ID"]);
                    candidate.firstName = rdr["FirstName"].ToString();
                    candidate.surname = rdr["Surname"].ToString();
                    candidate.DOB = Convert.ToDateTime(rdr["DateOfBirth"]);
                    candidate.address1 = rdr["Address1"].ToString();
                    candidate.town = rdr["Town"].ToString();
                    candidate.country = rdr["Country"].ToString();
                    candidate.postCode = rdr["PostCode"].ToString();
                    candidate.phoneHome = rdr["PhoneHome"].ToString();
                    candidate.phoneMobile = rdr["PhoneMobile"].ToString();
                    candidate.phoneWork = rdr["PhoneWork"].ToString();
                    candidate.createdDate = Convert.ToDateTime(rdr["CreatedDate"]);
                    candidate.updatedDate = Convert.ToDateTime(rdr["UpdatedDate"]);
                    candidateList.Add(candidate);
                }
            }
            return candidateList;
        }
    }

    */


    }

}
