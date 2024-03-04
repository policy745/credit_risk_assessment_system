﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace CreditRiskAssessment_Test
{
    public partial class CRASML
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"LoanAmount", @"LoanAmount"),new InputOutputColumnPair(@"AnnualIncome", @"AnnualIncome"),new InputOutputColumnPair(@"MonthlyNetSalary", @"MonthlyNetSalary"),new InputOutputColumnPair(@"InterestRate", @"InterestRate"),new InputOutputColumnPair(@"NumberOfLoan", @"NumberOfLoan"),new InputOutputColumnPair(@"NumberOfDelayedPayment", @"NumberOfDelayedPayment"),new InputOutputColumnPair(@"OutstandingDebt", @"OutstandingDebt"),new InputOutputColumnPair(@"DebtToIncomeRatio", @"DebtToIncomeRatio"),new InputOutputColumnPair(@"MonthsOfCreditHistory", @"MonthsOfCreditHistory"),new InputOutputColumnPair(@"PaymentOfMinimumAmount", @"PaymentOfMinimumAmount"),new InputOutputColumnPair(@"MonthlyInstallmentAmount", @"MonthlyInstallmentAmount"),new InputOutputColumnPair(@"AmountInvestedMonthly", @"AmountInvestedMonthly"),new InputOutputColumnPair(@"MonthlyBalance", @"MonthlyBalance")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"LoanAmount",@"AnnualIncome",@"MonthlyNetSalary",@"InterestRate",@"NumberOfLoan",@"NumberOfDelayedPayment",@"OutstandingDebt",@"DebtToIncomeRatio",@"MonthsOfCreditHistory",@"PaymentOfMinimumAmount",@"MonthlyInstallmentAmount",@"AmountInvestedMonthly",@"MonthlyBalance"}))      
                                    .Append(mlContext.Regression.Trainers.FastTree(new FastTreeRegressionTrainer.Options(){NumberOfLeaves=83,MinimumExampleCountPerLeaf=19,NumberOfTrees=445,MaximumBinCountPerFeature=122,FeatureFraction=0.99999999,LearningRate=0.0383546094166357,LabelColumnName=@"CreditScore",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
