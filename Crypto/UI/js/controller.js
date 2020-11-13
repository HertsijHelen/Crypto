var testApp = angular.module('testApp');
testApp.controller('testController', function ($scope) {

    $scope.items = [{
        id: 1,
        ticker: 'BTC',
        name: 'Bitcoin',
        createdon: '2008-01-03',
        charts: [
            {
                date: '2018-01-01',
                price: '12556'
            },
            {
                date: '2018-01-02',
                price: '15001'
            },
            {
                date: '2018-01-03',
                price: '16300'
            }]
    },
    {
        id: 2,
        ticker: 'ETH',
        name: 'Ethereum',
        createdon: '2012-01-23',
        charts: [
            {
                date: '2018-01-01',
                price: '657'
            },
            {
                date: '2018-01-02',
                price: '732'
            },
            {
                date: '2018-01-03',
                price: '590'
            }]
    },
    {
        id: 3,
        ticker: 'DASH',
        name: 'Dash',
        createdon: '2014-01-14',
        charts: [
            {
                date: '2018-01-01',
                price: '1501'
            },
            {
                date: '2018-01-02',
                price: '1634'
            },
            {
                date: '2018-01-03',
                price: '1490'
            }]
    }];

    $scope.show = function (item) {
        $scope.itemSearch = {
            Id: '',
            Ticker: '',
            Name: '',
            CreatedOn: ''
        };

        $scope.itemSearch = {
            Id: item.id,
            Ticker: item.ticker,
            Name: item.name,
            CreatedOn: item.createdon
        };
    }

});