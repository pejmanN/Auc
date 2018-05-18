using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Services;
using AuctionManagement.Interface.Facade.Contracts;
using AuctionManagement.Interface.Facade.Contracts.Auctions;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Commands;
using Framework.Application;
using Framework.Core;
using Framework.Core.Events;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandlers : ICommandHandler<PlaceBidOnAuctionCommand>,
                                          ICommandHandler<CreateAuctionCommand>
    {
        private readonly IAuctionRepository _repository;
        private readonly IAuctionService _service;
        private readonly IEventPublisher _publisher;
        private readonly IParticipantService _participantService;

        public AuctionCommandHandlers(IAuctionRepository repository, IAuctionService service
            ,IEventPublisher publisher, IParticipantService participantService)
        {
            _repository = repository;
            this._service = service;
            _publisher = publisher;
            _participantService = participantService;
        }

        public void Handle(PlaceBidOnAuctionCommand command)
        {
            var id = new AuctionId(command.AuctionId);
            var auction = this._repository.GetById(id);
            var money = new Money(command.Amount,"USD");
            var bid = new Bid(command.BidderId,money);
            auction.PlaceBid(bid);
        }

        public void Handle(CreateAuctionCommand command)
        {
            var money = new Money(command.StartingPrice,"USD");
            var id = _repository.GetNextId();
            var participant = _participantService.GetById(command.SellerId);

            var auction = new Auction(id, command.EndDateTime, 
                command.ProductId, participant, money, _service, _publisher);
            _repository.Add(auction);
        }
    }
}
