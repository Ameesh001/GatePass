﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Business.Contracts
{
    public interface IDashBoardService
    {
        Task<int> TotalSalesLastWeek();
        Task<int> SameDayPasses();
        Task<string> TotalIncomeLastWeek();
        Task<int> TotalProducts();
        Task<int> TotalCategories();
        Task<Dictionary<string, int>> SalesLastWeek();
        Task<Dictionary<string, int>> PassesLastWeek();
        Task<Dictionary<string, int>> ProductsTopLastWeek();
        Task<Dictionary<string, int>> TopStatuses();
        Task<int> SuccessReturned();
        Task<int> TodayPending();
        Task<int> TotalPending();
    }
}
