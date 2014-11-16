using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Serwer
{
    using Serwer.DTO;

    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private  DatabaseHelper DBHelper;

        public Service()
        {
            DBHelper = new DatabaseHelper();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Metoda wyciąga z tabeli Piwoes wiersz o danym ID i zwraca go w postaci PiwoDTO
        //Dodatkowo uzywamy metody policzOcene() do wyliczenia na podstawie danych z bazy sredniej oceny dla naszego piwa i wsadzenie jej do piwo.rate
        [WebMethod]
        public PiwoDetailDTO GetBeer(int id)
        {
            PiwoDetailDTO beer = DBHelper.getBeerWithId(id);

            return beer;
        }

        //Metoda zwraca wszystkie wiersze z tabeli Piwoes w postaci listy PiwoDTO
        //Dodatkowo uzywamy metody policzOcene() do wyliczenia na podstawie danych z bazy sredniej oceny dla nkazdego piwa i wsadzenie jej do piwo.rate każdego z piw
        [WebMethod]
        public List<PiwoDTO> GetBeers()
        {
            List<PiwoDTO> beers = DBHelper.getBeers();
            return beers;
        }

        //Kasuje piwo o danym id i zwraca true albo false czy coś, żeby było wiadomo czy się udało czy nie
        [WebMethod]
        public bool DeletePiwo(int id)
        {
            if(DBHelper.deleteBeer(id))
            {
                return true;
            }
            return false;
        }

        //Przyjmuje PiwoDTO i updateje wiersz o danym id wsadzajac dane  hasha, zwraca true false
        [WebMethod]
        public bool UpdatePiwo(PiwoDetailDTO piwo)
        {
            if(DBHelper.updateBeer(piwo))
            {
                return true;
            }
            return false;
        }

        //Wsadza do bazy wiersz z danymi z PiwoDTO, zwraca true/false
        [WebMethod]
        public bool InsertPiwo(PiwoDetailDTO piwo)
        {
            if(DBHelper.addBeer(piwo))
            {
                return true;
            }
            return false;
        }

        //Wyciaga z bazy srednia ocene dla danego piwa
        [WebMethod]
        public double PoliczOcene(int id)
        {
            return DBHelper.getAverageRate(id);
        }

        //Analogiczne metody, ale nie wszystkie dla User, Comment, Rate, Browarnia
        /*
         * User: insert, delete, update, get (pojedynczy), checkUser(login, haslo) - sprawdza czy user o danym loginie ma takie hasło
         * Comment: insert, get (wszystkie komenty uzytkownika o danym id), drugi get (wszystkie komenty danego piwa)
         * Rate: to samo co Comment
         * Browarnia: Takie same jak dla Piwo, tylko bez liczenia ocen
         */
 
        //PiwoDetailDTO przekopiowałem z klienta, chyba tak trzeba zrobić żeby wysyłać to samo co klient chce odebrać. Więc trzeba tak zrobić z innymi DTO też.

        //Nie wiem co z walidacją, ale to chyba raczej po stronie klienta będzie.
         
    }
}
