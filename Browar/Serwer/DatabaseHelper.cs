using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Serwer.DTO;

namespace Serwer
{
    public class DatabaseHelper
    {
        SqlConnection conn;
        string query;
        public DatabaseHelper()
        {
            this.conn = new SqlConnection(@"Data Source=montwulfpc\Baza;Initial Catalog=BeersDB; User Id=client; Password=test;");
            //string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        public PiwoDetailDTO getBeerWithId(int id)
        {
            PiwoDetailDTO beer = new PiwoDetailDTO();
            this.query = string.Format("SELECT id, nazwa FROM dbo.Browar WHERE id = {0}", id);
            using(SqlCommand command = new SqlCommand(this.query, this.conn))
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    beer.Id = int.Parse(reader.GetValue(0).ToString());
                    beer.Name = reader.GetValue(1).ToString();
                }
                return beer;
            }
        }

        public List<PiwoDTO> getBeers()
        {
            List<PiwoDTO> beers = new List<PiwoDTO>();
            this.query = string.Format("SELECT id, nazwa FROM dbo.Browar");
            using (SqlCommand command = new SqlCommand(this.query, this.conn))
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    PiwoDTO beer = new PiwoDTO();
                    beer.Id = int.Parse(reader.GetValue(0).ToString());
                    beer.Name = reader.GetValue(1).ToString();
                    beers.Add(beer);
                }
  
                return beers;
            }
        }

        public bool updateBeer(PiwoDetailDTO beer)
        {
            if(this.deleteBeer(beer.Id))
            {
                if(this.updateBeer(beer))
                {
                    return true;
                }
            }
            return false;
        }

        public bool deleteBeer(int id)
        {
            this.query = string.Format("DELETE FROM dbo.Browar WHERE id = {0}", id);
            using (SqlCommand command = new SqlCommand(this.query, this.conn))
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool addBeer(PiwoDetailDTO beer)
        {
            this.query = string.Format("INSERT INTO dbo.Browar (id, nazwa) VALUES ({0}, {1})", beer.Id, beer.Name);
            using (SqlCommand command = new SqlCommand(this.query, this.conn))
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public double getAverageRate(int id)
        {
            double averageRate = 0;
            this.query = string.Format("SELECT AVG(ocena) FROM dbo.Browar WHERE id = {0}", id);
            using (SqlCommand command = new SqlCommand(this.query, this.conn))
            {
                conn.Open();
                averageRate = double.Parse(command.ExecuteScalar().ToString());
            }
            return averageRate;
        }
        
    }
}