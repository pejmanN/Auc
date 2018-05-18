using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.BidHistories;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Services;
using AuctionManagement.Interface.Facade.Contracts;
using AuctionManagement.Interface.Facade.Contracts.Auctions;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Commands;
using AuctionManagement.Interface.Facade.Contracts.BidHistory;
using Framework.Application;
using Framework.Core;
using Framework.Core.Events;

namespace AuctionManagement.Application
{
    public class BidHistoryCommandHandlers : ICommandHandler<CreateBidHistoryCommand>
    {
        private readonly IBidHistoryRepository _repository;
        public BidHistoryCommandHandlers(IBidHistoryRepository repository)
        {
            _repository = repository;
        }
        public void Handle(CreateBidHistoryCommand command)
        {
            var auctionId = new AuctionId(command.AuctionId);
            var money = new Money(command.OfferedAmount, "USD");
            var bidHistory = new BidHistory(auctionId,command.BidderId, money, command.CreateDateTime);

            _repository.Add(bidHistory);
        }
    }
}
