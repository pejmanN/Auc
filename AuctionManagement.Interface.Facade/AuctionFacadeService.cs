using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Interface.Facade.Contracts;
using AuctionManagement.Interface.Facade.Contracts.Auctions;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Commands;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Services;
using AuctionManagement.Interface.Facade.Contracts.BidHistory;
using Framework.Application;
using Framework.Core.Events;

namespace AuctionManagement.Interface.Facade
{
    public class AuctionFacadeService : IAuctionFacadeService
    {
        private readonly ICommandBus _bus;
        private readonly IEventListener _listener;
        public AuctionFacadeService(ICommandBus bus, IEventListener listener)
        {
            _bus = bus;
            this._listener = listener;
        }

        public long Create(CreateAuctionCommand command)
        {
            long createdId = 0;
            _listener.Subscribe(new ActionEventHandler<AuctionOpened>(a => createdId = a.Id));
            _bus.Dispatch(command);
            return createdId;
        }

        public void PlaceBid(PlaceBidOnAuctionCommand command)
        {
            BidPlacedOnAuction @event = null;
            _listener.Subscribe(new ActionEventHandler<BidPlacedOnAuction>(a=> @event = a));

            //TODO: replace this transctional consistency with eventual consistency using NSB
            using (var scope = new TransactionScope())
            {
                _bus.Dispatch(command);
                var bidHistoryCommand = CreateBidHistoryCommand(@event);
                _bus.Dispatch(bidHistoryCommand);

                scope.Complete();
            }
        }

        private static CreateBidHistoryCommand CreateBidHistoryCommand(BidPlacedOnAuction @event)
        {
            var bidHistoryCommand = new CreateBidHistoryCommand()
            {
                AuctionId = @event.AuctionId,
                BidderId = @event.BidderId,
                CreateDateTime = @event.OfferDateTime,
                OfferedAmount = @event.Amount
            };
            return bidHistoryCommand;
        }
    }
}
