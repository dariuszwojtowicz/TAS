var ViewModel = function () {
    var self = this;
    self.piwoes = ko.observableArray();
    self.browarnias = ko.observableArray();
    self.error = ko.observable();
    self.piwoDetail = ko.observable();
    self.browarniaDetail = ko.observable();
    self.rejestracja = ko.observable();
    self.logowanie = ko.observable();

    var piwoesUri = '/api/Piwoes/';
    var browarniasUri = '/api/Browarnias/';

    function ajaxHelper(uri, method, data) {
        self.error(''); 
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    self.loguj = function () {
        self.rejestracja(0);
        self.logowanie(1);
    }

    self.rejestruj = function () {
        self.rejestracja(1);
        self.logowanie(0);
    }

    function getAllPiwoes() {
        ajaxHelper(piwoesUri, 'GET').done(function (data) {
            self.piwoes(data);
        });
    }

    function getAllBrowarnias() {
        ajaxHelper(browarniasUri, 'GET').done(function (data) {
            self.browarnias(data);
        });
    }

   self.getPiwoDetail = function (item) {
        ajaxHelper(piwoesUri + item.Id, 'GET').done(function (data) {
            self.piwoDetail(data);
        });
   }

   self.getBrowarniaDetail = function (item) {
       ajaxHelper(browarniasUri + item.Id, 'GET').done(function (data) {
           self.browarniaDetail(data);
       });
   }

   self.newPiwo = {
        Browarnia: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Name: ko.observable(),
        Power: ko.observable()
    }

  self.addPiwo = function (formElement) {
        var piwo = {
            BrowarniaId: self.newPiwo.Browarnia().Id,
            Genre: self.newPiwo.Genre(),
            Price: self.newPiwo.Price(),
            Name: self.newPiwo.Name(),
            Power: self.newPiwo.Power()
        };

        ajaxHelper(piwoesUri, 'POST', piwo).done(function (item) {
            self.piwoes.push(item);
        });
  }

  self.newBrowarnia = {
      Name: ko.observable(),
  }

  self.addBrowarnia = function (formElement) {
      var browarnia = {
          Name: self.newBrowarnia.Name(),
      };

      ajaxHelper(browarniasUri, 'POST', browarnia).done(function (item) {
          self.browarnias.push(item);
      });
  }
    
    // Inicjowanie danych.
    getAllPiwoes();
    getAllBrowarnias();
};

ko.applyBindings(new ViewModel());