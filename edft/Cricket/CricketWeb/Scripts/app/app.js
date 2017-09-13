
$(function () {
    var cw = new cricketWeb.CricketWeb();

    ko.applyBindings(cw, $('#cricket')[0]);
});

var cricketWeb = (function () {
    var urlBase = "/odata/Players?$orderby=SortNamePart";
    var pageSize = 20;

    function CricketWeb() {
        this.title = "Players";
        var countUrl = urlBase + "&$top=0&$count=true";
        $.getJSON(countUrl)
            .then(function (data) {
                var size = data["@odata.count"];
                var players = new Players(size);
                players.init($('#players')[0]);
                var initialUrl = urlBase + "&$top=" + pageSize + "&$count=true";
                players.getData(initialUrl, 0);
            });
    };


    function Players(size) {
        var self = this;
        var playersData = [];

        self.items = ko.observableArray(playersData);
        self.addItem = function () { }
        self.removeItem = function () { }
        self.element = null;

        self.getData = function (url, initialOffset) {
            $.getJSON(url)
                    .then(function (data) {
                        $.each(data.value, function () {
                            // for paging need to put the 'item' in the 'correct' place in the array
                            playersData[initialOffset++] = new Player(this);
                        });
                        $("#playersGrid").jqxGrid('updatebounddata');
                        $("#playersGrid").jqxGrid('selectrow', 0);
                    });
        }

        function setupPlayersGrid(playersInitialData) {
            var source = {
                localdata: playersInitialData,
                datatype: 'local'
            }
            source.totalrecords = size;
            $("#playersGrid").jqxGrid({
                source: source,
                autoheight: true,
                width: '100%',
                pageable: true,
                pagesize: 20,
                editable: true,
                virtualmode: true,
                rendergridrows: function (params) {
                    return params.data;
                },
                theme: 'bootstrap',
                columns: [
                    { text: 'Id', dataField: 'playerId', width: 0, hidden: true },
                    { text: 'Name', dataField: 'name', editable: false },
                    { text: 'Handed', dataField: 'battingType', editable: true }
                ]
            });

            $("#playersGrid").bind("pagechanged", function (event) {
                var args = event.args;
                var pagenumber = args.pagenum;
                //var pagesize = args.pagesize;
                var skip = args.pagenum * pageSize;
                var url = urlBase + "&$skip=" + skip + "&$top=" + pageSize;
                self.getData(url, skip);
            });

            $("#playersGrid").bind("pagesizechanged", function (event) {
                var args = event.args;
                var pagenumber = args.pagenum;
                var pagesize = args.pagesize;
            });
            $("#playersGrid").on('cellendedit', function (event) {
                var column = args.datafield;
                var row = args.rowindex;
                var value = args.value;
                var oldvalue = args.oldvalue;
                var playerId = $('#playersGrid').jqxGrid('getrowdata', event.args.rowindex).playerId;
                var updatedPlayers = $.map(self.items(), function (item) {
                    if (item.playerId == playerId) {
                        return item;
                    }
                });
                if (updatedPlayers.length == 1) {
                    var data = JSON.stringify({BattingType: value});
                    var url = "/odata/Players(" + playerId + ")";
                    $.ajax(url, {
                        type: 'PATCH',
                        data: data,
                        contentType: 'application/json',
                        dataType: 'application/json'
                    });
                }
                console.log("Edit: " + value + " for player: " + playerId);
            });
            var battingDetails = new BattingDetails();
            self.selectedRow = function (args) {
                var name = $('#playersGrid').jqxGrid('getrowdata', args).name;
                var playerId = $('#playersGrid').jqxGrid('getrowdata', args).playerId;
                console.log("selectedRow: args: " + args + " id: " + playerId + " name: " + name);
                battingDetails.init(playerId);
            };

            ko.applyBindings(self, $('#playersGrid')[0]);
        }

        self.init = function (element) {
            self.element = element;
            setupPlayersGrid(playersData);
        };

    }

    var Player = function (data) {
        var self = this;

        self.name = data.Name;
        self.playerId = data.Id;
        self.battingType = data.BattingType;
    }

    ko.bindingHandlers.updateSelection = {
        init: function (element, valueAccessor) {
            var value = valueAccessor();
            $(element).bind('rowselect', function (event) {
                value(event.args.rowindex);
            });
        }
    };

    var BattingDetails = function (initialData) {
        var self = this;
        var battingDetailsData = [{ opponents: "opponents" }];

        function setupBattingDetailsGrid() {
            var source = {
                localdata: battingDetailsData,
                datatype: 'local'
            }
            $("#battingDetailsGrid").jqxGrid({
                source: source,
                autoheight: true,
                width: '100%',
                theme: 'bootstrap',
                columns: [
                    { text: 'Test', dataField: 'test', width: '5%' },
                    { text: 'Opponents', dataField: 'opponents', width: '15%' },
                    { text: 'Year', dataField: 'seriesYear', width: '5%' },
                    { text: 'Innings', dataField: 'innings', width: '5%' },
                    { text: 'How Out', dataField: 'dismissal', width: '50%' },
                    { text: 'Score', dataField: 'score', width: '5%' },
                    { text: 'Minutes', dataField: 'minutes', width: '5%' },
                    { text: 'Fours', dataField: 'fours', width: '5%' },
                    { text: 'Sixes', dataField: 'sixes', width: '5%' }
                ]
            });
        }
        setupBattingDetailsGrid();

        self.items = ko.observableArray(battingDetailsData);
        console.log("BattingDetails: " + id);
        ko.applyBindings(self, $('#battingDetailsGrid')[0]);

        self.init = function (id) {
            self.items.removeAll();
            var url = '/odata/Players(' + id + ')?$expand=BattingDetails($expand=Country, Opponent, Match)';

            $.getJSON(url).then(function (data) {
                console.log("BattingDetails: " + data);
                $.each(data.BattingDetails, function () {
                    battingDetailsData.push(new BattingDetail(this));
                });
                $("#battingDetailsGrid").jqxGrid('updatebounddata');
            });
        }
    }

    var BattingDetail = function (data) {
        var self = this;
        var tests = {
            1: '1st',
            2: '2nd',
            3: '3rd',
            4: '4th',
            5: '5th',
            6: '6th'
        }
        self.test = tests[data.Match.TestNumber];
        self.innings = data.Innings;
        self.opponents = data.Opponent.Name;
        self.seriesYear = data.Match.SeriesYear;
        if (data.Dismissal == -1) {
            self.dismissal = "dnb";
            self.score = "";
            self.minutes = "";
            self.fours = "";
            self.sixes = "";
        } else {
            self.dismissal = data.Dismissal;
            self.score = data.Score;
            self.minutes = data.Minutes;
            self.fours = data.Fours;
            self.sixes = data.Sixes;
        }
    }
    return {
        CricketWeb: CricketWeb
    }
})();
