﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace AuctionManagement.Domain.Model.BidHistories
{
    public interface IBidHistoryRepository : IRepository
    {
        void Add(BidHistory history);
    }
}
