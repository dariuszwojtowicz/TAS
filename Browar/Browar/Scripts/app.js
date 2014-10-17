var ViewModel = function () {
    var self = this;
    self.piwoes = ko.observableArray();
    self.error = ko.observable();

    var piwoesUri = '/api/Piwoes/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
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

    function getAllPiwoes() {
        ajaxHelper(piwoesUri, 'GET').done(function (data) {
            self.piwoes(data);
        });
    }

    self.detail = ko.observable();

    self.getPiwoDetail = function (item) {
        ajaxHelper(piwoesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.browarnias = ko.observableArray();
    self.newPiwo = {
        Browarnia: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Name: ko.observable(),
        Power: ko.observable()
    }

    var browarniasUri = '/api/Browarnias/';

    function getBrowarnias() {
        ajaxHelper(browarniasUri, 'GET').done(function (data) {
            self.browarnias(data);
        });
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

    getBrowarnias();

    // Fetch the initial data.
    getAllPiwoes();
};

ko.applyBindings(new ViewModel());