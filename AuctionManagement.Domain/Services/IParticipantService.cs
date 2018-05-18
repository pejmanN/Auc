using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;

namespace AuctionManagement.Domain.Services
{
    public interface IParticipantService
    {
        Participant GetById(long id);
    }
}
