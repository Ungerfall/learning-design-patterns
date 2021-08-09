// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
using System.Collections.Generic;

namespace Calculator.Task4
{
    public class InsurancePaymentCalculator : ICalculator
    {
        private ICurrencyService currencyService;
        private ITripRepository tripRepository;

        public InsurancePaymentCalculator(
            ICurrencyService currencyService,
            ITripRepository tripRepository)
        {
            this.currencyService = currencyService;
            this.tripRepository = tripRepository;
        }

        public decimal CalculatePayment(string touristName)
        {
            var rate = currencyService.LoadCurrencyRate();
            var tripDetails = tripRepository.LoadTrip(touristName);
            return Constants.A * rate * tripDetails.FlyCost
                   + Constants.B * rate * tripDetails.AccomodationCost
                   + Constants.C * rate * tripDetails.ExcursionCost;
        }
    }

    public class RoundingCalculatorDecorator : ICalculator
    {
        private readonly ICalculator _calculator;

        public RoundingCalculatorDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public decimal CalculatePayment(string touristName)
        {
            var payment = _calculator.CalculatePayment(touristName);

            return Decimal.Round(payment);
        }
    }

    public class LoggingCalculatorDecorator : ICalculator
    {
        private readonly ILogger _logger;
        private readonly ICalculator _calculator;

        public LoggingCalculatorDecorator(ILogger logger, ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public decimal CalculatePayment(string touristName)
        {
            _logger.Log("Start");
            var payment = _calculator.CalculatePayment(touristName);
            _logger.Log("End");

            return payment;
        }
    }

    public class CachedPaymentDecorator : ICalculator
    {
        private readonly ICalculator _calculator;
        private readonly Dictionary<string, decimal> _memo = new Dictionary<string, decimal>();

        public CachedPaymentDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public decimal CalculatePayment(string touristName)
        {
            if (_memo.TryGetValue(touristName, out var payment))
            {
                return payment;
            }

            var calculatedPayment = _calculator.CalculatePayment(touristName);
            _memo[touristName] = calculatedPayment;

            return calculatedPayment;
        }
    }
}
